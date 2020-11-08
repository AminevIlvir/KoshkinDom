using Books;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr : Page
    {
        public Registr()
        {
            InitializeComponent();

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
        private void reg_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MediaSound();
            SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\BDCatHome; version=3;");
            conn.Open();
            SQLiteCommand cmd = conn.CreateCommand();
            string sql_command =" CREATE TABLE Main("+
    "`id`    INTEGER NOT NULL,"+
    "`name`  TEXT,"+
    "`login` TEXT,"+
    "`parol` TEXT,"+
    "`record`    INTEGER,"+
    "PRIMARY KEY(`id` AUTOINCREMENT));";
            cmd.CommandText = sql_command;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                //MessageBox.Show(ex.Message);
            }

            SQLiteCommand sqlCommand = conn.CreateCommand();

            string proverka = Convert.ToString("Select login from Main where login IN ('" + Login.Text + "')");
            sqlCommand.CommandText = proverka;
            try
            {
                SQLiteDataReader sdr = sqlCommand.ExecuteReader();
                if (!sdr.HasRows)
                {
                    conn.Close();
                    StringBuilder errors = new StringBuilder();
                    if (Login.Text.Length == 0)
                    {
                        errors.AppendLine("Укажите логин");
                    }
                    if(Name.Text.Length == 0)
                    {
                        errors.AppendLine("Укажите имя пользователя");
                    }
                    if (Parol.Text.Length == 0)
                    {
                        errors.AppendLine("Укажите пароль");
                    }

                    if (errors.Length > 0)
                    {
                        MessageBox.Show(errors.ToString());
                        return;
                    }

                    string cmd1 = "Insert Into Main (login,name,parol,record) values (@Login,@Name,@Parol,@Record)";

                    SQLiteCommand command = conn.CreateCommand();
                    command.CommandText = cmd1;
                    command.Parameters.AddWithValue("@Login", Login.Text);
                    command.Parameters.AddWithValue("@Name", Name.Text);
                    command.Parameters.AddWithValue("@Parol", Parol.Text);
                    command.Parameters.AddWithValue("@Record", 0);
                    try
                    {
                        conn.Open();
                        command.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Вы зарегистрировались");
                        Manager.Mainscreen.GoBack();
                    }
                    catch (Exception ex)
                    {
                        //If something went wrong
                        MessageBox.Show("Ошибка" + ex);
                    }
                }
                else { MessageBox.Show("Логин занят"); }
            }
            catch(Exception ex) 
            { MessageBox.Show("Ошибка" + ex); }
            try
            {
                conn.Close();
            }
            catch { }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MediaSound();
            Manager.Mainscreen.GoBack();
        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            var directory = FilePath.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var player = new SoundPlayer(FilePath.Combine(directory, "click.wav"));
            if (Option.isPlaying == false)
            {
                player.Play();
            }
            else
            {
                player.Stop();
            }
        }

        private void Parol_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = false;
            }
        }

        private void Login_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
        }

        private void Login_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void Name_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void Parol_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }

}