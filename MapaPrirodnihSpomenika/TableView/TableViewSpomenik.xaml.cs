using MapaPrirodnihSpomenika.Model;
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

namespace MapaPrirodnihSpomenika.TableView
{
    /// <summary>
    /// Interaction logic for TableViewSpomenik.xaml
    /// </summary>
    public partial class TableViewSpomenik : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        CollectionViewSource itemSourceList;
        ICollectionView Itemlist;
        
        private string _tip;
        public string Tip
        {
            get
            {
                return _tip;
            }
            set
            {
                if (value != _tip)
                {
                    _tip = value;
                    OnPropertyChanged("Tip");
                }
            }
        }

        public TableViewSpomenik()
        {
            InitializeComponent();
            this.textBoxTip.DataContext = this;
            itemSourceList = new CollectionViewSource() { Source = MainWindow.Spomenici };

            
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            Itemlist = itemSourceList.View;
            var yourCostumFilter = new Predicate<object>(item => ((Spomenik)item).Tip.Ime.Equals(Tip));
            
            Itemlist.Filter = yourCostumFilter;
            
            grdViewSpomenik.ItemsSource = Itemlist;
        }
    }
}
