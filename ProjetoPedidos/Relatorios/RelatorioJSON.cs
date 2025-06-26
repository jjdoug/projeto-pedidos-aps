using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoPedidos.Models;

namespace ProjetoPedidos.Relatorios
{
    public class RelatorioJSON
    {
        public void Gerar(Pedido pedido)
        {
            Console.WriteLine("{");
            Console.WriteLine($"  \"cliente\": \"{pedido.Cliente.Nome}\",");
            Console.WriteLine("  \"produtos\": [");
            for (int i = 0; i < pedido.Itens.Count; i++)
            {
                var item = pedido.Itens[i];
                Console.WriteLine("    {");
                Console.WriteLine($"      \"nome\": \"{item.Produto.Nome}\",");
                Console.WriteLine($"      \"quantidade\": {item.Quantidade},");
                Console.WriteLine($"      \"preco\": {item.Produto.Preco:F2}");
                Console.Write("    }");
                if (i < pedido.Itens.Count - 1)
                    Console.WriteLine(",");
                else
                    Console.WriteLine();
            }
            Console.WriteLine("  ],");
            Console.WriteLine($"  \"total\": {pedido.Total:F2},");
            Console.WriteLine($"  \"frete\": {pedido.Frete:F2},");
            Console.WriteLine($"  \"total_com_frete\": {pedido.TotalComFrete:F2}");
            Console.WriteLine("}");
        }
    }
}
