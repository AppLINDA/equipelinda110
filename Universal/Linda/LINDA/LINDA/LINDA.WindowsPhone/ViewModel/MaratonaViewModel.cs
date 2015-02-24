using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LINDA.ViewModel
{
    public class MaratonaViewModel
    {
        public static List<MaratonaView> listarMaratona()
        {
            List<MaratonaView> list = new List<MaratonaView>();

            list.Add(new MaratonaView() { Dia_maratona = new DateTime(2014, 10, 07), Distanciatotal = 3, Idmaratona = 1, Kcalperdido = 195, Tempo = 60, Velocidademedia = 50 });
            list.Add(new MaratonaView() { Dia_maratona = new DateTime(2014, 10, 08), Distanciatotal = 4, Idmaratona = 2, Kcalperdido = 260, Tempo = 80, Velocidademedia = 50 });
            list.Add(new MaratonaView() { Dia_maratona = new DateTime(2014, 10, 10), Distanciatotal = 4, Idmaratona = 3, Kcalperdido = 260, Tempo = 56, Velocidademedia = 71.42 });
            list.Add(new MaratonaView() { Dia_maratona = new DateTime(2014, 10, 11), Distanciatotal = 5, Idmaratona = 4, Kcalperdido = 325, Tempo = 60, Velocidademedia = 83.3 });
            list.Add(new MaratonaView() { Dia_maratona = new DateTime(2014, 10, 12), Distanciatotal = 5.5, Idmaratona = 5, Kcalperdido = 357.5, Tempo = 60, Velocidademedia = 91.6 });
            list.Add(new MaratonaView() { Dia_maratona = new DateTime(2014, 10, 13), Distanciatotal = 6, Idmaratona = 6, Kcalperdido = 390, Tempo = 70, Velocidademedia = 85.7 });
            list.Add(new MaratonaView() { Dia_maratona = new DateTime(2014, 10, 14), Distanciatotal = 7, Idmaratona = 7, Kcalperdido = 455, Tempo = 80, Velocidademedia = 87.7 });
            list.Add(new MaratonaView() { Dia_maratona = new DateTime(2014, 10, 15), Distanciatotal = 7, Idmaratona = 8, Kcalperdido = 455, Tempo = 90, Velocidademedia = 77.7 });
            list.Add(new MaratonaView() { Dia_maratona = new DateTime(2014, 10, 16), Distanciatotal = 9.8, Idmaratona = 9, Kcalperdido = 637, Tempo = 180, Velocidademedia =  54.4});
            list.Add(new MaratonaView() { Dia_maratona = new DateTime(2014, 10, 18), Distanciatotal = 10, Idmaratona = 10, Kcalperdido = 650, Tempo = 180, Velocidademedia = 55.5 });
            return list;
        }

        public static void Iniciar() 
        {
            List<MaratonaView> list = new List<MaratonaView>();

            list = listarMaratona();
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Idmaratona = i + 1;
                Gravar(list[i]);
            }
        }

        //TRATAMENDO DINÂMICO:
        /// <summary>
        /// Grava no banco um Maratona.
        /// </summary>
        /// <param name="Maratona">Instância de Maratona.</param>
        /// <returns> [true]: se cadastrou; [false]: se não cadastrou;</returns>
        public static bool Gravar(MaratonaView Maratona)
        {
            try
            {
                App thisApp = Application.Current as App;
                thisApp.LINDADB.MaratonaItems.InsertOnSubmit(Maratona);
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
        /// Exclui um Maratona.
        /// </summary>
        /// <param name="Maratona">Instância de Maratona.</param>
        /// <returns> [true]: se conseguiu; [false]: se não conseguiu;</returns>
        public static bool Excluir(MaratonaView Maratona)
        {
            try
            {
                App thisApp = Application.Current as App;
                var excluir = thisApp.LINDADB.MaratonaItems.Where(a => a.Idmaratona == Maratona.Idmaratona).First();
                thisApp.LINDADB.MaratonaItems.DeleteOnSubmit(excluir);
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
        /// Altera uma Maratona.
        /// </summary>
        /// <param name="Maratona">Instância de Maratona.</param>
        /// <returns> [true]: se alterou; [false]: se não alterou;</returns>
        public static bool Alterar(MaratonaView Maratona)
        {
            try
            {
                App thisApp = Application.Current as App;

                MaratonaView update = (from com in thisApp.LINDADB.MaratonaItems
                                       where com.Idmaratona == Maratona.Idmaratona
                                       select com).First();
                //update.Dia_maratona = Maratona.Dia_maratona;
                update.Distanciatotal = Maratona.Distanciatotal;
                update.Kcalperdido = Maratona.Kcalperdido;
                update.Tempo = Maratona.Tempo;
                update.Velocidademedia = Maratona.Velocidademedia;
                thisApp.LINDADB.SubmitChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        //retornando histórico de maratona
        /// <summary>
        /// Lista Maratonas ordenados por nome.
        /// </summary>
        /// <returns>Lista de Maratona.</returns>
        public static List<MaratonaView> listar()
        {
            App thisApp = Application.Current as App;
            return (
                from MaratonaView item in thisApp.LINDADB.MaratonaItems
                orderby 
                item.Idmaratona,
                item.Dia_maratona descending
                select item).ToList();
        }

    }
}
