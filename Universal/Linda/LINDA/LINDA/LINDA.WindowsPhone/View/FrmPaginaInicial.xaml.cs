using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace LINDA.View
{
    public sealed partial class FrmPaginaInicial : Page
    {
        public FrmPaginaInicial()
        {
            InitializeComponent();
           // App.Current.creatDB();            
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            /*
             * System.Threading.Thread.Sleep(2000);
            App.Current.primeiroAcesso();
            if (App.Current.isPrimeiroAcesso)
            {
                NavigationService.Navigate(new Uri("/View/FrmTermosdeUso.xaml", UriKind.Relative));    
            }
            else
            {
                NavigationService.Navigate(new Uri("/View/FrmMenuInicial.xaml", UriKind.Relative));    
            }
             */

            
        }
    }
}
