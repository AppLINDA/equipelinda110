using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LINDA.ViewModel
{
    public class AlimentoViewModel
    {
        /*
         * LÍQUIDO: 1
         * Vegetal: 2
         * Grãos: 3
         * Frutas: 4
         * Proteínas: 5
         * PÃO: 6
         */
        //TRATAMENDO DINÂMICO:
        /// <summary>
        /// Grava no banco um alimento.
        /// </summary>
        /// <param name="alimento">Instância de alimento.</param>
        /// <returns> [true]: se cadastrou; [false]: se não cadastrou;</returns>
        public static bool Gravar(AlimentoView alimento)
        {
            try
            {
                App thisApp = Application.Current as App;
                thisApp.LINDADB.AlimentoItems.InsertOnSubmit(alimento);
                thisApp.LINDADB.SubmitChanges();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro", MessageBoxButton.OK);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Exclui um alimento.
        /// </summary>
        /// <param name="alimento">Instância de alimento.</param>
        /// <returns> [true]: se conseguiu; [false]: se não conseguiu;</returns>
        public static bool Excluir(AlimentoView alimento)
        {
            try
            {
                App thisApp = Application.Current as App;
                var excluir = thisApp.LINDADB.AlimentoItems.Where(a => a.Id_alimento == alimento.Id_alimento).First();
                thisApp.LINDADB.AlimentoItems.DeleteOnSubmit(excluir);
                thisApp.LINDADB.SubmitChanges();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro", MessageBoxButton.OK);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Altera um alimento.
        /// </summary>
        /// <param name="alimento">Instância de alimento.</param>
        /// <param name="novoQTD">Nova quantidade.</param>
        /// <returns> [true]: se cadastrou; [false]: se não cadastrou;</returns>
        public static bool Alterar(AlimentoView alimento, int novoQTD)
        {
            try
            {
                App thisApp = Application.Current as App;

                AlimentoView update = (from com in thisApp.LINDADB.AlimentoItems
                                       where com.Id_alimento == alimento.Id_alimento
                                       select com).First();
                update.Quantidade = novoQTD;
                thisApp.LINDADB.SubmitChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Lista alimentos ordenados por nome.
        /// </summary>
        /// <returns>Lista de alimento.</returns>
        public static List<AlimentoView> listar()
        {
            App thisApp = Application.Current as App;
            return (
                from AlimentoView item in thisApp.LINDADB.AlimentoItems
                orderby item.Nome
                select item).ToList();
        }

        //TRATAMENTO ESTÁTICO:
        public static List<AlimentoView> listarvegetal()
        {
            List<AlimentoView> list = new List<AlimentoView>();
            list.Add(new AlimentoView(){
                Tipo =2 ,
                Nome = "Alface", 
                Img_source = "/Assets/Fatias/Vegetais/Alface.jpg", 
                Calorias = 45.8, 
                Quantidade = 3, 
                Descricao = "porcao"
            });
            list.Add(new AlimentoView() { 
                Tipo = 2, 
                Nome = "Beterraba", 
                Img_source = "/Assets/Fatias/Vegetais/Beterraba.jpg", 
                Calorias = 45.8, 
                Quantidade = 3, 
                Descricao = "porcao" 
            });
            list.Add(new AlimentoView() { 
                Tipo = 2, 
                Nome = "Brócolis", 
                Img_source = "/Assets/Fatias/Vegetais/Brocolis.jpg", 
                Calorias = 45.8, 
                Quantidade = 3, 
                Descricao = "porcao" 
            });
            list.Add(new AlimentoView() { 
                Tipo = 2, 
                Nome = "Couve", 
                Img_source = "/Assets/Fatias/Vegetais/Couve.jpg", 
                Calorias = 45.8, 
                Quantidade = 3, 
                Descricao = "porcao" 
            });
            list.Add(new AlimentoView() {
                Tipo = 2, Nome = "Quiabo", 
                Img_source = "/Assets/Fatias/Vegetais/Quiabo.jpg", 
                Calorias = 45.8, 
                Quantidade = 3, 
                Descricao = "porcao" 
            });
            list.Add(new AlimentoView()
            {
                Tipo = 2,
                Nome = "Agrião",
                Img_source = "/Assets/Fatias/Vegetais/Agriao.jpg",
                Calorias = 45.8,
                Quantidade = 3,
                Descricao = "porcao"
            });
            list.Add(new AlimentoView()
            {
                Tipo = 2,
                Nome = "Espinafre",
                Img_source = "/Assets/Fatias/Vegetais/Espinafre.jpg",
                Calorias = 45.8,
                Quantidade = 3,
                Descricao = "porcao"
            });         
            return list;
        }

        public static List<AlimentoView> listarGraoIntegral()
        {
            List<AlimentoView> list = new List<AlimentoView>();
            list.Add(new AlimentoView() { 
                Tipo =3 ,
                Nome = "Arroz integral", 
                Img_source = "/Assets/Fatias/Graos/Arroz.jpg", 
                Calorias = 45.8, 
                Quantidade = 3, 
                Descricao = "colheres de sopa" 
            });
            list.Add(new AlimentoView()
            {
                Tipo = 3,
                Nome = "Macarrão",
                Img_source = "/Assets/Images/fatia04.png",
                Calorias = 45.8,
                Quantidade = 3,
                Descricao = "porcao"
            });
            list.Add(new AlimentoView()
            {
                Tipo = 3,
                Nome = "Feijão",
                Img_source = "/Assets/Fatias/Graos/Feijao.jpg",
                Calorias = 45.8,
                Quantidade = 3,
                Descricao = "porcao"
            });
            list.Add(new AlimentoView()
            {
                Tipo = 3,
                Nome = "Lentilha",
                Img_source = "/Assets/Images/fatia01.png",
                Calorias = 45.8,
                Quantidade = 3,
                Descricao = "porcao"
            });
            list.Add(new AlimentoView()
            {
                Tipo = 3,
                Nome = "Ervilha",
                Img_source = "/Assets/Images/fatia03.png",
                Calorias = 45.8,
                Quantidade = 3,
                Descricao = "porcao"
            });
            list.Add(new AlimentoView() { 
                Tipo = 3,
                Nome = "Grão de Bico", 
                Img_source = "/Assets/Images/fatia04.png", 
                Calorias = 45.8, 
                Quantidade = 3, 
                Descricao = "porcao" 
            });
            list.Add(new AlimentoView() { 
                Tipo = 3, 
                Nome = "Soja", 
                Img_source = "/Assets/Images/fatia01.png", 
                Calorias = 45.8, 
                Quantidade = 3, 
                Descricao = "porcao" 
            });

            return list;
        }
        
        public static List<AlimentoView> listarFrutas()
        {
            List<AlimentoView> list = new List<AlimentoView>();
            string desc1, desc2, desc3, desc4;
            desc1 = "porção";
            desc2 = "porções";
            desc3 = "unidade";
            desc4 = "unidades";

            list.Add(new AlimentoView()
            {
                Tipo = 4,
                Nome = "Abacaxi",
                Img_source = "/Assets/Fatias/Frutas/Pineapple_Icon.jpg",
                Calorias = 45.8,
                Quantidade = 3,
                Descricao = desc3
            });
            list.Add(new AlimentoView()
            {
                Tipo = 4,
                Nome = "Banana",
                Img_source = "/Assets/Fatias/Frutas/Banana_Icon.png",
                Calorias = 45.8,
                Quantidade = 3,
                Descricao = desc4
            });
            list.Add(new AlimentoView()
            {
                Tipo = 4,
                Nome = "Melancia",
                Img_source = "/Assets/Fatias/Frutas/Slice_Watermelon.png",
                Calorias = 45.8,
                Quantidade = 3,
                Descricao = desc4
            });
            list.Add(new AlimentoView()
            {
                Tipo = 4,
                Nome = "Maça",
                Img_source = "/Assets/Fatias/Frutas/Slice_Apple_Icon.jpg",
                Calorias = 45.8,
                Quantidade = 3,
                Descricao = desc4
            });
            list.Add(new AlimentoView()
            {
                Tipo = 4,
                Nome = "Mamão",
                Img_source = "/Assets/Fatias/Frutas/Papaya_Icon.jpg",
                Calorias = 45.8,
                Quantidade = 3,
                Descricao = desc2
            });
            list.Add(new AlimentoView()
            {
                Tipo = 4,
                Nome = "Laranja",
                Img_source = "/Assets/Fatias/Frutas/Slice_Orange.png",
                Calorias = 45.8,
                Quantidade = 3,
                Descricao = desc2
            });
            list.Add(new AlimentoView()
            {
                Tipo = 4,
                Nome = "Pêssego",
                Img_source = "/Assets/Fatias/Frutas/Slice_Pear_Icon.png",
                Calorias = 45.8,
                Quantidade = 3,
                Descricao = desc2
            });
            list.Add(new AlimentoView()
            {
                Tipo = 4,
                Nome = "Morango",
                Img_source = "/Assets/Fatias/Frutas/Slice_Strawberry_Icon.png",
                Calorias = 45.8,
                Quantidade = 3,
                Descricao = desc2
            });
            list.Add(new AlimentoView()
            {
                Tipo = 4,
                Nome = "Uva",
                Img_source = "/Assets/Fatias/Frutas/Grape_Icon.jpg",
                Calorias = 45.8,
                Quantidade = 3,
                Descricao = "porcao"
            });
            list.Add(new AlimentoView()
            {
                Tipo = 4,
                Nome = "Goiaba",
                Img_source = "/Assets/Fatias/Frutas/Goiaba.jpg",
                Calorias = 45.8,
                Quantidade = 3,
                Descricao = desc4
            });
            list.Add(new AlimentoView()
            {
                Tipo = 4,
                Nome = "Manga",
                Img_source = "/Assets/Fatias/Frutas/Manga.jpg",
                Calorias = 45.8,
                Quantidade = 3,
                Descricao = desc4
            });
            return list;
        }

        public static List<AlimentoView> listarProteinas()
        {
            List<AlimentoView> list = new List<AlimentoView>();
            list.Add(new AlimentoView()
            {
                Tipo = 5,
                Nome = "Peixe",
                Img_source = "/Assets/Images/fatia01.png",
                Calorias = 45.8,
                Quantidade = 3,
                Descricao = "porcao"
            });
            list.Add(new AlimentoView()
            {
                Tipo = 5,
                Nome = "Peito de Frango",
                Img_source = "/Assets/Images/fatia01.png",
                Calorias = 45.8,
                Quantidade = 3,
                Descricao = "porcao"
            });
            list.Add(new AlimentoView()
            {
                Tipo = 5,
                Nome = "Ovos",
                Img_source = "/Assets/Images/fatia04.png",
                Calorias = 45.8,
                Quantidade = 3,
                Descricao = "porcao"
            });
            list.Add(new AlimentoView()
            {
                Tipo = 5,
                Nome = "Carne",
                Img_source = "/Assets/Images/fatia02.png",
                Calorias = 45.8,
                Quantidade = 3,
                Descricao = "porcao"
            });
            list.Add(new AlimentoView()
            {
                Tipo = 5,
                Nome = "Peru",
                Img_source = "/Assets/Images/fatia01.png",
                Calorias = 45.8,
                Quantidade = 3,
                Descricao = "porcao"
            });
            list.Add(new AlimentoView()
            {
                Tipo = 5,
                Nome = "Camarão",
                Img_source = "/Assets/Images/fatia02.png",
                Calorias = 45.8,
                Quantidade = 3,
                Descricao = "porcao"
            });
            list.Add(new AlimentoView()
            {
                Tipo = 5,
                Nome = "Bife Grelhado",
                Img_source = "/Assets/Images/fatia01.png",
                Calorias = 45.8,
                Quantidade = 3,
                Descricao = "porcao"
            });
            list.Add(new AlimentoView()
            {
                Tipo = 5,
                Nome = "Frango Cozido",
                Img_source = "/Assets/Images/fatia02.png",
                Calorias = 45.8,
                Quantidade = 3,
                Descricao = "porcao"
            });
            list.Add(new AlimentoView()
            {
                Tipo = 5,
                Nome = "Salmão",
                Img_source = "/Assets/Images/fatia04.png",
                Calorias = 45.8,
                Quantidade = 3,
                Descricao = "porcao"
            });
            return list;
        }

        public static List<AlimentoView> listarPaes()
        {
            List<AlimentoView> list = new List<AlimentoView>();
            list.Add(new AlimentoView()
            {
                Tipo = 6,
                Nome = "Granola",
                Img_source = "/Assets/Fatias/Paes/Granola.jpg",
                Calorias = 45.8,
                Quantidade = 3,
                Descricao = "porcao"
            });
            list.Add(new AlimentoView()
            {
                Tipo = 6,
                Nome = "Linhaça",
                Img_source = "/Assets/Fatias/Paes/Linhaça.jpg",
                Calorias = 45.8,
                Quantidade = 3,
                Descricao = "porcao"
            });
            list.Add(new AlimentoView()
            {
                Tipo = 6,
                Nome = "Aveia",
                Img_source = "/Assets/Images/fatia04.png",
                Calorias = 45.8,
                Quantidade = 3,
                Descricao = "porcao"
            });
            list.Add(new AlimentoView()
            {
                Tipo = 6,
                Nome = "Pão Integral",
                Img_source = "/Assets/Images/fatia02.png",
                Calorias = 45.8,
                Quantidade = 3,
                Descricao = "porcao"
            });
            list.Add(new AlimentoView()
            {
                Tipo = 6,
                Nome = "Pão Francês",
                Img_source = "/Assets/Images/fatia01.png",
                Calorias = 45.8,
                Quantidade = 3,
                Descricao = "porcao"
            });
            list.Add(new AlimentoView()
            {
                Tipo = 6,
                Nome = "Pão de Linhaça",
                Img_source = "/Assets/Images/fatia02.png",
                Calorias = 45.8,
                Quantidade = 3,
                Descricao = "porcao"
            });
            list.Add(new AlimentoView()
            {
                Tipo = 6,
                Nome = "Pão de Milho",
                Img_source = "/Assets/Images/fatia04.png",
                Calorias = 45.8,
                Quantidade = 3,
                Descricao = "porcao"
            });
            list.Add(new AlimentoView()
            {
                Tipo = 6,
                Nome = "Pão de Centeio",
                Img_source = "/Assets/Images/fatia02.png",
                Calorias = 45.8,
                Quantidade = 3,
                Descricao = "porcao"
            });
            list.Add(new AlimentoView()
            {
                Tipo = 6,
                Nome = "Pão de Aveia",
                Img_source = "/Assets/Images/fatia01.png",
                Calorias = 45.8,
                Quantidade = 3,
                Descricao = "porcao"
            });
            return list;
        }

        public static List<AlimentoView> listarCopos()
        {
            List<AlimentoView> list = new List<AlimentoView>();
            list.Add(new AlimentoView()
            {
                Tipo = 1,
                Calorias = 100,
                Nome = "Água",
                Quantidade = 1,
                Descricao = "Água",
                Img_source = "/Assets/Images/fatia01.png",
            });
            list.Add(new AlimentoView()
            {
                Tipo = 1,
                Calorias = 100,
                Nome = "Suco de Laranja",
                Quantidade = 1,
                Descricao = "Suco de Laranja",
                Img_source = "/Assets/Images/fatia02.png",
            });
            list.Add(new AlimentoView()
            {
                Tipo = 1,
                Calorias = 100,
                Nome = "Suco de Mamão",
                Quantidade = 1,
                Descricao = "Suco de Mamão",
                Img_source = "/Assets/Images/fatia04.png",
            });
            list.Add(new AlimentoView()
            {
                Tipo = 1,
                Calorias = 100,
                Nome = "Suco de Taperebá",
                Quantidade = 1,
                Descricao = "Suco de Taperebá",
                Img_source = "/Assets/Images/fatia04.png",
            });
            list.Add(new AlimentoView()
            {
                Tipo = 1,
                Calorias = 100,
                Nome = "Leite",
                Quantidade = 1,
                Descricao = "Leite",
                Img_source = "/Assets/Fatias/Copos/Leite.jpg",
            });
            list.Add(new AlimentoView()
            {
                Tipo = 1,
                Calorias = 100,
                Nome = "Suco de Cajú",
                Quantidade = 1,
                Descricao = "Suco de Cajú",
                Img_source = "/Assets/Images/fatia03.png",
            });
            list.Add(new AlimentoView()
            {
                Tipo = 1,
                Calorias = 100,
                Nome = "Suco de Tangerina",
                Quantidade = 1,
                Descricao = "Suco de Tangerina",
                Img_source = "/Assets/Images/fatia01.png",
            });
            list.Add(new AlimentoView()
            {
                Tipo = 1,
                Calorias = 100,
                Nome = "Chá de Camomila",
                Quantidade = 1,
                Descricao = "Chá de Camomila",
                Img_source = "/Assets/Images/fatia02.png",
            });

            return list;
        }


        public static ImageSource ImgConvertedSource(AlimentoView pAlimento)
        {
            return new BitmapImage(new Uri(pAlimento.Img_source, UriKind.RelativeOrAbsolute));
        }

    }
}
