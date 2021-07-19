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
    /// Interaction logic for Fremdenfbearb.xaml
    /// </summary>
    public partial class Fremdenfbearb : UserControl
    {
        Tour_DBEntities db = new Tour_DBEntities();
        public Fremdenfbearb()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var erg = db.Spraches;
            erg.Load();
            lisprache.ItemsSource = erg.Local;

        }
        private void NewFremdenfuehrer_Click(object sender, RoutedEventArgs e)
        {
            var f1 = new Fremdenfuehrer();
            f1.F_Vorname = "Neu";
              //((campoTabla columna1)x:name de columna1.SelectedItem).navigational property columna2.Add(var)
            ((Sprache)lisprache.SelectedItem).Fremdenfuehrers.Add(f1);
          
            limitarbeiter.Items.Refresh();
        }

        private void DeleteFremdenfuehrer_Click(object sender, RoutedEventArgs e)
        {
            if (limitarbeiter.SelectedItem != null)
            {
                var f1 = (Fremdenfuehrer)limitarbeiter.SelectedItem;
                db.Fremdenfuehrers.Remove(f1);
                limitarbeiter.Items.Refresh();
            }
        }

        private void SaveFremdenfuehrer_Click(object sender, RoutedEventArgs e)
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

