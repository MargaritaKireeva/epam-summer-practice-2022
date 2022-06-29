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
    /// Логика взаимодействия для AuthenticationWindow.xaml
    /// </summary>
    public partial class AuthenticationWindow : Window
    {
        private IAccountBL accountBL;
        public AuthenticationWindow()
        {
            accountBL = new AccountBL();
            InitializeComponent();
        }

        private void signInButton_Click(object sender, RoutedEventArgs e)
        {
            if (loginTextBox.Text == "")
                MessageBox.Show("Введите логин!");
            else if (passwordBox.Password == "")
                MessageBox.Show("Введите пароль!");
            else
            {
                Window window;
                Account account = accountBL.SearchAccountForAuth(loginTextBox.Text, passwordBox.Password);
                if (account == null)
                    MessageBox.Show("Неправильный логин или пароль!");
                else
                {
                    
                    if (account.UserRole.Equals("Администратор"))
                        window = new MainWindow(account);
                    else
                        window = new UserProfileWindow(account);
                    window.Closed += (sender1, e1) =>
                    {
                        Close();
                    };
                    window.Show();
                    Hide();
                }               
            }
        }

        private void addUserButton_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow addUserWindow = new AddUserWindow();
            addUserWindow.ShowDialog();
        }
    }
}
