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
    /// Interaction logic for IzmenaTipSpomenika.xaml
    /// </summary>
    public partial class IzmenaTipSpomenika : Window, INotifyPropertyChanged
    {
        private string _oznaka;
        private string _ime;
        public string Ime_tipa
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

        public string Oznaka_tipa
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
        public IzmenaTipSpomenika()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void cancelClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            forceValidation();
        }
        private void forceValidation()
        {
           txtBoxOznaka.GetBindingExpression(TextBox.TextProperty).UpdateSource();
           textBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }
    }
}
