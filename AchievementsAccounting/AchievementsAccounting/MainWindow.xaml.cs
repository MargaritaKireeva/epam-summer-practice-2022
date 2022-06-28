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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AchievementsAccounting.BLL.Interfaces;
using AchievementsAccounting.BLL;
using AchievementsAccounting.Entities;

namespace AchievementsAccounting
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IUserBL userBL;
        private IAccountBL accountBL;
        private IAchievementBL achievementBL;
        public MainWindow()
        {
            userBL = new UserBL();
            accountBL = new AccountBL();
            achievementBL = new AchievementBL();
            InitializeComponent();
            accountsListBox.ItemsSource = accountBL.GetAllAccounts();
            achievementsListBox.ItemsSource = achievementBL.GetAllAchievements();
            
        }

        private void addUserButton_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow addUserWindow = new AddUserWindow();
            addUserWindow.ShowDialog();
            accountsListBox.ItemsSource = accountBL.GetAllAccounts();
        }

        private void removeUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (accountsListBox.SelectedItem != null)
            {
                userBL.RemoveUser(((Account)accountsListBox.SelectedItem).UserID);
                accountsListBox.ItemsSource = accountBL.GetAllAccounts();
            }
            else
            {
                MessageBox.Show("Чтобы удалить пользователя, выберите его в списке!");
            }
        }

       

        private void editUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (accountsListBox.SelectedItem != null)
            {
                Account account = (Account)accountsListBox.SelectedItem;
                User user = userBL.GetUserByID(account.UserID);
                EditUserWindow editUserWindow = new EditUserWindow(user, account);
                editUserWindow.ShowDialog();
                accountsListBox.ItemsSource = accountBL.GetAllAccounts();
            }
            else
            {
                MessageBox.Show("Выберите пользователя, информацию о котором хотите редактировать!");
            }
        }

        private void accountsListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (accountsListBox.SelectedItem != null)
            {
                Account account = (Account)accountsListBox.SelectedItem;
                User user = userBL.GetUserByID(account.UserID);
                userInfoTextBox.Text = $"Информация о пользователе: \n" +
                    $"Имя: {user.Name} \n" +
                    $"Дата рождения: {user.Birthday.ToShortDateString()} \n" +
                    $"О себе: {user.Description} \n" +
                    $"Логин: {account.UserLogin} \n" +
                    $"Пароль: {account.UserPassword} \n" +
                    $"Роль: {account.UserRole} \n";
            }
        }

        private void addAchievementButton_Click(object sender, RoutedEventArgs e)
        {
            AddAchievementWindow addAchievementWindow = new AddAchievementWindow();
            addAchievementWindow.ShowDialog();
            achievementsListBox.ItemsSource = achievementBL.GetAllAchievements();
        }

        private void removeAchievementButton_Click(object sender, RoutedEventArgs e)
        {
            if (achievementsListBox.SelectedItem != null)
            {
                achievementBL.RemoveAchievement(((Achievement)achievementsListBox.SelectedItem).ID);
                achievementsListBox.ItemsSource = achievementBL.GetAllAchievements();
            }
            else
            {
                MessageBox.Show("Чтобы удалить достижение, выберите его в списке!");
            }
        }

        private void editAchievementButton_Click(object sender, RoutedEventArgs e)
        {
            if (achievementsListBox.SelectedItem != null)
            {
                Achievement achievement = (Achievement)achievementsListBox.SelectedItem;
                EditAchievementWindow editAchievementWindow = new EditAchievementWindow(achievement);
                editAchievementWindow.ShowDialog();
                achievementsListBox.ItemsSource = achievementBL.GetAllAchievements();
            }
            else
            {
                MessageBox.Show("Выберите пользователя, информацию о котором хотите редактировать!");
            }
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
    }
}
