using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MapaPrirodnihSpomenika.Model
{
    public class Spomenik : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private String _ime;
        public String Ime
        {
            get
            {
                return _ime;
            }
            set
            {
                if (_ime != value)
                {
                    _ime = value;
                    OnPropertyChanged("Ime");
                }
            }
        }

        private String _oznaka;
        public string Oznaka
        {
            get
            {
                return _oznaka;
            }
            set
            {
                if (_oznaka != value)
                {
                    _oznaka = value;
                    OnPropertyChanged("Oznaka");
                }
            }
        }


        private String _opis;
        public string Opis
        {
            get
            {
                return _opis;
            }
            set
            {
                if (_opis != value)
                {
                    _opis = value;
                    OnPropertyChanged("Opis");
                }
            }
        }
        private Tip _tip;
        public Tip Tip
        {
            get
            {
                return _tip;
            }
            set
            {
                if (_tip != value)
                {
                    _tip = value;
                    OnPropertyChanged("Tip");
                }
            }
        }
        private String _klima;
        public String Klima
        {
            get
            {
                return _klima;
            }
            set
            {
                if (_klima != value)
                {
                    _klima = value;
                    OnPropertyChanged("Tip");
                }
            }
        }
        private String _ikonica_putanja;
        public String Ikonica
        {
            get
            {
                return _ikonica_putanja;
            }
            set
            {
                if (_ikonica_putanja != value)
                {
                    _ikonica_putanja = value;
                    OnPropertyChanged("Ikonica");
                }
            }
        }
        private Boolean _ugrozen;
        public Boolean Ugrozen
        {
            get
            {
                return _ugrozen;
            }
            set
            {
                if (_ugrozen != value)
                {
                    _ugrozen = value;
                    OnPropertyChanged("Ugrozen");
                }
            }
        }
        private Boolean _naseljen;
        public Boolean Naseljen
        {
            get
            {
                return _naseljen;
            }
            set
            {
                if (_naseljen != value)
                {
                    _naseljen = value;
                    OnPropertyChanged("Naseljen");
                }
            }
        }
        private String _turisticki_status;
        public String Turisticki_status
        {
            get
            {
                return _turisticki_status;
            }
            set
            {
                if (_turisticki_status != value)
                {
                    _turisticki_status = value;
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
                if (_prihod != value)
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
                if (_datum != value)
                {
                    _datum = value;
                    OnPropertyChanged("Datum");
                }
            }
        }
        public Spomenik(String oznaka, String ime, String opis, String klima, String ikonica, Boolean ugrozen, Boolean naseljen, String tur_status, int prihod, DateTime datum)
        {
            this._oznaka = oznaka;
            this._ime = ime;
            this._opis = opis;
            this._klima = klima;
            this._ikonica_putanja = ikonica;
            this._ugrozen = ugrozen;
            this._naseljen = naseljen;
            this._turisticki_status = tur_status;
            this._prihod = prihod;
            this._datum = datum;
            
        }
        //test konstruktor
        public Spomenik(String oznaka, String ime, String opis)
        {
            this._oznaka = oznaka;
            this._ime = ime;
            this._opis = opis;
        }
    }
}
