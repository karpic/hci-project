using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MapaPrirodnihSpomenika.Model
{
    public class Spomenik
    {
        private String _oznaka { get; set; }
        private String _ime { get; set; }
        private String _opis { get; set; }
        private Tip _tip { get; set; }
        private String _klima { get; set; }
        //kako ikonicu sacuvati
        private String _ikonicaPutanja { get; set; }
        private Boolean _ekoUgorzen { get; set; }
        private Boolean _naseljen { get; set; }
        private double _prihod { get; set; }
        private DateTime _datum { get; set; }
        private List<Tag> _tagovi { get; set; }

        public Spomenik(String oznaka, String ime, String opis, Tip tip, String klima, String ikonicaPutanja, Boolean ekoUgorzen, Boolean naseljen, double prihod, DateTime datum, List<Tag> tagovi)
        {
            this._oznaka = oznaka;
            this._ime = ime;
            this._opis = opis;
            this._tip = tip;
            this._klima = klima;
            this._ikonicaPutanja = ikonicaPutanja;
            this._ekoUgorzen = ekoUgorzen;
            this._naseljen = naseljen;
            this._prihod = prihod;
            this._datum = datum;
            this._tagovi = tagovi;
        }
        public Spomenik(String oznaka, String ime, String opis)
        {
            this._oznaka = oznaka;
            this._ime = ime;
            this._opis = opis;
        }
    }
}
