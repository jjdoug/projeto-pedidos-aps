using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPedidos.Services
{
    public class ConfiguracaoNotificacao
    {
        private static ConfiguracaoNotificacao instancia;

        private ConfiguracaoNotificacao()
        {
            TipoPadrao = 1;
        }

        public int TipoPadrao { get; set; }

        public static ConfiguracaoNotificacao GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new ConfiguracaoNotificacao();
            }
            return instancia;
        }
    }
}
