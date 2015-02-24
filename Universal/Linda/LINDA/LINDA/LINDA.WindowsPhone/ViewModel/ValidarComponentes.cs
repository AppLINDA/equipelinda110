using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LINDA.ViewModel
{
    public static class ValidarComponentes
    {
        /**
         * Este método valida os tipos de componentes mais comuns:
         * 1: TexBox de texto simples
         * 2: TexBox numérico
         **/
        public static  bool ValidarTextBox( object txt, int Type)
        {
            TextBox txtBox = ( TextBox )txt;
            switch ( Type )
            {
                case 1:
                    return txtBox.Text != "";  
                case 2:
                    return txtBox.Text != ""  && txtBox.Text != ".";
                default:
                    return false;
            }
        }
        
        /**
         * Este método envia uma messagem de alerta
         * Em caso de erros de preenchimento de campo
         **/
        public static void msgValidacao1() 
        {
            MessageBox.Show("Verifique se os campos têm valores válidos, por favor", "Erro de preenchimento", MessageBoxButton.OK);
        }

    }
}
