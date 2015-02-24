using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LINDA.ViewModel
{
    public class CafedaManhaViewModel
    {
        //TRATAMENDO DINÂMICO:
        /// <summary>
        /// Grava no banco um CafedaManha.
        /// </summary>
        /// <param name="CafedaManha">Instância de CafedaManha.</param>
        /// <returns> [true]: se cadastrou; [false]: se não cadastrou;</returns>
        public static bool Gravar(CafedaManhaView CafedaManha)
        {
            try
            {
                App.Current.LINDADB.CafeManhaItems.InsertOnSubmit(CafedaManha);
                App.Current.LINDADB.SubmitChanges();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro", MessageBoxButton.OK);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Exclui um CafedaManha.
        /// </summary>
        /// <param name="CafedaManha">Instância de CafedaManha.</param>
        /// <returns> [true]: se conseguiu; [false]: se não conseguiu;</returns>
        public static bool Excluir(CafedaManhaView CafedaManha)
        {
            try
            {
                var excluir = App.Current.LINDADB.CafeManhaItems.Where(a => a.Id_cafedamanha == CafedaManha.Id_cafedamanha).First();
                App.Current.LINDADB.CafeManhaItems.DeleteOnSubmit(excluir);
                App.Current.LINDADB.SubmitChanges();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro", MessageBoxButton.OK);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Altera um CafedaManha.
        /// </summary>
        /// <param name="CafedaManha">Instância de CafedaManha.</param>
        /// <returns> [true]: se cadastrou; [false]: se não cadastrou;</returns>
        public static bool Alterar(CafedaManhaView CafedaManha)
        {
            try
            {

                CafedaManhaView update = (from com in App.Current.LINDADB.CafeManhaItems
                                          where com.Id_cafedamanha == CafedaManha.Id_cafedamanha
                                          select com).First();
                update.Frutafk = CafedaManha.Paofk;
                App.Current.LINDADB.SubmitChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Lista CafedaManhas ordenados por nome.
        /// </summary>
        /// <returns>Lista de CafedaManha.</returns>
        public static List<CafedaManhaView> listar()
        {
            return (
                from CafedaManhaView item in App.Current.LINDADB.CafeManhaItems
                orderby item.Id_cafedamanha
                select item).ToList();
        }
    }
}
