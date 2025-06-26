using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoPedidos.Models;
using ProjetoPedidos.Services;
using ProjetoPedidos.Relatorios;
using ProjetoPedidos.Utils;

namespace ProjetoPedidos
{
    internal class Program
    {
        static List<Cliente> clientes = new List<Cliente>();
        static List<Produto> produtos = new List<Produto>();
        static List<Pedido> pedidos = new List<Pedido>();

        static void Main(string[] args)
        {
            int opcao;
            do
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("1 - Cadastrar cliente");
                Console.WriteLine("2 - Cadastrar produto");
                Console.WriteLine("3 - Criar pedido");
                Console.WriteLine("4 - Listar pedidos (relatório)");
                Console.WriteLine("0 - Sair");
                opcao = Entrada.LerInt("Opção: ");

                switch (opcao)
                {
                    case 1:
                        CadastrarCliente();
                        break;
                    case 2:
                        CadastrarProduto();
                        break;
                    case 3:
                        CriarPedido();
                        break;
                    case 4:
                        GerarRelatorios();
                        break;
                    case 0:
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            } while (opcao != 0);
        }

        static void CadastrarCliente()
        {
            Console.WriteLine("\n-- Cadastro de Cliente --");
            var cliente = new Cliente
            {
                Nome = Entrada.LerString("Nome: "),
                Cpf = Entrada.LerString("CPF: "),
                Email = Entrada.LerString("E-mail: "),
                Telefone = Entrada.LerString("Telefone: ")
            };
            clientes.Add(cliente);
            Console.WriteLine("Cliente cadastrado com sucesso!");
        }

        static void CadastrarProduto()
        {
            Console.WriteLine("\n-- Cadastro de Produto --");
            var produto = new Produto
            {
                Nome = Entrada.LerString("Nome: "),
                Preco = Entrada.LerDouble("Preço: "),
                PesoKg = Entrada.LerDouble("Peso (kg): ")
            };
            produtos.Add(produto);
            Console.WriteLine("Produto cadastrado com sucesso!");
        }

        static void CriarPedido()
        {
            if (clientes.Count == 0 || produtos.Count == 0)
            {
                Console.WriteLine("Você precisa ter ao menos um cliente e um produto cadastrados.");
                return;
            }

            Console.WriteLine("\n-- Criação de Pedido --");

            for (int i = 0; i < clientes.Count; i++)
                Console.WriteLine("{0} - {1}", i, clientes[i].Nome);
            int indiceCliente = Entrada.LerInt("Escolha o cliente: ");
            if (indiceCliente < 0 || indiceCliente >= clientes.Count)
            {
                Console.WriteLine("Cliente inválido.");
                return;
            }
            var cliente = clientes[indiceCliente];

            var pedido = new Pedido();
            pedido.Cliente = cliente;

            string continuar = "";
            do
            {
                for (int i = 0; i < produtos.Count; i++)
                    Console.WriteLine("{0} - {1} - R$ {2:F2}", i, produtos[i].Nome, produtos[i].Preco);

                int indiceProduto = Entrada.LerInt("Escolha o produto: ");
                if (indiceProduto < 0 || indiceProduto >= produtos.Count)
                {
                    Console.WriteLine("Produto inválido.");
                    continue;
                }
                int quantidade = Entrada.LerInt("Quantidade: ");
                if (quantidade <= 0)
                {
                    Console.WriteLine("Quantidade deve ser maior que zero.");
                    continue;
                }

                var item = new ItemPedido();
                item.Produto = produtos[indiceProduto];
                item.Quantidade = quantidade;

                pedido.Itens.Add(item);
                continuar = Entrada.LerString("Adicionar mais produtos? (s/n): ");
            } while (continuar.ToLower() == "s");

            Console.WriteLine("1 - Frete por peso");
            Console.WriteLine("2 - Frete por distância");
            int tipoFrete = Entrada.LerInt("Escolha o tipo de frete: ");
            if (tipoFrete == 1)
            {
                var frete = new FreteCalculadoraPeso();
                pedido.Frete = frete.Calcular(pedido);
            }
            else if (tipoFrete == 2)
            {
                double distancia = Entrada.LerDouble("Informe a distância (km): ");
                var frete = new FreteCalculadoraDistancia();
                pedido.Frete = frete.Calcular(distancia);
            }
            else
            {
                Console.WriteLine("Tipo de frete inválido. Frete definido como zero.");
                pedido.Frete = 0;
            }

            Console.WriteLine("Tipo de notificação:");
            Console.WriteLine("1 - Email\n2 - SMS\n3 - WhatsApp");
            int tipoNotif = Entrada.LerInt("Escolha: ");
            switch (tipoNotif)
            {
                case 1:
                    new NotificadorEmail().Enviar(cliente);
                    break;
                case 2:
                    new NotificadorSMS().Enviar(cliente);
                    break;
                case 3:
                    new NotificadorWhatsApp().Enviar(cliente);
                    break;
                default:
                    Console.WriteLine("Tipo de notificação inválido.");
                    break;
            }

            pedidos.Add(pedido);
            Console.WriteLine("Pedido criado com sucesso!");
        }

        static void GerarRelatorios()
        {
            if (pedidos.Count == 0)
            {
                Console.WriteLine("Nenhum pedido encontrado.");
                return;
            }

            for (int i = 0; i < pedidos.Count; i++)
            {
                Console.WriteLine("\nPedido #{0}:", i + 1);
                Console.WriteLine("1 - Relatório Texto");
                Console.WriteLine("2 - Relatório JSON");
                int formato = Entrada.LerInt("Formato: ");

                if (formato == 1)
                    new RelatorioTexto().Gerar(pedidos[i]);
                else if (formato == 2)
                    new RelatorioJSON().Gerar(pedidos[i]);
                else
                    Console.WriteLine("Formato inválido.");
            }
        }
    }
}
