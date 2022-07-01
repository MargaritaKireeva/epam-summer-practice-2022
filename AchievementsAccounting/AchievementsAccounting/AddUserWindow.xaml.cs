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
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        private IUserBL userBL;
        private IAccountBL accountBL;
        public AddUserWindow()
        {
            userBL = DependencyResolver.Instance.UserBL;
            accountBL = DependencyResolver.Instance.AccountBL;
            InitializeComponent();
            roleComboBox.ItemsSource = new List<string> { "Администратор", "Пользователь" };
        }

        private void addUserButton_Click(object sender, RoutedEventArgs e)
        {
            string description = null;
            if (nameTextBox.Text == "")
                MessageBox.Show("Введите имя!");
            else if (birthdayDatePiker.SelectedDate == null)
                MessageBox.Show("Выберите дату рождения!");
            else if (birthdayDatePiker.SelectedDate >= DateTime.Today)
                MessageBox.Show("Дата рождения не может быть позже текущей даты!");
            else if (loginTextBox.Text == "")
                MessageBox.Show("Введите логин!");
            else if (passwordBox.Password == "")
                MessageBox.Show("Введите пароль!");
            else if (roleComboBox.SelectedItem == null)
                MessageBox.Show("Выберите роль!");
            else
            {
                if (descriptionTextBox.Text != "")
                    description = descriptionTextBox.Text;
                User user = new User(nameTextBox.Text, (DateTime)birthdayDatePiker.SelectedDate, description);
                user = userBL.AddUser(user);
                Account account = new Account(user.ID, loginTextBox.Text, passwordBox.Password, roleComboBox.Text);
                string message = accountBL.AddAccount(account);               
                MessageBox.Show(message);
                if (message == "Пользователь удачно зарегистрирован!")
                    Close();
            }            
        }
    }
}
