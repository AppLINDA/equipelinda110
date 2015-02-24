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


namespace LINDA.View
{
    public partial class FrmNutricionista : PhoneApplicationPage
    {
        public FrmNutricionista()
        {
            InitializeComponent();

            this.NutricionistaList.ItemsSource = NutricionistaViewModel.listarNutricionistas();
        }

        List<NutricionistaView> lst;
        private void NutricionistaList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lst = NutricionistaViewModel.listarNutricionistas();
            App.Current.Actives.id = lst[NutricionistaList.SelectedIndex].Id_nutricionista;
            App.Current.Actives.nome = lst[NutricionistaList.SelectedIndex].Nome;
            App.Current.Actives.telefone = lst[NutricionistaList.SelectedIndex].Telefone;
            NavigationService.Navigate(new Uri("/View/FrmNutricionistaInformacoes.xaml", UriKind.Relative));
        }
    }
}