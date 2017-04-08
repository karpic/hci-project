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
using MapaPrirodnihSpomenika.Dijalozi;
using MapaPrirodnihSpomenika.Model;

namespace MapaPrirodnihSpomenika
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MainWindow instance;
        private List<Spomenik> spomenici; 
        
        public MainWindow()
        {
            InitializeComponent();
        }
        public static MainWindow Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new MainWindow();
                }
                return instance;
            }
        }

        /*public void dodajSpomenik(Spomenik s)
        {
            spomenici.Add(s);
        }*/

        private void dodajSpomClicked(object sender, RoutedEventArgs e)
        {
            IzmenaSpomenik izspm = new IzmenaSpomenik();
            izspm.Show();
        }

        private void dodajEtiketuClicked(object sender, RoutedEventArgs e)
        {
            IzmenaTag it = new IzmenaTag();
            it.Show();
        }

        private void dodajTipClicked(object sender, RoutedEventArgs e)
        {
            IzmenaTipSpomenika its = new IzmenaTipSpomenika();
            its.Show();
        }

        private void noviSpomMenuClicked(object sender, RoutedEventArgs e)
        {
            IzmenaSpomenik izspm = new IzmenaSpomenik();
            izspm.Show();
        }

        private void noviTipMenuClicked(object sender, RoutedEventArgs e)
        {
            IzmenaTipSpomenika its = new IzmenaTipSpomenika();
            its.Show();
        }

        private void novaEtiketaMenuClicked(object sender, RoutedEventArgs e)
        {
            IzmenaTag it = new IzmenaTag();
            it.Show();
        }

        private void izadjiMenuClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
