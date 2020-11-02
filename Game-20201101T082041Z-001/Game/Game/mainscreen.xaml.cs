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
    /// Логика взаимодействия для mainscreen.xaml
    /// </summary>
    public partial class mainscreen : Page
    {
        MediaPlayer player;
        public mainscreen(MediaPlayer p1)
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
        private void newgame_Click(object sender, RoutedEventArgs e)
        {
            MediaSound();
            Manager.Mainscreen.Navigate(new Gam());
        }

        private void nast_Click(object sender, RoutedEventArgs e)
        {
            MediaSound();
            Manager.Mainscreen.Navigate(new Option(player));
        }

        private void records_Click(object sender, RoutedEventArgs e)
        {
            MediaSound();
            Manager.Mainscreen.Navigate(new Record());
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            MediaSound();
            if (MessageBox.Show("Вы действительно хотите выйти?", "Выход", MessageBoxButton.YesNo)==MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }
    }
}
