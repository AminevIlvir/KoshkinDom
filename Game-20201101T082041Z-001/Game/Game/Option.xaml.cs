using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
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
    /// Логика взаимодействия для Option.xaml
    /// </summary>
    public partial class Option : Page
    {
        MediaPlayer player;
        public Option(MediaPlayer p1)
        {
            InitializeComponent();
            player = p1;
            SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\BDCatHome; version=3;");
            conn.Open();
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = Convert.ToString("Select name from Main where id=@Id");;
            cmd.Parameters.AddWithValue("@Id", ID.id_igrok);
            SQLiteDataReader sdr = cmd.ExecuteReader();

            if (sdr.HasRows)
            {
                sdr.Read();
                Namelabel.Text = sdr.GetValue(0).ToString();
            }
            conn.Close();
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

            if(NameImage.imag=="3")
            {
                odin.Source = new BitmapImage(new Uri(@"Images\выбор1выбран.png", UriKind.Relative));
                dwa.Source = new BitmapImage(new Uri(@"Images\выбор2.png", UriKind.Relative));
                tri.Source = new BitmapImage(new Uri(@"Images\выбор3.png", UriKind.Relative));
            }
            else if(NameImage.imag=="2")
            {
                dwa.Source = new BitmapImage(new Uri(@"Images\выбор2выбран.png", UriKind.Relative));
                odin.Source = new BitmapImage(new Uri(@"Images\выбор1.png", UriKind.Relative));
                tri.Source = new BitmapImage(new Uri(@"Images\выбор3.png", UriKind.Relative));
            }
            else if (NameImage.imag == "1")
            {
                tri.Source = new BitmapImage(new Uri(@"Images\выбор3выбран.png", UriKind.Relative));
                dwa.Source = new BitmapImage(new Uri(@"Images\выбор2.png", UriKind.Relative));
                odin.Source = new BitmapImage(new Uri(@"Images\выбор1.png", UriKind.Relative));
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MediaSound();
            Manager.Mainscreen.GoBack();
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
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MediaSound();
            //var directory = FilePath.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            NameImage.imag = "3";
            odin.Source = new BitmapImage(new Uri(@"Images\выбор1выбран.png",UriKind.Relative));
            dwa.Source = new BitmapImage(new Uri(@"Images\выбор2.png",UriKind.Relative));
            tri.Source = new BitmapImage(new Uri(@"Images\выбор3.png",UriKind.Relative));
        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            MediaSound();
            //var directory = FilePath.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            NameImage.imag = "2";
            dwa.Source = new BitmapImage(new Uri(@"Images\выбор2выбран.png", UriKind.Relative));
            odin.Source = new BitmapImage(new Uri(@"Images\выбор1.png", UriKind.Relative));
            tri.Source = new BitmapImage(new Uri(@"Images\выбор3.png", UriKind.Relative));
        }

        private void Image_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            MediaSound();
            //var directory = FilePath.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            NameImage.imag = "1";
            tri.Source = new BitmapImage(new Uri(@"Images\выбор3выбран.png", UriKind.Relative));
            dwa.Source = new BitmapImage(new Uri(@"Images\выбор2.png", UriKind.Relative));
            odin.Source = new BitmapImage(new Uri(@"Images\выбор1.png", UriKind.Relative));
        }

        public static bool isPlaying = true;
        
        private void Image_MouseDown_3(object sender, MouseButtonEventArgs e)
        {
            MediaSound();
            var directory = FilePath.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            
            if (Media.music==true)
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (Namelabel.Text.Length!=0) 
            {
                SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\BDCatHome; version=3;");
                conn.Open();
                SQLiteCommand cmd = conn.CreateCommand();
                string sql_command = "Update Main SET name=@name where id=@Id";
                cmd.CommandText = sql_command;
                cmd.Parameters.AddWithValue("@name", Namelabel.Text);
                cmd.Parameters.AddWithValue("@Id", ID.id_igrok);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Имя пользователя изменено");
            }
            else
            {
                MessageBox.Show("Имя пользователя не может быть пустым!");
            }
        }

        private void zvu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var directory = FilePath.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var player1 = new SoundPlayer(FilePath.Combine(directory,"click.wav"));
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

