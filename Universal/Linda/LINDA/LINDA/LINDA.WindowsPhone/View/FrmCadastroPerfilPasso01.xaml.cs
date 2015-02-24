using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
//using LINDA.Model.Modulo1;
using LINDA.ViewModel;

namespace LINDA.View
{
    public partial class FrmCadastroPerfilPasso01 : PhoneApplicationPage
    {
        public FrmCadastroPerfilPasso01()
        {
            InitializeComponent();
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            if (ValidarComponentes.ValidarTextBox(txtBoxPeso, 1)
                && ValidarComponentes.ValidarTextBox(txtBoxAltura, 1))
            {
                App thisApp = Application.Current as App;
                thisApp.Actives.ActivePerfil = new PerfilView()
                {
                    Altura = float.Parse(txtBoxAltura.Text),
                    Peso = float.Parse(txtBoxPeso.Text)
                };
                NavigationService.Navigate(new Uri("/View/FrmCadastroPerfilPasso02.xaml", UriKind.Relative));
            }
            else
            { 
                ValidarComponentes.msgValidacao1();
            }
        }
        float pesoMaxSaudavel;
        private void txtBoxPeso_SelectionChanged( object sender, RoutedEventArgs e )
        {
            if ( ValidarComponentes.ValidarTextBox( txtBoxPeso, 2)
                && ValidarComponentes.ValidarTextBox( txtBoxAltura, 2))
            {
                pesoMaxSaudavel = (float)(float.Parse( txtBoxAltura.Text ) * float.Parse( txtBoxAltura.Text )*24.9);
                lblValorPesoMaximoSaudavel.Text = string.Format("{0:f2}", pesoMaxSaudavel);
            }
        }     
    }
}