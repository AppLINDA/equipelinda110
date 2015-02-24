using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using LINDA.ViewModel;
using System.Windows.Media.Imaging;

namespace LINDA.View.MontaPratoUtil
{
    public partial class FrmJanta : PhoneApplicationPage
    {
        public Image thisImagem;
        public JantaView jantarR;
        public FrmJanta()
        {
            InitializeComponent();
            int lastid = JantaViewModel.listar().Count + 1;
            jantarR = new JantaView() { Id_janta = lastid, Frutafk = 0, Liquidofk = 0, GraoIntegralfk = 0, Proteinafk = 0, Vegetalfk = 0 };
        }

        //EVENTOS IMAGENS
        private void imgJantaVegetais_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            App.Current.Actives.IdTipoAlimento_Select = 2;
            thisImagem = sender as Image;
            NavigationService.Navigate(new Uri("/View/MontaPratoUtil/FrmVegetais.xaml", UriKind.Relative));
        }

        private void imgJantaFrutas_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            App.Current.Actives.IdTipoAlimento_Select = 4;
            NavigationService.Navigate(new Uri("/View/MontaPratoUtil/FrmFrutas.xaml", UriKind.Relative));
            thisImagem = sender as Image;
        }

        private void imgJantaProteinas_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            thisImagem = sender as Image;
            App.Current.Actives.IdTipoAlimento_Select = 5;
            NavigationService.Navigate(new Uri("/View/MontaPratoUtil/FrmProteinas.xaml", UriKind.Relative));
        }

        private void imgJantaGraos_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            thisImagem = sender as Image;
            App.Current.Actives.IdTipoAlimento_Select = 3;
            NavigationService.Navigate(new Uri("/View/MontaPratoUtil/FrmGraoIntegral.xaml", UriKind.Relative));
        }

        private void imgcopo_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            App.Current.Actives.IdTipoAlimento_Select = 1;
            NavigationService.Navigate(new Uri("/View/MontaPratoUtil/FrmCopo.xaml", UriKind.Relative));
            thisImagem = sender as Image;
        }
        //FIM EVENTOS IMAGENS


        /// <summary>
        /// Chamado quando este forme é instanciado;
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (App.Current.Actives.ActiveImagem != null)
            {
                thisImagem.Source = new BitmapImage(new Uri(App.Current.Actives.ActiveImagem, UriKind.RelativeOrAbsolute));
                App.Current.Actives.ActiveImagem = null;
            }
            if (App.Current.Actives.R_jantar.Id_janta != 0)
            {
                this.imgJantaFrutas.Source = new BitmapImage(new Uri( AlimentoViewModel.listarFrutas()[App.Current.Actives.R_jantar.Frutafk -1].Img_source, UriKind.RelativeOrAbsolute));
                this.imgcopo.Source = new BitmapImage(new Uri(AlimentoViewModel.listarCopos()[App.Current.Actives.R_jantar.Liquidofk - 1].Img_source, UriKind.RelativeOrAbsolute));
                this.imgJantaVegetais.Source = new BitmapImage(new Uri(AlimentoViewModel.listarvegetal()[App.Current.Actives.R_jantar.Vegetalfk - 1].Img_source, UriKind.RelativeOrAbsolute));
                this.imgJantaProteinas.Source = new BitmapImage(new Uri(AlimentoViewModel.listarProteinas()[App.Current.Actives.R_jantar.Proteinafk - 1].Img_source, UriKind.RelativeOrAbsolute));
                this.imgJantaGraos.Source = new BitmapImage(new Uri(AlimentoViewModel.listarGraoIntegral()[App.Current.Actives.R_jantar.GraoIntegralfk - 1].Img_source, UriKind.RelativeOrAbsolute));
                jantarR = App.Current.Actives.R_jantar;
            }
        }

        //VALIDAÇÕES
        protected bool ValidarJantar()
        {
            if (App.Current.Actives.R_jantar.Frutafk != 0 && App.Current.Actives.R_jantar.Liquidofk != 0 && 
                App.Current.Actives.R_jantar.Proteinafk != 0 && App.Current.Actives.R_jantar.GraoIntegralfk != 0 && 
                App.Current.Actives.R_jantar.Vegetalfk != 0)
            {
                App.Current.Actives.bolRefeicoes[4] = true;
                App.Current.Actives.R_jantar.Id_janta = JantaViewModel.listar().Count + 1;
                return true;
            }
            else
                return false;
        }
        //FIM VALIDAÇÕES

        private void SalvarJantar_Click(object sender, EventArgs e)
        {
            if (ValidarJantar())
            {
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Falta selecionar alguns", "Jantar Monta-Prato LINDA...", MessageBoxButton.OK);
            }
        }

    }
}