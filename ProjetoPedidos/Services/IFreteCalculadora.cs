using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoPedidos.Models;

namespace ProjetoPedidos.Services
{
    public interface IFreteCalculadora
    {
        double Calcular(Pedido pedido);
    }
}
