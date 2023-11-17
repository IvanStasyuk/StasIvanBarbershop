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
            var ClientRemoving = DTBarbershopClient.SelectedItems.Cast<Clients>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить {ClientRemoving.Count()} элементов",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    BarbershopIvanEntities.GetContext().Clients.RemoveRange(ClientRemoving);
                    BarbershopIvanEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DTBarbershopClient.ItemsSource = BarbershopIvanEntities.GetContext().Clients.ToList();
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
                BarbershopIvanEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DTBarbershopClient.ItemsSource = BarbershopIvanEntities.GetContext().Clients.ToList();
            }
        }
        private void btnPageVisits_Click(object sender, RoutedEventArgs e)
        {
            Manager.MyFrame.Navigate(new Страницы_фрейма.ClientVisits());
            return;
        }
    }
}
