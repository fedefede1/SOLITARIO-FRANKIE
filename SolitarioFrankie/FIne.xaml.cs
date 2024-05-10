using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace SolitarioFrankie
{
    /// <summary>
    /// Logica di interazione per Fine.xaml
    /// </summary>
    public partial class Fine : Page
    {
        private MainWindow window;
        public Fine(bool vinto, MainWindow window)
        {
            InitializeComponent();
            ImageBrush temp = new ImageBrush();
            temp.ImageSource = new BitmapImage(new Uri($"..\\..\\..\\Immagini\\Sfondi\\Sfondo.png", UriKind.Relative));
            Background = temp;
            if (vinto)
            {
                lblRisultato.Content = "Hai Vinto";
            }
            else
            {
                lblRisultato.Content = "Hai Perso";
            }
            this.window = window;
        }

        private void btnEsci_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnGiocaAncora_Click(object sender, RoutedEventArgs e)
        {
            MainWindow temp = new MainWindow();
            temp.Show();
            window.Close();
        }

        private void btnAnimazione_MouseEnter(object sender, MouseEventArgs e)
        {
            
            Button button = sender as Button;
            DoubleAnimation WidthAnimation = new DoubleAnimation() { To = 180, Duration = TimeSpan.FromSeconds(0.15) };
            DoubleAnimation HeightAnimation = new DoubleAnimation() { To = 130, Duration = TimeSpan.FromSeconds(0.15) };

            button.BeginAnimation(WidthProperty, WidthAnimation);
            button.BeginAnimation(HeightProperty, HeightAnimation);
            
        }

        private void btnAnimazione_MouseLeave(object sender, MouseEventArgs e)
        {
            
            Button button = sender as Button;
            DoubleAnimation WidthAnimation = new DoubleAnimation() { To = 170, Duration = TimeSpan.FromSeconds(0.15) };
            DoubleAnimation HeightAnimation = new DoubleAnimation() { To = 120, Duration = TimeSpan.FromSeconds(0.15) };

            button.BeginAnimation(WidthProperty, WidthAnimation);
            button.BeginAnimation(HeightProperty, HeightAnimation);
            
        }
    }
}
