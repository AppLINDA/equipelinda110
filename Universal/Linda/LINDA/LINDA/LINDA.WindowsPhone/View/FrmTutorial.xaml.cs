using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using LINDA.ViewModel;

namespace LINDA.View
{
    public partial class FrmTutorial : PhoneApplicationPage
    {
        // Constructor
        public FrmTutorial()
        {
            InitializeComponent();
            AvatarView escolido = AvatarViewModel.BuscarporID(1);            
            this.imgAvatarEscolhido.Source = escolido.imgAvatar;
            this.imgAvatarEscolhido1.Source = escolido.imgAvatar;
            this.imgAvatarEscolhido2.Source = escolido.imgAvatar;
            this.imgAvatarEscolhido3.Source = escolido.imgAvatar;
            this.imgAvatarEscolhido4.Source = escolido.imgAvatar;
            this.imgAvatarEscolhido5.Source = escolido.imgAvatar;
        }
    }
}