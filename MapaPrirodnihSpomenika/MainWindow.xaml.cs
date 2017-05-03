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
using MapaPrirodnihSpomenika.TableView;
using System.ComponentModel;
using Microsoft.Win32;

namespace MapaPrirodnihSpomenika
{
    [Serializable]
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
        private String _putanja;
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

        private void izmeniTipClicked(object sender, RoutedEventArgs e)
        {
            Tip selectedTip = (Tip)treeTipovi.SelectedItem;
            IzmenaTipSpomenika iz = new IzmenaTipSpomenika(selectedTip);
            iz.Show();
        }

        private void izmeniTagClicked(object sender, RoutedEventArgs e)
        {
            Tag selectedTag = (Tag)treeViewTagovi.SelectedItem;
            IzmenaTag iz = new IzmenaTag(selectedTag);
            iz.Show();
        }

        private void obrisiSpomenikClicked(object sender, RoutedEventArgs e)
        {
            Spomenik spomenikToDelete = (Spomenik)treeViewSpomenici.SelectedItem;
            Spomenici.Remove(spomenikToDelete);
        }

        private void obrisiTipClicked(object sender, RoutedEventArgs e)
        {
            Tip tipToDelete = (Tip)treeTipovi.SelectedItem;
            Tipovi.Remove(tipToDelete);
        }

        private void obrisiTagClicked(object sender, RoutedEventArgs e)
        {
            Tag tagToDelete = (Tag)treeViewTagovi.SelectedItem;
            Tagovi.Remove(tagToDelete);
        }

        private void sviSpomeniciClicked(object sender, RoutedEventArgs e)
        {
            TableViewSpomenik tvs = new TableViewSpomenik();
            tvs.DataContext = this;
            tvs.Show();
        }

        private void sviTipoviClicked(object sender, RoutedEventArgs e)
        {
            TableViewTip tvt = new TableViewTip();
            tvt.DataContext = this;
            tvt.Show();
        }

        private void sviTagoviClicked(object sender, RoutedEventArgs e)
        {
            TableViewTag tvt = new TableViewTag();
            tvt.DataContext = this;
            tvt.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //openFileDialog1.InitialDirectory = "c:\\";
            //openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            //openFileDialog1.FilterIndex = 2;
            //openFileDialog1.RestoreDirectory = true;
            //System.Windows.Forms.DialogResult result = openFileDialog1
            //if (openFileDialog1.ShowDialog() == )
            //{
            //    try
            //    {
            //        _putanja = openFileDialog1.FileName;
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            //    }
            //}
        }
    }
}
