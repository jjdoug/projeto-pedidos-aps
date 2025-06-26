using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPedidos.Models
{
    public class ItemPedido
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }

        public double Subtotal()
        {
            return Produto.Preco * Quantidade;
        }

        public double PesoTotal()
        {
            return Produto.PesoKg * Quantidade;
        }
    }
}
