using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Data.Linq.Mapping;
using System.Windows.Media;
using System.Windows.Media.Imaging;
namespace LINDA.ViewModel
{
    [Table]
    public class AvatarView : INotifyPropertyChanged
    {
        private string _name;
        [Column]
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("_name"));
                }
            }
        }

        private string _avatar;
        [Column]
        public string Avatar
        {
            get { return _avatar; }
            set
            {
                _avatar = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("_avatar"));
                }
            }
        }

        private int _id;
        [Column (
             IsPrimaryKey=true,
             IsDbGenerated=true,
             DbType="INT NOT NULL Identity", 
             CanBeNull= false ,
             AutoSync=AutoSync.OnInsert)]
        public int Id
        {
            get { return _id; }
            set {
                _id = value;
                if (PropertyChanged!= null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("_id"));
                }
            }
        }

        public ImageSource imgAvatar
        {
            get
            {
                return new BitmapImage (new Uri(_avatar, UriKind.RelativeOrAbsolute)); 
            }
        }

        /**
         * Propriedade responsável por comunicar a modificação do valor de uma variável
         */
        public List<MaratonaView> ObtemMaratonas()
        {
            return MaratonaViewModel.listar();
        }

        
        public bool Gravar()
        {
            return AvatarViewModel.inserir(this);
        }


        /// <summary>
        /// Altera uma maratona.
        /// </summary>
        /// <returns>[true]: se conseguiu; [false]: se não conseguiu;</returns>
        public bool Alterar()
        {
            return AvatarViewModel.Alterar(this);
        }

        public AvatarView BuscarById( int id)
        {
            return AvatarViewModel.BuscarporID(id);
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}