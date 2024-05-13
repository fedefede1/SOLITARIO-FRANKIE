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
        private DispatcherTimer TimerFinale;
        private int time = 0;
        Gioco g;
        private bool cartaDeposito;
        private bool vinto;
        public MainWindow()
        {
            InitializeComponent();
            ImageBrush temp = new ImageBrush();
            Background = temp;
            imgMazzoInizialeStatica.Source = new BitmapImage(new Uri($"Immagini\\Carte\\RETRO.jpg", UriKind.Relative));
            imgCarta.Source = new BitmapImage(new Uri($"Immagini\\Carte\\RETRO.jpg", UriKind.Relative));
            g = new Gioco();
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            Timer.Tick += Timer_Tick;
            TimerFinale = new DispatcherTimer();
            TimerFinale.Interval = new TimeSpan(0, 0, 0, 1, 500);
            TimerFinale.Tick += TimerFinale_Tick;
            cartaDeposito = false;
            InizializzaImmagini();
            Top = 125;
            Left = 685;
        }

        public void InizializzaImmagini()
        {
            imgCartaInCima.Source = new BitmapImage(new Uri($"Immagini\\Carte\\{g.CartaInCima}.jpg", UriKind.Relative));
            imgMazzoDepositoStatica.Source = new BitmapImage(new Uri($"Immagini\\Carte\\{g.MazzoDeposito[0]}.jpg", UriKind.Relative));
        }

        private void btnMazzoIniziale_Click(object sender, RoutedEventArgs e)
        {
            btnMazzoIniziale.IsEnabled = false;
            btnMazzoDeposito.IsEnabled = false;
            if (g.GiraCarta())
            {
                
                SlideCardRight(sender, e);
                
                if (g.MazzoIniziale.Empty)
                {
                    imgMazzoInizialeStatica.Visibility = Visibility.Collapsed;
                    if (!g.ControlloSeCartaAccettabile(g.MazzoDeposito[g.MazzoDeposito.Count-1]))
                    {
                        vinto = false;
                        TimerFinale.Start();
                    }
                }
            }
            else
            {
                imgMazzoInizialeStatica.Visibility = Visibility.Collapsed;
                btnMazzoIniziale.IsEnabled = true;
                btnMazzoDeposito.IsEnabled=true;
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
                    imgCartaInCima.Source = new BitmapImage(new Uri($"Immagini\\Carte\\{g.CartaInCima}.jpg", UriKind.Relative));
                    cartaDeposito = false;
                }
                else
                {
                    imgMazzoDepositoStatica.Source = new BitmapImage(new Uri($"Immagini\\Carte\\{g.MazzoDeposito[g.MazzoDeposito.Count - 1]}.jpg", UriKind.Relative));
                }
                btnMazzoIniziale.IsEnabled = true;
                btnMazzoDeposito.IsEnabled = true;
            }
        }

        private void btnMazzoDeposito_Click(object sender, RoutedEventArgs e)
        {
            btnMazzoDeposito.IsEnabled = false;
            btnMazzoIniziale.IsEnabled = false;
            if (g.GiocaCarta())
            {
                imgCartaDeposito.Source = imgMazzoDepositoStatica.Source;
                SlideCardTopLeft(sender, e);
                cartaDeposito = true;        
                if (!(g.MazzoDeposito.Count == 0))
                {
                    imgMazzoDepositoStatica.Source = new BitmapImage(new Uri($"Immagini\\Carte\\{g.MazzoDeposito[g.MazzoDeposito.Count - 1]}.jpg", UriKind.Relative));
                }
                else
                {
                    imgMazzoDepositoStatica.Source = new BitmapImage(new Uri("", UriKind.Relative));
                }
                if (g.MazzoIniziale.Empty && g.MazzoDeposito.Count == 0)
                {
                    vinto = true;
                    TimerFinale.Start();
                }
                else if (g.MazzoIniziale.Empty && !g.ControlloSeCartaAccettabile(g.MazzoDeposito[g.MazzoDeposito.Count - 1]))
                {
                    vinto = false;
                    TimerFinale.Start();
                }    
            }
            else
            {
                btnMazzoIniziale.IsEnabled = true;
                btnMazzoDeposito.IsEnabled = true;
                DoubleAnimation animationX = new DoubleAnimation();
                animationX.From = 0; 
                animationX.To = 10; 
                animationX.Duration = TimeSpan.FromSeconds(0.05); 

                animationX.AutoReverse = true;

                animationX.RepeatBehavior = new RepeatBehavior(2);

                shakeImage.BeginAnimation(TranslateTransform.XProperty, animationX);
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
        void TimerFinale_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                time--;
            }
            else
            {
                TimerFinale.Stop();
                Content = new Fine(vinto, this);
            }
        }
    }
}