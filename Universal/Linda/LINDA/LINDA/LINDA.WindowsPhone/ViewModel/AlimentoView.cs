using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
namespace LINDA.ViewModel
{
    [Table( Name = "tbl_alimentos" )]
    public class AlimentoView : INotifyPropertyChanged
    {
        /// <summary>
        /// Atributos da tabela alimento:
        /// </summary>
        private int _id_alimento;
        [Column(
            Name = "id_alimento",
            IsPrimaryKey = true,
            IsDbGenerated = true,
            CanBeNull = false,
            AutoSync = AutoSync.OnInsert )]
        public int Id_alimento
        {
            get { return _id_alimento; }
            set 
            {
                _id_alimento = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("_id_alimento"));
                }
            }
        }

        private string _nome;
        [Column(
            Name="nome", CanBeNull = false )]
        public string Nome
        {
            get { return _nome; }
            set 
            { 
                _nome = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("_nome"));
                }
            }
        }

        private double _calorias;
        [Column(
            Name = "calorias", CanBeNull = false)]
        public double Calorias
        {
            get { return _calorias; }
            set { _calorias = value; }
        }

        private int _tipo;
        [Column(
            Name = "tipo", CanBeNull = false)]
        public int Tipo
        {
            get { 
                return _tipo; 
            }
            set { _tipo = value; }
        }

        private string _img_source;
        [Column(
            Name = "img_source", CanBeNull = false)]
        public string Img_source
        {
            get { return _img_source; }
            set { _img_source = value; }
        }

        private int _quantidade;
        [Column(
            Name = "quantidade", CanBeNull = false)]
        public int Quantidade
        {
            get { return _quantidade; }
            set { _quantidade = value; }
        }

        private string _descricao;
        [Column(
            Name = "descricao", CanBeNull = false)]
        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }

        public string TipoNome
        {
         /*
          * Classificação!
          * * LÍQUIDO: 1
          * * Vegetal: 2
          * * Grãos: 3
          * * Frutas: 4
          * * Proteínas: 5
          * * PÃO: 7
          */
            get
            {
                switch (_tipo)
                {
                    case 1:
                        return "Liquido";
                    case 2:
                        return "Vegetal";
                    case 3:
                        return "Grãos";
                    case 4:
                        return "Frutas";
                    case 5:
                        return "Proteína";
                    case 6:
                        return "Pão";
                    default:
                        return "Tipo não encontrado";
                };
            }
            
        }
        //Fim da declaração.

        // FUNÇÕES CRUD:

        /// <summary>
        /// Função que retorna uma lista de alimentos.
        /// </summary>
        /// <returns>Coleção de alimento </returns>
        public List<AlimentoView> ObtemAlimentos()
        {
            return AlimentoViewModel.listar();
        }

        /// <summary>
        /// Grava o alimento.
        /// </summary>
        /// <returns>[true]: se cadastrou; [false]: se não cadastrou;</returns>
        public bool Gravar()
        {
            return AlimentoViewModel.Gravar( this );
        }

        /// <summary>
        /// Exclui um alimento.
        /// </summary>
        /// <returns>[true]: se conseguiu; [false]: se não conseguiu;</returns>
        public bool Excluir()
        {
            return AlimentoViewModel.Excluir(this);
        }

        /// <summary>
        /// Altera um alimento.
        /// </summary>
        /// <param name="qdt">Quantidade nova.</param>
        /// <returns>[true]: se conseguiu; [false]: se não conseguiu;</returns>
        public bool Alterar( int qdt)
        {
            return AlimentoViewModel.Alterar(this, qdt);
        }

        public ImageSource ImgConvertedSource ()
        {
            return AlimentoViewModel.ImgConvertedSource(this);
        }


        //* Propriedade responsável por comunicar a modificação do valor de uma variável
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
