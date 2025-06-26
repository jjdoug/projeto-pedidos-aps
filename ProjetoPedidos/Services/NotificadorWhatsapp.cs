using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoPedidos.Models;

namespace ProjetoPedidos.Services
{
    public class NotificadorWhatsApp
    {
        public void Enviar(Cliente cliente)
        {
            Console.WriteLine($"Enviando WhatsApp para {cliente.Telefone}: Seu pedido foi confirmado!");
        }
    }
}
