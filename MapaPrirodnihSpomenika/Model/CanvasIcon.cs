using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Serialization;

namespace MapaPrirodnihSpomenika.Model
{
    public class CanvasIcon
    {
        
        public String Img
        {
            get;
            set;
        }

        
        public double XCoord
        {
            get;
            set;
        }

        
        public double YXCoord
        {
            get;
            set;
        }
        public CanvasIcon(String img, double xCoordinate, double yCoordinate)
        {
            this.Img = img;
            this.XCoord = xCoordinate;
            this.YXCoord = yCoordinate;
        }

        public CanvasIcon()
        {

        }
    }
}
