using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoPedidos.Models;

namespace ProjetoPedidos.Services
{
    public class FreteCalculadoraPeso
    {
        public double Calcular(Pedido pedido)
        {
            double pesoTotal = 0;
            foreach (var item in pedido.Itens)
            {
                pesoTotal += item.PesoTotal();
            }
            return pesoTotal * 5.0;
        }
    }
}
