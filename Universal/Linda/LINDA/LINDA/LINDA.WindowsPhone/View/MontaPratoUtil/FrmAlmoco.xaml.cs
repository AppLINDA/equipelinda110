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
    public partial class FrmAlmoco : PhoneApplicationPage
    {
        public AlmocoView almocoR;
        public Image thisImagem;
        public FrmAlmoco()
        {
            InitializeComponent();
            int lastid = AlmocoViewModel.listar().Count + 1;
            almocoR = new AlmocoView() { Id_almoco = lastid, Frutafk = 0, Liquidofk = 0, GraoIntegralfk = 0, Proteinafk = 0, Vegetalfk = 0 };
        }
        #region EVENTOS IMAGENS

        private void imgAlmocoVegetais_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            thisImagem = sender as Image;
            App.Current.Actives.IdTipoAlimento_Select = 2;
            NavigationService.Navigate(new Uri("/View/MontaPratoUtil/FrmVegetais.xaml", UriKind.Relative));
        }

        private void imgAlmocoFrutas_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            App.Current.Actives.IdTipoAlimento_Select = 4;
            NavigationService.Navigate(new Uri("/View/MontaPratoUtil/FrmFrutas.xaml", UriKind.Relative));
            thisImagem = sender as Image;
        }

        private void imgAlmocoProteinas_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            thisImagem = sender as Image;
            App.Current.Actives.IdTipoAlimento_Select = 5;
            NavigationService.Navigate(new Uri("/View/MontaPratoUtil/FrmProteinas.xaml", UriKind.Relative));
        }

        private void imgAlmocoGraos_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
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

        #endregion

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
            if (App.Current.Actives.R_almoco.Id_almoco != 0)
            {
                this.imgAlmocoFrutas.Source = new BitmapImage(new Uri(AlimentoViewModel.listarFrutas()[App.Current.Actives.R_almoco.Frutafk - 1].Img_source, UriKind.RelativeOrAbsolute));
                this.imgcopo.Source = new BitmapImage(new Uri(AlimentoViewModel.listarCopos()[App.Current.Actives.R_almoco.Liquidofk - 1].Img_source, UriKind.RelativeOrAbsolute));
                this.imgAlmocoVegetais.Source = new BitmapImage(new Uri(AlimentoViewModel.listarvegetal()[App.Current.Actives.R_almoco.Vegetalfk - 1].Img_source, UriKind.RelativeOrAbsolute));
                this.imgAlmocoProteinas.Source = new BitmapImage(new Uri(AlimentoViewModel.listarProteinas()[App.Current.Actives.R_almoco.Proteinafk - 1].Img_source, UriKind.RelativeOrAbsolute));
                this.imgAlmocoGraos.Source = new BitmapImage(new Uri(AlimentoViewModel.listarGraoIntegral()[App.Current.Actives.R_almoco.GraoIntegralfk - 1].Img_source, UriKind.RelativeOrAbsolute));
                almocoR = App.Current.Actives.R_almoco;
            }

        }

        //VALIDAÇÕES
        protected bool ValidarAlmoco(AlmocoView pobject)
        {
            if (App.Current.Actives.R_almoco.Frutafk != 0 && App.Current.Actives.R_almoco.Liquidofk != 0 &&
                App.Current.Actives.R_almoco.Proteinafk != 0 && App.Current.Actives.R_almoco.GraoIntegralfk != 0 &&
                App.Current.Actives.R_almoco.Vegetalfk != 0)
            {
                App.Current.Actives.bolRefeicoes[2] = true;
                App.Current.Actives.R_almoco.Id_almoco = AlmocoViewModel.listar().Count + 1;
                return true;
            }
            else
                return false;
        }

        private void Salvar_Click(object sender, EventArgs e)
        {
            
            if (ValidarAlmoco(almocoR))
            {
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Falta selecionar alguns", "Almoco Monta-Prato LINDA...", MessageBoxButton.OK);
            }
        }

    }
}