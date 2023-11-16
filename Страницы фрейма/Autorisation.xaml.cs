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

namespace StasIvanBarbershop.Pages
{
    /// <summary>
    /// Логика взаимодействия для Autorisation.xaml
    /// </summary>
    public partial class Autorisation : Page
    {
        public Autorisation()
        {
            InitializeComponent();
        }

        private void btnVhod_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            LoginBox.AppendText(errors.ToString());
            PasswordBox.AppendText(errors.ToString());

            var VhodClient = BarbershopIvanEntities.GetContext().Clients.FirstOrDefault(x => x.Login == LoginBox.Text && x.Password == PasswordBox.Text);
            if (VhodClient == null)
            {
                MessageBox.Show("Пользователь не найден", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else if (CaptchaInput.Text == null)
            {
                MessageBox.Show("Введите капчу", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (CaptchaInput.Text != "ABCDEF")
            {
                MessageBox.Show("Капча не верна", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                switch (VhodClient.idRole)
                {
                    case 1:
                        MessageBox.Show("Добро пожаловать, администратор " + VhodClient.Name, "Авторизация успешна", MessageBoxButton.OK, MessageBoxImage.Information);
                        Manager.MyFrame.Navigate(new Pages.ClientTable());
                        break;
                    case 2:
                        MessageBox.Show("Добро пожаловать, менеджер " + VhodClient.Name, "Авторизация успешна", MessageBoxButton.OK, MessageBoxImage.Information);
                        Manager.MyFrame.Navigate(new Pages.ClientTable());
                        break;
                    case 3:
                        MessageBox.Show("Добро пожаловать, клиент " + VhodClient.Name, "Авторизация успешна", MessageBoxButton.OK, MessageBoxImage.Information);
                        Manager.MyFrame.Navigate(new Pages.ClientTable());
                        break;
                }
        }
    }
}
