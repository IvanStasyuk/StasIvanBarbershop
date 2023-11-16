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
            var VhodClient = BarbershopIvanEntities.GetContext().Clients.FirstOrDefault(x => x.Login == LoginBox.Text && x.Password == PasswordBox.Text);
            if (VhodClient == null)
            {
                MessageBox.Show("Пользователь не найден", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
                switch (VhodClient.idRole)
                {
                    case 1:
                        MessageBox.Show("Добро пожаловать, администратор" + VhodClient.Name, "Авторизация успешна", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    case 2:
                        MessageBox.Show("Добро пожаловать, менеджер" + VhodClient.Name, "Авторизация успешна", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    case 3:
                        MessageBox.Show("Добро пожаловать, клиент" + VhodClient.Name, "Авторизация успешна", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                }
        }
    }
}
