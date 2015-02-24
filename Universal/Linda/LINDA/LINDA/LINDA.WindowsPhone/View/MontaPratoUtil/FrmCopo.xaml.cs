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
    public partial class FrmCopo : PhoneApplicationPage
    {
        
        public FrmCopo()
        {
            InitializeComponent();
            this.CopoList.ItemsSource = AlimentoViewModel.listarCopos();
        }
        List<AlimentoView> lst;
        private void coposList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lst = AlimentoViewModel.listarCopos();
            thisApp.Actives.ActiveImagem = lst[CopoList.SelectedIndex].Img_source;
            thisApp.Actives.IdAlimento_Select = CopoList.SelectedIndex +1;
            switch (App.Current.Actives.IdRefeicao_Select)
            {
                case 1:
                    App.Current.Actives.R_cafedamanha.Liquidofk = CopoList.SelectedIndex + 1;
                    break;
                case 2:
                    App.Current.Actives.R_lanchedamanha.Liquidofk = CopoList.SelectedIndex + 1;
                    break;
                case 3:
                    App.Current.Actives.R_almoco.Liquidofk = CopoList.SelectedIndex + 1;
                    break;
                case 4:
                    App.Current.Actives.R_lanchetarde.Liquidofk = CopoList.SelectedIndex + 1;
                    break;
                case 5:
                    App.Current.Actives.R_jantar.Liquidofk = CopoList.SelectedIndex + 1;
                    break;
                case 6:
                    App.Current.Actives.R_lanchenoite.Liquidofk = CopoList.SelectedIndex + 1;
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