using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace LINDA.ViewModel
{
    //implementar os métodos para o Avatar
    public class AvatarViewModel 
    {                
        public static bool inserir(AvatarView item)
        {
            try
            {
                App thisApp = Application.Current as App;
                thisApp.LINDADB.AvatarItems.InsertOnSubmit(item);
                thisApp.LINDADB.SubmitChanges();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro", MessageBoxButton.OK);
                return false;
            }
            return true;
        }
        //retorna uma lista de Avatar
        public static List<AvatarView> listar()
        {
            App thisApp = Application.Current as App;
            return (from AvatarView item in thisApp.LINDADB.AvatarItems
                        select item).ToList();
        }
        public static AvatarView BuscarporID(int id)
        {
            return (from com in App.Current.LINDADB.AvatarItems
                    where (com.Id == id)
                    select com).First();
        }

        public static bool Alterar(AvatarView av)
        {
            try
            {

                AvatarView update = (from com in App.Current.LINDADB.AvatarItems
                                         where com.Id == av.Id
                                         select com).First();
                update.Name = av.Name;
                update.Avatar = av.Avatar;
                App.Current.LINDADB.SubmitChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}