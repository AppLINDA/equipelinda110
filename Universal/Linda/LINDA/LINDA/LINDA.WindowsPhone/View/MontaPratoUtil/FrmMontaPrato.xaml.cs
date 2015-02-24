using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using LINDA.ViewModel;
using System.Windows.Threading;


namespace LINDA.View.MontaPratoUtil
{
    public partial class FrmMontaPrato : PhoneApplicationPage
    {
        private DispatcherTimer _timer = new DispatcherTimer();
        private int tempoativo;
        public FrmMontaPrato()
        {

            InitializeComponent();            
           //Verifica necessidade de criar nova instância de monta prato
            //Caso ainda não se tenha iniciado o processo de definição de dieta:
            if (!App.Current.Actives.usandomontaprato)
            {
                App.Current.Actives.MontapratoUsar();
            }
            this._timer.Interval = TimeSpan.FromSeconds(1);
            this.tempoativo = 0;
            this._timer.Tick += Timer_Tick;
            this._timer.Start();
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.tempoativo++;
            if (this.tempoativo == 1)
            {
                this.hubCafeManha.IsEnabled = true;
                this._timer.Stop();
            }
        }

        #region EVENTOS DE BOTÕES

        private void hubCafeManha_Tap(object sender, System.Windows.Input.MouseEventArgs e)
        {
            App.Current.Actives.IdRefeicao_Select = 1;
            NavigationService.Navigate(new Uri("/View/MontaPratoUtil/FrmCafedaManha.xaml", UriKind.Relative));
            
        }

        private void hubLancheManha_Tap(object sender, System.Windows.Input.MouseEventArgs e)
        {
            App.Current.Actives.IdRefeicao_Select = 2;
            NavigationService.Navigate(new Uri("/View/MontaPratoUtil/FrmLanchedaManha.xaml", UriKind.Relative));
            
        }

        private void hubAlmoco_Tap(object sender, System.Windows.Input.MouseEventArgs e)
        {
            App.Current.Actives.IdRefeicao_Select = 3;
            NavigationService.Navigate(new Uri("/View/MontaPratoUtil/FrmAlmoco.xaml", UriKind.Relative));
        }

        private void hubLancheTarde_Tap(object sender, System.Windows.Input.MouseEventArgs e)
        {
            App.Current.Actives.IdRefeicao_Select = 4;
            NavigationService.Navigate(new Uri("/View/MontaPratoUtil/FrmLanchedaTarde.xaml", UriKind.Relative));   
        }

        private void hubJanta_Tap(object sender, System.Windows.Input.MouseEventArgs e)
        {
            App.Current.Actives.IdRefeicao_Select = 5;
            NavigationService.Navigate(new Uri("/View/MontaPratoUtil/FrmJanta.xaml", UriKind.Relative)); 
        }

        private void hubLancheNoite_Tap(object sender, System.Windows.Input.MouseEventArgs e)
        {
            App.Current.Actives.IdRefeicao_Select = 6;
            NavigationService.Navigate(new Uri("/View/MontaPratoUtil/FrmLanchedaNoite.xaml", UriKind.Relative));   
        }
        //FIM EVENTOS BOTÕES
        #endregion

        #region EVENTOS AUXILIARES:

        //AUXILIADORES

        
        /// <summary>
        /// Verificar utilidade
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (App.Current.Actives.ActiveImagem != null)
            {
                App.Current.Actives.ActiveImagem = null;
            }
            this.Verificar();
            base.OnNavigatedTo(e);
        }        
        //SALVAR:
        private void Salvar_Click(object sender, EventArgs e)
        {
           
                if ( App.Current.Actives.R_almoco.Id_almoco != 0 &&
                    App.Current.Actives.R_cafedamanha.Id_cafedamanha != 0 &&
                    App.Current.Actives.R_jantar.Id_janta != 0 &&
                    App.Current.Actives.R_lanchenoite.Id_lanchedanoite != 0 &&
                    App.Current.Actives.R_lanchetarde.Id_lanchedatarde != 0 &&
                    App.Current.Actives.R_lanchedamanha.Id_lanchedamanha != 0
                    )
                {
                    NavigationService.Navigate(new Uri("/View/MontaPratoUtil/FrmDiasSemana.xaml", UriKind.Relative));
                }
                else
                {
                    MessageBox.Show("Ainda faltam dados para sua dieta!", "Monta Prato Linda...", MessageBoxButton.OK);
                }
        }
        #endregion        
        protected void Verificar() 
        {
            if (App.Current.Actives.bolRefeicoes[0])
            {
                this.imgCheckedcm.Visibility = System.Windows.Visibility.Visible;
            }
            if (App.Current.Actives.bolRefeicoes[1])
            {
                this.imgCheckedlm.Visibility = System.Windows.Visibility.Visible;
            }
            if (App.Current.Actives.bolRefeicoes[2])
            {
                this.imgCheckedal.Visibility = System.Windows.Visibility.Visible;
            }
            if (App.Current.Actives.bolRefeicoes[3])
            {
                this.imgCheckedlt.Visibility = System.Windows.Visibility.Visible;
            }
            if (App.Current.Actives.bolRefeicoes[4])
            {
                this.imgCheckedja.Visibility = System.Windows.Visibility.Visible;
            }
            if (App.Current.Actives.bolRefeicoes[5])
            {
                this.imgCheckedln.Visibility = System.Windows.Visibility.Visible;
            }
        }
    }
}