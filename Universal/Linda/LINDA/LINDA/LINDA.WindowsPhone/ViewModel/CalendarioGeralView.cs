using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINDA.ViewModel
{
    [Table( Name = "tbl_calendarios" )]
    public class CalendarioGeralView : INotifyPropertyChanged
    {
        /// <summary>
        ///  Atributos da tabela calendario:
        /// </summary>
        private int _id_calendario;
        [Column(
            Name = "id_calendario",
            IsPrimaryKey = true,
            IsDbGenerated = true,
            CanBeNull = false,
            AutoSync = AutoSync.OnInsert )]
        public int Id_calendario
        {
            get { return _id_calendario; }
            set { _id_calendario = value; }
        }

        private string _mes;
        [Column( Name = "mes",
            CanBeNull = false)]
        public string Mes
        {
            get { return _mes; }
            set { _mes = value; }
        }
        private int _ano;
        [Column(Name = "ano",
            CanBeNull = false)]
        public int Ano
        {
            get { return _ano; }
              set { _ano = value; }
        }

        private double _kcaltotais;
        [Column(Name = "kcaltotais",
            CanBeNull = false)]
        public double Kcaltotais
        {
            get { return _kcaltotais; }
            set { _kcaltotais = value; }
        }
        private int _idweek1;
        [Column(Name = "idweek1",
            CanBeNull = false)]
        public int Idweek1
        {
            get { return _idweek1; }
            set { _idweek1 = value; }
        }
        private int _idweek2;
        [Column(Name = "idweek2",
            CanBeNull = false)]
        public int Idweek2
        {
            get { return _idweek2; }
            set { _idweek2 = value; }
        }
        private int _idweek3;
        [Column(Name = "idweek3",
            CanBeNull = false)]
        public int Idweek3
        {
            get { return _idweek3; }
            set { _idweek3 = value; }
        }
        private int _idweek4;
        [Column(Name = "idweek4",
            CanBeNull = false)]
        public int Idweek4
        {
            get { return _idweek4; }
            set { _idweek4 = value; }
        }

        //Fim da declaração.

        // FUNÇÕES CRUD:

        /// <summary>
        /// Função que retorna uma lista de CalendarioGerals.
        /// </summary>
        /// <returns>Coleção de CalendarioGeral </returns>
        public List<CalendarioGeralView> ObtemCalendarioGerals()
        {
            return CalendarioGeralViewModel.listar();
        }

        /// <summary>
        /// Grava o CalendarioGeral.
        /// </summary>
        /// <returns>[true]: se cadastrou; [false]: se não cadastrou;</returns>
        public bool Gravar()
        {
            return CalendarioGeralViewModel.Gravar(this);
        }

        /// <summary>
        /// Exclui um CalendarioGeral.
        /// </summary>
        /// <returns>[true]: se conseguiu; [false]: se não conseguiu;</returns>
        public bool Excluir()
        {
            return CalendarioGeralViewModel.Excluir(this);
        }

        /// <summary>
        /// Altera uma CalendarioGeral.
        /// </summary>
        /// <returns>[true]: se conseguiu; [false]: se não conseguiu;</returns>
        public bool Alterar()
        {
            return CalendarioGeralViewModel.Alterar(this);
        }
        //* Propriedade responsável por comunicar a modificação do valor de uma variável
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
