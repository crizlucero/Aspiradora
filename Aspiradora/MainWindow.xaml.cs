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

namespace Aspiradora
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Agente aspiradora;

        public MainWindow()
        {
            InitializeComponent();
            this.ColocarBasura();
            this.InitAgente();
        }

        private void ColocarBasura()
        {
            Random rand = new Random();
            int total = rand.Next(1, 64);
            int x = rand.Next(0, 8);
            int y = rand.Next(0, 8);
            for (int i = 0; i < total; ++i)
            {
                Rectangle r = new Rectangle
                {
                    Fill = new SolidColorBrush(Colors.Brown),
                    Visibility = System.Windows.Visibility.Visible,
                };
                this.Entorno.Children.Add(r);
                r.SetValue(Grid.ColumnProperty, x);
                r.SetValue(Grid.RowProperty, y);
                x = rand.Next(0, 8);
                y = rand.Next(0, 8);
            }

        }

        private void InitAgente()
        {
            this.aspiradora = new Agente(this.Entorno);
        }

        private void Button_MouseLeftButtonUp(object sender, EventArgs e)
        {
            this.aspiradora.MoverAgente();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 64; i++)
            {
                this.aspiradora.MoverAgente();
                //System.Threading.Thread.Sleep(500);
            }

        }
    }
}
