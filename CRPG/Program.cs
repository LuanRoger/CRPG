using System;
using System.Threading;
using Konsole;

namespace CRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Config.SetConfigs();

            //Menu
            var bemvindoWin = Window.OpenBox("C# RPG", 30, 5, new BoxStyle
            {
                ThickNess = LineThickNess.Double,
                Title = new Colors(ConsoleColor.White, ConsoleColor.DarkMagenta)
            });
            bemvindoWin.WriteLine("       por Luan Roger");
            bemvindoWin.WriteLine($"          v{Config.versao}");

            var menuWin = new Window(35, 4, ConsoleColor.White, ConsoleColor.DarkBlue);
            menuWin.WriteLine("Menu");
            menuWin.WriteLine("-----------");
            menuWin.WriteLine("> [ 1 ] - Começar.    [ 2 ] - Sair.");
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
            try { playerName = Console.ReadLine()?.ToUpper(); }
            catch (Exception e) { Error.ErrorFatal(e); }

            Player player = new(playerName);
            switch (playerName)
            {
                #region Nome de personagens
                case "KONAMI":
                    player = player with
                    {
                        playerHp = 999
                    };
                    break;
                case "EASY":
                    player = player with
                    {
                        playerAtk = 8,
                        playerHp = 32,
                        playerDef = 6,
                        xpParaProximo = 2
                    };
                    break;
                case "HARD":
                    player = player with
                    {
                        playerAtk = 2,
                        playerHp = 16,
                        playerDef = 0,
                        xpParaProximo = 20
                    };
                    break;
                case "GOD":
                    player = player with
                    {
                        playerAtk = int.MaxValue,
                        playerHp = int.MaxValue,
                        playerDef = int.MaxValue,
                        xpParaProximo = int.MaxValue,
                        playerLevel = int.MaxValue,
                        playerXp = 999
                    };
                    break;
                    #endregion
            }
            Console.Clear();
            player.VerStatus();
            Thread.Sleep(3000);

            Console.Clear();

            while (player.passos < 100)
            {
                //Informações inicias
                var infoWin = Window.OpenBox("Informações", 50, 4, new BoxStyle
                {
                    Title = new Colors(ConsoleColor.White, ConsoleColor.Blue)
                });
                infoWin.WriteLine($"Você está em: {player.VerAoRedor()}, você já andou {player.passos} vezes.");

                var menuGameWin = new Window(87, 4, ConsoleColor.White, ConsoleColor.DarkBlue);
                menuGameWin.WriteLine("O que deseja fazer?");
                menuGameWin.WriteLine("------------------");
                menuGameWin.WriteLine("> [ 1 ] - Andar.    [ 2 ] - Voltar.    [ 3 ] - Ver personagem.    [ 4 ] - Sair do jogo.");
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

                        //Criar tela andar
                        var telaAndar = new Window();
                        var telasAndar = telaAndar.SplitRows(
                            new Split(4, "Progresso", LineThickNess.Single),
                            new Split(0, "Batalha"),
                            new Split(6, "Acontecimentos", LineThickNess.Single));

                        var meioTela = telasAndar[1];
                        var statusTela = telasAndar[2];

                        var progressoAndar = new ProgressBar(telasAndar[0], andar);

                        for (int a = 0; andar != 0; andar--)
                        {
                            player.Andar();
                            a++;
                            progressoAndar.Refresh(a, "Andando...");

                            Acessorios.ProcurarItem(player.VerAoRedor(), player);

                            Thread.Sleep(350);

                            Monstros monstros = new Monstros().MonstroAchar(player.VerAoRedor());
                            if (monstros != null) new Batalha(player, monstros, meioTela, statusTela);

                            telaAndar.SplitRows(
                                new Split(4, "Progresso", LineThickNess.Single),
                                new Split(0, "Batalha"),
                                new Split(5, "Acontecimentos", LineThickNess.Single));
                        }

                        Console.Clear();
                        break;

                    case 2:
                        Console.WriteLine("Quer voltar quantas vezes?");
                        int voltar = 0;
                        try { voltar = Convert.ToInt32(Console.ReadLine()); }
                        catch (Exception e) { Error.ErrorFatal(e); }

                        var telaVoltar = new Window().SplitRows(
                            new Split(5, "Progresso", LineThickNess.Single),
                            new Split(0));

                            var progressoVoltar = new ProgressBar(telaVoltar[0], voltar);

                        for (int v = 0; voltar != 0; voltar--)
                        {
                            player.Voltar();
                            v++;
                            progressoVoltar.Refresh(v, "Voltando...");
                            Thread.Sleep(800);
                        }

                        Console.Clear();
                        break;

                    case 3:
                        player.VerStatus();
                        player.VerAcessorios();
                        Thread.Sleep(5000);
                        Console.Clear();
                        break;

                    case 4:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
