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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            main.Navigate(new mainscreen(this.main));
            NameImage.imag = "1";
            Manager.mainscreen = main;
        }
        private void DoubleAnimation_Completed(object sender, EventArgs e)
        {

        }
    }
    public static class NameImage
    {
        public static string imag { get; set; }
    }
}
