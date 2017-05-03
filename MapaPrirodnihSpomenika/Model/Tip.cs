using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapaPrirodnihSpomenika.Model
{
    public class Tip : INotifyPropertyChanged
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
        private String _oznaka;
        public String Oznaka
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
        //Kako hendlovati ikonicu?
        private String _putanja_ikonica;
        public String Putanja
        {
            get
            {
                return _putanja_ikonica;
            }
            set
            {
                if (_putanja_ikonica != value)
                {
                    _putanja_ikonica = value;
                    OnPropertyChanged("Ime");
                }
            }
        }
        private String _opis;
        public String Opis
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


        public Tip(String oznaka, String ime, String opis, String putanja)
        {
            this._oznaka = oznaka;
            this._ime = ime;
            this._opis = opis;
            this._putanja_ikonica = putanja;
        }
    }
}
