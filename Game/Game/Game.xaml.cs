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
        public Gam()
        {
            InitializeComponent();
            l7.Content = "";
            Korobki();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer2.Tick += new EventHandler(timerTick2);
            timer2.Interval = new TimeSpan(0, 0, 1);

        }
        int sekunda2;
        int ocki = 0;
        int sloshost = 3;
        int kolichestvoprav;
        int vsegoockov;
        private void timerTick3(object sender, EventArgs e)
        {
            Korobki();
        }
        private void timerTick2(object sender, EventArgs e)
        {
            ltime.Content = "Время: " + sekunda2;
            if (sekunda2 < 20)
            {
                sekunda2++;
            }
            else
            {
                timer2.Stop();
                vsegoockov -= ocki;
                //opisanie.Text = "Время окончено.Cложность будет понижена на уровень. \nВаше количество очков за уровень: " + ocki;
                sekunda2 = 0;
                lpoint.Content = "Всего очков: " + vsegoockov.ToString();
                if (sloshost > 3)
                    sloshost--;
                //oc2.Content = "Очки за раунд: " + ocki;
            }
            if (kolichestvoprav == sloshost)
            {
                timer2.Stop();
                vsegoockov += ocki;
                //opisanie.Text = "Вы выиграли.";
                dostup = false;
                lpoint.Content = "Очки: " + vsegoockov.ToString();
                sloshost++;
                sekunda2 = 0;
                ocki = 0;
                pologhenievmassive = 0;
                l7.Content = "";
                i = 0;
                //l2.Content = "Сложность: " + sloshost.ToString();
                kolicestvokorobok = 0;
                kolichestvoclikovnakorobki = 0;
                kolichestvoprav = 0;
                Korobki();
                timer.Stop();
            }
        }
        int i;
        int last = 0;
        Random rnd = new Random();

        private void timerTick(object sender, EventArgs e)
        {
            int ver = rnd.Next(1, 7);
            while (last == ver)
            { ver = rnd.Next(1, 7); }
            last = ver;
            var directory = FilePath.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //opisanie.Text = "";
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
                dostup = true;
                MessageBox.Show("Ваш ход");
                timer2.Start();
                Korobki();
                timer.Stop();
            }
            i++;
        }
        public void Error(object sender, MouseButtonEventArgs e)
        {
            sekunda2 = 0;
            sloshost = 3;
            vsegoockov = 0;
            l7.Content = "";
            dostup = false;
            //MessageBox.Show("Вы проиграли");
            timer2.Stop();
            Image.Visibility = Visibility.Hidden;
            Image1.Visibility = Visibility.Hidden;
            Image2.Visibility = Visibility.Hidden;
            Image3.Visibility = Visibility.Hidden;
            Image4.Visibility = Visibility.Hidden;
            Image5.Visibility = Visibility.Hidden;
            MessageImage.Visibility = Visibility.Visible;
            var directory = FilePath.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            MessageImage.Source = new BitmapImage(new Uri(FilePath.Combine(directory, Convert.ToString("Theend.png"))));
            //Button_Click(sender, e);
        }
        bool dostup;
        int kolichestvoclikovnakorobki, kolicestvokorobok, pologhenievmassive;
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Korobki();
            string s = l7.Content.ToString();
            string[] a = s.Split(' ');
            if (dostup == true)
            {
                var directory = FilePath.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                Image.Source = new BitmapImage(new Uri(FilePath.Combine(directory, Convert.ToString("1" + imag + ".png"))));
                kolichestvoclikovnakorobki++;

                if (a[pologhenievmassive] == "1")
                { vsegoockov++; pologhenievmassive++; kolichestvoprav++;
                    lpoint.Content = "Всего очков: " + vsegoockov.ToString();/*oc2.Content = "Очки за раунд: " + ocki; */
                }
                else
                {
                    Error(sender,e);
                }
                if (pologhenievmassive == sloshost)
                {
                    timerTick2(sender,e);
                    Button_Click(sender,e);
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            timer2.Stop();
            timer.Stop();

            /*if (MessageBox.Show("Вы уверены в этом? Ваш прогресс будет утерян", "Stop", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Window1 w2 = new Window1();
                this.Hide();
                w2.Show();
                sekunda2 = 0;
            }*/
        }

        private void Image4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Korobki();
            string s = l7.Content.ToString();
            string[] a = s.Split(' ');
            if (dostup == true)
            {
                var directory = FilePath.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                Image4.Source = new BitmapImage(new Uri(FilePath.Combine(directory, Convert.ToString("5" + imag + ".png"))));
                kolichestvoclikovnakorobki++;

                if (a[pologhenievmassive] == "5")
                { vsegoockov++; pologhenievmassive++; kolichestvoprav++;
                    lpoint.Content = "Всего очков: " + vsegoockov.ToString();/* oc2.Content = "Очки за раунд: " + ocki;*/
                }
                else
                {
                    Error(sender,e);
                }
                if (pologhenievmassive == sloshost)
                {
                    timerTick2(sender, e);
                    Button_Click(sender, e);
                }
            }
        }

        private void Image2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Korobki();
            string s = l7.Content.ToString();
            string[] a = s.Split(' ');
            if (dostup == true)
            {
                var directory = FilePath.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                Image2.Source = new BitmapImage(new Uri(FilePath.Combine(directory, Convert.ToString("3" + imag + ".png"))));
                kolichestvoclikovnakorobki++;
                if (a[pologhenievmassive] == "3")
                { vsegoockov++; pologhenievmassive++; kolichestvoprav++;
                    lpoint.Content = "Всего очков: " + vsegoockov.ToString();/*oc2.Content = "Очки за раунд: " + ocki;*/
                }
                else
                {
                    Error(sender,e);
                }
                if (pologhenievmassive == sloshost)
                {
                    timerTick2(sender, e);
                    Button_Click(sender, e);
                }
            }
        }

        private void Image3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Korobki();
            string s = l7.Content.ToString();
            string[] a = s.Split(' ');
            if (dostup == true)
            {
                var directory = FilePath.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                Image3.Source = new BitmapImage(new Uri(FilePath.Combine(directory, Convert.ToString("4" + imag + ".png"))));
                kolichestvoclikovnakorobki++;
                if (a[pologhenievmassive] == "4")
                { vsegoockov++; pologhenievmassive++; kolichestvoprav++;
                    lpoint.Content = "Всего очков: " + vsegoockov.ToString();/*oc2.Content = "Очки за раунд: " + ocki;*/
                }
                else
                {
                    Error(sender,e);
                }
                if (pologhenievmassive == sloshost)
                {
                    timerTick2(sender, e);
                    Button_Click(sender, e);
                }
            }
        }

        private void Image5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Korobki();
            string s = l7.Content.ToString();
            string[] a = s.Split(' ');
            if (dostup == true)
            {
                var directory = FilePath.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                Image5.Source = new BitmapImage(new Uri(FilePath.Combine(directory, Convert.ToString("6" + imag + ".png"))));
                kolichestvoclikovnakorobki++;
                if (a[pologhenievmassive] == "6")
                { vsegoockov++; pologhenievmassive++; kolichestvoprav++;
                    lpoint.Content = "Всего очков: " + vsegoockov.ToString();/*oc2.Content = "Очки за раунд: " + ocki; */
                }
                else
                {
                    Error(sender,e);
                }
                if (pologhenievmassive == sloshost)
                {
                    timerTick2(sender, e);
                    Button_Click(sender, e);
                }
            }
        }
        private void Korobki()
        {
            var directory = FilePath.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Image.Source = new BitmapImage(new Uri(FilePath.Combine(directory, "0.png")));
            Image1.Source = new BitmapImage(new Uri(FilePath.Combine(directory, "0.png")));
            Image2.Source = new BitmapImage(new Uri(FilePath.Combine(directory, "0.png")));
            Image3.Source = new BitmapImage(new Uri(FilePath.Combine(directory, "0.png")));
            Image4.Source = new BitmapImage(new Uri(FilePath.Combine(directory, "0.png")));
            Image5.Source = new BitmapImage(new Uri(FilePath.Combine(directory, "0.png")));
        }
        private void Image1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Korobki();
            string s = l7.Content.ToString();
            string[] a = s.Split(' ');
            if (dostup == true)
            {
                var directory = FilePath.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                Image1.Source = new BitmapImage(new Uri(FilePath.Combine(directory, Convert.ToString("2" + imag + ".png"))));
                kolichestvoclikovnakorobki++;
                if (a[pologhenievmassive] == "2")
                { vsegoockov++; pologhenievmassive++; kolichestvoprav++;
                    lpoint.Content = "Всего очков: " + vsegoockov.ToString();/*oc2.Content = "Очки за раунд: " + ocki;*/
                }
                else
                {
                    Error(sender,e);
                }
                if (pologhenievmassive == sloshost)
                {
                    timerTick2(sender, e);
                    Button_Click(sender, e);
                }
            }
        }
        int record1, record2, record3;

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Manager.mainscreen.GoBack();
        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            string[] rea = File.ReadAllLines("rekord.txt");
            record1 = Convert.ToInt32(rea[0]);
            record2 = Convert.ToInt32(rea[1]);
            record3 = Convert.ToInt32(rea[2]);
            if (vsegoockov == record1 || vsegoockov == record2 || vsegoockov == record3)
            { }
            else
            {
                if (vsegoockov > record3)
                {
                    if (vsegoockov > record2)
                    {
                        if (vsegoockov > record1)
                        {
                            record3 = record2;
                            record2 = record1;
                            record1 = vsegoockov;
                        }
                        else
                        {
                            record3 = record2;
                            record2 = vsegoockov;
                        }
                    }
                    else
                    {
                        record3 = vsegoockov;
                    }
                }
            }
            using (StreamWriter sw = new StreamWriter("rekord.txt", false, System.Text.Encoding.Default))
            {
                int[] arr = { record1, record2, record3 };
                for (int i = 0; i < arr.Length; i++)
                {
                    sw.WriteLine(arr[i]);
                }
            }
            Application.Current.Shutdown();
        }
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sekunda2 = 0;
            kolicestvokorobok = 0;
            kolichestvoclikovnakorobki = 0;
            timer.Start();
            //l2.Content = "Сложность " + sloshost.ToString();
            lpoint.Content = "Всего очков: " + vsegoockov.ToString();
            //oc2.Content = "Очки за раунд: " + ocki;
            ltime.Content = "Время: " + sekunda2;
            pologhenievmassive = 0;
            l7.Content = "";
            i = 0;
            ocki = 0;
            kolichestvoprav = 0;
            Korobki();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("За 10 секунд нажми нужную комбинацию картинок, которую системa показала в начале", "Правила");
        }
    }
}
