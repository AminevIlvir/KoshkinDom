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

namespace Game
{
    /// <summary>
    /// Логика взаимодействия для record1.xaml
    /// </summary>
    public partial class record1 : Page
    {
        public record1()
        {
            InitializeComponent();
        }
        CatHomeEntities bd = new CatHomeEntities();
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            var max = bd.Record.OrderByDescending(i => i.id_record).FirstOrDefault();
           
            if (max != null)
            {
                var name = bd.Players.Where(l => l.id_player == max.id_player).FirstOrDefault();
                var r1 = "1. "+max.score+" "+name.username;
                rec1.Content = r1;
                var re2 = bd.Record.OrderBy(i => i.id_record).Take(2).FirstOrDefault();
                if (re2 != null)
                {
                     name = bd.Players.Where(l => l.id_player == re2.id_player).FirstOrDefault();
                    var r2 = "1. " + max.score + " " + name.username;
                    if(max.id_record!=re2.id_record)
                    rec2.Content = r1;
                }
                var re3 = bd.Record.OrderBy(i => i.id_record).Take(3).FirstOrDefault();
                if (re3 != null)
                {
                    name = bd.Players.Where(l => l.id_player == re3.id_player).FirstOrDefault();
                    var r3 = "1. " + max.score + " " + name.username;
                    if (re2.id_record != re3.id_record)
                        rec3.Content = r1;
                }
                var re4 = bd.Record.OrderBy(i => i.id_record).Take(4).FirstOrDefault();
                if (re4 != null)
                {
                     name = bd.Players.Where(l => l.id_player == re4.id_player).FirstOrDefault();
                    var r4 = "1. " + max.score + " " + name.username;
                    if (re3.id_record != re4.id_record)
                        rec4.Content = r1;
                }
                var re5 = bd.Record.OrderBy(i => i.id_record).Take(5).FirstOrDefault();
                if (re5 != null)
                {
                     name = bd.Players.Where(l => l.id_player == re5.id_player).FirstOrDefault();
                    var r5 = "1. " + max.score + " " + name.username;
                    if (re4.id_record != re5.id_record)
                        rec5.Content = r1;
                }
            }
            schet.Content ="Ваш счет: "+ Gam.vsegoockov;
            Record r = new Record();
            r.id_player = Gam.idPlayer;
            r.score = Gam.vsegoockov;
            bd.Record.Add(r);
            bd.SaveChanges();
            
        }
    }
}
