using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MapaPrirodnihSpomenika.Dijalozi
{
    /// <summary>
    /// Interaction logic for IzmenaSpomenik.xaml
    /// </summary>
    public partial class IzmenaSpomenik : Window
    {
        List<String> klime = new List<string>();

        public IzmenaSpomenik()
        {
            InitializeComponent();
            this.comboBoxKlima.Items.Add("Polarna");
            this.comboBoxKlima.Items.Add("Kontinentalna");
            this.comboBoxKlima.Items.Add("Umereno-kontinentalna");
            this.comboBoxKlima.Items.Add("Pustinjska");
            this.comboBoxKlima.Items.Add("Suptropska");
            this.comboBoxKlima.Items.Add("Tropska");

            this.comboBoxTurStatus.Items.Add("Eksploatisan");
            this.comboBoxTurStatus.Items.Add("Dostupan");
            this.comboBoxTurStatus.Items.Add("Nedostupan");

        }

        
    }
}
