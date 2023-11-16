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
    /// Логика взаимодействия для ClientTable.xaml
    /// </summary>
    public partial class ClientTable : Page
    {
        public ClientTable()
        {
            InitializeComponent();
            DTBarbershopClient.ItemsSource = BarbershopIvanEntities.GetContext().Clients.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MyFrame.Navigate(new Страницы_фрейма.AddClient(null));
            return;
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            var ClientRemoving = BarbershopIvanEntities.GetContext().Clients.ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MyFrame.Navigate(new Страницы_фрейма.AddClient((sender as Button).DataContext as Clients));
        }
    }
}
