using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MapaPrirodnihSpomenika.Model
{
    public class Tag : INotifyPropertyChanged
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
        private Color _boja;
        public Color Boja
        {
            get
            {
                return _boja;
            }
            set
            {
                if (_boja != value)
                {
                    _boja = value;
                    OnPropertyChanged("Boja");
                }
            }
        }

        public Tag(String oznaka, String opis, Color boja)
        {
            this._oznaka = oznaka;
            this._boja = boja;
            this._opis = opis;
        }
        public Tag()
        {

        }
    }

}
