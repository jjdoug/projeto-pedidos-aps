using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPedidos.Services
{
    public class FreteCalculadoraDistancia
    {
        public double Calcular(double distanciaKm)
        {
            return distanciaKm * 0.5;
        }
    }
}
