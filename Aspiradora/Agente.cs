using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Aspiradora
{
    class Agente
    {
        private string Nombre;
        private Grid edoInicial { get; set; }
        private Grid edoActual { get; set; }
        private int[] posicion = new int[2];
        public Agente(Grid Entorno)
        {
            this.Nombre = "Aspiradora";
            this.edoInicial = Entorno;
            this.edoActual = Entorno;
            this.posicion[0] = Grid.GetColumn(Entorno.Children[0]);
            this.posicion[1] = Grid.GetRow(Entorno.Children[0]);
        }

        public void Reglas()
        {
            //Girar derecha, moverse una posicion para enfrente y girar de nuevo
            if ((this.posicion[1] % 2 == 0 && this.posicion[0] == 7) || (this.posicion[1] % 2 != 0 && this.posicion[0] == 0))
            {
                this.posicion[1]++;
                Grid.SetRow(this.edoActual.Children[0], this.posicion[1]);
            }
            else if (this.posicion[0] == 7 && this.posicion[1] == 0) //posición final, pasar al agente a posición inicial
            {
                this.posicion[0] = 0;
                this.posicion[1] = 0;
            }
        }

        public void MoverAgente()
        {
            //Limpiar basura
            foreach (var espacio in this.edoActual.Children)
            {
                if (espacio is Rectangle)
                    if (((Rectangle)espacio).Fill.ToString() == Colors.Brown.ToString())
                        this.LimpiarPiso(espacio);
            }
            if (this.posicion[0] != 0 || this.posicion[1] != 7)
            {
                Console.WriteLine("Posicion: " + this.posicion[0] + this.posicion[1]);

                if (this.posicion[1] % 2 == 0)
                {
                    if (this.posicion[0] != 7)
                    {
                        //Mover derecha
                        this.posicion[0]++;
                        Grid.SetColumn(this.edoActual.Children[0], this.posicion[0]);
                    }
                    else
                    {
                        this.posicion[1]++;
                        Grid.SetRow(this.edoActual.Children[0], this.posicion[1]);
                        ((Label)this.edoActual.Children[0]).Content = "<";
                    }
                }
                else if (this.posicion[1] % 2 != 0)
                {
                    if (this.posicion[0] != 0)
                    {
                        //Mover izquierda
                        this.posicion[0]--;
                        Grid.SetColumn(this.edoActual.Children[0], this.posicion[0]);
                    }
                    else
                    {
                        this.posicion[1]++;
                        Grid.SetRow(this.edoActual.Children[0], this.posicion[1]);
                        ((Label)this.edoActual.Children[0]).Content = ">";
                    }
                }
            }
            else
            {
                this.posicion[0] = 0;
                this.posicion[1] = 0;
                Grid.SetColumn(this.edoActual.Children[0], this.posicion[0]);
                Grid.SetRow(this.edoActual.Children[0], this.posicion[1]);
                ((Label)this.edoActual.Children[0]).Content = ">";
            }
        }
        private void LimpiarPiso(object espacio)
        {
            if (Grid.GetColumn((UIElement)espacio) == this.posicion[0] && Grid.GetRow((UIElement)espacio) == this.posicion[1])
                ((Rectangle)espacio).Fill = new SolidColorBrush(Colors.White);
        }
    }
}
