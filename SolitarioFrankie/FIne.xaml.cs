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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SolitarioFrankie
{
    /// <summary>
    /// Logica di interazione per FIne.xaml
    /// </summary>
    public partial class Fine : Page
    {
        private MainWindow window;
        public Fine(bool vinto, MainWindow window)
        {
            InitializeComponent();
            if(vinto)
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
    }
}
