using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINDA.ViewModel
{
    [Table(Name = "tbl_nutricionistas")]
    public class NutricionistaView : INotifyPropertyChanged
    {
        /// <summary>
        /// Atributos da tabela tbl_nutricionistas:
        /// </summary>
        private int _id_nutricionista;
        [Column]
        public int Id_nutricionista
        {
            get { return _id_nutricionista; }
            set { _id_nutricionista = value; }
        }

        private string _nome;
        [Column]
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        private string _pnome;
        [Column]
        public string PrimeiroNome
        {
            get { return _pnome; }
            set { _pnome = value; }
        }

        private string _unome;
        [Column]
        public string UltimoNome
        {
            get { return _unome; }
            set { _unome = value; }
        }

        private string _especialidade;
        [Column]
        public string Especialidade
        {
            get { return _especialidade; }
            set { _especialidade = value; }
        }

        private string _img;
        [Column]
        public string Img_source
        {
            get { return _img; }
            set { _img = value; }
        }

        private string _bairro;
        [Column]
        public string Bairro
        {
            get { return _bairro; }
            set { _bairro = value; }
        }

        private string _endereco;
        [Column]
        public string Endereco
        {
            get { return _endereco; }
            set { _endereco = value; }
        }

        private string _telefone;
        [Column]
        public string Telefone
        {
            get { return _telefone; }
            set { _telefone = value; }
        }

        private string _email;
        [Column]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }


        // metodo reposánsavel por carregar o View com o objeto passado por parâmetro.
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
