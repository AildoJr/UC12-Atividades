using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pessoas.Classes
{
    public static class Utils
    {
        public static void loading(string texto, int pontos, int tempo, ConsoleColor corFonte = ConsoleColor.White ) //Parâmetros já pré-definidos são considerados como opcionais
        { 
            //Console.BackgroundColor = ConsoleColor.Green;//cor de fundo
            Console.ForegroundColor = corFonte;//cor da fonte


            Console.Write(texto);
            for (int i = 0; i < pontos; i++)
            {
                Thread.Sleep(tempo);
                Console.Write(".");
            }

            Console.ResetColor();
        }
    }
}