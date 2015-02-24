using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINDA.ViewModel
{
     [Table(Name = "tbl_lanchedanoite")]
    public class LanchedaNoiteView : INotifyPropertyChanged
    {                           
         
        private int _id_lanchedanoite;
        [Column(
           Name = "id_lanchedanoite",
           IsPrimaryKey = true,
           IsDbGenerated = true,
           CanBeNull = false,
           AutoSync = AutoSync.OnInsert)]
        public int Id_lanchedanoite
        {
            get { return _id_lanchedanoite; }
            set
            {
                _id_lanchedanoite = value;
            }
        }

        private int _paofk;
        [Column(
            Name = "paofk",
            CanBeNull = false)]
        public int Paofk
        {
            get { return _paofk; }
            set
            {
                _paofk = value;
            }
        }

        private int _id_frutafk;
        [Column(
            Name = "frutafk",
            CanBeNull = false)]
        public int Frutafk
        {
            get { return _id_frutafk; }
            set
            {
                _id_frutafk = value;
            }
        }

        private int _liquidofk;
        [Column(
            Name = "liquidofk",
            CanBeNull = false)]
        public int Liquidofk
        {
            get { return _liquidofk; }
            set
            {
                _liquidofk = value;
            }
        }
        public bool Gravar()
        {
            return LanchedaNoiteViewModel.Gravar(this);
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
