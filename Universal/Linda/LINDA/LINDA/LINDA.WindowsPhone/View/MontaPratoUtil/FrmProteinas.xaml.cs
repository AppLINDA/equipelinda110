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
//using LINDA.Model.Modulo1;

namespace LINDA.View.MontaPratoUtil
{
    public partial class FrmProteinas : PhoneApplicationPage
    {
        public FrmProteinas()
        {
            InitializeComponent();

            this.proteinasList.ItemsSource = AlimentoViewModel.listarProteinas();
        }

        List<AlimentoView> lst;
        private void proteinasList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lst = AlimentoViewModel.listarProteinas();
            thisApp.Actives.ActiveImagem = lst[proteinasList.SelectedIndex].Img_source;
            thisApp.Actives.IdAlimento_Select = proteinasList.SelectedIndex + 1;
            
              switch (App.Current.Actives.IdRefeicao_Select)
            {

                case 3:
                    App.Current.Actives.R_almoco.Proteinafk = proteinasList.SelectedIndex + 1;
                    break;
                case 5:
                    App.Current.Actives.R_jantar.Proteinafk = proteinasList.SelectedIndex + 1;
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