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
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class AddClient : Page
    {
        private Clients AddingClient = new Clients();
        public AddClient()
        {
            InitializeComponent();
            DataContext = AddingClient;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errorsDT = new StringBuilder();
            if (string.IsNullOrEmpty(BoxFamilia.Text))
                errorsDT.AppendLine("Введите фамилию");
            if (string.IsNullOrEmpty(BoxName.Text))
                errorsDT.AppendLine("Введите имя");
            if (string.IsNullOrEmpty(BoxPatronymic.Text))
                errorsDT.AppendLine("Введите отчество");
            if (string.IsNullOrEmpty(BoxTelefon.Text))
                errorsDT.AppendLine("Введите телефон");
            if (string.IsNullOrEmpty(BoxBirthday.Text))
                errorsDT.AppendLine("Введите дату рождения");
            if (string.IsNullOrEmpty(BoxGender.Text))
                errorsDT.AppendLine("Введите пол");
            if (string.IsNullOrEmpty(BoxLoginName.Text))
                errorsDT.AppendLine("Введите логин");
            if (string.IsNullOrEmpty(BoxPasswordName.Text))
                errorsDT.AppendLine("Введите пароль");
            if (int.Parse(BoxIdRole.Text) == 0)
                errorsDT.AppendLine("Введите роль");
            if (errorsDT.Length > 0)
            {
                MessageBox.Show(errorsDT.ToString());
                return;
            }
            if (AddingClient.id > 0)
            {
                BarbershopIvanEntitiesBD.GetContext().Clients.Add(AddingClient);
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
