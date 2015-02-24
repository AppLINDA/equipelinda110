using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINDA.ViewModel
{
    public class DiasDaSemanaViewModel
    {
        public static List<DiasDaSemana> listarDiasDaSemana()
        {
            List<DiasDaSemana> list = new List<DiasDaSemana>();
            list.Add(new DiasDaSemana()  { Nome = "Domingo" });
            list.Add(new DiasDaSemana() {  Nome = "Segunda-feira"});
            list.Add(new DiasDaSemana() { Nome = "Terça-feira" });
            list.Add(new DiasDaSemana() { Nome = "Quarta-feira" });
            list.Add(new DiasDaSemana() { Nome = "Quinta-feira" });
            list.Add(new DiasDaSemana() { Nome = "Sexta-feira" });
            list.Add(new DiasDaSemana() { Nome = "Sábado" });
            return list;
        }
    }
}
