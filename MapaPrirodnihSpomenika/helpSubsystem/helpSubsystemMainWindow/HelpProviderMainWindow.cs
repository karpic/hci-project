using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MapaPrirodnihSpomenika.helpSubsystem.helpSubsystemMainWindow
{
    class HelpProviderMainWindow
    {
        public static string GetHelpKey(DependencyObject obj)
        {
            return obj.GetValue(HelpKeyProperty) as string;
        }

        public static void SetHelpKey(DependencyObject obj, string value)
        {
            obj.SetValue(HelpKeyProperty, value);
        }

        public static readonly DependencyProperty HelpKeyProperty =
            DependencyProperty.RegisterAttached("HelpKeyMain", typeof(string), typeof(HelpProvider), new PropertyMetadata("index", HelpKey));
        private static void HelpKey(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //NOOP
        }

        public static void ShowHelp(string key, MainWindow originator)
        {
            HelpViewerMainWindow hh = new HelpViewerMainWindow(key, originator);
            hh.Show();
        }
    }
}
