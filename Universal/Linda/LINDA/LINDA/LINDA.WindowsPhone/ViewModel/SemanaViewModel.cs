using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINDA.ViewModel
{
    public class SemanaViewModel
    {

        public static List<SemanaView> listar()
        {
            return (
                from SemanaView item in App.Current.LINDADB.SemanaKcalItems
                orderby item.Idsemana
                select item).ToList();
        }

        public  static bool Gravar(SemanaView semanaView)
        {
            try
            {
                App.Current.LINDADB.SemanaKcalItems.InsertOnSubmit(semanaView);
                App.Current.LINDADB.SubmitChanges();
            }
            catch (Exception error)
            {
                return false;
            }
            return true;
        }

        public static void IniciarSemanas()
        {
            List<SemanaView> lst = new List<SemanaView>();
            lst.Add(new SemanaView()
            {
                Idsemana = 1,
                Kcaltotais = 2500
            });
            lst.Add(new SemanaView()
            {
                Idsemana = 2,
                Kcaltotais = 0
            });
            for (int i = 0; i < lst.Count; i++)
            {
                lst[i].Gravar();
            }
        }

        public static bool Alterar(SemanaView semanaView)
        {
            try
            {


                SemanaView update = (from com in App.Current.LINDADB.SemanaKcalItems
                                         where com.Idsemana == semanaView.Idsemana
                                         select com).First();
                update.Kcaltotais = semanaView.Kcaltotais;
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
