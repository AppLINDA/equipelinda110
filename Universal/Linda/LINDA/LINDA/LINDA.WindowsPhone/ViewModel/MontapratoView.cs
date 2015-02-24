using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINDA.ViewModel
{
    [Table(Name = "tbl_montaprato")]
    public class MontapratoView : INotifyPropertyChanged
    {
        /// <summary>
        /// Atributos da tabela tbl_refeicoes:
        /// </summary>

        private int _id_montaprato;
        [Column(
            Name = "id_montaprato",
            IsPrimaryKey = true,
            IsDbGenerated = true,
            CanBeNull = false,
            AutoSync = AutoSync.OnInsert)]
        public int Id_montaprato
        {
            get { return _id_montaprato; }
            set 
            {
                _id_montaprato = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("_id_montaprato"));
                }
 
            }
        }
        
        private int _datasemana;
        [Column
            ( Name="datasemana" ,CanBeNull = false )]
        public int Datasemana
        {
            get { return _datasemana; }
            set {
                _datasemana = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("_datasemana"));
                }
            }
        }

        private int _cafedamanha_fk;
        [Column(Name = "cafedamanha_fk", CanBeNull = false)]
        public int Cafedamanha_fk
        {
            get { return _cafedamanha_fk; }
            set { 
                _cafedamanha_fk = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("_cafedamanha_fk"));
                }
            }
        }

        private int _jantar_fk;
        [Column(Name = "jantar_fk", CanBeNull = false)]
        public int Jantar_fk
        {
            get { return _jantar_fk; }
            set { 
                _jantar_fk = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("_jantar_fk"));
                }
            }
        }

        private int _almoco_fk;
        [Column(Name = "almoco_fk", CanBeNull = false)]
        public int Almoco_fk
        {
            get { return _almoco_fk; }
            set {
                _almoco_fk = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("_almoco_fk"));
                }
            }
        }

        private int _lanchetarde_fk;
        [Column(Name = "lanchetarde_fk", CanBeNull = false)]
        public int Lanchetarde_fk
        {
            get { return _lanchetarde_fk; }
            set { 
                _lanchetarde_fk = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("_lanchetarde_fk"));
                }
            }
        }

        private int _lanchemanha_fk;
        [Column(Name = "lanchemanha_fk", CanBeNull = false)]
        public int Lanchemanha_fk
        {
            get { return _lanchemanha_fk; }
            set { _lanchemanha_fk = value;
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs("_lanchemanha_fk"));
            }
            }
        }

        private int _lanchedanoite_fk;
        [Column(Name = "lanchedanoite_fk", CanBeNull = false)]
        public int Lanchedanoite_fk
        {
            get { return _lanchedanoite_fk; }
            set { _lanchedanoite_fk = value;
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs("_lanchedanoite_fk"));
            }
            }
        }
        private bool _statuspronto;
        [Column(
            Name = "statuspronto", CanBeNull = false)]
        public bool Statuspronto
        {
            get { return _statuspronto; }
            set
            {
                _statuspronto = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("_statuspronto"));
                }
            }
        }

        //Fim da declaração.

        // FUNÇÕES CRUD:

        /// <summary>
        /// Função que retorna uma lista de Refeicoes.
        /// </summary>
        /// <returns>Coleção de Refeicao </returns>
        public List<MontapratoView> ObtemRefeicoes()
        {
            return MontapratoViewModel.listar();
        }

        /// <summary>
        /// Grava uma Refeicao.
        /// </summary>
        /// <returns>[true]: se cadastrou; [false]: se não cadastrou;</returns>
        public bool Gravar()
        {
            return MontapratoViewModel.Gravar(this);
        }

        /// <summary>
        /// Exclui uma Refeicao.
        /// </summary>
        /// <returns>[true]: se conseguiu; [false]: se não conseguiu;</returns>
        public bool Excluir()
        {
            return MontapratoViewModel.Excluir(this);
        }

        /// <summary>
        /// Altera uma Refeicao.
        /// </summary>
        /// <param name="kcal">Quantidade nova.</param>
        /// <returns>[true]: se conseguiu; [false]: se não conseguiu;</returns>
        public bool Alterar()
        {
            return MontapratoViewModel.Alterar(this);
        }

        /// <summary>
        /// metodo reposánsavel por carregar o View com o objeto passado por parâmetro.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
