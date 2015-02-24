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
    public partial class FrmLanchedaTarde : PhoneApplicationPage
    {
        public Image thisImagem;
        public LanchedaTardeView lanchetardeR;
        public FrmLanchedaTarde()
        {
            InitializeComponent();
            int lastid = LanchedaNoiteViewModel.listar().Count +1;
            lanchetardeR = new LanchedaTardeView() { Id_lanchedatarde =  lastid , Frutafk = 0, Liquidofk = 0, Paofk = 0 };
        }

        //EVENTOS IMAGENS
        private void imgLANCHETardePaesCereais_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            thisImagem = sender as Image;
            App.Current.Actives.IdTipoAlimento_Select = 7;
            NavigationService.Navigate(new Uri("/View/MontaPratoUtil/FrmPaoCereal.xaml", UriKind.Relative));
        }

        private void imgLANCHETardeFrutas_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            App.Current.Actives.IdTipoAlimento_Select = 4;
            NavigationService.Navigate(new Uri("/View/MontaPratoUtil/FrmFrutas.xaml", UriKind.Relative));
            thisImagem = sender as Image;
        }

        private void imgcopo_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            App.Current.Actives.IdTipoAlimento_Select = 1;
            NavigationService.Navigate(new Uri("/View/MontaPratoUtil/FrmCopo.xaml", UriKind.Relative));
            thisImagem = sender as Image;
        }
        //FIM EVENTOS IMAGENS

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            if (App.Current.Actives.ActiveImagem != null)
            {
                thisImagem.Source = new BitmapImage(new Uri(App.Current.Actives.ActiveImagem, UriKind.RelativeOrAbsolute));
                App.Current.Actives.ActiveImagem = null;
            }
            if (App.Current.Actives.R_lanchetarde.Id_lanchedatarde != 0)
            {
                this.imgLANCHETardeFrutas.Source = new BitmapImage(new Uri(AlimentoViewModel.listarFrutas()[App.Current.Actives.R_lanchetarde.Frutafk - 1].Img_source, UriKind.RelativeOrAbsolute));
                this.imgcopo.Source = new BitmapImage(new Uri(AlimentoViewModel.listarCopos()[App.Current.Actives.R_lanchetarde.Liquidofk - 1].Img_source, UriKind.RelativeOrAbsolute));
                this.imgLANCHETardePaesCereais.Source = new BitmapImage(new Uri(AlimentoViewModel.listarPaes()[App.Current.Actives.R_lanchetarde.Paofk - 1].Img_source, UriKind.RelativeOrAbsolute));
                lanchetardeR = App.Current.Actives.R_lanchetarde;
            }

        }

        //VALIDAÇÕES
        protected bool ValidarLanchedatarde(LanchedaTardeView pobject)
        {
            if (App.Current.Actives.R_lanchetarde.Frutafk != 0 && App.Current.Actives.R_lanchetarde.Liquidofk != 0 &&
                App.Current.Actives.R_lanchetarde.Paofk != 0)
            {
                App.Current.Actives.bolRefeicoes[3] = true;
                App.Current.Actives.R_lanchetarde.Id_lanchedatarde = LanchedaTardeViewModel.listar().Count + 1;
                return true;
            }
            else
                return false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidarLanchedatarde(lanchetardeR))
            {
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Falta selecionar alguns", "Monta-Prato LINDA...", MessageBoxButton.OK);
            }
        }
    }
}