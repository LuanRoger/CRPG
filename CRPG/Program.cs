using System;
using System.Threading;

namespace CRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Config.SetConfigs();

            //Menu
            Console.WriteLine("=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+");
            Console.WriteLine("+           C# RPG             +");
            Console.WriteLine("+       por Luan Roger         +");
            Console.WriteLine("=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+");
            Console.WriteLine("=+=+=+=+=+= Menu =+=+=+=+=+=+=+=+");
            Console.WriteLine("> [ 1 ] - Começar.    [ 2 ] - Sair.");
            int escolhaMenu = 0;
            try { escolhaMenu = Convert.ToInt32(Console.ReadLine()); }
            catch (Exception e) { Error.ErrorFatal(e); }

            switch (escolhaMenu)
            {
                case 1:
                    break;

                case 2:
                    Environment.Exit(0);
                    break;
            }

            //Criar personagem
            Console.WriteLine("> Digite o nome do seu personagem:");
            string playerName = null;
            try { playerName = Console.ReadLine().ToUpper(); }
            catch (Exception e) { Error.ErrorFatal(e); }

            Player player = new(playerName);
            player.VerStatus();
            Thread.Sleep(3000);

            while (player.passos < 100)
            {
                //Informações inicias
                Console.WriteLine($"Você está em: {player.VerAoRedor()}, você já andou {player.passos} vezes.");

                Console.WriteLine("O que deseja fazer?");
                Console.WriteLine("> [ 1 ] - Andar.    [ 2 ] - Voltar.    [ 3 ] - Ver status.    [ 4 ] - Sair do jogo.");
                int playerChoice = 0;
                try { playerChoice = Convert.ToInt32(Console.ReadLine()); }
                catch (Exception e) { Error.ErrorFatal(e); }

                switch (playerChoice)
                {
                    case 1:
                        Console.WriteLine("Quer andar quantas vezes?");
                        int andar = 0;
                        try { andar = Convert.ToInt32(Console.ReadLine()); }
                        catch (Exception e) { Error.ErrorFatal(e); }

                        for (; andar != 0; andar--)
                        {
                            player.Andar();
                            Console.WriteLine($"[ {andar} ] - Você andou.");
                            Thread.Sleep(500);

                            #region Encontrar monstro
                            switch (player.VerAoRedor())
                            {
                                case Locais.Planices:
                                    Monstros planiceMonstro = new Monstros().MonstroPlanice();
                                    if (planiceMonstro != null) new Batalha(player, planiceMonstro);
                                    break;
                                case Locais.Floresta:
                                    Monstros florestaMonstros = new Monstros().FlorestaMonstro();
                                    if (florestaMonstros != null) new Batalha(player, florestaMonstros);
                                    break;
                                case Locais.Pantano:
                                    Monstros pantanoMonstros = new Monstros().PantanoMonstro();
                                    if (pantanoMonstros != null) new Batalha(player, pantanoMonstros);
                                    break;
                                case Locais.Deserto:
                                    Monstros desertoMonstros = new Monstros().DesertoMonstro();
                                    if (desertoMonstros != null) new Batalha(player, desertoMonstros);
                                    break;
                                case Locais.Piramide:
                                    Monstros piramideMonstros = new Monstros().PiramideMosntro();
                                    if (piramideMonstros != null) new Batalha(player, piramideMonstros);
                                    break;
                                case Locais.Void:
                                    Monstros voider = new Monstros().Vodier();
                                    new Batalha(player, voider);
                                    break;
                            }
                            #endregion
                        }
                        break;

                    case 2:
                        Console.WriteLine("Quer voltar quantas vezes?");
                        int voltar = 0;
                        try { voltar = Convert.ToInt32(Console.ReadLine()); }
                        catch (Exception e) { Error.ErrorFatal(e); }

                        for (; voltar != 0; voltar--)
                        {
                            player.Voltar();
                            Console.WriteLine($"[ {voltar} ] - Você voltou.");
                            Thread.Sleep(800);
                        }
                        break;

                    case 3:
                        player.VerStatus();
                        break;

                    case 4:
                        Environment.Exit(0);
                        break;
                }
            }
            Console.WriteLine("=+=+=+=+=+=+Parabéns!!!=+=+=+=+=+");
            Console.WriteLine("+Você conseguiu terminar o jogo.+");
            Console.WriteLine("+             😎                +");
            Console.WriteLine("=+=+=+=+Obrigado por jogar.=+=+=+\n");

            Console.WriteLine("!..GitHub.................................!");
            Console.WriteLine("! Visite meu GitHub: github.com/LuanRoger !...................!");
            Console.WriteLine("! Veja também o repositório do jogo: github.com/LuanRoger/CRPG!");
            Console.WriteLine("!.............................................................!");
        }
    }
}
