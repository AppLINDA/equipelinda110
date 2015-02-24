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
    public partial class FrmCafe : PhoneApplicationPage
    {
        public FrmCafe()
        {
            InitializeComponent();

            this.paocerealList.ItemsSource = AlimentoViewModel.listarPaes(); 
        }

        List<AlimentoView> lst;
        private void paocerealList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lst = AlimentoViewModel.listarPaes();
            thisApp.Actives.ActiveImagem = lst[paocerealList.SelectedIndex].Img_source;
            thisApp.Actives.IdAlimento_Select = paocerealList.SelectedIndex + 1;
     
               switch (App.Current.Actives.IdRefeicao_Select)
            {

                case 1:
                    App.Current.Actives.R_cafedamanha.Paofk = paocerealList.SelectedIndex + 1;
                    break;
                case 2:
                    App.Current.Actives.R_lanchedamanha.Paofk = paocerealList.SelectedIndex + 1;
                    break;
                case 4:
                    App.Current.Actives.R_lanchetarde.Paofk = paocerealList.SelectedIndex + 1;
                    break;
                case 6:
                    App.Current.Actives.R_lanchenoite.Paofk = paocerealList.SelectedIndex + 1;
                    break;

                default:
                    break;
            }
            
            this.NavigationService.GoBack();
        }

        App thisApp = Application.Current as App;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            thisApp.Actives.IdAlimento_Select = 0;
            base.OnNavigatedTo(e);
        }
    }
}