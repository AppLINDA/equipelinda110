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

namespace LINDA.View
{
    public partial class FrmDadosRefeicao : PhoneApplicationPage
    {
        MontapratoView atual;
        
        public FrmDadosRefeicao()
        {
            InitializeComponent();

            AvatarView escolido = AvatarViewModel.BuscarporID(1);            
            this.imgAvatarEscolhido.Source = escolido.imgAvatar;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            atual = MontapratoViewModel.BuscarporIDSemana(App.Current.Actives.IdSemena_Select);
            trocarNomeHeader();
            base.OnNavigatedTo(e);
        }
        
        public void trocarNomeHeader()
        {
            #region Verificação do tipo de qual alimento será referenciado
            //Lista de alimentos a exibir;
            List<AlimentoView> lstDados = new List<AlimentoView>();

            switch (App.Current.Actives.IdRefeicao_Select){
                case 1:
                    // Nome do cabeçalho:
                    this.txtTitulo1.Text = "café da manhã";
                    // Recolhando os alimentos que serão exibidos:
                    lstDados.Add(
                        AlimentoViewModel.listarFrutas()[
                            CafedaManhaViewModel.listar()[atual.Cafedamanha_fk - 1].Frutafk - 1]);
                    lstDados.Add(
                        AlimentoViewModel.listarPaes()[
                            CafedaManhaViewModel.listar()[atual.Cafedamanha_fk - 1].Paofk - 1]);
                    lstDados.Add(
                        AlimentoViewModel.listarCopos()[
                            CafedaManhaViewModel.listar()[atual.Cafedamanha_fk - 1].Liquidofk - 1 ]);
                    break;
                case 2:
                    // Nome do cabeçalho:
                    this.txtTitulo1.Text = "lanche da manhã";
                    // Recolhando os alimentos que serão exibidos:
                    lstDados.Add(
                        AlimentoViewModel.listarFrutas()[
                            LanchedaManhaViewModel.listar()[atual.Lanchemanha_fk - 1].Frutafk - 1]);
                    lstDados.Add(
                        AlimentoViewModel.listarCopos()[
                            LanchedaManhaViewModel.listar()[atual.Lanchemanha_fk - 1].Liquidofk - 1]);
                    lstDados.Add(
                        AlimentoViewModel.listarPaes()[
                            LanchedaManhaViewModel.listar()[atual.Lanchemanha_fk - 1].Paofk - 1]);
                    break;
                case 3:
                    // Nome do cabeçalho:
                    this.txtTitulo1.Text = "almoço";
                    // Recolhando os alimentos que serão exibidos:
                    lstDados.Add(
                        AlimentoViewModel.listarCopos() [
                            AlmocoViewModel.listar()[atual.Almoco_fk - 1].Liquidofk - 1]);
                    lstDados.Add(
                        AlimentoViewModel.listarGraoIntegral()[
                            AlmocoViewModel.listar()[atual.Almoco_fk - 1].GraoIntegralfk - 1]);
                    lstDados.Add(
                        AlimentoViewModel.listarvegetal()[
                            AlmocoViewModel.listar()[atual.Almoco_fk - 1].Vegetalfk - 1]);
                    lstDados.Add(
                        AlimentoViewModel.listarFrutas()[
                            AlmocoViewModel.listar()[atual.Almoco_fk - 1].Frutafk - 1]);
                    lstDados.Add(
                        AlimentoViewModel.listarProteinas()[
                            AlmocoViewModel.listar()[atual.Almoco_fk - 1].Proteinafk - 1]);
                    break;
                case 4:
                    // Nome do cabeçalho:
                    this.txtTitulo1.Text = "lanche da tarde";
                    // Exibe as imagens correspondentes no prato e copo:
                    lstDados.Add(
                        AlimentoViewModel.listarFrutas()[
                            LanchedaTardeViewModel.listar()[atual.Lanchetarde_fk - 1].Frutafk - 1]);
                    lstDados.Add(
                        AlimentoViewModel.listarCopos()[
                            LanchedaTardeViewModel.listar()[atual.Lanchetarde_fk - 1].Liquidofk - 1]);
                    lstDados.Add(
                        AlimentoViewModel.listarPaes()[
                            LanchedaTardeViewModel.listar()[atual.Lanchetarde_fk - 1].Paofk - 1]);
                    break;
                case 5:
                    // Nome do cabeçalho:
                    this.txtTitulo1.Text = "jantar";
                    // Exibe as imagens correspondentes no prato e copo:
                    lstDados.Add(
                        AlimentoViewModel.listarCopos() [
                            JantaViewModel.listar()[atual.Jantar_fk - 1].Frutafk - 1]);
                    lstDados.Add(
                        AlimentoViewModel.listarGraoIntegral()[
                            JantaViewModel.listar()[atual.Jantar_fk - 1].GraoIntegralfk - 1]);
                    lstDados.Add(
                        AlimentoViewModel.listarvegetal()[
                            JantaViewModel.listar()[atual.Jantar_fk - 1].Vegetalfk - 1]);
                    lstDados.Add(
                        AlimentoViewModel.listarFrutas()[
                            JantaViewModel.listar()[atual.Jantar_fk - 1].Frutafk - 1]);
                    lstDados.Add(
                        AlimentoViewModel.listarProteinas()[
                            JantaViewModel.listar()[atual.Jantar_fk - 1].Proteinafk - 1]);
                    break;
                case 6:
                    // Nome do cabeçalho:
                    this.txtTitulo1.Text = "lanche da noite";
                    // Exibe as imagens correspondentes no prato e copo:
                    lstDados.Add(
                        AlimentoViewModel.listarFrutas()[
                            LanchedaNoiteViewModel.listar()
                            [atual.Lanchedanoite_fk - 1].Frutafk - 1]);
                    lstDados.Add(
                        AlimentoViewModel.listarCopos()[
                            LanchedaNoiteViewModel.listar()
                            [atual.Lanchedanoite_fk - 1].Liquidofk - 1]);
                    lstDados.Add(
                        AlimentoViewModel.listarPaes()[
                            LanchedaNoiteViewModel.listar()
                            [atual.Lanchedanoite_fk - 1].Paofk - 1]);
                    
                    break;
                default:
                    break;
            }
            // Fim da Listagem detalhada da refeição:
            for (int i = 0; i < lstDados.Count; i++)
            {
                lstDados[i].Id_alimento = i + 1;
            }
            this.DadosalimentosCtrl.lstDadosAlimento.ItemsSource = lstDados;
            #endregion
        }

        private void Salvar_Click(object sender, EventArgs e)
        {
            double TotalCalorias = 0;
            AlimentoView auxAlimento = new AlimentoView();
            for (int i = 0; i < this.DadosalimentosCtrl.lstDadosAlimento.Items.Count; i++)
            {
                auxAlimento = this.DadosalimentosCtrl.lstDadosAlimento.Items[i] as AlimentoView;
                if (this.DadosalimentosCtrl.IdsSelected.Contains(auxAlimento.Id_alimento))
                {
                    TotalCalorias += auxAlimento.Calorias;
                }
            }
            this.txtCalorias.Text = TotalCalorias.ToString();
            this.ApplicationBar.IsVisible = false;
            this.grdAvatarInteracao.Visibility = System.Windows.Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

    }
}