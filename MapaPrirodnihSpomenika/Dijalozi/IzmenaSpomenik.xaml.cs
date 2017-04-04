using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class IzmenaSpomenik : Window, INotifyPropertyChanged
    {
        private string _ime;
        private string _oznaka;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Ime
        {
            get
            {
                return _ime;
            }
            set
            {
                if (value != _ime)
                {
                    _ime = value;
                    OnPropertyChanged("Ime");
                }
            }
        }

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
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
                if (value != _oznaka)
                {
                    _oznaka = value;
                    OnPropertyChanged("Oznaka");
                }
            }
        }

        public IzmenaSpomenik()
        {
            InitializeComponent();
            this.DataContext = this;
            this.comboBoxKlima.Items.Add("Polarna");
            this.comboBoxKlima.Items.Add("Kontinentalna");
            this.comboBoxKlima.Items.Add("Umereno-kontinentalna");
            this.comboBoxKlima.Items.Add("Pustinjska");
            this.comboBoxKlima.Items.Add("Suptropska");
            this.comboBoxKlima.Items.Add("Tropska");

            this.comboBoxTurStatus.Items.Add("Eksploatisan");
            this.comboBoxTurStatus.Items.Add("Dostupan");
            this.comboBoxTurStatus.Items.Add("Nedostupan");

            this.comboBoxEkoUgorzen.Items.Add("Da");
            this.comboBoxEkoUgorzen.Items.Add("Ne");

            this.comboBoxNaselje.Items.Add("Da");
            this.comboBoxNaselje.Items.Add("Ne");
        }

        
    }
}
