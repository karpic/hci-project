using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapaPrirodnihSpomenika.Model
{
    
    public class ListContainer
    {
        public ObservableCollection<Spomenik> Spomenici
        {
            get;
            set;
        }
        public ObservableCollection<Tip> Tipovi
        {
            get;
            set;
        }
        public ObservableCollection<Tag> Tagovi
        {
            get;
            set;
        }
        public ListContainer()
        {
            Spomenici = new ObservableCollection<Spomenik>();
            Tipovi = new ObservableCollection<Tip>();
            Tagovi = new ObservableCollection<Tag>();
        }
        
    }
}
