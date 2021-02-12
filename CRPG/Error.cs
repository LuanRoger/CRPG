using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRPG
{
    class Error
    {
        public static void ErrorFatal(Exception exception)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Ocorreu um error: {exception.Message}");
            Console.WriteLine("O programa será encerrado.");
            Environment.Exit(1);
        }
    }
}
