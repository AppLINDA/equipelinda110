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
    public partial class FrmLanchedaManha : PhoneApplicationPage
    {
        public Image thisImagem;
        private LanchedaManhaView lanchedamanhaR;
        public FrmLanchedaManha()
        {
            InitializeComponent();
            int lastid = LanchedaManhaViewModel.listar().Count + 1;
            lanchedamanhaR = new LanchedaManhaView() { Id_lanchedamanha = lastid, Frutafk = 0, Liquidofk = 0, Paofk = 0 };
        }

        //INICIO DOS EVENTOS DAS IMAGENS
        private void imgcopo_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            App.Current.Actives.IdTipoAlimento_Select = 1;
            NavigationService.Navigate(new Uri("/View/MontaPratoUtil/FrmCopo.xaml", UriKind.Relative));
            thisImagem = sender as Image;
        }

        private void imgLANCHEManhaPaesCereais_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            App.Current.Actives.IdTipoAlimento_Select = 7;
            thisImagem = sender as Image;
            NavigationService.Navigate(new Uri("/View/MontaPratoUtil/FrmPaoCereal.xaml", UriKind.Relative));
        }

        private void imgLANCHEManhaFrutas_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            App.Current.Actives.IdTipoAlimento_Select = 4;
            NavigationService.Navigate(new Uri("/View/MontaPratoUtil/FrmFrutas.xaml", UriKind.Relative));
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
            if (App.Current.Actives.R_lanchedamanha.Id_lanchedamanha != 0)
            {
                this.imgLANCHEManhaFrutas.Source = new BitmapImage(new Uri(AlimentoViewModel.listarFrutas()[App.Current.Actives.R_lanchedamanha.Frutafk - 1].Img_source, UriKind.RelativeOrAbsolute));
                this.imgcopo.Source = new BitmapImage(new Uri(AlimentoViewModel.listarCopos()[App.Current.Actives.R_lanchedamanha.Liquidofk - 1].Img_source, UriKind.RelativeOrAbsolute));
                this.imgLANCHEManhaPaesCereais.Source = new BitmapImage(new Uri(AlimentoViewModel.listarPaes()[App.Current.Actives.R_lanchedamanha.Paofk - 1].Img_source, UriKind.RelativeOrAbsolute));
                lanchedamanhaR = App.Current.Actives.R_lanchedamanha;
            }

        }

        //VALIDAÇÕES
        protected bool ValidarLanchedamanha(LanchedaManhaView pobject)
        {
            if (App.Current.Actives.R_lanchedamanha.Frutafk != 0 && App.Current.Actives.R_lanchedamanha.Liquidofk != 0 &&
     App.Current.Actives.R_lanchedamanha.Paofk != 0)
            {
                App.Current.Actives.bolRefeicoes[1] = true;
                App.Current.Actives.R_lanchedamanha.Id_lanchedamanha = LanchedaManhaViewModel.listar().Count + 1;
                return true;
            }
            else
                return false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidarLanchedamanha(lanchedamanhaR))
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