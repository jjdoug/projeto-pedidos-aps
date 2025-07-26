using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoPedidos.Models;

namespace ProjetoPedidos.Notificacoes
{
    public interface INotificacao
    {
        void Enviar(Cliente cliente);
    }
}
