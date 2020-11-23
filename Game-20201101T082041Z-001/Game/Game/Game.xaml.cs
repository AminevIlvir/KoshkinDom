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
using FilePath = System.IO.Path;
using System.Reflection;
using Microsoft.Win32;
using System.IO;
using System.Data.SqlClient;
using System.Threading;
using System.Media;
using System.Data.SQLite;

namespace Game
{
    /// <summary>
    /// Логика взаимодействия для Game.xaml
    /// </summary>
    public partial class Gam : Page
    {
        string imag=NameImage.imag;
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer timer2 = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer korobkatick = new System.Windows.Threading.DispatcherTimer();
        public Gam()
        {
            InitializeComponent();
            l7.Content = "";
            Korobki();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer2.Tick += new EventHandler(timerTick2);
            timer2.Interval = new TimeSpan(0, 0, 1);
            korobkatick.Interval = new TimeSpan(0, 0, 1);
            vsegoockov = 0;
            sloshost = 3;
            lrecord.Content = ID.Record;
            
        }

        int sekunda2;
        int sloshost = 3;
        int kolichestvoprav;
        public static int vsegoockov = 0;

        private void timerTick3(object sender, EventArgs e)
        {
            Korobki();
        }

        private void timerTick2(object sender, EventArgs e)
        {
            ltime.Content = 20 - sekunda2;
            if (sekunda2 < 20)
            {
                sekunda2++;
            }
            else
            {
                timer2.Stop();
                Error();
                sekunda2 = 0;
            }
            if (kolichestvoprav == sloshost)
            {
                timer2.Stop();
                dostup = false;
                /*Image.Visibility = Visibility.Hidden;
                Image1.Visibility = Visibility.Hidden;
                Image2.Visibility = Visibility.Hidden;
                Image3.Visibility = Visibility.Hidden;
                Image4.Visibility = Visibility.Hidden;
                Image5.Visibility = Visibility.Hidden;
                MessageImage.Visibility = Visibility.Visible;
                MessageImage.Source = new BitmapImage(new Uri(@"Images\Sloshnost.png", UriKind.Relative));*/
                vsegoockov++;
                timer.Stop();
                lpoint.Content = vsegoockov.ToString();
                sloshost++;
                sekunda2 = 0;
                l7.Content = "";
                i = 0;
                kolicestvokorobok = 0;
                kolichestvoclikovnakorobki = 0;
                kolichestvoprav = 0;
                Prodol();
            }
        }
        int i;
        int last = 0;
        Random rnd = new Random();

        async void timerTick(object sender, EventArgs e)
        {
            IgrovMessageImage.Source = new BitmapImage(new Uri(@"Images\vosproizvedenie.png", UriKind.Relative));
            int ver = rnd.Next(1, 7);
            while (last == ver)
            { ver = rnd.Next(1, 7); }
            last = ver;
            var directory = FilePath.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Korobki();
            switch (ver)
            {
                case 1:
                    Image.Source = new BitmapImage(new Uri(FilePath.Combine(directory, Convert.ToString("1" + imag + ".png")))); kolicestvokorobok++; l7.Content += ver.ToString() + " ";
                    break;
                case 2:
                    Image1.Source = new BitmapImage(new Uri(FilePath.Combine(directory, Convert.ToString("2" + imag + ".png")))); kolicestvokorobok++; l7.Content += ver.ToString() + " ";
                    break;
                case 3:
                    Image2.Source = new BitmapImage(new Uri(FilePath.Combine(directory, Convert.ToString("3" + imag + ".png")))); kolicestvokorobok++; l7.Content += ver.ToString() + " ";
                    break;
                case 4:
                    Image3.Source = new BitmapImage(new Uri(FilePath.Combine(directory, Convert.ToString("4" + imag + ".png")))); kolicestvokorobok++; l7.Content += ver.ToString() + " ";
                    break;
                case 5:
                    Image4.Source = new BitmapImage(new Uri(FilePath.Combine(directory, Convert.ToString("5" + imag + ".png")))); kolicestvokorobok++; l7.Content += ver.ToString() + " ";
                    break;
                case 6:
                    Image5.Source = new BitmapImage(new Uri(FilePath.Combine(directory, Convert.ToString("6" + imag + ".png")))); kolicestvokorobok++; l7.Content += ver.ToString() + " ";
                    break;
            }
            if (kolicestvokorobok == sloshost)
            {
                timer.Stop();
                await Task.Delay(1000);
                dostup = true;
                IgrovMessageImage.Source=new BitmapImage(new Uri(@"Images\Vashhod.png",UriKind.Relative));
                Korobki();

                timer2.Start();
            }
            i++;
        }

        public void Error()
        {
            ltime.Content = 0;
            pologhenievmassive = 0;
            sekunda2 = 0;
            sloshost = 3;
            l7.Content = "";
            dostup = false;
            timer2.Stop();
            timer.Stop();
            RecordCheck();
            vsegoockov = 0;
            Image.Visibility = Visibility.Hidden;
            Image1.Visibility = Visibility.Hidden;
            Image2.Visibility = Visibility.Hidden;
            Image3.Visibility = Visibility.Hidden;
            Image4.Visibility = Visibility.Hidden;
            Image5.Visibility = Visibility.Hidden;
            MessageImage.Visibility = Visibility.Visible;
            var directory = FilePath.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            MessageImage.Source = new BitmapImage(new Uri(FilePath.Combine(directory, Convert.ToString("Theend.png"))));
        }

        bool dostup;

        int kolichestvoclikovnakorobki, kolicestvokorobok, pologhenievmassive;
        async void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (dostup == true)
            {
                MediaSound();
                Korobki();
                string s = l7.Content.ToString();
                string[] a = s.Split(' ');

                var directory = FilePath.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                Image.Source = new BitmapImage(new Uri(FilePath.Combine(directory, Convert.ToString("1" + imag + ".png"))));
                
                kolichestvoclikovnakorobki++;

                if (a[pologhenievmassive] == "1")
                {pologhenievmassive++; kolichestvoprav++; await Task.Delay(1000);
                }
                else
                {
                    Error();
                }
                if (pologhenievmassive == sloshost)
                {
                    timerTick2(sender,e);
                }
            }
        }
        async void Image1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (dostup == true)
            {
                MediaSound();
                Korobki();
                string s = l7.Content.ToString();
                string[] a = s.Split(' ');
            
                var directory = FilePath.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                Image1.Source = new BitmapImage(new Uri(FilePath.Combine(directory, Convert.ToString("2" + imag + ".png"))));
                kolichestvoclikovnakorobki++;
                if (a[pologhenievmassive] == "2")
                {
                    pologhenievmassive++; kolichestvoprav++; await Task.Delay(1000);
                }
                else
                {
                    Error();
                }
                if (pologhenievmassive == sloshost)
                {
                    timerTick2(sender, e);
                }
            }
        }
        async void Image2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (dostup == true)
            {
                MediaSound();
                Korobki();
                string s = l7.Content.ToString();
                string[] a = s.Split(' ');
            
                var directory = FilePath.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                Image2.Source = new BitmapImage(new Uri(FilePath.Combine(directory, Convert.ToString("3" + imag + ".png"))));
                kolichestvoclikovnakorobki++;
                if (a[pologhenievmassive] == "3")
                {
                    pologhenievmassive++; kolichestvoprav++; await Task.Delay(1000);
                }
                else
                {
                    Error();
                }
                if (pologhenievmassive == sloshost)
                {
                    timerTick2(sender, e);
                }
            }
        }
        async void Image3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (dostup == true)
            {
                MediaSound();
                Korobki();
                string s = l7.Content.ToString();
                string[] a = s.Split(' ');
            
                var directory = FilePath.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                Image3.Source = new BitmapImage(new Uri(FilePath.Combine(directory, Convert.ToString("4" + imag + ".png"))));

                kolichestvoclikovnakorobki++;
                if (a[pologhenievmassive] == "4")
                {
                    pologhenievmassive++; kolichestvoprav++; await Task.Delay(1000);
                }
                else
                {
                    Error();
                }
                if (pologhenievmassive == sloshost)
                {
                    timerTick2(sender, e);
                }
            }
        }
        async void Image4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (dostup == true)
            {
                MediaSound();
                Korobki();
                string s = l7.Content.ToString();
                string[] a = s.Split(' ');
            
                var directory = FilePath.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                Image4.Source = new BitmapImage(new Uri(FilePath.Combine(directory, Convert.ToString("5" + imag + ".png"))));

                kolichestvoclikovnakorobki++;

                if (a[pologhenievmassive] == "5")
                {
                    pologhenievmassive++; kolichestvoprav++; await Task.Delay(1000);
                }
                else
                {
                    Error();
                }
                if (pologhenievmassive == sloshost)
                {
                    timerTick2(sender, e);
                }
            }
        }
        async void Image5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (dostup == true)
            {
                MediaSound();
                Korobki();
                string s = l7.Content.ToString();
                string[] a = s.Split(' ');
            
                var directory = FilePath.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                Image5.Source = new BitmapImage(new Uri(FilePath.Combine(directory, Convert.ToString("6" + imag + ".png"))));
                kolichestvoclikovnakorobki++;
                if (a[pologhenievmassive] == "6")
                {
                    pologhenievmassive++; kolichestvoprav++; await Task.Delay(1000);
                }
                else
                {
                    Error();
                }
                if (pologhenievmassive == sloshost)
                {
                    timerTick2(sender, e);
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MediaSound();
            timer2.Stop();
            timer.Stop();
        }
        
        private void Korobki()
        {
            Image.Visibility = Visibility.Visible;
            Image1.Visibility = Visibility.Visible;
            Image2.Visibility = Visibility.Visible;
            Image3.Visibility = Visibility.Visible;
            Image4.Visibility = Visibility.Visible;
            Image5.Visibility = Visibility.Visible;
            MessageImage.Visibility = Visibility.Hidden;
            var directory = FilePath.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Image.Source = new BitmapImage(new Uri(FilePath.Combine(directory, "0.png")));
            Image1.Source = new BitmapImage(new Uri(FilePath.Combine(directory, "0.png")));
            Image2.Source = new BitmapImage(new Uri(FilePath.Combine(directory, "0.png")));
            Image3.Source = new BitmapImage(new Uri(FilePath.Combine(directory, "0.png")));
            Image4.Source = new BitmapImage(new Uri(FilePath.Combine(directory, "0.png")));
            Image5.Source = new BitmapImage(new Uri(FilePath.Combine(directory, "0.png")));
        }
        
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MediaSound();
            Error();
            Manager.Mainscreen.GoBack();
        }

        private void RecordCheck()
        {
            if (vsegoockov > ID.Record)
            {
                ID.Record = vsegoockov;

                SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\BDCatHome; version=3;");
                conn.Open();
                SQLiteCommand cmd = conn.CreateCommand();
                string cmd1 ="Update Main SET record=@Record where id=@Id";
                cmd.CommandText = cmd1;
                cmd.Parameters.AddWithValue("@Record", ID.Record);
                cmd.Parameters.AddWithValue("@Id", ID.id_igrok);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            lrecord.Content = ID.Record;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MediaSound();
            Error();
            sekunda2 = 0;
            kolicestvokorobok = 0;
            kolichestvoclikovnakorobki = 0;
            timer.Start();
            ltime.Content = 20-sekunda2;
            lpoint.Content = vsegoockov.ToString();
            pologhenievmassive = 0;
            l7.Content = "";
            i = 0;
            kolichestvoprav = 0;
            Korobki();
        }

        private void Prodol()
        {
            sekunda2 = 0;
            kolicestvokorobok = 0;
            kolichestvoclikovnakorobki = 0;
            timer.Start();
            ltime.Content = 20 - sekunda2;
            lpoint.Content = vsegoockov.ToString();
            pologhenievmassive = 0;
            l7.Content = "";
            i = 0;
            kolichestvoprav = 0;
            Korobki();
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

    }
}
