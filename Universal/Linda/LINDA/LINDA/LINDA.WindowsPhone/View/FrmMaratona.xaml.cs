using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using LINDA.ViewModel;
using Microsoft.Phone.Maps.Controls;
using System.Windows.Threading;
using System.Device.Location;
using System.Windows.Media;
using NExtra.Geo;
using System.Windows.Media.Imaging;
using Windows.Devices.Geolocation;

namespace LINDA.View
{
    public partial class FrmMaratona : PhoneApplicationPage
    {
        private GeoCoordinateWatcher _watcher ;
        private GeoCoordinate asd = new GeoCoordinate();
        private Geolocator geolocator = new Geolocator()
        {
            ReportInterval = 5000 //A cada 15segundos ele vai atualizar o mapa
        };
        private DispatcherTimer _timer = new DispatcherTimer();
        private MapPolyline _line;

        private long _startTime;
        private long _fisrtTime;
        private long _lastsTime;
        private double _kilometros;
        private long _previousPositionChangeTick;

        private MaratonaView Maratona;

        private bool inicio;

        public FrmMaratona()
        {
            InitializeComponent();
            //this.geolocator.PositionChanged += geolocator_PositionChanged;
            this.Maratona = new MaratonaView();

            this._timer.Interval = TimeSpan.FromSeconds(1);
            this._timer.Tick += Timer_Tick;

            InicializarComponentes();

            this.conteudoList.ItemsSource = this.Maratona.ObtemMaratonas();
        }

        void geolocator_PositionChanged(Geolocator sender, PositionChangedEventArgs e)
        {
                throw new NotImplementedException();
        }
                /// <summary>
        /// Inicializa componentes
        /// </summary>
        protected void InicializarComponentes()
        {
            this._watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
            this._watcher.PositionChanged += Watcher_PositionChanged;

            //VARIÁVEIS CONTADORAS
            this.inicio = true;
            this._lastsTime = 0;
            this._startTime = 0;
            this._kilometros = 0;
            this._previousPositionChangeTick = 0;

            //COMPONENTES VISUAIS

            //DISTÂNCIA:
            distanciaLabel.Text = "00.00";
            distanceLabel.Text = "0.00 km";

            //CALORIAS:

            caloriasqLabel.Text = "00";
            caloriesLabel.Text = "00";

            //VELOCIDADE MÉDIA:
            velocidademediaLabel.Text = "00";
            vmLabel.Text = "00";

            TimeSpan runTime = TimeSpan.FromMilliseconds(0);

            //TEMPO
            timeLabel.Text = runTime.ToString(@"hh\:mm\:ss");
            horaLabel.Text = runTime.ToString(@"hh\:mm\:ss");

            if (_line != null)
            {
                Map.MapElements.Remove(_line);
            }
            _line = new MapPolyline();
            _line.StrokeColor = Colors.Red;
            _line.StrokeThickness = 5;
            Map.MapElements.Add(_line);
        }

        //SEGUNDO PLANO
        /// <summary>
        /// Controla o tempo contado
        /// </summary>
        /// <param name="sender">objeto</param>
        /// <param name="e">evento</param>
        /// 
        int segundos = 0;
        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan runTime = TimeSpan.FromMilliseconds(System.Environment.TickCount - this._startTime + this._lastsTime);
            //TEMPO
            timeLabel.Text = runTime.ToString(@"hh\:mm\:ss");
            horaLabel.Text = runTime.ToString(@"hh\:mm\:ss");
            this.Maratona.Distanciatotal = double.Parse(distanciaLabel.Text);
            this.Maratona.Kcalperdido = double.Parse(caloriesLabel.Text);
            this.Maratona.Tempo = runTime.Minutes;
            this.Maratona.Velocidademedia = double.Parse(velocidademediaLabel.Text);

            segundos++;
            if (segundos>10)
            {
                segundos = 0;
                Deployment.Current.Dispatcher.BeginInvoke(() => AtualizarTabela());
            }
        }
        #region APPLICATION BAR        

        /// <summary>
        /// Inicia a maratona
        /// </summary>
        /// <param name="sender">Botão clicado</param>
        /// <param name="e">tipo de evento</param>
        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (_timer.IsEnabled)
            { }
            else
            {
                if (this.inicio)
                {
                    this.Maratona = new MaratonaView() { 
                            Idmaratona = this.conteudoList.Items.Count+1,
                            Distanciatotal = 0,
                            Kcalperdido = 0,
                            Tempo = 0,
                            Velocidademedia = 0,
                            Dia_maratona = DateTime.UtcNow.Date
                    };
                    this.Maratona.Gravar();
                    Deployment.Current.Dispatcher.BeginInvoke(() => AtualizarTabela());
                    this._fisrtTime = _startTime = System.Environment.TickCount;
                    _watcher.Start();
                }
                else
                {
                    _startTime = System.Environment.TickCount;
                }
                _timer.Start();
                
            }
        }

        /// <summary>
        /// Botão pause geral do Maratona
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pausar_Click(object sender, EventArgs e)
        {

            this.inicio = false;
            if (this.inicio)
            {
                this._lastsTime = System.Environment.TickCount - this._fisrtTime;
            }
            else
                this._lastsTime = System.Environment.TickCount - this._startTime + this._lastsTime;
            this._timer.Stop();
            Deployment.Current.Dispatcher.BeginInvoke(() => AtualizarTabela());
        }

        /// <summary>
        /// Zera a maratona, iniciando a contagem do 0;
        /// </summary>
        /// <param name="sender"> Botão clicado</param>
        /// <param name="e">Tipo de evento</param>
        private void Zerar_Click(object sender, EventArgs e)
        {
            this._timer.Stop();
            if (this._watcher != null)
                this._watcher.Stop();
            InicializarComponentes();
            Deployment.Current.Dispatcher.BeginInvoke(() => AtualizarTabela());
        }

        /// <summary>
        /// Barra de detalhes visível no mapa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void Detalhes_Click(object sender, System.Windows.Input.GestureEventArgs e)
        {

            if (grdDetalhesMaratona.Visibility == System.Windows.Visibility.Visible)
            {
                grdDetalhesMaratona.Visibility = System.Windows.Visibility.Collapsed;
                barDetalhes.Source = new BitmapImage(new Uri("/Assets/AppBar/add.png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                grdDetalhesMaratona.Visibility = System.Windows.Visibility.Visible;
                barDetalhes.Source = new BitmapImage(new Uri("/Assets/AppBar/minus.png", UriKind.RelativeOrAbsolute));
            }
        }
        #endregion

        #region ID_CAP_LOCATION

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            if (_timer.IsEnabled)
            { 
                var coord = new GeoCoordinate(e.Position.Location.Latitude, e.Position.Location.Longitude);
                if (_line.Path.Count > 0)
                {
                    var previousPoint = _line.Path.Last();
                    var distance = coord.GetDistanceTo(previousPoint);

                    this._kilometros += distance / 1000.0;

                    //DISTÂNCIA:
                    distanciaLabel.Text = string.Format("{0:f2}", _kilometros);
                    distanceLabel.Text = string.Format("{0:f2} km", _kilometros);

                    //CALORIAS:
                    caloriasqLabel.Text = string.Format("{0:f2}", _kilometros * 65);
                    caloriesLabel.Text = string.Format("{0:f2}", _kilometros * 65);

                    PositionHandler handler = new PositionHandler();
                    var heading = handler.CalculateBearing(new Position(previousPoint), new Position(coord));
                    Map.SetView(coord, Map.ZoomLevel, heading, MapAnimationKind.Parabolic);

                }
                else
                {
                    Map.Center = coord;
                }
                _line.Path.Add(coord);
                _previousPositionChangeTick = System.Environment.TickCount;
                VelocidaMediaMaratona(_kilometros);
            }
        }

        #endregion

        #region UTILITÁRIOS
        /// <summary>
        /// Atualiza periodicamente a tabela.
        /// </summary>
        protected void AtualizarTabela()
        {
            this.Maratona.Alterar();
            this.conteudoList.ItemsSource = this.Maratona.ObtemMaratonas();
        }
        /// <summary>
        /// Contabiliza o total de tempo;
        /// </summary>
        private double totaltempo;// total em segundos

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kilometros"></param>
        private void VelocidaMediaMaratona(double kilometros)
        {

            Maratona.Dia_maratona = System.DateTime.Today;
            Maratona.Distanciatotal = kilometros;
            string MTempo = timeLabel.Text;

            //Convertendo string tempo em segundos
            int achou2pontos = 0;
            string apoio = "";
            for (int i = 0; i < MTempo.Length; i++)
            {
                if (MTempo[i] == ':')
                {
                    if (achou2pontos == 0)
                    {
                        totaltempo += (double.Parse(apoio) * 3600);
                        achou2pontos++;
                        apoio = "";
                    }
                    else
                    {
                        if (achou2pontos == 1)
                        {

                            totaltempo += (double.Parse(apoio) * 60);
                            achou2pontos++;
                            apoio = "";
                        }
                    }
                }
                else
                {
                    apoio += MTempo[i];
                }
            }
            totaltempo += double.Parse(apoio);
            double vm = (this._kilometros * 1000) / totaltempo;

            //VELOCIDADE MÉDIA:
            
            velocidademediaLabel.Text = string.Format("{0:f2}", vm);
            vmLabel.Text = string.Format("{0:f2}", vm);
        }

        #endregion

        private void FecharMaratona(object sender, RoutedEventArgs e)
        {
            this._timer.Stop();
            if (this._watcher != null)
                this._watcher.Stop();
            if (this.Maratona != null)
            {
                this.Maratona.Alterar();    
            }
            
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            this._timer.Stop();
            if (this._watcher != null)
                this._watcher.Stop();
            if (this.Maratona != null)
            {
                this.Maratona.Alterar();
            }
            base.OnBackKeyPress(e);
        }



    }
}