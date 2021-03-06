﻿using MapaPrirodnihSpomenika.Dijalozi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MapaPrirodnihSpomenika.helpSubsystem.helpSubsystemTip
{
    class HelpProviderTip
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
            DependencyProperty.RegisterAttached("HelpKeyTip", typeof(string), typeof(HelpProvider), new PropertyMetadata("index", HelpKey));
        private static void HelpKey(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //NOOP
        }

        public static void ShowHelp(string key, IzmenaTipSpomenika originator)
        {
            HelpViewerTip hh = new HelpViewerTip(key, originator);
            hh.Show();
        }
    }
}
