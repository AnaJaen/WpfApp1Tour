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
    /// Interaction logic for Kundenbearb.xaml
    /// </summary>
    public partial class Kundenbearb : UserControl
    {
        Tour_DBEntities db = new Tour_DBEntities();

        public Kundenbearb()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //litour.ItemsSource = db.Tours.OrderBy(x => x.To_Bezeichnung).ToList();
            var erg = db.Kundes;
            erg.Load();
            likunden.ItemsSource = erg.Local;
        }

        private void NewKunde_Click(object sender, RoutedEventArgs e)
        {
           

            Kunde k = new Kunde
            {
                K_Kunde_Id = neuId(),
                K_Nachname = "Neuer Kunde"
            };
            db.Kundes.Add(k);
            db.SaveChanges();
            likunden.ItemsSource = db.Kundes.OrderBy(x => x.K_Nachname).ToList();
            likunden.SelectedItem = k;
            fehler.Text = "Neuer Kunde erfolgreich hinzugefügt";

        }

        private int neuId()
        {
            int nextId = (from k in db.Kundes
                          select k.K_Kunde_Id).Max() + 1;
            return nextId;
        }



        private void DeleteKunde_Click(object sender, RoutedEventArgs e)
        {
            if (likunden.SelectedItem != null)
            {
                var k1 = (Kunde)likunden.SelectedItem;
                db.Kundes.Remove(k1);
                likunden.Items.Refresh();
            }
        }

        private void SaveKunde_Click(object sender, RoutedEventArgs e)
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
