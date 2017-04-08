using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapaPrirodnihSpomenika.Model
{
    public class Tip
    {
        private String _oznaka;
        private String _ime;
        //Kako hendlovati ikonicu?
        private String _opis;


        public Tip(String oznaka, String ime, String opis)
        {
            this._oznaka = oznaka;
            this._ime = ime;
            this._opis = opis;
        }
    }
}
