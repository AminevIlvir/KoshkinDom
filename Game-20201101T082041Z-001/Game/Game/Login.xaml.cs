using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
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
using FilePath = System.IO.Path;
using System.Media;
using System.Reflection;
using System.Data.Entity;
using System.Data.SQLite;

namespace Game
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        MediaPlayer player;
        public Login(MediaPlayer p1)
        {
            InitializeComponent();
            player = p1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MediaSound();
            SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\BDCatHome; version=3;");
            conn.Open();
            SQLiteCommand cmd = conn.CreateCommand();
            string cmd1 = "Select id,login,parol,record from main where login=@login and parol=@parol";
            cmd.CommandText = cmd1;
            cmd.Parameters.AddWithValue("@login",LoginLabel.Text);
            cmd.Parameters.AddWithValue("@parol",ParolLabel.Password);
            SQLiteDataReader sdr= cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                ID.id_igrok = Convert.ToInt32(sdr.GetValue(0));
                ID.Record = Convert.ToInt32( sdr.GetValue(3));
                conn.Close();
            Manager.Mainscreen.Navigate(new mainscreen(player));

            }
            else { MessageBox.Show("Неверный логин или пароль","Вход не выполнен"); }
            conn.Close();
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MediaSound();
            Manager.Mainscreen.GoBack();

        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
