using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using MapaPrirodnihSpomenika.Model;

namespace MapaPrirodnihSpomenika.Dijalozi
{
    /// <summary>
    /// Interaction logic for IzmenaSpomenik.xaml
    /// </summary>
    public partial class IzmenaSpomenik : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        Boolean constructor2used = false;
        Spomenik constructor2spomenik;
        private string _oznaka;
        public string Oznaka
        {
            get
            {
                return _oznaka;
            }
            set
            {
                if (value != _oznaka)
                {
                    _oznaka = value;
                    OnPropertyChanged("Oznaka");
                }
            }
        }
        private string _ime;
        public string Ime
        {
            get
            {
                return _ime;
            }
            set
            {
                if (value != _ime)
                {
                    _ime = value;
                    OnPropertyChanged("Ime");
                }
            }
        }
        private string _opis;
        public string Opis
        {
            get
            {
                return _opis;
            }
            set
            {
                if (value != _opis)
                {
                    _opis = value;
                    OnPropertyChanged("Ime");
                }
            }
        }
        private string _tip;
        public string Tip
        {
            get
            {
                return _tip;
            }
            set
            {
                if (value != _tip)
                {
                    _tip = value;
                    OnPropertyChanged("Ime");
                }
            }
        }
        private string _klima;
        public string Klima
        {
            get
            {
                return _klima;
            }
            set
            {
                if (value != _klima)
                {
                    _klima = value;
                    OnPropertyChanged("Ime");
                }
            }
        }
        private double _prihod;
        public double Prihod
        {
            get
            {
                return _prihod;
            }
            set
            {
                if (value != _prihod)
                {
                    _prihod = value;
                    OnPropertyChanged("Prihod");
                }
            }
        }
        

        
        public IzmenaSpomenik(Spomenik s)
        {
            InitializeComponent();
            this.DataContext = this;
            constructor2used = true;
            constructor2spomenik = s;
            this._oznaka = s.Oznaka;
            this._ime = s.Ime;
        }
        public IzmenaSpomenik()
        {
            InitializeComponent();
            this.DataContext = this;
            this.comboBoxKlima.Items.Add("Polarna");
            this.comboBoxKlima.Items.Add("Kontinentalna");
            this.comboBoxKlima.Items.Add("Umereno-kontinentalna");
            this.comboBoxKlima.Items.Add("Pustinjska");
            this.comboBoxKlima.Items.Add("Suptropska");
            this.comboBoxKlima.Items.Add("Tropska");

            this.comboBoxTurStatus.Items.Add("Eksploatisan");
            this.comboBoxTurStatus.Items.Add("Dostupan");
            this.comboBoxTurStatus.Items.Add("Nedostupan");

            this.comboBoxEkoUgorzen.Items.Add("Da");
            this.comboBoxEkoUgorzen.Items.Add("Ne");

            this.comboBoxNaselje.Items.Add("Da");
            this.comboBoxNaselje.Items.Add("Ne");
        }

        private void cancelClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void okClicked(object sender, RoutedEventArgs e)
        {
         
            forceValidation();
            if (!Validation.GetHasError(txtBoxImeSpomenika) && !Validation.GetHasError(txtBoxOznakaSpomenika))
            {
                //ovde ide kod ako sve validacije prodju 
                if (constructor2used)
                {
                    constructor2spomenik.Ime = _ime;
                    constructor2spomenik.Oznaka = _oznaka;
                    var currentSpomenik = constructor2spomenik;
                    int index = MainWindow.Spomenici.IndexOf(currentSpomenik);
                    MainWindow.Spomenici.Remove(currentSpomenik);
                    MainWindow.Spomenici.Insert(index, currentSpomenik);
                    this.Close();
                }
                else
                {
                    Spomenik s = new Spomenik(_oznaka, _ime, _opis);
                    MainWindow.Spomenici.Add(s);
                    this.Close();
                }
                
            }
        }
        private void forceValidation()
        {
            txtBoxImeSpomenika.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtBoxOznakaSpomenika.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }
    }
}
