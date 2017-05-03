using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapaPrirodnihSpomenika.Model
{
    [Serializable]
    public class ListContainer
    {
        public ObservableCollection<Spomenik> spomenici
        {
            get;
            set;
        }
        public ObservableCollection<Tip> tipovi
        {
            get;
            set;
        }
        public ObservableCollection<Tag> tagovi
        {
            get;
            set;
        }
        public ListContainer()
        {
            spomenici = new ObservableCollection<Spomenik>();
            tipovi = new ObservableCollection<Tip>();
            tagovi = new ObservableCollection<Tag>();
        }
    }
}
