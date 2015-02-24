using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LINDA.ViewModel
{
    public class LanchedaTardeViewModel
    {
        //TRATAMENDO DINÂMICO:
        /// <summary>
        /// Grava no banco um LanchedaTarde.
        /// </summary>
        /// <param name="LanchedaTarde">Instância de LanchedaTarde.</param>
        /// <returns> [true]: se cadastrou; [false]: se não cadastrou;</returns>
        public static bool Gravar(LanchedaTardeView LanchedaTarde)
        {
            try
            {
                App.Current.LINDADB.LancheTardeItems.InsertOnSubmit(LanchedaTarde);
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
        /// Exclui um LanchedaTarde.
        /// </summary>
        /// <param name="LanchedaTarde">Instância de LanchedaTarde.</param>
        /// <returns> [true]: se conseguiu; [false]: se não conseguiu;</returns>
        public static bool Excluir(LanchedaTardeView LanchedaTarde)
        {
            try
            {
                var excluir = App.Current.LINDADB.LancheTardeItems.Where(a => a.Id_lanchedatarde == LanchedaTarde.Id_lanchedatarde).First();
                App.Current.LINDADB.LancheTardeItems.DeleteOnSubmit(excluir);
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
        /// Altera um LanchedaTarde.
        /// </summary>
        /// <param name="LanchedaTarde">Instância de LanchedaTarde.</param>
        /// <returns> [true]: se cadastrou; [false]: se não cadastrou;</returns>
        public static bool Alterar(LanchedaTardeView LanchedaTarde)
        {
            try
            {

                LanchedaTardeView update = (from com in App.Current.LINDADB.LancheTardeItems
                                            where com.Id_lanchedatarde == LanchedaTarde.Id_lanchedatarde
                                            select com).First();
                update.Frutafk = LanchedaTarde.Paofk;
                App.Current.LINDADB.SubmitChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Lista LanchedaTardes ordenados por nome.
        /// </summary>
        /// <returns>Lista de LanchedaTarde.</returns>
        public static List<LanchedaTardeView> listar()
        {
            return (
                from LanchedaTardeView item in App.Current.LINDADB.LancheTardeItems
                orderby item.Id_lanchedatarde
                select item).ToList();
        }
    }
}
