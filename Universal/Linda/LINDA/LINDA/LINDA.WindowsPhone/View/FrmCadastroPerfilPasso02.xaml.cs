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
    public partial class FrmCadastroPerfilPasso02 : PhoneApplicationPage
    {
        public FrmCadastroPerfilPasso02()
        {
            InitializeComponent();
            float KlrMax = 0;
            float pesoMaxSaudavel;
            App thisApp = Application.Current as App;
            pesoMaxSaudavel = (thisApp.Actives.ActivePerfil.Altura * thisApp.Actives.ActivePerfil.Altura);
            KlrMax = (float)(20 * pesoMaxSaudavel * 24.9);
            lblMaxKlDiaria.Text = string.Format("{0:f2}", KlrMax);
        }
        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            float KlrMax = 0 ;
            float pesoMaxSaudavel;
            App thisApp = Application.Current as App;
            pesoMaxSaudavel = (thisApp.Actives.ActivePerfil.Altura * thisApp.Actives.ActivePerfil.Altura);
            RadioButton rb = sender as RadioButton;
            switch (rb.Content.ToString())
            {
                case "20 - Leve":
                    KlrMax = (float)(20 * pesoMaxSaudavel * 24.9);
                    thisApp.Actives.ActivePerfil.Indiceatividadefisica = 20;
                    break;
                case "30 - Moderada":
                    KlrMax = (float)(30 * pesoMaxSaudavel * 24.9);
                    thisApp.Actives.ActivePerfil.Indiceatividadefisica = 30;
                    break;
                case "40 - Intensa":
                    KlrMax = (float)(40 * pesoMaxSaudavel * 24.9);
                    thisApp.Actives.ActivePerfil.Indiceatividadefisica = 40;
                    break;
                default:
                    break;
            }
            lblMaxKlDiaria.Text = string.Format("{0:f2}", KlrMax);
        }
        private void Salvar_Click(object sender, EventArgs e)
        {
            App.Current.Actives.ActivePerfil.Idavatar = 1;
            PerfilViewModel.Gravar(App.Current.Actives.ActivePerfil);
            MassaView massa = new MassaView()
            {
                Idmassa = MassaViewModel.listar().Count + 1,
                Dataupadate = DateTime.Now.Date,
                Massa = App.Current.Actives.ActivePerfil.Peso
            };
            massa.Gravar();
            NavigationService.Navigate(new Uri("/View/FrmMenuInicial.xaml", UriKind.Relative));
            Image img = new Image();
            img.Source = AvatarViewModel.BuscarporID(1).imgAvatar;
        }

    }
}