using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace LINDA.View
{
    public partial class FrmCalendario : PhoneApplicationPage
    {

        public FrmCalendario()
        {
            InitializeComponent();
            App.Current.Actives.IdSemena_Select = 1;
            App.Current.Actives.IdRefeicao_Select = 0;
        }
       
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
                e.Cancel = true;
                NavigationService.Navigate(new Uri("/View/FrmMenuInicial.xaml", UriKind.Relative));
        }        

        private void Selected_Dia(object sender, SelectionChangedEventArgs e)
        {
            //Definição de Qual dia da semana está selecionado.
            App.Current.Actives.IdSemena_Select = dietaSemana.SelectedIndex + 1;

            switch ( dietaSemana.SelectedIndex + 1 )
            { 
                case 1:
                    this.CtrlDomingo.MostrarPratos();
                    break;
                case 2:
                    this.CtrlSegunda.MostrarPratos();
                    break;
                case 3:
                    this.CtrlTerca.MostrarPratos();
                    break;
                case 4:
                    this.CtrlQuarta.MostrarPratos();
                    break;
                case 5:
                    this.CtrlQuinta.MostrarPratos();
                    break;
                case 6:
                    this.CtrlSexta.MostrarPratos();
                    break;
                case 7:
                    this.CtrlSabado.MostrarPratos();        
                    break;
                default:
                    break;
            }
        }

        private void LoadedPivotItem(object sender, PivotItemEventArgs e)
        {
            App.Current.Actives.IdRefeicao_Select = 0;            
        }

    }
}