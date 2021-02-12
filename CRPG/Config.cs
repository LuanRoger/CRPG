using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CRPG
{
    internal class Config
    {
        public static readonly string versao = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public static void SetConfigs()
        {
            Console.Title = $"C# RPG v{versao}";
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
