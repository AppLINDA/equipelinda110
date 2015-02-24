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
    public partial class FrmEscolherAvatar : PhoneApplicationPage
    {
        public FrmEscolherAvatar()
        {
            InitializeComponent();
        }
        private void Escolher_Click(object sender, EventArgs e)
        {
            
            App.Current.Actives.ActiveAvatar = new Image();
            App.Current.Actives.ActiveAvatarP = new AvatarView();
            App.Current.Actives.ActiveAvatar = QualAvatar();
            //Salvando caminho do avatar;
            App.Current.Actives.ActiveAvatarP.Avatar = (App.Current.Actives.ActiveAvatar.Source as BitmapImage).UriSource.ToString();
            App.Current.Actives.ActiveAvatarP.Id = 1;
            App.Current.Actives.ActiveAvatarP.Gravar();
            NavigationService.Navigate(new Uri("/View/FrmEscolherApelido.xaml", UriKind.Relative));
        }

        protected Image QualAvatar() 
        {
            switch (panAvatares.SelectedIndex)
            {
                case 0:
                    return imgAvatar1;
                case 1:
                    return imgAvatar2;
                case 2:
                    return imgAvatar3;
                default:
                    return null;
            }
        }
    }
}