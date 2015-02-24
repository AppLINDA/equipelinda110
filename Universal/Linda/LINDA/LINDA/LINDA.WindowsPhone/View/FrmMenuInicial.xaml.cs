using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace LINDA.View
{
    public partial class FrmMenuInicial : PhoneApplicationPage
    {
        public FrmMenuInicial()
        {
            InitializeComponent();               
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/FrmTutorial.xaml", UriKind.Relative));
        }

        private void hubTileMontaPrato_MouseEnter(object sender, MouseEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/MontaPratoUtil/FrmMontaPrato.xaml", UriKind.Relative));            
        }

        private void hubTileMaratona_MouseEnter(object sender, MouseEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/FrmMaratona.xaml", UriKind.Relative));
        }

        private void hubTileCalendario_MouseEnter(object sender, MouseEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/FrmCalendario.xaml", UriKind.Relative));
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Sair do aplicativo?", "Linda", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                base.OnBackKeyPress(e);
            }
            else
                e.Cancel = true;
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            while (NavigationService.BackStack.Any())
            {
                NavigationService.RemoveBackEntry();
            }
            App.Current.Actives.usandomontaprato = false;
            base.OnNavigatedTo(e);
        }

        private void hubTileNutricionistas_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/FrmNutricionista.xaml", UriKind.Relative));
        }

        private void hubTileGrafico_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/GraficoUtil/FrmGraficoLINDA.xaml", UriKind.Relative));
        }
    }
}
