using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINDA.ViewModel
{
    [Table(Name = "tbl_massas")]
    public class MassaView : INotifyPropertyChanged
    {
        private int _idmassa;
        [Column(
           Name = "idmassa",
           IsPrimaryKey = true,
           IsDbGenerated = true,
           CanBeNull = false,
           AutoSync = AutoSync.OnInsert)]
        public int Idmassa
        {
            get { return _idmassa; }
            set
            {
                _idmassa = value;
            }
        }

        private float _massa;
        [Column(
           Name = "massa",
           CanBeNull = false)]
        public float Massa
        {
            get { return _massa; }
            set { _massa = value; }
        }

        private DateTime _dataupdate;
        [Column(
           Name = "dataupdate",
           CanBeNull = false)]
        public DateTime Dataupadate
        {
            get { return _dataupdate; }
            set { _dataupdate = value; }
        }

        public bool Gravar()
        {
            return MassaViewModel.Gravar(this);
        }
        public List<MassaView> ObtemMassas()
        {
            return MassaViewModel.listar();
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
