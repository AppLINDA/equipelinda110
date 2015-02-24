using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINDA.ViewModel
{
    [Table(Name = "tbl_semanas")]
    public class SemanaView : INotifyPropertyChanged
    {
        private int _id_semana;
        [Column(
            Name = "id_semana",
            IsPrimaryKey = true,
            IsDbGenerated = true,
            CanBeNull = false,
            AutoSync = AutoSync.OnInsert)]
        public int Idsemana
        {
            get { return _id_semana; }
            set
            {
                _id_semana = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("_id_semana"));
                }

            }
        }
        private double _kcaltotais;
        [Column
            (Name = "kcaltotais", CanBeNull = false)]
        public double Kcaltotais
        {
            get { return _kcaltotais; }
            set {
                _kcaltotais = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("_id_kcaltotais"));
                }
            }
        }

        public bool Gravar()
        {
            return SemanaViewModel.Gravar(this);
        }
        public List<SemanaView> ObtemSemanas()
        {
            return SemanaViewModel.listar();
        }
        public bool Alterar()
        {
            return SemanaViewModel.Alterar(this);
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
