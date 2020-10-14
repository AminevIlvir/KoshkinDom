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
    /// Логика взаимодействия для mainscreen.xaml
    /// </summary>
    public partial class mainscreen : Page
    {
        Frame main;
        public mainscreen(Frame a)
        {
            InitializeComponent();
            main = a;
        }

        private void newgame_Click(object sender, RoutedEventArgs e)
        {
            main.Navigate(new Gam());
        }

        private void nast_Click(object sender, RoutedEventArgs e)
        {
            main.Navigate(new Option(this.main));
        }

        private void records_Click(object sender, RoutedEventArgs e)
        {

        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
