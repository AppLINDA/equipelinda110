using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LINDA.ViewModel
{
    public class LanchedaManhaViewModel
    {
        //TRATAMENDO DINÂMICO:
        /// <summary>
        /// Grava no banco um LanchedaManha.
        /// </summary>
        /// <param name="LanchedaManha">Instância de LanchedaManha.</param>
        /// <returns> [true]: se cadastrou; [false]: se não cadastrou;</returns>
        public static bool Gravar(LanchedaManhaView LanchedaManha)
        {
            try
            {
                App.Current.LINDADB.LancheManhaItems.InsertOnSubmit(LanchedaManha);
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
        /// Exclui um LanchedaManha.
        /// </summary>
        /// <param name="LanchedaManha">Instância de LanchedaManha.</param>
        /// <returns> [true]: se conseguiu; [false]: se não conseguiu;</returns>
        public static bool Excluir(LanchedaManhaView LanchedaManha)
        {
            try
            {
                var excluir = App.Current.LINDADB.LancheManhaItems.Where(a => a.Id_lanchedamanha == LanchedaManha.Id_lanchedamanha).First();
                App.Current.LINDADB.LancheManhaItems.DeleteOnSubmit(excluir);
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
        /// Altera um LanchedaManha.
        /// </summary>
        /// <param name="LanchedaManha">Instância de LanchedaManha.</param>
        /// <returns> [true]: se cadastrou; [false]: se não cadastrou;</returns>
        public static bool Alterar(LanchedaManhaView LanchedaManha)
        {
            try
            {

                LanchedaManhaView update = (from com in App.Current.LINDADB.LancheManhaItems
                                            where com.Id_lanchedamanha == LanchedaManha.Id_lanchedamanha
                                            select com).First();
                update.Frutafk = LanchedaManha.Paofk;
                App.Current.LINDADB.SubmitChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Lista LanchedaManhas ordenados por nome.
        /// </summary>
        /// <returns>Lista de LanchedaManha.</returns>
        public static List<LanchedaManhaView> listar()
        {
            return (
                from LanchedaManhaView item in App.Current.LINDADB.LancheManhaItems
                orderby item.Id_lanchedamanha
                select item).ToList();
        }
    }
}
