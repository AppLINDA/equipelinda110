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
    public partial class FrmVegetais : PhoneApplicationPage
    {
        public FrmVegetais()
        {
            InitializeComponent();

            this.vegetalList.ItemsSource = AlimentoViewModel.listarvegetal();
        }
        List<AlimentoView> lst;
        private void vegetaisList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lst = AlimentoViewModel.listarvegetal();
            thisApp.Actives.ActiveImagem = lst[vegetalList.SelectedIndex].Img_source;
            thisApp.Actives.IdAlimento_Select = vegetalList.SelectedIndex + 1;
            switch (App.Current.Actives.IdRefeicao_Select)
            {
                case 3:
                    App.Current.Actives.R_almoco.Vegetalfk = vegetalList.SelectedIndex + 1;
                    break;
                case 5:
                    App.Current.Actives.R_jantar.Vegetalfk = vegetalList.SelectedIndex + 1;
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