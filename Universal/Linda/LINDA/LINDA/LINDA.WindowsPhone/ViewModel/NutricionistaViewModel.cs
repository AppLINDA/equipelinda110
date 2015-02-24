using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LINDA.ViewModel
{
    public class NutricionistaViewModel
    {
        //TRATAMENDO DINÂMICO:
        /// <summary>
        /// Grava no banco um Nutricionista.
        /// </summary>
        /// <param name="Nutricionista">Instância de Nutricionista.</param>
        /// <returns> [true]: se cadastrou; [false]: se não cadastrou;</returns>
        public static bool Gravar(NutricionistaView Nutricionista)
        {
            try
            {
                App.Current.LINDADB.NutricionistaItems.InsertOnSubmit(Nutricionista);
                App.Current.LINDADB.SubmitChanges();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro", MessageBoxButton.OK);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Exclui um Nutricionista.
        /// </summary>
        /// <param name="Nutricionista">Instância de Nutricionista.</param>
        /// <returns> [true]: se conseguiu; [false]: se não conseguiu;</returns>
        public static bool Excluir(NutricionistaView Nutricionista)
        {
            try
            {
                var excluir = App.Current.LINDADB.NutricionistaItems.Where(a => a.Id_nutricionista == Nutricionista.Id_nutricionista).First();
                App.Current.LINDADB.NutricionistaItems.DeleteOnSubmit(excluir);
                App.Current.LINDADB.SubmitChanges();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro", MessageBoxButton.OK);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Altera um Nutricionista.
        /// </summary>
        /// <param name="Nutricionista">Instância de Nutricionista.</param>
        /// <returns> [true]: se cadastrou; [false]: se não cadastrou;</returns>
        public static bool Alterar(NutricionistaView Nutricionista)
        {
            try
            {

                NutricionistaView update = (from com in App.Current.LINDADB.NutricionistaItems
                                            where com.Id_nutricionista == Nutricionista.Id_nutricionista
                                            select com).First();
                update.Email = Nutricionista.Email;
                App.Current.LINDADB.SubmitChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Lista Nutricionistas ordenados por nome.
        /// </summary>
        /// <returns>Lista de Nutricionista.</returns>
        public static List<NutricionistaView> listar()
        {
            return (
                from NutricionistaView item in App.Current.LINDADB.NutricionistaItems
                orderby item.Nome
                select item).ToList();
        }

        public static List<NutricionistaView> listarNutricionistas()
        {
            List<NutricionistaView> lis = new List<NutricionistaView>();           

            lis.Add(new NutricionistaView()
            {
                Id_nutricionista = 2,
                Nome = "Jonathan Maia Ferreira",
                PrimeiroNome = "Jonathan",
                UltimoNome = "Ferreira",
                Especialidade = "Nutricionista",
                Bairro = "Hileia",
                Endereco = "São José",
                Telefone = "00000-0000",
                Email = "www.Dom@gmail.com",
                Img_source = "/Assets/Tiles/nutricionista_Linda.png"
            });

            lis.Add(new NutricionistaView()
            {
                Id_nutricionista = 3,
                Nome = "Patricia de Paula Barros Moraes",
                PrimeiroNome = "Patricia",
                UltimoNome = "Moraes",
                Especialidade = "Nutrologa",
                Bairro = "Aleixo",
                Endereco = "Redenção",
                Telefone = "00000-0000",
                Email = "www.paty@gmail.com",
                Img_source = "/Assets/Tiles/nutricionista_Linda.png"
            });

            lis.Add(new NutricionistaView()
            {
                Id_nutricionista = 4,
                Nome = "Olga Leão Alves",
                PrimeiroNome = "Olaga",
                UltimoNome = "Alves",
                Especialidade = "Nutricionista",
                Bairro="Redenção",
                Endereco = "Cidade Nova",
                Telefone = "00000-0000",
                Email = "www.Olgão@gmail.com",
                Img_source = "/Assets/Tiles/nutricionista_Linda.png"
            });

            lis.Add(new NutricionistaView()
            {
                Id_nutricionista = 5,
                Nome = "Juliany Raiol Barroso",
                PrimeiroNome = "Juliany",
                UltimoNome = "Barroso",
                Especialidade = "Nutrologa",
                Bairro = "Petrópolis",
                Endereco = "São José",
                Telefone = "00000-0000",
                Email = "www.Jujuh@gmail.com",
                Img_source = "/Assets/Tiles/nutricionista_Linda.png"
            });

            lis.Add(new NutricionistaView()
            {
                Id_nutricionista = 6,
                Nome = "Yasmim Libório Santos",
                PrimeiroNome = "Yasmim",
                UltimoNome = "Santos",
                Especialidade = "Nutricionista",
                Bairro = "São José",
                Endereco = "São José",
                Telefone = "00000-0000",
                Email = "www.Girina@gmail.com",
                Img_source = "/Assets/Tiles/nutricionista_Linda.png"
            });

            lis.Add(new NutricionistaView()
            {
                Id_nutricionista = 7,
                Nome = "Jonatas Reis Cavalcante",
                PrimeiroNome = "Jonatas",
                UltimoNome = "Cavalcante",
                Especialidade = "Nutrologa",
                Bairro = "Redenção",
                Endereco = "Cidade Nova",
                Telefone = "00000-0000",
                Email = "www.Jojo@gmail.com",
                Img_source = "/Assets/Tiles/nutricionista_Linda.png"
            });

            lis.Add(new NutricionistaView()
            {
                Id_nutricionista = 8,
                Nome = "Max Williams Cardoso",
                PrimeiroNome = "Max",
                UltimoNome = "Cardoso",
                Especialidade = "Nutrologa",
                Bairro = "Cidade Nova",
                Endereco = "Betânia",
                Telefone = "00000-0000",
                Email = "www.Max@gmail.com",
                Img_source = "/Assets/Tiles/nutricionista_Linda.png"
            });
           

            return lis;
        }

        public static List<NutricionistaView> listarDados()
        {
            List<NutricionistaView> lst = NutricionistaViewModel.listarNutricionistas();
            List<NutricionistaView> lstDados = new List<NutricionistaView>();
            for (int i = 0; i <= lst.Count; i++)
            {
                if (lst[i].Id_nutricionista == App.Current.Actives.id)
                {
                    lstDados.Add(lst[i]);
                    break;
                }
            }
            return lstDados;
        }
    }
}
