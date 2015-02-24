using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LINDA.ViewModel
{
    public class PerfilViewModel
    {

        //TRATAMENDO DINÂMICO:
        /// <summary>
        /// Grava no banco um Perfil.
        /// </summary>
        /// <param name="Perfil">Instância de Perfil.</param>
        /// <returns> [true]: se cadastrou; [false]: se não cadastrou;</returns>
        public static bool Gravar(PerfilView Perfil)
        {
            try
            {
                App thisApp = Application.Current as App;
                thisApp.LINDADB.PerfilItems.InsertOnSubmit(Perfil);
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
        /// Exclui um perfil.
        /// </summary>
        /// <param name="perfil">Instância de perfil.</param>
        /// <returns> [true]: se conseguiu; [false]: se não conseguiu;</returns>
        public static bool Excluir(PerfilView perfil)
        {
            try
            {
                App thisApp = Application.Current as App;
                var excluir = thisApp.LINDADB.PerfilItems.Where(a => a.Id_perfil == perfil.Id_perfil).First();
                thisApp.LINDADB.PerfilItems.DeleteOnSubmit(excluir);
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
        /// Altera um perfil.
        /// </summary>
        /// <param name="perfil">Instância de perfil.</param>
        /// <param name="novoPeso">Novo peso.</param>
        /// <returns> [true]: se cadastrou; [false]: se não cadastrou;</returns>
        public static bool Alterar(PerfilView perfil, int novoPeso)
        {
            try
            {
                App thisApp = Application.Current as App;

                PerfilView update = (from com in thisApp.LINDADB.PerfilItems
                                     where com.Id_perfil == perfil.Id_perfil
                                     select com).First();
                update.Peso = novoPeso;
                thisApp.LINDADB.SubmitChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Lista perfils ordenados por nome.
        /// </summary>
        /// <returns>Lista de perfil.</returns>
        public static List<PerfilView> listar()
        {
            App thisApp = Application.Current as App;
            return (
                from PerfilView item in thisApp.LINDADB.PerfilItems
                orderby item.Id_perfil
                select item).ToList();
        }

    }
}