using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Reflection;
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
using FilePath = System.IO.Path;

namespace Game
{
    /// <summary>
    /// Логика взаимодействия для Login_and_Registr.xaml
    /// </summary>
    public partial class Login_and_Registr : Page
    {
        MediaPlayer player;
        public Login_and_Registr(MediaPlayer p1)
        {
            InitializeComponent();
            player = p1;
        }
        public void MediaSound()
        {
            var directory = FilePath.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var player = new SoundPlayer(FilePath.Combine(directory, "click.wav"));
            if (Media.sound == false)
            {
                player.Play();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MediaSound();
            Manager.Mainscreen.Navigate(new Login(player));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MediaSound();
            Manager.Mainscreen.Navigate(new Registr());
        }
    }
}
