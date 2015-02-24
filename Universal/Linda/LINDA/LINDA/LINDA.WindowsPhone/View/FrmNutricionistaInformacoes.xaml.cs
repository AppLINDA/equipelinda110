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
using Microsoft.Phone.Tasks;

namespace LINDA.View
{
    public partial class FrmInformacoesNutricionista : PhoneApplicationPage
    {
        public FrmInformacoesNutricionista()
        {
            InitializeComponent();
            this.NutricionistaInformacoesList.ItemsSource = NutricionistaViewModel.listarDados();                                    
        }


        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            var call = new PhoneCallTask();
            call.PhoneNumber = App.Current.Actives.telefone;
            call.DisplayName = App.Current.Actives.nome;
            call.Show();
            

        }
    }
}