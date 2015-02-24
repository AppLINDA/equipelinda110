using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Microsoft.Phone.Scheduler;

namespace LINDA.ViewModel
{
    public class ActivesModel
    {
        /// Atributos relacionados a Nutricionista
        ///  usados no FrmNutricionista e para ter acesso no FrmNutricinistaInformacoes
        /// </summary>
        public int id;
        public string nome;
        public string telefone;


        #region Usado em FrmEscolherAvatar:
        public Image ActiveAvatar;
        public AvatarView ActiveAvatarP;
        #endregion
        
        //Usado em FrmCadastroPerfil:
        public PerfilView ActivePerfil;
        
        #region MontaPrato

            public MontapratoView RefeicaoActive;
            public CafedaManhaView R_cafedamanha;
            //public LiquidoView R_Lcafedamanha;
            public AlmocoView R_almoco;
            //public LiquidoView R_Lalmoco;
            public LanchedaTardeView R_lanchetarde;
            //public LiquidoView R_Llanchetarde;
            public JantaView R_jantar;
            //public LiquidoView R_Ljantar;
            public LanchedaNoiteView R_lanchenoite;

            public LanchedaManhaView R_lanchedamanha;
            /// <summary>
            /// Diz se já foi iniciado o processo de definição de dieta:
            /// </summary>
            public bool usandomontaprato;
            /// <summary>
            /// Usado para trocar imagem enquanto carrega:
            /// </summary>
            public string ActiveImagem;
            /// <summary>
            /// Usado para definir o índice do alimento selecionado:
            /// </summary>
            public int IdAlimento_Select;
            /// <summary>
            /// Usado para definir qual o tipo de refeição do dia foi selecionado:
            /// </summary>
            public int IdRefeicao_Select;
            /// <summary>
            /// Usado para definir o dia da semana que foi selecionado:
            /// </summary>
            public int IdSemena_Select;
            /// <summary>
            /// Usado para definir o tipo de alimento a ser escolhido:
            /// </summary>
            public int IdTipoAlimento_Select;

            public bool[] bolRefeicoes;

        #endregion
        public ActivesModel()
        {
            usandomontaprato = false;
        }
        public void MontapratoUsar() 
        {
            usandomontaprato =  ! usandomontaprato;
            RefeicaoActive = new MontapratoView() ;
            R_almoco = new AlmocoView();
            R_cafedamanha = new CafedaManhaView();
            R_jantar = new JantaView();
            R_lanchetarde = new LanchedaTardeView();
            R_lanchedamanha = new LanchedaManhaView();
            R_lanchenoite = new LanchedaNoiteView();
            bolRefeicoes = new bool[6];
            for (int i = 0; i < 6; i++)
            {
                bolRefeicoes[i] = false;    
            }
        }
        #region Alarme

        public Reminder remindergeral;

        /// <summary>
        /// Criando alarme
        /// </summary>
        /// <param name="nameAlarme"></param>
        /// <param name="dtHora"></param>
        /// <param name="Titulo"></param>
        /// <param name="descricao"></param>
        /// <param name="Tiporefeicao"></param>
        public void CriarAlarme( string nameAlarme, DateTime dtHora, string Titulo, 
            string descricao, int Tiporefeicao)
        {
            Reminder reminder = new Reminder(nameAlarme)
            {
                BeginTime = dtHora,
                Title = Titulo,
                Content = descricao,
                RecurrenceType = RecurrenceInterval.None,
               // NavigationUri = new Uri("/View/FrmAlarme.xaml?idrefeicao=" + Tiporefeicao.ToString(), UriKind.Relative)
            };
            ScheduledActionService.Add(reminder);
        }
        public void AlterarAlarme(string nameAlarme)
        {
            var schedule = ScheduledActionService.Find(nameAlarme);
            Reminder reminder = schedule as Reminder;
            reminder.BeginTime = DateTime.Now.AddSeconds(10);
            if (reminder.BeginTime.Day <= DateTime.Now.Day)
            {
                reminder.BeginTime = reminder.BeginTime.AddDays(1);
            }
            ScheduledActionService.Replace(reminder);
        }
        #endregion

       
        
    }
}
