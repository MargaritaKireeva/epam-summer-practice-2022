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
using AchievementsAccounting.BLL;
using AchievementsAccounting.Entities;
using AchievementsAccounting.BLL.Interfaces;
using AchievementsAccounting.Dependencies;

namespace AchievementsAccounting
{
    /// <summary>
    /// Логика взаимодействия для AddAchievementWindow.xaml
    /// </summary>
    public partial class AddAchievementWindow : Window
    {
        private IAchievementBL achievementBL;
        public AddAchievementWindow()
        {
            achievementBL = DependencyResolver.Instance.AchievementBL;
            InitializeComponent();
        }

        private void addAchievementButton_Click(object sender, RoutedEventArgs e)
        {
            if (nameTextBox.Text == "")
                MessageBox.Show("Введите название!");
            else if (descriptionTextBox.Text == "")
                MessageBox.Show("Введите описание!");
            else
            {
                Achievement achievement = new Achievement(nameTextBox.Text, descriptionTextBox.Text);
                achievementBL.AddAchievement(achievement);
                Close();
            }
        }
    }
}
