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

namespace WpfApp1Tour_6AKIF_JaenV
{
    /// <summary>
    /// Interaction logic for StatTour.xaml
    /// </summary>
    public partial class StatTour : UserControl
    {
        public StatTour()
        {
            InitializeComponent();

            var db = new Tour_DBEntities();
           
            //Buchung pro Tour
            liStatBuchTour.ItemsSource =
                (from t in db.Tours
                 orderby t.To_Bezeichnung
                 select new BuchungTourStat
                     {
                        Tour_Id = t.To_Tour_Id,
                        Bezeichnung = t.To_Bezeichnung,
                        Buchungszahl = t.Buchungs.Count ,
                        Breite = t.Buchungs.Count()*20
                 }
                ).ToList();
        }
    }

    public class BuchungTourStat
    {
        public  int Tour_Id { get; set; }
        public String Bezeichnung { get; set; }
        public int Buchungszahl { get; set; }
        public int Breite { get; set; }
    }
}
