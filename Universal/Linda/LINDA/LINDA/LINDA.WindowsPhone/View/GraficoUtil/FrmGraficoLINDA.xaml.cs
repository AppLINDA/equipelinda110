using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Visifire.Charts;
using LINDA.ViewModel;

namespace LINDA.View.GraficoUtil
{
    public partial class FrmGraficoLINDA : PhoneApplicationPage
    {
        public FrmGraficoLINDA()
        {
            InitializeComponent();
        }
        #region Gráficos
        
        /// <summary>
        /// Inicia o Gráfico Anual
        /// </summary>
        public void GraficoAnualStart()
        {
            DataPoint dadosmes;
            List<CalendarioGeralView> lstCalendariogeral = CalendarioGeralViewModel.listar();
            CalendarioGeralView auxCGV;
            GraficoGeral.Series[0].DataPoints = new DataPointCollection();
            for (int i = 0; i < lstCalendariogeral.Count; i++)
            {
                auxCGV = lstCalendariogeral[i];
                dadosmes = new DataPoint() { XValue = auxCGV.Id_calendario, YValue = auxCGV.Kcaltotais , AxisXLabel = auxCGV.Mes, Exploded = false, LightingEnabled = false, LegendText = auxCGV.Mes + "/" + auxCGV.Ano.ToString() , LabelLineEnabled = false, MarkerEnabled = false, ShowInLegend = true, ShadowEnabled = true };
                GraficoGeral.Series[0].DataPoints.Add(dadosmes);
            }
        }

        /// <summary>
        /// inicia o gráfico maratona
        /// </summary>
        public void GraficoMaratonaStart()
        {
            DataPoint dadosmes;
            List<MaratonaView> lst = MaratonaViewModel.listar();
            MaratonaView aux;
            graficoMaratona.Series[0].DataPoints = new DataPointCollection();
            for (int i = 0; i < lst.Count; i++)
            {
                aux = lst[i];
                dadosmes = new DataPoint() { XValue = aux.Idmaratona+1, YValue = aux.Kcalperdido,
                                             AxisXLabel = aux.Idmaratona.ToString(),
                                             Exploded = false, 
                    LightingEnabled = false, LegendText = aux.Dia_maratona.Date.ToShortDateString() +" , Distância percorrida: " + aux.Distanciatotal +"km" ,
                    LabelLineEnabled = false, MarkerEnabled = false, ShowInLegend = true, ShadowEnabled = true };
                graficoMaratona.Series[0].DataPoints.Add(dadosmes);
            }
        }
        public void GraficoPesoStart()
        {
            DataPoint dados;
            List<MassaView> lst = MassaViewModel.listar();
            MassaView aux;
            Graficopeso.Series[0].DataPoints = new DataPointCollection();
            for (int i = 0; i < lst.Count; i++)
            {
                aux = lst[i];
                dados = new DataPoint() {     XValue=aux.Dataupadate,
                                              YValue=aux.Massa,
                                              AxisXLabel="",
                                              Exploded=false, 
                                              LightingEnabled=false, 
                                              LegendText= Graficopeso.Series[0].LegendText + " em " + aux.Dataupadate.ToShortDateString() + ": " + aux.Massa +"kg",
                                              LabelLineEnabled=false, 
                                              MarkerEnabled=false,
                                              ShowInLegend=true, 
                                              ShadowEnabled=false};
                Graficopeso.Series[0].DataPoints.Add(dados);
            }
        }
        public void GraficoSemanalStart()
        {
            DataPoint dados;
            List<SemanaView> lst = SemanaViewModel.listar();
            SemanaView aux;
            Graficopeso.Series[0].DataPoints = new DataPointCollection();
            for (int i = 0; i < lst.Count; i++)
            {
                aux = lst[i];
                if (aux.Kcaltotais != 0)
                {
                    
                
                dados = new DataPoint()
                {
                    XValue = aux.Idsemana,
                    YValue = float.Parse(aux.Kcaltotais.ToString()),
                    AxisXLabel = "",
                    Exploded = false,
                    LightingEnabled = false,
                    LegendText = "Semana "+ aux.Idsemana.ToString()+": " + aux.Kcaltotais.ToString() + " cal",
                    LabelLineEnabled = false,
                    MarkerEnabled = false,
                    ShowInLegend = true,
                    ShadowEnabled = false
                };
                Graficopeso.Series[0].DataPoints.Add(dados);
                }
            }
        }
        #endregion

        #region Utilitários

        
        /// <summary>
        /// Responsável por inicializar um gráfico específico.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PanoramaItem_Loaded(object sender, RoutedEventArgs e)
        {
            GraficoPesoStart();
        }

        public void Mostrar()
        {
            GraficoPesoStart();
            GraficoMaratonaStart();
            GraficoAnualStart();
            //GraficoSemanalStart();
        }
        #endregion

        private void panoramogeral_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (panoramogeral.SelectedIndex + 1)
            {
                case 1:
                    GraficoPesoStart();
                    break;
                case 2:
                    GraficoMaratonaStart();
                    break;
                case 3:
                    GraficoAnualStart();
                    break;
                case 4:
                    //GraficoSemanalStart();
                    break;
                default:
                    break;
            }
        }


        
    }
}