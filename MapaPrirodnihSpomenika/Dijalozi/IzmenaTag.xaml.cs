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
    /// Interaction logic for IzmenaTag.xaml
    /// </summary>
    public partial class IzmenaTag : Window, INotifyPropertyChanged
    {
        private string _oznaka;

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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public IzmenaTag()
        {
            InitializeComponent();
            this.DataContext = this;
        }

       

        private void cancelClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void okClicked(object sender, RoutedEventArgs e)
        {
            forceValidation();
        }
        private void forceValidation()
        {
            txtBoxOznaka.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }
    }
}
