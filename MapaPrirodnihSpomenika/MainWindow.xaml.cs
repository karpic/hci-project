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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MapaPrirodnihSpomenika.Dijalozi;
using MapaPrirodnihSpomenika.Model;
using System.Collections.ObjectModel;
using MapaPrirodnihSpomenika.TableView;
using System.ComponentModel;
using Microsoft.Win32;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;
using MapaPrirodnihSpomenika.helpSubsystem;

namespace MapaPrirodnihSpomenika
{
    [Serializable]
    public partial class MainWindow : Window
    {
        Point startPoint = new Point();
        public static ObservableCollection<Spomenik> Spomenici
        {
            set;
            get;
        }
        public static ObservableCollection<Tip> Tipovi
        {
            set;
            get;
        }
        public static ObservableCollection<Tag> Tagovi
        {
            set;
            get;
        }
        private ListContainer container;
        private String _putanja;
        public MainWindow()
        { 
            InitializeComponent();
            this.DataContext = this;
            Spomenici = new ObservableCollection<Spomenik>();
            Tipovi = new ObservableCollection<Tip>();
            Tagovi = new ObservableCollection<Tag>();
            container = new ListContainer();
            deserijalizuj();
        }
      
        public void dodajSpomenik(Spomenik s)
        {
            Spomenici.Add(s);
            
            
        }

        private void dodajSpomClicked(object sender, RoutedEventArgs e)
        {
            IzmenaSpomenik izspm = new IzmenaSpomenik();
            izspm.Show();
        }

        private void dodajEtiketuClicked(object sender, RoutedEventArgs e)
        {
            IzmenaTag it = new IzmenaTag();
            it.Show();
        }

        private void dodajTipClicked(object sender, RoutedEventArgs e)
        {
            IzmenaTipSpomenika its = new IzmenaTipSpomenika();
            its.Show();
        }

        private void noviSpomMenuClicked(object sender, RoutedEventArgs e)
        {
            IzmenaSpomenik izspm = new IzmenaSpomenik();
            izspm.Show();
        }

        private void noviTipMenuClicked(object sender, RoutedEventArgs e)
        {
            IzmenaTipSpomenika its = new IzmenaTipSpomenika();
            its.Show();
        }

        private void novaEtiketaMenuClicked(object sender, RoutedEventArgs e)
        {
            IzmenaTag it = new IzmenaTag();
            it.Show();
        }

        private void izadjiMenuClicked(object sender, RoutedEventArgs e)
        {
            seriajalizuj();
            this.Close();
        }

        private void okClicked(object sender, RoutedEventArgs e)
        {
            Spomenik selectedSpomenik = (Spomenik)treeViewSpomenici.SelectedItem;
            IzmenaSpomenik iz = new IzmenaSpomenik(selectedSpomenik);
            iz.Show();
        }

        private void izmeniTipClicked(object sender, RoutedEventArgs e)
        {
            Tip selectedTip = (Tip)treeTipovi.SelectedItem;
            IzmenaTipSpomenika iz = new IzmenaTipSpomenika(selectedTip);
            iz.Show();
        }

        private void izmeniTagClicked(object sender, RoutedEventArgs e)
        {
            Tag selectedTag = (Tag)treeViewTagovi.SelectedItem;
            IzmenaTag iz = new IzmenaTag(selectedTag);
            iz.Show();
        }

        private void obrisiSpomenikClicked(object sender, RoutedEventArgs e)
        {
            Spomenik spomenikToDelete = (Spomenik)treeViewSpomenici.SelectedItem;
            Spomenici.Remove(spomenikToDelete);
        }

        private void obrisiTipClicked(object sender, RoutedEventArgs e)
        {
            Tip tipToDelete = (Tip)treeTipovi.SelectedItem;
            Tipovi.Remove(tipToDelete);
        }

        private void obrisiTagClicked(object sender, RoutedEventArgs e)
        {
            Tag tagToDelete = (Tag)treeViewTagovi.SelectedItem;
            Tagovi.Remove(tagToDelete);
        }

        private void sviSpomeniciClicked(object sender, RoutedEventArgs e)
        {
            TableViewSpomenik tvs = new TableViewSpomenik();
            tvs.DataContext = this;
            tvs.Show();
        }

        private void sviTipoviClicked(object sender, RoutedEventArgs e)
        {
            TableViewTip tvt = new TableViewTip();
            tvt.DataContext = this;
            tvt.Show();
        }

        private void sviTagoviClicked(object sender, RoutedEventArgs e)
        {
            TableViewTag tvt = new TableViewTag();
            tvt.DataContext = this;
            tvt.Show();
        }
        public void seriajalizuj()
        {
            container.Tipovi = Tipovi;
            container.Tagovi = Tagovi;
            container.Spomenici = Spomenici;

            XmlSerializer mySerializer = new
            XmlSerializer(typeof(ListContainer));
            // To write to a file, create a StreamWriter object.  
            StreamWriter myWriter = new StreamWriter("listContainerSerialized.xml");
            mySerializer.Serialize(myWriter, container);
            myWriter.Close();
        }
        public void deserijalizuj()
        {
            string path = "listContainerSerialized.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(ListContainer));

            StreamReader reader = new StreamReader(path);
            container = (ListContainer)serializer.Deserialize(reader);
            reader.Close();

            Tipovi = container.Tipovi;
            Tagovi = container.Tagovi;
            Spomenici = container.Spomenici;

            treeViewSpomenici.ItemsSource = Spomenici;
            treeViewTagovi.ItemsSource = Tagovi;
            treeTipovi.ItemsSource = Tipovi;
        }
        //sacuvaj dugme iz menija
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            seriajalizuj();
        }
        //otvori dugme iz menija
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            //ListContainer container = null;
            deserijalizuj();
        }

        private void onCloseAction(object sender, EventArgs e)
        {
            seriajalizuj();
        }

        private void spomeniciTreeView_mouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //Point mousePos = e.GetPosition(null);
            //Vector diff = startPoint - mousePos;

            //if (e.LeftButton == MouseButtonState.Pressed &&
            //    (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
            //    Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            //{
            //    // Get the dragged ListViewItem
            //    TreeView treeView = sender as System.Windows.Controls.TreeView;
            //    TreeViewItem treeViewItem =
            //        FindAncestor<TreeViewItem>((DependencyObject)e.OriginalSource);

            //    // Find the data behind the ListViewItem
            //    Spomenik spomenik = (Spomenik)treeView.ItemContainerGenerator.
            //        ItemFromContainer(treeViewItem);

            //    // Initialize the drag & drop operation
            //    DataObject dragData = new DataObject("myFormat", spomenik);
            //    DragDrop.DoDragDrop(treeViewItem, dragData, System.Windows.DragDropEffects.Move);
            //    Console.WriteLine(spomenik.Ime);
            //}
        }
        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }

        private void spomeniciTreeView_previewLeftMouseDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        //private void map_dragEnter(object sender, DragEventArgs e)
        //{
        //    if (!e.Data.GetDataPresent("myFormat") || sender == e.Source)
        //    {
        //        e.Effects = DragDropEffects.None;
        //    }
        //}

        //private void map_drop(object sender, DragEventArgs e)
        //{
        //    if (e.Data.GetDataPresent("myFormat"))
        //    {
        //        Spomenik spomenik = e.Data.GetData("myFormat") as Spomenik;
        //        BitmapImage spomenikIcon = new BitmapImage(new Uri(spomenik.Ikonica, UriKind.Relative));


        //    }
        //}

        
    }
}
