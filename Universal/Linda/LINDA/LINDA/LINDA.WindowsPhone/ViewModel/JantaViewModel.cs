using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LINDA.ViewModel
{
    public class JantaViewModel
    {
        //TRATAMENDO DINÂMICO:
        /// <summary>
        /// Grava no banco um Janta.
        /// </summary>
        /// <param name="Janta">Instância de Janta.</param>
        /// <returns> [true]: se cadastrou; [false]: se não cadastrou;</returns>
        public static bool Gravar(JantaView Janta)
        {
            try
            {
                App.Current.LINDADB.JantarItems.InsertOnSubmit(Janta);
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
        /// Exclui um Janta.
        /// </summary>
        /// <param name="Janta">Instância de Janta.</param>
        /// <returns> [true]: se conseguiu; [false]: se não conseguiu;</returns>
        public static bool Excluir(JantaView Janta)
        {
            try
            {
                var excluir = App.Current.LINDADB.JantarItems.Where(a => a.Id_janta == Janta.Id_janta).First();
                App.Current.LINDADB.JantarItems.DeleteOnSubmit(excluir);
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
        /// Altera um Janta.
        /// </summary>
        /// <param name="Janta">Instância de Janta.</param>
        /// <returns> [true]: se cadastrou; [false]: se não cadastrou;</returns>
        public static bool Alterar(JantaView Janta)
        {
            try
            {

                JantaView update = (from com in App.Current.LINDADB.JantarItems
                                    where com.Id_janta == Janta.Id_janta
                                    select com).First();
                update.Frutafk = Janta.Vegetalfk;
                App.Current.LINDADB.SubmitChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Lista Jantas ordenados por nome.
        /// </summary>
        /// <returns>Lista de Janta.</returns>
        public static List<JantaView> listar()
        {
            return (
                from JantaView item in App.Current.LINDADB.JantarItems
                orderby item.Id_janta
                select item).ToList();
        }
    }
}
