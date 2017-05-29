using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MapaPrirodnihSpomenika.Model
{
    public class CanvasIconContainer
    {
        [XmlElement]
        public ObservableCollection<CanvasIcon> Ikonice
        {
            get;
            set;
        }

        public CanvasIconContainer()
        {
            Ikonice = new ObservableCollection<CanvasIcon>();
        }
        
    }
}
