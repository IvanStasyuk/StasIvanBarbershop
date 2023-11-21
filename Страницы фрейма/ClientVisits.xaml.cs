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

namespace StasIvanBarbershop.Страницы_фрейма
{
    /// <summary>
    /// Логика взаимодействия для ClientVisits.xaml
    /// </summary>
    public partial class ClientVisits : Page
    {
        public ClientVisits()
        {
            InitializeComponent();
            DTBarbershopVisits.ItemsSource = BarbershopIvanEntitiesBD.GetContext().Clients.ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MyFrame.Navigate(new Страницы_фрейма.AddVisit((sender as Button).DataContext as DatesVisits));
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MyFrame.Navigate(new Страницы_фрейма.AddVisit(null));
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            var VisitRemoving = DTBarbershopVisits.SelectedItems.Cast<DatesVisits>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить {VisitRemoving.Count()} элементов",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    BarbershopIvanEntitiesBD.GetContext().DatesVisits.RemoveRange(VisitRemoving);
                    BarbershopIvanEntitiesBD.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DTBarbershopVisits.ItemsSource = BarbershopIvanEntitiesBD.GetContext().DatesVisits.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                BarbershopIvanEntitiesBD.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DTBarbershopVisits.ItemsSource = BarbershopIvanEntitiesBD.GetContext().DatesVisits.ToList();
            }
        }
    }
}
