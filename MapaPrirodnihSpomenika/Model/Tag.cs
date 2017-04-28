using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MapaPrirodnihSpomenika.Model
{
    public class Tag
    {
        private String _oznaka;
        //private Color _boja;
        private String _opis;

        public string Opis
        {
            get
            {
                return _opis;
            }

            set
            {
                _opis = value;
            }
        }

        public string Oznaka
        {
            get
            {
                return _oznaka;
            }

            set
            {
                _oznaka = value;
            }
        }

        public Tag(String oznaka, String opis)
        {
            this._oznaka = oznaka;
            //this._boja = boja;
            this._opis = opis;
        }
    }

}
