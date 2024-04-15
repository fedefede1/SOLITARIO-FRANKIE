using ClassiSolitarioFrankie;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SolitarioFrankie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Gioco g;
        public MainWindow()
        {
            InitializeComponent();
            g = new Gioco();


        }

        public void InizializzaImmagini()
        {
            imgCartaInCima.Source = new BitmapImage(new Uri($"{g.CartaInCima}.png", UriKind.Relative));
        }

        private void btnMazzoIniziale_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}