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
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MapaPrirodnihSpomenika
{

    public partial class MainWindow : Window
    {

        public static ObservableCollection<Spomenik> Spomenici
        {
            set;
            get;
        }
        public static ObservableCollection<Tip> Tipovi
        {
            set;
            get;
        }
        public static ObservableCollection<Tag> Tagovi
        {
            set;
            get;
        }
        public MainWindow()
        { 
            InitializeComponent();
            this.DataContext = this;
            Spomenici = new ObservableCollection<Spomenik>();
            Tipovi = new ObservableCollection<Tip>();
            Tagovi = new ObservableCollection<Tag>();
        }
      
        public void dodajSpomenik(Spomenik s)
        {
            Spomenici.Add(s);
            
            
        }

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

        private void okClicked(object sender, RoutedEventArgs e)
        {
            Spomenik selectedSpomenik = (Spomenik)treeViewSpomenici.SelectedItem;
            IzmenaSpomenik iz = new IzmenaSpomenik(selectedSpomenik);
            iz.Show();
        }
    }
}
