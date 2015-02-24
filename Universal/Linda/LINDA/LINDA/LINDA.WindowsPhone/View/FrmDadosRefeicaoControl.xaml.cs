using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace LINDA.View
{
    public partial class FrmDadosRefeicaoControl : UserControl
    {
         public List<int> IdsSelected;
        public FrmDadosRefeicaoControl()
        {
            InitializeComponent();
            IdsSelected = new List<int>();
        }
        

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox selecionado = sender as CheckBox;
            IdsSelected.Add( int.Parse( selecionado.Content.ToString() ) );
        }
        private void CheckBox_DesCheckar(object sender, RoutedEventArgs e)
        {
            CheckBox selecionado = sender as CheckBox;
            IdsSelected.Remove( int.Parse( selecionado.Content.ToString()) );
        }
    }
}
