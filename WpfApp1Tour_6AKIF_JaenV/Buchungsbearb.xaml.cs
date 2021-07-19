using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Interaction logic for Buchungsbearb.xaml
    /// </summary>
    public partial class Buchungsbearb : UserControl
    {
        Tour_DBEntities db = new Tour_DBEntities();

        public Buchungsbearb()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var erg = db.Tours;
            erg.Load();
            litourname.ItemsSource = erg.Local;

            //cb vom StackPanel

            cbKundeId.ItemsSource = db.Kundes.OrderBy(x => x.K_Kunde_Id).ToList();

            cbsprache.ItemsSource = db.Spraches.OrderBy(x => x.S_Language).ToList();

        }

        private void NewBuchung_Click(object sender, RoutedEventArgs e)
        {
            var b1 = new Buchung();
            b1.B_Buchung_Id = neuId();
            ((Tour)litourname.SelectedItem).Buchungs.Add(b1);
            //((campoTabla columna1)x:name de columna1.SelectedItem).navigational property columna2.Add(var)
            libuchung.Items.Refresh();
        }

        //Neu ID : erhöht das letzte ID auf 1
        private int neuId()
        {
            int nextId = (from b in db.Buchungs
                          select b.B_Buchung_Id).Max() + 1;
            return nextId;
        }
        
     

        private void DeleteBuchung_Click(object sender, RoutedEventArgs e)
        {
            if (libuchung.SelectedItem != null)
            {
                var b1 = (Buchung)libuchung.SelectedItem;
                db.Buchungs.Remove(b1);
                libuchung.Items.Refresh();

            }

        }

        private void SaveBuchung_Click(object sender, RoutedEventArgs e)
        {
            fehler.Text = "";

            try
            {
                int anz = db.SaveChanges();
                fehler.Text = anz + "Datenzeilen betroffen!";
            }
            catch (Exception e1)
            {
                fehler.Text = e1.Message;
                for (var ex = e1.InnerException; ex != null; ex = ex.InnerException)
                    fehler.Text = fehler.Text + " / " + ex.Message;
            }
        }

    }
}
