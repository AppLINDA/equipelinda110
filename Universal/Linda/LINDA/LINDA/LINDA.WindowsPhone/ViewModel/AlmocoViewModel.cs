using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LINDA.ViewModel
{
    public class AlmocoViewModel
    {
        //TRATAMENDO DINÂMICO:
        /// <summary>
        /// Grava no banco um Almoco.
        /// </summary>
        /// <param name="Almoco">Instância de Almoco.</param>
        /// <returns> [true]: se cadastrou; [false]: se não cadastrou;</returns>
        public static bool Gravar(AlmocoView Almoco)
        {
            try
            {
                App thisApp = Application.Current as App;
                thisApp.LINDADB.AlmocoItems.InsertOnSubmit(Almoco);
                thisApp.LINDADB.SubmitChanges();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro", MessageBoxButton.OK);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Exclui um Almoco.
        /// </summary>
        /// <param name="Almoco">Instância de Almoco.</param>
        /// <returns> [true]: se conseguiu; [false]: se não conseguiu;</returns>
        public static bool Excluir(AlmocoView Almoco)
        {
            try
            {
                App thisApp = Application.Current as App;
                var excluir = thisApp.LINDADB.AlmocoItems.Where(a => a.Id_almoco == Almoco.Id_almoco).First();
                thisApp.LINDADB.AlmocoItems.DeleteOnSubmit(excluir);
                thisApp.LINDADB.SubmitChanges();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro", MessageBoxButton.OK);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Altera um Almoco.
        /// </summary>
        /// <param name="Almoco">Instância de Almoco.</param>
        /// <param name="novoQTD">Nova quantidade.</param>
        /// <returns> [true]: se cadastrou; [false]: se não cadastrou;</returns>
        public static bool Alterar(AlmocoView Almoco, int novoQTD)
        {
            try
            {
                App thisApp = Application.Current as App;

                AlmocoView update = (from com in thisApp.LINDADB.AlmocoItems
                                     where com.Id_almoco == Almoco.Id_almoco
                                     select com).First();
                update.GraoIntegralfk = novoQTD;
                thisApp.LINDADB.SubmitChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Lista Almocos ordenados por nome.
        /// </summary>
        /// <returns>Lista de Almoco.</returns>
        public static List<AlmocoView> listar()
        {
            return (
                from AlmocoView item in App.Current.LINDADB.AlmocoItems
                orderby item.Id_almoco
                select item).ToList();
        }
    }
}
