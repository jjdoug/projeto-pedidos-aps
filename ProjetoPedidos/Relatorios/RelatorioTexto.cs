using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoPedidos.Models;

namespace ProjetoPedidos.Relatorios
{
    public class RelatorioTexto
    {
        public void Gerar(Pedido pedido)
        {
            Console.WriteLine($"Cliente: {pedido.Cliente.Nome}");
            Console.WriteLine("Produtos:");
            foreach (var item in pedido.Itens)
            {
                Console.WriteLine($"- {item.Produto.Nome} ({item.Quantidade}x) - R$ {item.Subtotal():F2}");
            }
            Console.WriteLine($"Total: R$ {pedido.Total:F2}");
            Console.WriteLine($"Frete: R$ {pedido.Frete:F2}");
            Console.WriteLine($"Total com frete: R$ {pedido.TotalComFrete:F2}");
        }
    }
}
