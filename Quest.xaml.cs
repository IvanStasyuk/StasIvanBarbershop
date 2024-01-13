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

namespace StasIvanBarbershop
{
    /// <summary>
    /// Логика взаимодействия для Quest.xaml
    /// </summary>
    public partial class Quest : Window
    {
        public Quest()
        {
            InitializeComponent();
            Manager.MyFrame2 = MyFrame2;
            Manager.MyFrame2.Navigate(new Страницы_фрейма.OneProduct());
        }
    }
}
