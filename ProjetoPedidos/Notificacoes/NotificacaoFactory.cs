using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPedidos.Notificacoes
{
    public static class NotificacaoFactory
    {
        public static INotificacao Criar(int tipo)
        {
            if (tipo == 1)
                return new NotificacaoEmail();
            else if (tipo == 2)
                return new NotificacaoSMS();
            else if (tipo == 3)
                return new NotificacaoWhatsApp();
            else
                return null; // não lança exceção, apenas retorna null
        }
    }
}
