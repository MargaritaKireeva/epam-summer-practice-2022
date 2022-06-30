using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AchievementsAccounting.BLL.Interfaces;
using AchievementsAccounting.BLL;
using AchievementsAccounting.Entities;
using AchievementsAccounting.Dependencies;

namespace AchievementsAccounting
{
    /// <summary>
    /// Логика взаимодействия для AddAchievementUserWindow.xaml
    /// </summary>
    public partial class AddAchievementUserWindow : Window
    {
        private IUserBL userBL;
        private IAchievementBL achievementBL;
        private IAchievementUserConnectionBL achievementUserConnectionBL;
        User user;
        public AddAchievementUserWindow(User user)
        {
            userBL = DependencyResolver.Instance.UserBL;
            achievementBL = DependencyResolver.Instance.AchievementBL;
            achievementUserConnectionBL = DependencyResolver.Instance.AchievementUserConnectionBL;
            this.user = user;
            InitializeComponent();
            achievementsListBox.ItemsSource = achievementBL.GetAllAchievements();
        }
        private void searchAchievementButton_Click(object sender, RoutedEventArgs e)
        {
            achievementsListBox.ItemsSource = achievementBL.SearchAchievementByDescription(searchAchievementTextBox.Text);
        }

        private void showAllAchievementsButton_Click(object sender, RoutedEventArgs e)
        {
            achievementsListBox.ItemsSource = achievementBL.GetAllAchievements();
            searchAchievementTextBox.Text = "(Искать достижение)";
        }


        private void searchAchievementTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            searchAchievementTextBox.Text = "";
        }

        private void achievementsListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (achievementsListBox.SelectedItem != null)
            {
                Achievement achievement = (Achievement)achievementsListBox.SelectedItem;
                achievementInfoTextBox.Text = $"Информация о достижении: \n" +
                    $"Название: {achievement.Name} \n" +
                    $"Описание: {achievement.Description} \n";
            }
        }

        private void addAchievementButton_Click(object sender, RoutedEventArgs e)
        {
            if (achievementsListBox.SelectedItem != null)
            {
                Achievement achievement = (Achievement)achievementsListBox.SelectedItem;
                achievementUserConnectionBL.AddAchievementUserConnection(user.ID, achievement.ID);
                Close();
            }
            else
            {
                MessageBox.Show("Чтобы добавить достижение, выберите его в списке!");
            }
        }
    }
}
