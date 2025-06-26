using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPedidos.Utils
{
    public static class Entrada
    {
        public static string LerString(string mensagem)
        {
            Console.Write(mensagem);
            return Console.ReadLine();
        }

        public static double LerDouble(string mensagem)
        {
            Console.Write(mensagem);
            return double.Parse(Console.ReadLine());
        }

        public static int LerInt(string mensagem)
        {
            Console.Write(mensagem);
            return int.Parse(Console.ReadLine());
        }
    }
}
