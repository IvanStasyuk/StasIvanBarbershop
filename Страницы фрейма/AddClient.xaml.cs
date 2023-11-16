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
        public AddClient(Clients context)
        {
            InitializeComponent();
            if (context == null)
            {
                context = new Clients();
            }

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errorsDT = new StringBuilder();
            if (BoxFamilia.Text == null)
                errorsDT.AppendLine("Введите фамилию");
            if (BoxName.Text == null)
                errorsDT.AppendLine("Введите имя");
            if (BoxPatronymic.Text == null)
                errorsDT.AppendLine("Введите отчество");
            if (BoxTelefon.Text == null)
                errorsDT.AppendLine("Введите телефон");
            if (BoxBirthday.Text == null)
                errorsDT.AppendLine("Введите дату рождения");
            if (BoxGender.Text == null)
                errorsDT.AppendLine("Введите пол");
            if (BoxLoginName.Text == null)
                errorsDT.AppendLine("Введите логин");
            if (BoxPasswordName.Text == null)
                errorsDT.AppendLine("Введите пароль");
            errorsDT.AppendLine(ToString());


        }
    }
}
