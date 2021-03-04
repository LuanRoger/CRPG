using System;
using Konsole;

namespace CRPG
{
    class GameManagment
    {
        public static void AgradecimentosFinais()
        {
            Console.Clear();

            var agradecimento = Window.OpenBox("Parabéns!!!", 40, 5);
            agradecimento.WriteLine("Você conseguiu terminar o jogo.");
            agradecimento.WriteLine("Obrigado por jogar.");

            var creditos = Window.OpenBox("GitHub", 70, 5);
            creditos.WriteLine("Visite meu GitHub: github.com/LuanRoger");
            creditos.WriteLine("Veja também o repositório do jogo: github.com/LuanRoger/CRPG");

            Console.ReadKey();

            Environment.Exit(0);
        }
    }
}
