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
        }

        public void InizializzaImmagini()
        {
            imgCartaInCima.Source = new BitmapImage(new Uri($"{g.CartaInCima}.png", UriKind.Relative));
        }

        private void btnMazzoIniziale_Click(object sender, RoutedEventArgs e)
        {
            g.GiraCarta();
            SlideCardRight(sender, e);
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
                    imgCartaInCima.Source = new BitmapImage(new Uri("dwayne.png", UriKind.Relative));
                    cartaDeposito = false;
                }
            }
        }

        private void btnMazzoDeposito_Click(object sender, RoutedEventArgs e)
        {
            if (g.GiocaCarta())
            {
                SlideCardTopLeft(sender, e);
                cartaDeposito = true;
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