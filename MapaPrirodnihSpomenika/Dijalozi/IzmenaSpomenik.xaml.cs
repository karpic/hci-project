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
using System.Collections.ObjectModel;
using Microsoft.Win32;
using MapaPrirodnihSpomenika.helpSubsystem;

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
        public ObservableCollection<Tip> Tipovi
        {
            set;
            get;
        }
        public ObservableCollection<Tag> Tagovi
        {
            set;
            get;
        }
        private Boolean ikonicaUneta;
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
        private string _putanja;
        public string Putanja
        {
            get
            {
                return _putanja;
            }
            set
            {
                if (value != _putanja)
                {
                    _putanja = value;
                    OnPropertyChanged("Putanja");
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
                    OnPropertyChanged("Opis");
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
                    OnPropertyChanged("Tip");
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
                    OnPropertyChanged("Klima");
                }
            }
        }
        private String _eko_ugrozen;
        public String Eko_ugrozen
        {
            get
            {
                return _eko_ugrozen;
            }
            set
            {
                if (value != _eko_ugrozen)
                {
                    _eko_ugrozen = value;
                    OnPropertyChanged("Eko_ugrozen");
                }
            }
        }
        private String _naseljen;
        public String Naseljen
        {
            get
            {
                return _naseljen;
            }
            set
            {
                if (value != _naseljen)
                {
                    _naseljen = value;
                    OnPropertyChanged("Naseljen");
                }
            }
        }
        private String _status;
        public String Status
        {
            get
            {
                return _status;
            }
            set
            {
                if (value != _status)
                {
                    _status = value;
                    OnPropertyChanged("Status");
                }
            }
        }
        private int _prihod;
        public int Prihod
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
        private DateTime _datum;
        public DateTime Datum
        {
            get
            {
                return _datum;
            }
            set
            {
                if (value != _datum)
                {
                    _datum = value;
                    OnPropertyChanged("Datum");
                }
            }
        }

        
        public IzmenaSpomenik(Spomenik s)
        {
            InitializeComponent();
            this.DataContext = this;
            constructor2used = true;
            constructor2spomenik = s;
            
            Oznaka = s.Oznaka;
            Ime = s.Ime;
            Opis = s.Opis;
            //hendlovanje tipa...
            Tipovi = MainWindow.Tipovi;
            Tagovi = MainWindow.Tagovi;
            comboBoxTip.ItemsSource = Tipovi;
            listBoxEtikete.ItemsSource = Tagovi;
            int idx = comboBoxTip.Items.IndexOf(s.Tip);
            comboBoxTip.SelectedIndex = idx;
            //hendlovanje selektovanih etiketa
            foreach(Tag item in listBoxEtikete.Items)
            {
                if (Tagovi.Contains(item))
                {
                    int index = listBoxEtikete.Items.IndexOf(item);
                    listBoxEtikete.SelectedIndex = index;
                }
            }
            this.comboBoxKlima.Items.Add("Polarna");
            this.comboBoxKlima.Items.Add("Kontinentalna");
            this.comboBoxKlima.Items.Add("Umereno-kontinentalna");
            this.comboBoxKlima.Items.Add("Pustinjska");
            this.comboBoxKlima.Items.Add("Suptropska");
            this.comboBoxKlima.Items.Add("Tropska");
            Klima = s.Klima;
            this.comboBoxKlima.SelectedIndex = comboBoxKlima.Items.IndexOf(Klima);
            if (s.Ugrozen)
            {
                Eko_ugrozen = "Da";
            }
            else
            {
                Eko_ugrozen = "Ne";
            }
            this.comboBoxEkoUgorzen.Items.Add("Da");
            this.comboBoxEkoUgorzen.Items.Add("Ne");
            this.comboBoxEkoUgorzen.SelectedIndex = comboBoxEkoUgorzen.Items.IndexOf(Eko_ugrozen);
            if (s.Naseljen)
            {
                Naseljen = "Da";
            }
            else
            {
                Naseljen = "Ne";
            }
            this.comboBoxNaselje.Items.Add("Da");
            this.comboBoxNaselje.Items.Add("Ne");
            this.comboBoxNaselje.SelectedIndex = comboBoxNaselje.Items.IndexOf(Naseljen);
            Status = s.Turisticki_status;
            this.comboBoxTurStatus.Items.Add("Eksploatisan");
            this.comboBoxTurStatus.Items.Add("Dostupan");
            this.comboBoxTurStatus.Items.Add("Nedostupan");
            this.comboBoxTurStatus.SelectedIndex = comboBoxTurStatus.Items.IndexOf(Status);
            Prihod = s.Prihod;
            Datum = s.Datum;
            Putanja = s.Ikonica;
        }
        public IzmenaSpomenik()
        {
            InitializeComponent();
            this.DataContext = this;
            Tipovi = MainWindow.Tipovi;
            Tagovi = MainWindow.Tagovi;
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
                    constructor2spomenik.Ime = Ime;
                    constructor2spomenik.Oznaka = Oznaka;
                    constructor2spomenik.Opis = Opis;
                    constructor2spomenik.Klima = Klima;
                    if (Eko_ugrozen.Equals("Da"))
                    {
                        constructor2spomenik.Ugrozen = true;
                    }
                    else
                    {
                        constructor2spomenik.Ugrozen = false;
                    }
                    if (Naseljen.Equals("Da"))
                    {
                        constructor2spomenik.Naseljen = true;
                    }
                    else
                    {
                        constructor2spomenik.Naseljen = false;
                    }
                    constructor2spomenik.Turisticki_status = Status;
                    constructor2spomenik.Prihod = Prihod;
                    constructor2spomenik.Datum = Datum;
                    constructor2spomenik.Ikonica = Putanja;
                    constructor2spomenik.Tip = getTip(Tip);
                    constructor2spomenik.etiketeSpomenika = Tagovi;
                    var currentSpomenik = constructor2spomenik;
                    int index = MainWindow.Spomenici.IndexOf(currentSpomenik);
                    MainWindow.Spomenici.Remove(currentSpomenik);
                    MainWindow.Spomenici.Insert(index, currentSpomenik);
                    this.Close();
                }
                else
                {
                    String oznaka = Oznaka;
                    String ime = Ime;
                    String opis = Opis;

                    Tagovi = getTagsFromListBox();
                    String klima = Klima;
                    int prihod = Prihod;
                    Boolean ugrozen;
                    if (Eko_ugrozen.Equals("Da"))
                    {
                        ugrozen = true;
                    }
                    else
                    {
                        ugrozen = false;
                    }
                    Boolean naseljen;
                    if (Naseljen.Equals("Da"))
                    {
                        naseljen = true;
                    }
                    else
                    {
                        naseljen = false;
                    }
                    String status = Status;
                    String putanja = Putanja;
                    DateTime datum = Datum;
                    Tip tipSpomenika = getTip(Tip);
                    if(Putanja == null)
                    {
                        putanja = tipSpomenika.Putanja;
                    }
                    Spomenik sp = new Spomenik(oznaka, ime, opis, tipSpomenika,  klima, putanja, ugrozen, naseljen, status, prihod, datum, Tagovi, false);
                    MainWindow.Spomenici.Add(sp);
                    this.Close();
                }
                
            }
        }
        public Tip getTip(String oznakaTrazenog)
        {
            Tip retVal = null;
            foreach(Tip t in MainWindow.Tipovi)
            {
                if (t.Oznaka.Equals(oznakaTrazenog))
                {
                    retVal = t;
                }
            }
            return retVal;
        }
        public ObservableCollection<Tag> getTagsFromListBox()
        {
            ObservableCollection<Tag> retVal = null;
            foreach(Tag t in listBoxEtikete.SelectedItems)
            {
                Tagovi.Add(t);
            }
            return retVal;
        }
        private void forceValidation()
        {
            txtBoxImeSpomenika.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtBoxOznakaSpomenika.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }

        private void izaberiIkonicuClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Windows.Forms.OpenFileDialog open = new System.Windows.Forms.OpenFileDialog(); open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Putanja = open.FileName;
                }
            }
            catch (Exception)
            {
                throw new ApplicationException("Failed loading image");
            }
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[0]);
            IInputElement focusedControl = FocusManager.GetFocusedElement(this);
            if (focusedControl is DependencyObject)
            {
                string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                HelpProvider.ShowHelp(str, this);
            }
        }

        public void doThings(string param)
        {
            Title = param;
        }
    }
}
