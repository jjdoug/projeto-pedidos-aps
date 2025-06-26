using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPedidos.Models
{
    public class Pedido
    {
        public Cliente Cliente { get; set; }
        public List<ItemPedido> Itens { get; set; } = new List<ItemPedido>();
        public double Frete { get; set; }

        public double Total => Itens.Sum(i => i.Subtotal());
        public double TotalComFrete => Total + Frete;
    }
}
