using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINDA.ViewModel
{
    [Table]
    public class DiasDaSemana
    {
        private int _id;
        [Column]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _nome;
        [Column]
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
    }
}
