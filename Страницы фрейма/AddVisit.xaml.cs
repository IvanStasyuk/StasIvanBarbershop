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
    /// Логика взаимодействия для AddVisit.xaml
    /// </summary>
    public partial class AddVisit : Page
    {
        private DatesVisits AddingVisit = new DatesVisits();
        public AddVisit(DatesVisits hosteds)
        {
            InitializeComponent();
            DataContext = AddingVisit;
            if (hosteds != null)
                AddingVisit = hosteds;
            DataContext = AddingVisit;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errorsDT = new StringBuilder();
            if (string.IsNullOrEmpty(BoxLoginVisit.Text))
                errorsDT.AppendLine("Введите фамилию");
            if (string.IsNullOrEmpty(BoxNameVisit.Text))
                errorsDT.AppendLine("Введите имя");
            if (string.IsNullOrEmpty(BoxSurnameVisit.Text))
                errorsDT.AppendLine("Введите отчество");
            if (string.IsNullOrEmpty(DateFirstVisitBox.Text))
                errorsDT.AppendLine("Введите телефон");
            if (string.IsNullOrEmpty(DateLaterVisitBox.Text))
                errorsDT.AppendLine("Введите дату рождения");
            if (errorsDT.Length > 0)
            {
                MessageBox.Show(errorsDT.ToString());
                return;
            }
            if (AddingVisit.id_Client > 0)
            {
                BarbershopIvanEntitiesBD.GetContext().DatesVisits.Add(AddingVisit);
            }
            try
            {
                BarbershopIvanEntitiesBD.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MyFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
