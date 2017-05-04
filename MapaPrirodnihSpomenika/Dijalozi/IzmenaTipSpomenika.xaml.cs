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
    /// Interaction logic for IzmenaTipSpomenika.xaml
    /// </summary>
    public partial class IzmenaTipSpomenika : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        Boolean constructor2used;
        Tip constructor2tip;
        private string _ime;
        public string Ime_tipa
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

        
        private string _oznaka;
        public string Oznaka_tipa
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

        private string _opis;
        public string Opis_tipa
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
        public IzmenaTipSpomenika()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        public IzmenaTipSpomenika(Tip t)
        {
            InitializeComponent();
            this.DataContext = this;
            constructor2used = true;
            constructor2tip = t;
            Ime_tipa = t.Ime;
            Opis_tipa = t.Opis;
            Oznaka_tipa = t.Oznaka;
            Putanja = t.Putanja;
        }


        private void cancelClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            forceValidation();
            if (!Validation.GetHasError(txtBoxOznaka) && !Validation.GetHasError(textBox))
            {
                //ovde ide kod ako sve validacije prodju 
                if (constructor2used)
                {
                    constructor2tip.Ime = Ime_tipa;
                    constructor2tip.Oznaka = Oznaka_tipa;
                    constructor2tip.Opis = Opis_tipa;
                    constructor2tip.Putanja = Putanja;
                    var currentTip = constructor2tip;
                    int index = MainWindow.Tipovi.IndexOf(currentTip);
                    MainWindow.Tipovi.Remove(currentTip);
                    MainWindow.Tipovi.Insert(index, currentTip);
                    this.Close();
                }
                else
                {
                    Tip t = new Tip(_oznaka, _ime, _opis, _putanja);
                    MainWindow.Tipovi.Add(t);

                    this.Close();
                }
            }
        }
        private void forceValidation()
        {
           txtBoxOznaka.GetBindingExpression(TextBox.TextProperty).UpdateSource();
           textBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }

        private void izaberiteIkonicuClicked(object sender, RoutedEventArgs e)
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
    }
}
