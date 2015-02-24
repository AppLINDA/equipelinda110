using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINDA.ViewModel
{
    [Table(Name = "tbl_maratonas")]
    public class MaratonaView : INotifyPropertyChanged
    {
        /**
        * Propriedade responsável por comunicar a modificação do valor de uma variável
        */
        public event PropertyChangedEventHandler PropertyChanged;

        private int _id_maratona;
        [Column
        (
        Name = "id_maratona",
        IsPrimaryKey = true,
        IsDbGenerated = true,
        DbType = "INT NOT NULL Identity",
        CanBeNull = false,
        AutoSync = AutoSync.OnInsert)]
        public int Idmaratona
        {
            get { return _id_maratona; }
            set
            {
                _id_maratona = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("_id_maratona"));
                }
            }
        }

        private double _tempo;//em segundos;
        [Column(
            Name = "tempo", CanBeNull = false)]
        public double Tempo
        {
            get { return _tempo; }
            set
            {
                _tempo = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("_tempo"));
                }
            }
        }

        private double _distanciatotal;//em metros;
        [Column(
            Name = "distanciatotal", CanBeNull = false)]
        public double Distanciatotal
        {
            get { return _distanciatotal; }
            set
            {
                _distanciatotal = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("_distanciatotal"));
                }
            }
        }

        private DateTime _dia_maratona;//data da maratona;
        [Column(
            Name = "dia_maratona", CanBeNull = false)]
        public DateTime Dia_maratona
        {
            get { return _dia_maratona; }
            set
            {
                _dia_maratona = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("_dia_maratona"));
                }
            }
        }
        private double _velocidademedia;// em metros por segundo
        [Column(
            Name = "velocidademedia", CanBeNull = false)]
        public double Velocidademedia
        {
            get { return _velocidademedia; }
            set
            {
                _velocidademedia = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("_velocidademedia"));
                }
            }
        }

        private double _kcalperdido;
        [Column(
            Name = "kcalperdido", CanBeNull = false)]
        public double Kcalperdido
        {
            get { return _kcalperdido; }
            set
            {
                _kcalperdido = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("_kcalperdido"));
                }
            }
        }

        public string Datanormal
        {
            get
            {
                return _dia_maratona.Date.ToShortDateString();
            }
        }
        public string Datasemana{
            get {
                switch (_dia_maratona.Date.DayOfWeek.ToString())
                {
                    case "Tuesday":
                        return "Terça-feira"; 
                    case "Friday":
                        return "Sexta-feira"; 
                    case "Wednesday":
                        return "Quarta-feira";
                    case "Saturday":
                        return "Sábado";
                    case "Thursday":
                        return "Quinta-feira";
                    case "Monday":
                        return "Segunda-feira";
                    case "Sunday":
                        return "Domingo";
                    default:
                        return ""; 
                }
               }
            
        }


        /// <summary>
        /// Função que retorna uma lista de Maratonas.
        /// </summary>
        /// <returns>Coleção de Maratona </returns>
        public List<MaratonaView> ObtemMaratonas()
        {
            return MaratonaViewModel.listar();
        }

        /// <summary>
        /// Grava o Maratona.
        /// </summary>
        /// <returns>[true]: se cadastrou; [false]: se não cadastrou;</returns>
        public bool Gravar()
        {
            return MaratonaViewModel.Gravar(this);
        }

        /// <summary>
        /// Exclui um Maratona.
        /// </summary>
        /// <returns>[true]: se conseguiu; [false]: se não conseguiu;</returns>
        public bool Excluir()
        {
            return MaratonaViewModel.Excluir(this);
        }

        /// <summary>
        /// Altera uma maratona.
        /// </summary>
        /// <returns>[true]: se conseguiu; [false]: se não conseguiu;</returns>
        public bool Alterar()
        {
            return MaratonaViewModel.Alterar(this);
        }
    }
}
