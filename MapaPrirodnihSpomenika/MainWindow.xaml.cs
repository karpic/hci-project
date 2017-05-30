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
using System.Windows.Markup;
using MapaPrirodnihSpomenika.helpSubsystem.helpSubsystemMainWindow;
using System.Diagnostics;

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
        private CanvasIconContainer canvasIconContainer;
        private String _putanja;
        public MainWindow()
        { 
            InitializeComponent();
            this.DataContext = this;
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = new BitmapImage(new Uri(@"C:\Users\Arsenije\Documents\Faks\hci\project\MapaPrirodnihSpomenika\MapaPrirodnihSpomenika\bin\Debug\map.jpg", UriKind.Relative));
            myCanvas.Background = imageBrush;
            Spomenici = new ObservableCollection<Spomenik>();
            Tipovi = new ObservableCollection<Tip>();
            Tagovi = new ObservableCollection<Tag>();
            container = new ListContainer();
            canvasIconContainer = new CanvasIconContainer();
            deserijalizuj();
            deserializeMyCanvas();
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
            serializeMyCanvas();
            this.Close();
        }

        private void okClicked(object sender, RoutedEventArgs e)
        {
            Spomenik selectedSpomenik = (Spomenik)treeViewSpomenici.SelectedItem;
            if(selectedSpomenik != null)
            {
                IzmenaSpomenik iz = new IzmenaSpomenik(selectedSpomenik);
                iz.Show();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Nije izabran nijedan spomenik.");
            }
            
        }

        private void izmeniTipClicked(object sender, RoutedEventArgs e)
        {
            Tip selectedTip = (Tip)treeTipovi.SelectedItem;
            if(selectedTip != null)
            {
                IzmenaTipSpomenika iz = new IzmenaTipSpomenika(selectedTip);
                iz.Show();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Nije izabran nijedan tip spomenika.");
            }
        }

        private void izmeniTagClicked(object sender, RoutedEventArgs e)
        {
            Tag selectedTag = (Tag)treeViewTagovi.SelectedItem;
            if(selectedTag != null)
            {
                IzmenaTag iz = new IzmenaTag(selectedTag);
                iz.Show();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Nije izabrana nijedna etiketa spomenika.");
            }
            
        }

        private void obrisiSpomenikClicked(object sender, RoutedEventArgs e)
        {
            Spomenik spomenikToDelete = (Spomenik)treeViewSpomenici.SelectedItem;

            
            //Uri spomenikUri = new Uri(spomenikToDelete.Ikonica);
            //string spomenikToDeletePath = spomenikUri.AbsolutePath;
            if (spomenikToDelete != null)
            {
                string spomenikToDeletePathRelative = spomenikToDelete.Ikonica;
                string spomenikToDeletePathApsolute = System.IO.Path.GetFullPath(spomenikToDeletePathRelative);
                string spomenikToDeleteFileName = System.IO.Path.GetFileName(spomenikToDeletePathApsolute);
                Spomenici.Remove(spomenikToDelete);
                Image imgToDeleteFromCanvas = null;
                foreach (Image img in myCanvas.Children)
                {
                    BitmapImage source = (BitmapImage)img.Source;
                    Uri u = source.UriSource;
                    string path = u.AbsolutePath;
                    string pathFileName = System.IO.Path.GetFileName(path);
                    if (pathFileName.Equals(spomenikToDeleteFileName))
                    {
                        //myCanvas.Children.Remove(img);
                        imgToDeleteFromCanvas = img;

                    }
                }
                myCanvas.Children.Remove(imgToDeleteFromCanvas);
                foreach(CanvasIcon icon in canvasIconContainer.Ikonice.ToList())
                {
                    if (spomenikToDelete.Ikonica.Equals(icon.Img))
                    {
                        canvasIconContainer.Ikonice.Remove(icon);
                    }
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Nije izabran nijedan spomenik iz liste spomenika.");
            }
        }

        private void obrisiTipClicked(object sender, RoutedEventArgs e)
        {
            Tip tipToDelete = (Tip)treeTipovi.SelectedItem;
            if(tipToDelete != null)
            {
                if (System.Windows.Forms.MessageBox.Show("Svi spomenici ovog tipa ce takodje biti obirsani.", "Da li ste sigurni?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {


                    foreach (Spomenik s in Spomenici.ToList())
                    {
                        if (tipToDelete.Oznaka.Equals(s.Tip.Oznaka))
                        {
                            Spomenici.Remove(s);
                        }
                    }

                    Tipovi.Remove(tipToDelete);
                }
                else
                {
                    //do nothing
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Nije izabran nijedan tip spomenika iz liste tipova.");
            }
            
           
        }

        private void obrisiTagClicked(object sender, RoutedEventArgs e)
        {
            Tag tagToDelete = (Tag)treeViewTagovi.SelectedItem;
            if(tagToDelete != null)
            {
                Tagovi.Remove(tagToDelete);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Nije izabrana nijedna etiketa spomenika iz liste etiketa.");
            }
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
            serializeMyCanvas();
        }
        //otvori dugme iz menija
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            //ListContainer container = null;
            deserijalizuj();
            deserializeMyCanvas();
        }

        private void onCloseAction(object sender, EventArgs e)
        {
            seriajalizuj();
            serializeMyCanvas();
        }

        private void spomeniciTreeView_mouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                // Get the dragged ListViewItem
                System.Windows.Controls.TreeView treeView = sender as System.Windows.Controls.TreeView;
                TreeViewItem treeViewItem =
                    FindAncestor<TreeViewItem>((DependencyObject)e.OriginalSource);

                // Find the data behind the ListViewItem
                Spomenik spomenik = (Spomenik)treeView.ItemContainerGenerator.
                    ItemFromContainer(treeViewItem);

                // Initialize the drag & drop operation
                System.Windows.DataObject dragData = new System.Windows.DataObject("myFormat", spomenik);
                DragDrop.DoDragDrop(treeViewItem, dragData, System.Windows.DragDropEffects.Move);
                
            }
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

        

        private void myCanvas_Drop(object sender, System.Windows.DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                Spomenik spomenik = e.Data.GetData("myFormat") as Spomenik;
                //BitmapImage spomenikIcon = new BitmapImage(new Uri(spomenik.Ikonica, UriKind.Relative));
                //myCanvas.Children.Add(spomenikIcon);
                if(spomenik.NaMapi == false)
                {
                    Image spomenikIcon = new Image();
                    BitmapImage source = new BitmapImage(new Uri(spomenik.Ikonica, UriKind.Absolute));
                    spomenikIcon.Source = source;
                    spomenikIcon.Width = 30;
                    spomenikIcon.Height = 30;
                    Point currentMousePosition = e.GetPosition(this.myCanvas);
                    spomenik.NaMapi = true;

                    CanvasIcon canvasIcon = new CanvasIcon(spomenik.Ikonica, currentMousePosition.X, currentMousePosition.Y);
                    canvasIconContainer.Ikonice.Add(canvasIcon);

                    myCanvas.Children.Add(spomenikIcon);
                    Canvas.SetLeft(spomenikIcon, currentMousePosition.X);
                    Canvas.SetTop(spomenikIcon, currentMousePosition.Y);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Ovaj spomenik je vec dodan na mapu!");
                }
                
            }
        }

        private void myCanvas_DragEnter(object sender, System.Windows.DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || sender == e.Source)
            {
                e.Effects = System.Windows.DragDropEffects.None;
            }
        }

        private void serializeMyCanvas()
        {
            XmlSerializer mySerializer = new
            XmlSerializer(typeof(CanvasIconContainer));
            // To write to a file, create a StreamWriter object.  
            StreamWriter myWriter = new StreamWriter("myCanvas.xml");
            mySerializer.Serialize(myWriter, canvasIconContainer);
            myWriter.Close();


            //FileStream fs = File.Open("myCanvas.txt", FileMode.Create);
            //XamlWriter.Save(myCanvas, fs);
            //fs.Close();
        }
        private void deserializeMyCanvas()
        {
            string path = "myCanvas.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(CanvasIconContainer));

            StreamReader reader = new StreamReader(path);
            CanvasIconContainer canContainer = (CanvasIconContainer)serializer.Deserialize(reader);

            reader.Close();

            myCanvas.Children.Clear();
            canvasIconContainer.Ikonice.Clear();
            foreach(CanvasIcon ci in canContainer.Ikonice)
            {
                Image spomenikIcon = new Image();
                BitmapImage source = new BitmapImage(new Uri(ci.Img, UriKind.Absolute));
                spomenikIcon.Source = source;
                spomenikIcon.Width = 30;
                spomenikIcon.Height = 30;

                myCanvas.Children.Add(spomenikIcon);
                Canvas.SetLeft(spomenikIcon, ci.XCoord);
                Canvas.SetTop(spomenikIcon, ci.YXCoord);

                CanvasIcon canvasIcon = new CanvasIcon(ci.Img, ci.XCoord, ci.YXCoord);
                canvasIconContainer.Ikonice.Add(canvasIcon);
            }

            //this.myCanvas = canvasContainer.Can;
            //    FileStream fs = File.Open("myCanvas.txt", FileMode.Open);
            //    Canvas savedCanvas = XamlReader.Load(fs) as Canvas;
            //    RegisterName("myCanvas", savedCanvas);
            //    fs.Close();
            //    //this.myCanvas.Children.Add(savedCanvas);
            //    myCanvas = savedCanvas;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[0]);
            IInputElement focusedControl = FocusManager.GetFocusedElement(this);
            if (focusedControl is DependencyObject)
            {
                string str = HelpProviderMainWindow.GetHelpKey((DependencyObject)focusedControl);
                HelpProviderMainWindow.ShowHelp(str, this);
            }
        }

        public void doThings(string param)
        {
            Title = param;
        }
        //clear map clicked
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            myCanvas.Children.Clear();
            canvasIconContainer.Ikonice.Clear();
        }
        //tutorijal window 
        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            string filePath = @"C:\Users\Arsenije\Documents\Faks\hci\project\MapaPrirodnihSpomenika\MapaPrirodnihSpomenika\tutorial\tutorial.html";
            Process.Start(filePath);
        }
    }
}
