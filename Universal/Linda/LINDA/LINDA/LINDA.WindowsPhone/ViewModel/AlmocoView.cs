using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINDA.ViewModel
{
    [Table(Name = "tbl_almoco")]
    public class AlmocoView : INotifyPropertyChanged
    {
         private int _id_almoco;
        [Column(
           Name = "id_almoco",
           IsPrimaryKey = true,
           IsDbGenerated = true,
           CanBeNull = false,
           AutoSync = AutoSync.OnInsert)]
        public int Id_almoco
        {
            get { return _id_almoco; }
            set
            {
                _id_almoco = value;
            }
        }

        private int _vegetalfk;
        [Column(
            Name = "vegetalfk",
            CanBeNull = false)]
        public int Vegetalfk
        {
            get { return _vegetalfk; }
            set { _vegetalfk = value; }
        }

        private int _proteinafk;
        [Column(
            Name = "proteinafk",
            CanBeNull = false)]
        public int Proteinafk
        {
            get { return _proteinafk; }
            set
            {
                _proteinafk = value;
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

        private int _frutafk;
        [Column(
            Name = "frutafk",
            CanBeNull = false)]
        public int Frutafk
        {
            get { return _frutafk; }
            set
            {
                _frutafk = value;
            }
        }

        private int _graoIntegralfk;
        [Column(
            Name = "graoIntegralfk",
            CanBeNull = false)]
        public int GraoIntegralfk
        {
            get { return _graoIntegralfk; }
            set
            {
                _graoIntegralfk = value;
            }
        }
        public bool Gravar()
        {
            return AlmocoViewModel.Gravar(this);
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    
}
