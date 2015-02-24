using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LINDA.ViewModel
{
    public class MontapratoViewModel
    {
        //TRATAMENDO DINÂMICO:
        /// <summary>
        /// Grava no banco uma Refeicao.
        /// </summary>
        /// <param name="Refeicao">Instância de Refeicao.</param>
        /// <returns> [true]: se cadastrou; [false]: se não cadastrou;</returns>
        public static bool Gravar(MontapratoView Refeicao)
        {
            try
            {
                App thisApp = Application.Current as App;
                thisApp.LINDADB.RefeicaoItems.InsertOnSubmit(Refeicao);
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
        /// Exclui uma Refeicao.
        /// </summary>
        /// <param name="Refeicao">Instância de Refeicao.</param>
        /// <returns> [true]: se conseguiu; [false]: se não conseguiu;</returns>
        public static bool Excluir(MontapratoView Refeicao)
        {
            try
            {
                App thisApp = Application.Current as App;
                var excluir = thisApp.LINDADB.RefeicaoItems.Where(a => a.Id_montaprato == Refeicao.Id_montaprato).First();
                thisApp.LINDADB.RefeicaoItems.DeleteOnSubmit(excluir);
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
        /// Altera uma Refeicao.
        /// </summary>
        /// <param name="Refeicao">Instância de Refeicao.</param>
        /// <returns> [true]: se cadastrou; [false]: se não cadastrou;</returns>
        public static bool Alterar(MontapratoView Refeicao)
        {
            try
            {
                App thisApp = Application.Current as App;

                MontapratoView update = (from com in thisApp.LINDADB.RefeicaoItems
                                       where com.Id_montaprato == Refeicao.Id_montaprato
                                       select com).First();
                //update.Datasemana = novoDia;
                update.Almoco_fk = Refeicao.Almoco_fk;
                update.Cafedamanha_fk = Refeicao.Cafedamanha_fk;
                update.Jantar_fk = Refeicao.Jantar_fk;
                update.Lanchedanoite_fk = Refeicao.Lanchedanoite_fk;
                update.Lanchemanha_fk = Refeicao.Lanchemanha_fk;
                update.Lanchetarde_fk = Refeicao.Lanchetarde_fk;
                thisApp.LINDADB.SubmitChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Lista Refeicaos ordenados por nome.
        /// </summary>
        /// <returns>Lista de Refeicao.</returns>
        public static List<MontapratoView> listar()
        {
            App thisApp = Application.Current as App;
            return (
                from MontapratoView item in thisApp.LINDADB.RefeicaoItems
                orderby item.Id_montaprato
                select item).ToList();
        }
        public static MontapratoView BuscarporIDSemana(int datasemana)
        {
            return (from com in App.Current.LINDADB.RefeicaoItems
                    where (com.Datasemana == datasemana)
                    select com).First();
        }

        //TRATAMENTO ESTÁTICO:
        public static void Iniciar()
        {
            MontapratoView lst;
            AlmocoView almoco;
            JantaView janta;
            LanchedaManhaView lm;
            LanchedaNoiteView ln;
            LanchedaTardeView lt;
            CafedaManhaView cafe;
            for (int i = 1; i <= 7; i++)
            {
                lst = new MontapratoView() { Datasemana = i, Almoco_fk = i, Cafedamanha_fk = i, Jantar_fk = i, Id_montaprato = i, Lanchedanoite_fk = i, Lanchemanha_fk = i, Lanchetarde_fk = i, Statuspronto = false };
                almoco = new AlmocoView() { Frutafk = i, GraoIntegralfk = i, Liquidofk = i, Proteinafk= i , Vegetalfk = i, Id_almoco = i};
                almoco.Gravar();
                janta = new JantaView() { Frutafk = i, GraoIntegralfk = i, Liquidofk = i, Proteinafk = i, Vegetalfk = i, Id_janta = i };
                janta.Gravar();
                lm = new LanchedaManhaView() { Frutafk = i, Id_lanchedamanha = i, Liquidofk = i, Paofk = i};
                lm.Gravar();
                ln = new LanchedaNoiteView() { Frutafk = i, Id_lanchedanoite = i, Liquidofk = i, Paofk = i };
                ln.Gravar();
                lt = new LanchedaTardeView() { Frutafk = i, Id_lanchedatarde = i, Liquidofk = i, Paofk = i };
                lt.Gravar();
                cafe = new CafedaManhaView() { Frutafk = i, Id_cafedamanha = i, Liquidofk = i, Paofk = i };
                cafe.Gravar();
                Gravar(lst);
            }
        }
    }
}
