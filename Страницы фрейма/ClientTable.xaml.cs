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
            DTBarbershopClient.ItemsSource = BarbershopIvanEntitiesBD.GetContext().Clients.ToList();
        }
        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            var ClientRemoving = DTBarbershopClient.SelectedItems.Cast<Clients>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить {ClientRemoving.Count()} элементов",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    BarbershopIvanEntitiesBD.GetContext().Clients.RemoveRange(ClientRemoving);
                    BarbershopIvanEntitiesBD.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DTBarbershopClient.ItemsSource = BarbershopIvanEntitiesBD.GetContext().Clients.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MyFrame.Navigate(new Страницы_фрейма.AddClient((sender as Button).DataContext as Clients));
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                BarbershopIvanEntitiesBD.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DTBarbershopClient.ItemsSource = BarbershopIvanEntitiesBD.GetContext().Clients.ToList();
            }
        }
        private void btnPageVisits_Click(object sender, RoutedEventArgs e)
        {
            Manager.MyFrame.Navigate(new Страницы_фрейма.ClientVisits());
            return;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MyFrame.Navigate(new Страницы_фрейма.AddClient(null));
            return;
        }
    }
}
