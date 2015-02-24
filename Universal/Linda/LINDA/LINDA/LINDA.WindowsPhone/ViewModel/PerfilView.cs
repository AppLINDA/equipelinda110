using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINDA.ViewModel
{
    [Table(Name = "tbl_perfils")]
    public class PerfilView : INotifyPropertyChanged
    {
        /// <summary>
        /// Atributos da tabela tbl_perfils:
        /// </summary>

        private int _id_perfil;
        [Column(
            Name = "id_perfil",
            IsPrimaryKey = true,
            IsDbGenerated = true,
            DbType = "INT NOT NULL Identity",
            CanBeNull = false,
            AutoSync = AutoSync.OnInsert)]
        public int Id_perfil
        {
            get { return _id_perfil; }
            set
            {
                _id_perfil = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("_id_perfil"));
                }
            }
        }

        private int _indice_atividadefisica;
        [Column(
            Name = "indice_atividadefisica", CanBeNull = false)]
        public int Indiceatividadefisica
        {
            get { return _indice_atividadefisica; }
            set
            {
                _indice_atividadefisica = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("_indice_atividadefisica"));
                }
            }
        }

        private float _peso;
        [Column(
            Name = "peso", CanBeNull = false)]
        public float Peso
        {
            get { return _peso; }
            set
            {
                _peso = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("_peso"));
                }
            }
        }

        private float _altura;
        [Column(
            Name = "altura", CanBeNull = false)]
        public float Altura
        {
            get { return _altura; }
            set
            {
                _altura = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("_altura"));
                }
            }
        }
        private int _idavatar;
        [Column(
            Name = "idavatar", CanBeNull = false)]
        public int Idavatar
        {
            get { return _idavatar; }
            set {
                _idavatar = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("_idavatar"));
                }
            }
        }

        //Fim da declaração.

        // FUNÇÕES CRUD:

        /// <summary>
        /// Função que retorna uma lista de Perfils.
        /// </summary>
        /// <returns>Coleção de Perfil </returns>
        public List<PerfilView> ObtemPerfils()
        {
            return PerfilViewModel.listar();
        }

        /// <summary>
        /// Grava o Perfil.
        /// </summary>
        /// <returns>[true]: se cadastrou; [false]: se não cadastrou;</returns>
        public bool Gravar()
        {
            return PerfilViewModel.Gravar(this);
        }

        /// <summary>
        /// Exclui um Perfil.
        /// </summary>
        /// <returns>[true]: se conseguiu; [false]: se não conseguiu;</returns>
        public bool Excluir()
        {
            return PerfilViewModel.Excluir(this);
        }

        /// <summary>
        /// Altera um Perfil.
        /// </summary>
        /// <param name="qdt">Quantidade nova.</param>
        /// <returns>[true]: se conseguiu; [false]: se não conseguiu;</returns>
        public bool Alterar(int peso)
        {
            return PerfilViewModel.Alterar(this, peso);
        }

        // metodo reposánsavel por carregar o View com o objeto passado por parâmetro.
        public event PropertyChangedEventHandler PropertyChanged;

    }
}
