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
            if (Media.music == false)
            {
                mus.Source = new BitmapImage(new Uri(@"Images\musicвыбран.png", UriKind.Relative));
            }
            else
            {
                mus.Source = new BitmapImage(new Uri(@"Images\music.png", UriKind.Relative));
            }
            if (Media.sound == false)
            {
                zvu.Source = new BitmapImage(new Uri(@"Images\zvukвыбрано.png", UriKind.Relative));
            }
            else
            {
                zvu.Source = new BitmapImage(new Uri(@"Images\zvuk.png", UriKind.Relative));
            }
        }
        public void MediaSound()
        {
            var directory = FilePath.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var player1 = new SoundPlayer(FilePath.Combine(directory, "click.wav"));
            if (Media.sound == false)
            {
                player1.Play();
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
        }

        private void mus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MediaSound();
            var directory = FilePath.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (Media.music == true)
            {
                player.Play();
                Media.music = false;
                mus.Source = new BitmapImage(new Uri(@"Images\musicвыбран.png", UriKind.Relative));
            }
            else
            {
                player.Stop();
                Media.music = true;
                mus.Source = new BitmapImage(new Uri(@"Images\music.png", UriKind.Relative));
            }
        }

        private void zvu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var directory = FilePath.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var player1 = new SoundPlayer(FilePath.Combine(directory, "click.wav"));
            if (Media.sound == true)
            {
                player1.Play();
                Media.sound = false;
                zvu.Source = new BitmapImage(new Uri(@"Images\zvukвыбрано.png", UriKind.Relative));
            }
            else
            {
                player1.Stop();
                Media.sound = true;
                zvu.Source = new BitmapImage(new Uri(@"Images\zvuk.png", UriKind.Relative));
            }
        }
    }
}
