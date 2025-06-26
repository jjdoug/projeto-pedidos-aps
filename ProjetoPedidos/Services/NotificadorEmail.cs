using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoPedidos.Models;

namespace ProjetoPedidos.Services
{
    public class NotificadorEmail
    {
        public void Enviar(Cliente cliente)
        {
            Console.WriteLine($"Enviando e-mail para {cliente.Email}: Seu pedido foi confirmado!");
        }
    }
}
