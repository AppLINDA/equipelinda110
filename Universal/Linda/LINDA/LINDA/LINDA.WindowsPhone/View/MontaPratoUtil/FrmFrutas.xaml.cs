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
    public partial class FrmFrutas : PhoneApplicationPage
    {
        
        public FrmFrutas()
        {
            InitializeComponent();
            
            this.FrutaList.ItemsSource = AlimentoViewModel.listarFrutas() ;
          
        }
        List<AlimentoView> lst;
        private void FrutaList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lst = AlimentoViewModel.listarFrutas();
            App.Current.Actives.ActiveImagem = lst[FrutaList.SelectedIndex].Img_source;
            App.Current.Actives.IdAlimento_Select = FrutaList.SelectedIndex + 1;
            switch (App.Current.Actives.IdRefeicao_Select)
            {
                case 1:
                    App.Current.Actives.R_cafedamanha.Frutafk = FrutaList.SelectedIndex + 1;
                    break;
                case 2:
                    App.Current.Actives.R_lanchedamanha.Frutafk = FrutaList.SelectedIndex + 1;
                    break;
                case 3:
                    App.Current.Actives.R_almoco.Frutafk = FrutaList.SelectedIndex + 1;
                    break;
                case 4:
                    App.Current.Actives.R_lanchetarde.Frutafk = FrutaList.SelectedIndex + 1;
                    break;
                case 5:
                    App.Current.Actives.R_jantar.Frutafk = FrutaList.SelectedIndex + 1;
                    break;
                case 6:
                    App.Current.Actives.R_lanchenoite.Frutafk = FrutaList.SelectedIndex + 1;
                    break;

                default:
                    break;
            }
            this.NavigationService.GoBack();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            App.Current.Actives.IdAlimento_Select = 0;
            base.OnNavigatedTo(e);
        }
  
    }
}