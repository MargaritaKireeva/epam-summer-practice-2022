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

namespace AchievementsAccounting
{
    /// <summary>
    /// Логика взаимодействия для EditAchievementWindow.xaml
    /// </summary>
    public partial class EditAchievementWindow : Window
    {
        private IAchievementBL achievementBL;
        Achievement achievement;
        public EditAchievementWindow(Achievement achievement)
        {
            achievementBL = new AchievementBL();
            InitializeComponent();
            this.achievement = achievement;
            nameTextBox.Text = achievement.Name;
            descriptionTextBox.Text = achievement.Description;
        }

        private void editAchievementButton_Click(object sender, RoutedEventArgs e)
        {
            if (nameTextBox.Text == "")
                MessageBox.Show("Введите название!");
            else if (descriptionTextBox.Text == "")
                MessageBox.Show("Введите описание!");
            else
            {
                Achievement newAchievement = new Achievement(achievement.ID, nameTextBox.Text, descriptionTextBox.Text);
                achievementBL.EditAchievement(newAchievement);
                Close();
            }
        }
    }
}
