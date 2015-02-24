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

namespace LINDA.View.MontaPratoUtil
{
    public partial class FrmDiasSemana : PhoneApplicationPage
    {
        public FrmDiasSemana()
        {
            InitializeComponent();

            AvatarView escolido = AvatarViewModel.BuscarporID(1);
            this.txtNomeApelido.Text = escolido.Name;
            this.imgAvatarEscolhido.Source = escolido.imgAvatar;
        }

        private void Salvar_Click(object sender, EventArgs e)
        {
            if (Validaou())
            {
                    App.Current.Actives.R_lanchenoite.Gravar();
                    App.Current.Actives.R_lanchedamanha.Gravar();
                    App.Current.Actives.R_lanchetarde.Gravar();
                    App.Current.Actives.R_jantar.Gravar();
                    App.Current.Actives.R_almoco.Gravar();
                    App.Current.Actives.R_cafedamanha.Gravar();
                    for (int i = 0; i < listadosemana.Count; i++)
                    {
                       App.Current.Actives.RefeicaoActive = MontapratoViewModel.BuscarporIDSemana(listadosemana[i]);
                       App.Current.Actives.RefeicaoActive.Almoco_fk = AlmocoViewModel.listar().Count;
                       App.Current.Actives.RefeicaoActive.Cafedamanha_fk = CafedaManhaViewModel.listar().Count;
                       App.Current.Actives.RefeicaoActive.Lanchetarde_fk = LanchedaTardeViewModel.listar().Count;
                       App.Current.Actives.RefeicaoActive.Lanchemanha_fk = LanchedaManhaViewModel.listar().Count;
                       App.Current.Actives.RefeicaoActive.Lanchedanoite_fk = LanchedaNoiteViewModel.listar().Count;
                       App.Current.Actives.RefeicaoActive.Jantar_fk = JantaViewModel.listar().Count;
                       App.Current.Actives.RefeicaoActive.Statuspronto = true;
                       App.Current.Actives.RefeicaoActive.Alterar();
                    }
                    ApplicationBar.IsVisible = false;
                    this.grdAvatarInteracao.Visibility = System.Windows.Visibility.Visible;                    
            }
            else
            {
                MessageBox.Show("Selecione um dia da semana ao menos", "Monta Prato Linda...", MessageBoxButton.OK);
            }
        }
        List < int > listadosemana;
        private bool Validaou()
        {
            bool retorno = false;
            listadosemana = new List<int>();
            for (int i = 0; i < this.lista.Items.Count; i++)
            {
                CheckBox ag = this.lista.Items[i] as CheckBox;
                if (ag.IsChecked.Value)
                {
                    retorno = true;
                    listadosemana.Add(i+1);
                }
            }
            return retorno;
        }

        private void btnAvatarInteracaoOK_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/FrmCalendario.xaml", UriKind.Relative));
        }
    }
}