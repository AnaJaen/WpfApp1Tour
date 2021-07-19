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
using System.Reflection;

namespace WpfApp1Tour_6AKIF_JaenV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
          
        private void Kundenbearb_Click(object sender, RoutedEventArgs e)
        {
            contentcontrol.Children.Clear();
            contentcontrol.Children.Add(new Kundenbearb());
        }
        
         private void Buchungsbearb_Click(object sender, RoutedEventArgs e)
        {
            contentcontrol.Children.Clear();
            contentcontrol.Children.Add(new Buchungsbearb());
        }

        private void Tour_Click(object sender, RoutedEventArgs e)
        {
            contentcontrol.Children.Clear();
            contentcontrol.Children.Add(new Tourbearb());
        }

        private void Treffanzeigen_Click(object sender, RoutedEventArgs e)
        {
            contentcontrol.Children.Clear();
            contentcontrol.Children.Add(new Treffanzeigen());
        }

        private void Treffbearb_Click(object sender, RoutedEventArgs e)
        {
            contentcontrol.Children.Clear();
            contentcontrol.Children.Add(new Treffbearb());
        }

        private void Fremdenfbearb_Click(object sender, RoutedEventArgs e)
        {
            contentcontrol.Children.Clear();
            contentcontrol.Children.Add(new Fremdenfbearb());
        }

        private void StatTour_Click(object sender, RoutedEventArgs e)
        {
            contentcontrol.Children.Clear();
            contentcontrol.Children.Add(new StatTour());
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            AboutUns au = new AboutUns();
            au.ShowDialog();
    
        }

        private void cbfarbeselect(object sender, SelectionChangedEventArgs e)
        {
            Color selectedColor = (Color)(cbfarben.SelectedItem as PropertyInfo).GetValue(1, null);
            this.Background = new SolidColorBrush(selectedColor);
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbfarben.ItemsSource = typeof(Colors).GetProperties();
           
        }
    }
}
