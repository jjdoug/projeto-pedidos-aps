using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoPedidos.Models;

namespace ProjetoPedidos.Services
{
    public class FreteCalculadoraDistancia : IFreteCalculadora
    {
        private double distanciaKm;

        public FreteCalculadoraDistancia(double distanciaKm)
        {
            this.distanciaKm = distanciaKm;
        }

        public double Calcular(Pedido pedido)
        {
            return distanciaKm * 0.5;
        }
    }
}
