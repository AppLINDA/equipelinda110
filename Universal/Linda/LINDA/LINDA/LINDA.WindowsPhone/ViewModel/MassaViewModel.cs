using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LINDA.ViewModel
{
    public class MassaViewModel
    {
        public static bool Gravar(MassaView massaView)
        {
            try
            {
                
                App.Current.LINDADB.MassaItems.InsertOnSubmit(massaView);
                App.Current.LINDADB.SubmitChanges();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro", MessageBoxButton.OK);
                return false;
            }
            return true;
        }

        public static List<MassaView> listar()
        {
            return (
                from MassaView item in App.Current.LINDADB.MassaItems
                orderby
                item.Idmassa ascending
                select item).ToList();
        }
    }
}
