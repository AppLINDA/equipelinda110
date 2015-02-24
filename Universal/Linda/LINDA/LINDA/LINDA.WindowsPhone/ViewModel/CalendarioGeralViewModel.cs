using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LINDA.ViewModel
{
    public class CalendarioGeralViewModel
    {
        //TRATAMENDO DINÂMICO:
        /// <summary>
        /// Grava no banco um Calendario.
        /// </summary>
        /// <param name="Calendario">Instância de Calendario.</param>
        /// <returns> [true]: se cadastrou; [false]: se não cadastrou;</returns>
        public static bool Gravar(CalendarioGeralView Calendario)
        {
            try
            {
                App.Current.LINDADB.CalendarioItems.InsertOnSubmit(Calendario);
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
        /// Exclui um Calendario.
        /// </summary>
        /// <param name="Calendario">Instância de Calendario.</param>
        /// <returns> [true]: se conseguiu; [false]: se não conseguiu;</returns>
        public static bool Excluir(CalendarioGeralView Calendario)
        {
            try
            {
                var excluir = App.Current.LINDADB.CalendarioItems.Where(a => a.Id_calendario == Calendario.Id_calendario).First();
                App.Current.LINDADB.CalendarioItems.DeleteOnSubmit(excluir);
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
        /// Altera um Calendario.
        /// </summary>
        /// <param name="Calendario">Instância de Calendario.</param>
        /// <returns> [true]: se cadastrou; [false]: se não cadastrou;</returns>
        public static bool Alterar(CalendarioGeralView Calendario)
        {
            try
            {

                CalendarioGeralView update = (from com in App.Current.LINDADB.CalendarioItems
                                         where com.Id_calendario == Calendario.Id_calendario
                                         select com).First();
                update.Kcaltotais = Calendario.Kcaltotais;
                App.Current.LINDADB.SubmitChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Lista Calendarios ordenados por nome.
        /// </summary>
        /// <returns>Lista de Calendario.</returns>
        public static List<CalendarioGeralView> listar()
        {
            return (
                from CalendarioGeralView item in App.Current.LINDADB.CalendarioItems
                orderby item.Id_calendario
                select item).ToList();
        }

        //Tratamento Estático:

        public static void IniciarCalendario()
        {
            List<CalendarioGeralView> lstcalendario = new List<CalendarioGeralView>();
            int i = 1;
            lstcalendario.Add( new CalendarioGeralView()  { Ano = 2014, Id_calendario = 1, Kcaltotais = 10000, Mes = "jan", Idweek1 = i, Idweek2 = i, Idweek3 = i, Idweek4 = i });
            i++;
            lstcalendario.Add(new CalendarioGeralView() { Ano = 2014, Id_calendario = 2, Kcaltotais = 6000, Mes = "fev", Idweek1 = i, Idweek2 = i, Idweek3 = i, Idweek4 = i });
            i++;
            lstcalendario.Add(new CalendarioGeralView() { Ano = 2014, Id_calendario = 3, Kcaltotais = 5000, Mes = "mar", Idweek1 = i, Idweek2 = i, Idweek3 = i, Idweek4 = i });
            i++;
            lstcalendario.Add(new CalendarioGeralView() { Ano = 2014, Id_calendario = 4, Kcaltotais = 4500, Mes = "abr", Idweek1 = i, Idweek2 = i, Idweek3 = i, Idweek4 = i });
            i++;
            lstcalendario.Add(new CalendarioGeralView() { Ano = 2014, Id_calendario = 5, Kcaltotais = 4400, Mes = "mai", Idweek1 = i, Idweek2 = i, Idweek3 = i, Idweek4 = i });
            i++;
            lstcalendario.Add(new CalendarioGeralView() { Ano = 2014, Id_calendario = 6, Kcaltotais = 4200, Mes = "jun", Idweek1 = i, Idweek2 = i, Idweek3 = i, Idweek4 = i });
            i++;
            lstcalendario.Add(new CalendarioGeralView() { Ano = 2014, Id_calendario = 7, Kcaltotais = 3800, Mes = "jul", Idweek1 = i, Idweek2 = i, Idweek3 = i, Idweek4 = i });
            i++;
            lstcalendario.Add(new CalendarioGeralView() { Ano = 2014, Id_calendario = 8, Kcaltotais = 3000, Mes = "ago", Idweek1 = i, Idweek2 = i, Idweek3 = i, Idweek4 = i });
            i++;
            lstcalendario.Add(new CalendarioGeralView() { Ano = 2014, Id_calendario = 9, Kcaltotais = 2900, Mes = "set", Idweek1 = i, Idweek2 = i, Idweek3 = i, Idweek4 = i });
            i++;
            lstcalendario.Add(new CalendarioGeralView() { Ano = 2014, Id_calendario = 10, Kcaltotais = 2600, Mes = "out", Idweek1 = i, Idweek2 = i, Idweek3 = i, Idweek4 = i });

            for (i = 0; i < lstcalendario.Count; i++)
            {
                lstcalendario[i].Gravar();   
            }
        }
    }
}
