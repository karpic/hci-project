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

namespace MapaPrirodnihSpomenika
{

    public partial class MainWindow : Window
    {
        private static MainWindow instance;
        private ObservableCollection<Spomenik> spomenici;
        private List<Tip> tipovi;

        public ObservableCollection<Spomenik> Spomenici
        {
            get
            {
                return spomenici;
            }
        }
        private void OnPropertyChanged(string v)
        {
            throw new NotImplementedException();
        }

        public MainWindow()
        { 
            InitializeComponent();
            spomenici = new ObservableCollection<Spomenik>();
            Spomenik s = new Spomenik("a", "a", "a");
            spomenici.Add(s);
            listViewSpomenici.ItemsSource = spomenici;
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
        public void dodajSpomenik(Spomenik s)
        {
            spomenici.Add(s);
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
    }
}
