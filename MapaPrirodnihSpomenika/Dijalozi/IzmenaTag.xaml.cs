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
using MapaPrirodnihSpomenika.Model;
namespace MapaPrirodnihSpomenika.Dijalozi
{
    /// <summary>
    /// Interaction logic for IzmenaTag.xaml
    /// </summary>
    public partial class IzmenaTag : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        Boolean constructor2used;
        Tag constructor2tag;
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

        private String _opis;
        public String Opis
        {
            get
            {
                return _opis;
            }
            set
            {
                if (value != _opis)
                {
                    _opis = value;
                    OnPropertyChanged("Opis");
                }
            }
        }

        public IzmenaTag()
        {
            InitializeComponent();
            this.DataContext = this;
            constructor2used = false;
        }
        public IzmenaTag(Tag t)
        {
            InitializeComponent();
            this.DataContext = this;
            constructor2used = true;
            constructor2tag = t;
            Oznaka = t.Oznaka;
            Opis = t.Opis;

        }
       

        private void cancelClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void okClicked(object sender, RoutedEventArgs e)
        {
            forceValidation();
            if (!Validation.GetHasError(txtBoxOznaka))
            {
                //ovde ide kod ako sve validacije prodju 
                if (constructor2used)
                {
                    constructor2tag.Opis = Opis;
                    constructor2tag.Oznaka = Oznaka;
                    var currentTag = constructor2tag;
                    int index = MainWindow.Tagovi.IndexOf(currentTag);
                    MainWindow.Tagovi.Remove(currentTag);
                    MainWindow.Tagovi.Insert(index, currentTag);
                    this.Close();
                }
                else
                {
                    Tag t = new Tag(_oznaka, _opis);

                    MainWindow.Tagovi.Add(t);
                    this.Close();
                }
            }
        }
        private void forceValidation()
        {
            txtBoxOznaka.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }
    }
}
