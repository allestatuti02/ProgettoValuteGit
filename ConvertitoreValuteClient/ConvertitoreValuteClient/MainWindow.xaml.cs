using ServiceReference1;
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

namespace ConvertitoreValuteClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InizializzaCombo();
            aggiorna();
        }

        public void InizializzaCombo()
        {
            ServiceClient s = new ServiceClient();
            List<Valuta> lista = new List<Valuta>();
            int cont = 0;
            foreach(Valuta i in s.getValute())
            {
                if(cont == 0)
                {
                    PrimaCombo.SelectedItem = i.Nome;
                    SecondaCombo.SelectedItem = i.Nome;
                }
                lista.Add(i);
                PrimaCombo.Items.Add(i.Nome); 
                SecondaCombo.Items.Add(i.Nome);
            }
            
            //PrimaCombo.Items.Add()
        }
        private void Calcola_Click(object sender, RoutedEventArgs e)
        {
            ServiceClient s = new ServiceClient();
            lbConvertito.Content = s.converti(double.Parse(tbConverti.Text), PrimaCombo.SelectedItem.ToString(), SecondaCombo.SelectedItem.ToString()).ToString();
            aggiorna();
        }

        private void scambiaValute(object sender, RoutedEventArgs e)
        {
            var box = PrimaCombo.SelectedItem;
            PrimaCombo.SelectedItem = SecondaCombo.SelectedItem;
            SecondaCombo.SelectedItem = box;
            aggiorna();
        }

        public void aggiorna()
        {
            const string cambio = "Tasso di cambio: 1 {0} = {1} {2}";

            string a = PrimaCombo.SelectedItem.ToString();
            double tempX = double.Parse(tbConverti.Text);
            double tempY = double.Parse(lbConvertito.Content.ToString());
            double tot = tempX / tempY;
            string b = (tot).ToString();
            string c = PrimaCombo.SelectedItem.ToString();

            lbConvertReale.Content = string.Format(cambio, a, b, c);
        }
    }
}
