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
    public partial class GraoIntegral : PhoneApplicationPage
    {
        public GraoIntegral()
        {
            InitializeComponent();

            this.GraoList.ItemsSource = AlimentoViewModel.listarGraoIntegral();
        }

        List<AlimentoView> lst;
        private void GraoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lst = AlimentoViewModel.listarGraoIntegral();
            thisApp.Actives.ActiveImagem = lst[GraoList.SelectedIndex].Img_source;
            thisApp.Actives.IdAlimento_Select = GraoList.SelectedIndex + 1;
            switch (App.Current.Actives.IdRefeicao_Select)
            {
                case 3:
                    App.Current.Actives.R_almoco.GraoIntegralfk = GraoList.SelectedIndex + 1;
                    break;
                case 5:
                    App.Current.Actives.R_jantar.GraoIntegralfk = GraoList.SelectedIndex + 1;
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