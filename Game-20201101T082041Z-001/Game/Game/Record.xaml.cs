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
    /// Логика взаимодействия для Record.xaml
    /// </summary>
    public partial class Record : Page
    {
        public Record()
        {
            InitializeComponent();
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\BDCatHome; version=3;");
            conn.Open();
            SQLiteCommand cmd = conn.CreateCommand();
            string sql_command = "Select name,record from Main Order by record Desc limit 5;";
            cmd.CommandText = sql_command;

            try
            {
                SQLiteDataReader bd = cmd.ExecuteReader();
                if (bd.HasRows)
                {
                    int i = 0;
                    if (bd.Read())
                    {
                        i++;
                        var read = i.ToString() + "." + bd.GetValue(0);
                        rec11.Content= bd.GetValue(1);
                        rec1.Content = read;
                        if (bd.Read())
                        {
                            i++;
                            read = i.ToString() + "." + bd.GetValue(0);
                            rec21.Content = bd.GetValue(1);
                            rec2.Content = read;
                            if (bd.Read())
                            {
                                i++;
                                read = i.ToString() + "." + bd.GetValue(0);
                                rec31.Content = bd.GetValue(1);
                                rec3.Content = read;
                                if (bd.Read())
                                {
                                    i++;
                                    read = i.ToString() + "." + bd.GetValue(0);
                                    rec41.Content = bd.GetValue(1);
                                    rec4.Content = read;
                                    if (bd.Read())
                                    {
                                        i++;
                                        read = i.ToString() + "." + bd.GetValue(0);
                                        rec51.Content = bd.GetValue(1);
                                        rec5.Content = read;
                                    }
                                }
                            }
                        }
                    }
                    schet.Content = "Ваш счет: ";
                    schet1.Content = ID.Record;
                }
            }
            catch
            { MessageBox.Show("Произошла непредвиденная ошибка"); }
            try
            {
                conn.Close();
            }
            catch { }
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
            
        }
    }
}
