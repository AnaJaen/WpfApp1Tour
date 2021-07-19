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
    /// Interaction logic for Treffanzeigen.xaml
    /// </summary>
    public partial class Treffanzeigen : UserControl
    {
        Tour_DBEntities db = new Tour_DBEntities();
        public Treffanzeigen()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            cbTouranz.ItemsSource = db.Tours.OrderBy(x => x.To_Bezeichnung).ToList();
        }
    }
}
