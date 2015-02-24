using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LINDA.ViewModel
{
    public class LanchedaNoiteViewModel
    {
        //TRATAMENDO DINÂMICO:
        /// <summary>
        /// Grava no banco um LanchedaNoite.
        /// </summary>
        /// <param name="LanchedaNoite">Instância de LanchedaNoite.</param>
        /// <returns> [true]: se cadastrou; [false]: se não cadastrou;</returns>
        public static bool Gravar(LanchedaNoiteView LanchedaNoite)
        {
            try
            {
                App.Current.LINDADB.LancheNoiteItems.InsertOnSubmit(LanchedaNoite);
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
        /// Exclui um LanchedaNoite.
        /// </summary>
        /// <param name="LanchedaNoite">Instância de LanchedaNoite.</param>
        /// <returns> [true]: se conseguiu; [false]: se não conseguiu;</returns>
        public static bool Excluir(LanchedaNoiteView LanchedaNoite)
        {
            try
            {
                var excluir = App.Current.LINDADB.LancheNoiteItems.Where(a => a.Id_lanchedanoite == LanchedaNoite.Id_lanchedanoite).First();
                App.Current.LINDADB.LancheNoiteItems.DeleteOnSubmit(excluir);
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
        /// Altera um LanchedaNoite.
        /// </summary>
        /// <param name="LanchedaNoite">Instância de LanchedaNoite.</param>
        /// <returns> [true]: se cadastrou; [false]: se não cadastrou;</returns>
        public static bool Alterar(LanchedaNoiteView LanchedaNoite)
        {
            try
            {

                LanchedaNoiteView update = (from com in App.Current.LINDADB.LancheNoiteItems
                                            where com.Id_lanchedanoite == LanchedaNoite.Id_lanchedanoite
                                            select com).First();
                update.Frutafk = LanchedaNoite.Paofk;
                App.Current.LINDADB.SubmitChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Lista LanchedaNoites ordenados por nome.
        /// </summary>
        /// <returns>Lista de LanchedaNoite.</returns>
        public static List<LanchedaNoiteView> listar()
        {
            return (
                from LanchedaNoiteView item in App.Current.LINDADB.LancheNoiteItems
                orderby item.Id_lanchedanoite
                select item).ToList();
        }
    }
}
