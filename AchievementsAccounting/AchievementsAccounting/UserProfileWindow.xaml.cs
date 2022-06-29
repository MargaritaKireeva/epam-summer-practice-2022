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

namespace AchievementsAccounting
{
    /// <summary>
    /// Логика взаимодействия для UserProfileWindow.xaml
    /// </summary>
    public partial class UserProfileWindow : Window
    {
        private IAccountBL accountBL;
        private IUserBL userBL;
        private IAchievementBL achievementBL;
        private IAchievementUserConnectionBL achievementUserConnectionBL;
        Account account;
        User user;
        public UserProfileWindow(Account account)
        {
            accountBL = new AccountBL();
            userBL = new UserBL();
            achievementBL = new AchievementBL();
            achievementUserConnectionBL = new AchievementUserConnectionBL();
            this.account = account;
            user = userBL.GetUserByID(account.UserID);
            InitializeComponent();
            achievementsComboBox.ItemsSource = achievementBL.GetAllAchievements();
            achievementsListBox.ItemsSource = achievementUserConnectionBL.GetAllAchievementsByUser(user.ID);
            userInfoTextBox.Text = $"Информация о пользователе: \n" +
                    $"Имя: {user.Name} \n" +
                    $"Дата рождения: {user.Birthday.ToShortDateString()} \n" +
                    $"О себе: {user.Description} \n" +
                    $"Логин: {account.UserLogin} \n" +
                    $"Пароль: {account.UserPassword} \n" +
                    $"Роль: {account.UserRole} \n";
        }

        private void addAchievementButton_Click(object sender, RoutedEventArgs e)
        {            
            if (achievementsComboBox.SelectedItem != null)
            {
                Achievement achievement = (Achievement)achievementsComboBox.SelectedItem;
                achievementUserConnectionBL.AddAchievementUserConnection(user.ID, achievement.ID);
                achievementsListBox.ItemsSource = achievementUserConnectionBL.GetAllAchievementsByUser(user.ID);
            }
            else
            {
                MessageBox.Show("Чтобы добавить достижение, выберите его в списке!");
            }
        }

        private void removeAchievementButton_Click(object sender, RoutedEventArgs e)
        {
            if (achievementsListBox.SelectedItem != null)
            {
                Achievement achievement = (Achievement)achievementsListBox.SelectedItem;
                achievementUserConnectionBL.RemoveAchievementUserConnection(user.ID, achievement.ID);
                achievementsListBox.ItemsSource = achievementUserConnectionBL.GetAllAchievementsByUser(user.ID);
            }
            else
            {
                MessageBox.Show("Чтобы удалить достижение, выберите его в списке!");
            }
        }

        private void removeUserButton_Click(object sender, RoutedEventArgs e)
        {
            userBL.RemoveUser(user.ID);
            AuthenticationWindow authenticationWindow = new AuthenticationWindow();
            authenticationWindow.Show();
            Close();
        }

        private void editUserButton_Click(object sender, RoutedEventArgs e)
        {
            EditUserWindow editUserWindow = new EditUserWindow(user, account);
                        
            //Создаем анонимный метод - обработчик события FormClosing дочерней формы (возникающего перед закрытием)
            //Подписаться на событие необходимо до открытия дочерней формы
            //Использовать событие FormClosed не стоит, так как оно возникает уже после закрытия формы, когда все переменные формы уже уничтожены
            editUserWindow.Closing += (sender1, e1) =>
            {
                user = editUserWindow.newUser;
                account = editUserWindow.newAccount;
            };
            //Открывает форму на просмотр
            editUserWindow.ShowDialog();
            userInfoTextBox.Text = $"Информация о пользователе: \n" +
                    $"Имя: {user.Name} \n" +
                    $"Дата рождения: {user.Birthday.ToShortDateString()} \n" +
                    $"О себе: {user.Description} \n" +
                    $"Логин: {account.UserLogin} \n" +
                    $"Пароль: {account.UserPassword} \n" +
                    $"Роль: {account.UserRole} \n";
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

        private void signOutButton_Click(object sender, RoutedEventArgs e)
        {
            AuthenticationWindow authenticationWindow = new AuthenticationWindow();
            authenticationWindow.Show();
            Close();
        }

        private void achievementsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (achievementsComboBox.SelectedItem != null)
            {
                Achievement achievement = (Achievement)achievementsComboBox.SelectedItem;
                achievementInfoTextBox.Text = $"Информация о достижении: \n" +
                    $"Название: {achievement.Name} \n" +
                    $"Описание: {achievement.Description} \n";
            }
        }
    }
}
