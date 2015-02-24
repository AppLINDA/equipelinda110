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
using System.Windows.Media.Imaging;

namespace LINDA.View
{
    public partial class FrmEscolherApelido : PhoneApplicationPage
    {
        public FrmEscolherApelido()
        {
            InitializeComponent();
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            if (ValidarComponentes.ValidarTextBox(txtNomeApelido,1))
            {
                App.Current.Actives.ActiveAvatarP = AvatarViewModel.BuscarporID(1);
                App.Current.Actives.ActiveAvatarP.Name = txtNomeApelido.Text;
                App.Current.Actives.ActiveAvatarP.Alterar();
                NavigationService.Navigate(new Uri("/View/FrmCadastroPerfilPasso01.xaml", UriKind.Relative));
            }
            else 
            {
                MessageBox.Show("Insira o nome de apelido, por favor", "Erro de preenchimento!", MessageBoxButton.OK);
            }
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            App thisApp = Application.Current as App;
            imgAvatar3.Source = thisApp.Actives.ActiveAvatar.Source;
        }
    }
}