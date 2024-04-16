using ClassiSolitarioFrankie;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SolitarioFrankie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer Timer;
        private int time = 0;
        Gioco g;
        private bool cartaDeposito;
        public MainWindow()
        {
            InitializeComponent();
            g = new Gioco();
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            Timer.Tick += Timer_Tick;
            cartaDeposito = false;
            InizializzaImmagini();
        }

        public void InizializzaImmagini()
        {
            imgCartaInCima.Source = new BitmapImage(new Uri($"{g.CartaInCima}.png", UriKind.Relative));
            imgMazzoDepositoStatica.Source = new BitmapImage(new Uri($"{g.MazzoDeposito[0]}.png", UriKind.Relative));
        }

        private void btnMazzoIniziale_Click(object sender, RoutedEventArgs e)
        {
            if (g.GiraCarta())
            {
                SlideCardRight(sender, e);
                
                if (g.MazzoIniziale.Empty)
                {
                    imgMazzoInizialeStatica.Visibility = Visibility.Collapsed;
                    if (!g.ControlloSeCartaAccettabile(g.MazzoDeposito[g.MazzoDeposito.Count-1]))
                    {
                        //pagina you lose
                    }
                }
            }
            else
            {
                imgMazzoInizialeStatica.Visibility = Visibility.Collapsed;
            }
        }
        private void SlideCardRight(object sender, RoutedEventArgs e)
        {
            Timer.Start();
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 0;
            animation.To = 240;
            animation.Duration = TimeSpan.FromSeconds(0.5);

            TranslateTransform translateTransform = new TranslateTransform();

            imgCarta.Visibility = Visibility.Visible;
            imgCarta.RenderTransform = translateTransform;

            translateTransform.BeginAnimation(TranslateTransform.XProperty, animation);

        }
        void Timer_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                time--;
            }
            else
            {
                Timer.Stop();
                imgCarta.Visibility = Visibility.Collapsed;
                imgCartaDeposito.Visibility = Visibility.Collapsed;
                if (cartaDeposito)
                {
                    imgCartaInCima.Source = new BitmapImage(new Uri($"{g.CartaInCima}.png", UriKind.Relative));
                    cartaDeposito = false;
                }
                else
                {
                    imgMazzoDepositoStatica.Source = new BitmapImage(new Uri($"{g.MazzoDeposito[g.MazzoDeposito.Count - 1]}.png", UriKind.Relative));
                }
            }
        }

        private void btnMazzoDeposito_Click(object sender, RoutedEventArgs e)
        {
            if (g.GiocaCarta())
            {
                imgCartaDeposito.Source = imgMazzoDepositoStatica.Source;
                SlideCardTopLeft(sender, e);
                cartaDeposito = true;        
                if (!(g.MazzoDeposito.Count == 0))
                {
                    imgMazzoDepositoStatica.Source = new BitmapImage(new Uri($"{g.MazzoDeposito[g.MazzoDeposito.Count - 1]}.png", UriKind.Relative));
                }
                else
                {
                    imgMazzoDepositoStatica.Source = new BitmapImage(new Uri("", UriKind.Relative));
                }      
                if (g.MazzoIniziale.Empty && g.MazzoDeposito.Count == 0)
                {
                    //pagina you win
                }
            }
        }

        private void SlideCardTopLeft(object sender, RoutedEventArgs e)
        {
            Timer.Start();
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 0;
            animation.To = -120;
            animation.Duration = TimeSpan.FromSeconds(0.5);

            DoubleAnimation up = new DoubleAnimation();
            up.From = 0;
            up.To = -320;
            up.Duration = TimeSpan.FromSeconds(0.5);

            TranslateTransform translateTransform = new TranslateTransform();

            imgCartaDeposito.Visibility = Visibility.Visible;
            imgCartaDeposito.RenderTransform = translateTransform;

            translateTransform.BeginAnimation(TranslateTransform.XProperty, animation);
            translateTransform.BeginAnimation(TranslateTransform.YProperty, up);
        }
    }
}