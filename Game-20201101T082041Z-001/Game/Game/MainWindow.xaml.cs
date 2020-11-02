using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Permissions;
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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using FilePath = System.IO.Path;
using System.Media;
using System.Reflection;

namespace Game
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MediaPlayer player = new MediaPlayer();
        public MainWindow()
        {
            InitializeComponent();
            main.Navigate(new Login_and_Registr(player));
            NameImage.imag = "1";
            Manager.Mainscreen = main;
            Media.music = true;
            Media.sound = false;

            var directory = FilePath.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            player.Open(new Uri(FilePath.Combine(directory, "music.wav")));
            if (Media.music == true)
            {
                player.Play();
                Media.music = false;
            }
            else
            {
                player.Stop();
                Media.music = true;
            }
        }
        private void DoubleAnimation_Completed(object sender, EventArgs e)
        {

        }
    
    }
    public static class NameImage
    {
        public static string imag { get; set; }
    }
    public static class ID
    {
        public static int id_igrok { get; set; }
        public static int Record { get; set; } 
    }
    public static class Media
    {
        public static bool music { get; set; }
        public static bool sound { get; set; }
    }

}
