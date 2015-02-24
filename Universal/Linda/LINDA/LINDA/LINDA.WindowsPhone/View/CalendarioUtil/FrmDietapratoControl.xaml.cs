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

namespace LINDA.View.CalendarioUtil
{
    public partial class FrmDietapratoControl : UserControl
    {
        /// <summary>
        /// Refeição de determinaod dia da semana montado;
        /// </summary>
        private MontapratoView atual ;
        public FrmDietapratoControl()
        {
            InitializeComponent();
            this.atual = new MontapratoView();
        }
        /// <summary>
        /// Exibe os pretos de cada tipo de refeição.
        /// </summary>
        public void MostrarPratos()
        {
            atual = MontapratoViewModel.BuscarporIDSemana(
                App.Current.Actives.IdSemena_Select);
            if (atual.Statuspronto)
            {

                //"café da manhã";
                this.Ctrlprato_cafedamanha.imgFrutas.Source =
                    AlimentoViewModel.listarFrutas()[
                        CafedaManhaViewModel.listar()
                        [atual.Cafedamanha_fk - 1].Frutafk - 1].ImgConvertedSource();
                this.Ctrlprato_cafedamanha.imgPaos.Source =
                    AlimentoViewModel.listarPaes()[
                        CafedaManhaViewModel.listar()
                        [atual.Cafedamanha_fk - 1].Paofk - 1].ImgConvertedSource();
                //"lanche da manhã";
                this.Ctrlprato_lanchedamanha.imgFrutas.Source =
                    AlimentoViewModel.listarFrutas()[
                        LanchedaManhaViewModel.listar()
                        [atual.Lanchemanha_fk - 1].Frutafk - 1].ImgConvertedSource();
                this.Ctrlprato_lanchedamanha.imgPaos.Source =
                    AlimentoViewModel.listarPaes()[
                                LanchedaManhaViewModel.listar()
                                [atual.Lanchemanha_fk - 1].Paofk - 1].ImgConvertedSource();
                // "almoço";

                this.Ctrlprato_almoco.imgFrutas.Source =
                    AlimentoViewModel.listarFrutas()[
                        AlmocoViewModel.listar()
                        [atual.Almoco_fk - 1].Frutafk - 1].ImgConvertedSource();
                this.Ctrlprato_almoco.imgGraos.Source = AlimentoViewModel.listarGraoIntegral()[
                        AlmocoViewModel.listar()
                        [atual.Almoco_fk - 1].GraoIntegralfk - 1].ImgConvertedSource();
                this.Ctrlprato_almoco.imgProteinas.Source = AlimentoViewModel.listarProteinas()[
                        AlmocoViewModel.listar()
                        [atual.Almoco_fk - 1].Proteinafk - 1].ImgConvertedSource();
                this.Ctrlprato_almoco.imgVegetais.Source = AlimentoViewModel.listarvegetal()[
                        AlmocoViewModel.listar()
                        [atual.Almoco_fk - 1].Vegetalfk - 1].ImgConvertedSource();
                //"lanche da tarde";

                this.Ctrlprato_lanchedatarde.imgFrutas.Source =
                    AlimentoViewModel.listarFrutas()[
                        LanchedaTardeViewModel.listar()
                        [atual.Lanchetarde_fk - 1].Frutafk - 1].ImgConvertedSource();
                this.Ctrlprato_lanchedatarde.imgPaos.Source =
                    AlimentoViewModel.listarPaes()[
                        LanchedaTardeViewModel.listar()
                        [atual.Lanchetarde_fk - 1].Paofk - 1].ImgConvertedSource();

                //janta

                this.Ctrlprato_janta.imgFrutas.Source = AlimentoViewModel.listarFrutas()[
                        JantaViewModel.listar()
                        [atual.Jantar_fk - 1].Frutafk - 1].ImgConvertedSource();
                this.Ctrlprato_janta.imgGraos.Source = AlimentoViewModel.listarGraoIntegral()[
                        JantaViewModel.listar()
                        [atual.Jantar_fk - 1].GraoIntegralfk - 1].ImgConvertedSource();
                this.Ctrlprato_janta.imgProteinas.Source = AlimentoViewModel.listarProteinas()[
                        JantaViewModel.listar()
                        [atual.Jantar_fk - 1].Proteinafk - 1].ImgConvertedSource();
                this.Ctrlprato_janta.imgVegetais.Source = AlimentoViewModel.listarvegetal()[
                        JantaViewModel.listar()
                        [atual.Jantar_fk - 1].Vegetalfk - 1].ImgConvertedSource();

                //"lanche da noite";

                this.Ctrlprato_lanchedanoite.imgFrutas.Source = AlimentoViewModel.listarFrutas()[
                        LanchedaNoiteViewModel.listar()
                        [atual.Lanchedanoite_fk - 1].Frutafk - 1].ImgConvertedSource();
                this.Ctrlprato_lanchedanoite.imgPaos.Source =
                    AlimentoViewModel.listarPaes()[
                        LanchedaNoiteViewModel.listar()
                        [atual.Lanchedanoite_fk - 1].Paofk - 1].ImgConvertedSource();
            }
        }

        #region Botões eventos

        private void Cafedamanha_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (atual.Statuspronto)
            {
                App.Current.Actives.IdRefeicao_Select = 1;
                App.RootFrame.Navigate(new Uri("/View/FrmDadosRefeicao.xaml", UriKind.Relative));
            }
        }

        private void Lanchedamanha_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (atual.Statuspronto)
            {
                App.Current.Actives.IdRefeicao_Select = 2;
                App.RootFrame.Navigate(new Uri("/View/FrmDadosRefeicao.xaml", UriKind.Relative));
            }
        }

        private void Almoco_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (atual.Statuspronto)
            {
                App.Current.Actives.IdRefeicao_Select = 3;
                App.RootFrame.Navigate(new Uri("/View/FrmDadosRefeicao.xaml", UriKind.Relative));
            }
        }

        private void Lanchedatarde_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (atual.Statuspronto)
            {
                App.Current.Actives.IdRefeicao_Select = 4;
                App.RootFrame.Navigate(new Uri("/View/FrmDadosRefeicao.xaml", UriKind.Relative));
            }
        }

        private void Janta_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (atual.Statuspronto)
            {
                App.Current.Actives.IdRefeicao_Select = 5;
                App.RootFrame.Navigate(new Uri("/View/FrmDadosRefeicao.xaml", UriKind.Relative));
            }
        }

        private void Lanchedanoite_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (atual.Statuspronto)
            {
                App.Current.Actives.IdRefeicao_Select = 6;
                App.RootFrame.Navigate(new Uri("/View/FrmDadosRefeicao.xaml", UriKind.Relative));
            }
        }
        #endregion

    }
}
