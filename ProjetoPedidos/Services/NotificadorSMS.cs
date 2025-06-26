using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoPedidos.Models;

namespace ProjetoPedidos.Services
{
    public class NotificadorSMS
    {
        public void Enviar(Cliente cliente)
        {
            Console.WriteLine($"Enviando SMS para {cliente.Telefone}: Seu pedido foi confirmado!");
        }
    }
}
