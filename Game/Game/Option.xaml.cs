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

namespace Game
{
    /// <summary>
    /// Логика взаимодействия для Option.xaml
    /// </summary>
    public partial class Option : Page
    {
        Frame main;

        public Option(Frame a)
        {
            main = a;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NameImage.imag = "3";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NameImage.imag = "2";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NameImage.imag = "1";
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Manager.mainscreen.GoBack();
        }
    }
}
