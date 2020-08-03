using System;
using PlayerNS;
using System.Threading;
using MonstersNS;
using BattleNS;
using ConfigNS;

namespace src
{
    class Program
    {
        static void Main(string[] args)
        {
            Config.setConfigs();

            //Menu
            Console.WriteLine("=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+");
            Console.WriteLine("+      C# RPG v0.0.4         +");
            Console.WriteLine("+      por Luan Roger        +");
            Console.WriteLine("=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+");
            Console.WriteLine("=+=+=+=+=+= Menu =+=+=+=+=+=+=+=+");
            Console.WriteLine("> [ 1 ] - Começar.    [ 2 ] - Sair.");
            int menuChoice = 0; //Valor padrão
            try{ menuChoice = Convert.ToInt32(Console.ReadLine()); }
            catch(Exception e){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ocorreu um error: {e.Message}");
                Console.WriteLine($"O programa será encerrado.");
                Environment.Exit(1);
            }

            switch(menuChoice){//Processar escolha
                case 1:
                break;

                case 2:
                Environment.Exit(0);
                break;
            }

            //Criar personagem
            Console.WriteLine("> Digite o nome do seu personagem:");
            string playerName = "player";
            try{ playerName = Console.ReadLine().ToUpper(); }
            catch(Exception e){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ocorreu um error: {e.Message}");
                Console.WriteLine($"O programa será encerrado.");
            }

            Player player = new Player();
            player.CreatePlayer(playerName);
            player.SeeStatus();//Ver status
            Thread.Sleep(3000);

            while(player.steps < 100){
                //Informações inicias
                Console.WriteLine($"Você está em: {player.SeeArroud()}, você já andou {player.steps} vezes.");

                Console.WriteLine("O que deseja fazer?");
                Console.WriteLine("> [ 1 ] - Andar.    [ 2 ] - Voltar.    [ 3 ] - Ver status.    [ 4 ] - Sair do jogo.");
                int playerChoice = 0;
                try{ playerChoice = Convert.ToInt32(Console.ReadLine()); }
                catch(Exception e){
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ocorreu um error: {e.Message}");
                    Console.WriteLine($"O programa será encerrado.");
                    Environment.Exit(1);
                }
                
                switch(playerChoice){//Processar escolha
                    case 1:
                    Console.WriteLine("Quer executar quantas vezes a ação Andar?");
                    int walkTimes = 0;
                    try{ walkTimes = Convert.ToInt32(Console.ReadLine()); }
                    catch(Exception e) {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Ocorreu um error: {e.Message}");
                        Console.WriteLine($"O programa será encerrado.");
                    }

                    for(; walkTimes != 0; walkTimes--){//Andar quantas vezes o usuário mandar
                        player.Walk();
                        Console.WriteLine($"[ {walkTimes} ] - Você andou.");
                        Thread.Sleep(500);//Tempo entre um e outro 'Andar'

                        //Chace de encontrar algum monstro no meio do caminho
                        #region Monster Founder
                        if(Monster.MonsterFound() == false){
                            continue;
                        }else{
                            //Cria Monstro de acordo com o local
                            Monster monster = new Monster();
                            if(player.SeeArroud() == "Planices"){
                                PlaniceMonsters planiceMonsters = new PlaniceMonsters();
                                monster = planiceMonsters.createPlaniceMonster();

                                Console.WriteLine("Um monstro apareceu!");
                                Thread.Sleep(3000);
                                Console.WriteLine($"Você vai lutar contra: {monster.monsterName}");
                                
                                Battle battle = new Battle(player, monster);
                            }
                            else if(player.SeeArroud() == "Floresta"){
                                FlorestMonsters florestMonsters = new FlorestMonsters();
                                monster = florestMonsters.createFlorestMonster();

                                Console.WriteLine("Um monstro apareceu!");
                                Thread.Sleep(3000);
                                Console.WriteLine($"Você vai lutar contra: {monster.monsterName}");

                                Battle battle = new Battle(player, monster);
                            }
                            else if(player.SeeArroud() == "Pantano"){
                                SwampMonsters swampMonsters = new SwampMonsters();
                                monster = swampMonsters.createSwampMonster();

                                Console.WriteLine("Um monstro apareceu!");
                                Thread.Sleep(3000);
                                Console.WriteLine($"Você vai lutar contra: {monster.monsterName}");

                                Battle battle = new Battle(player, monster);
                            }else if(player.SeeArroud() == "Deserto"){
                                DesertMonsters desertMonsters = new DesertMonsters();
                                monster = desertMonsters.createDesertMonster();

                                Console.WriteLine("Um monstro apareceu!");
                                Thread.Sleep(3000);
                                Console.WriteLine($"Você vai lutar contra: {monster.monsterName}");
                                
                                Battle battle = new Battle(player, monster);
                            }
                            else if(player.SeeArroud() == "Piramide"){
                                PyramidMonsters pyramidMonsters = new PyramidMonsters();
                                monster = pyramidMonsters.createPyramidMonster();

                                Console.WriteLine("Um monstro apareceu!");
                                Thread.Sleep(3000);
                                Console.WriteLine($"Você vai lutar contra: {monster.monsterName}");
                                
                                Battle battle = new Battle(player, monster);
                            }
                            else if(player.SeeArroud() == "Final Boss"){
                                Boss finalBoss = new Boss();
                                monster = finalBoss.createFinalBoss();

                                Console.WriteLine("Um monstro apareceu!");
                                Thread.Sleep(3000);
                                Console.WriteLine($"Você vai lutar contra: {monster.monsterName}");
                                
                                Battle battle = new Battle(player, monster);
                            }
                        }
                        #endregion
                    }
                    break;

                    case 2:
                    Console.WriteLine("Quer executar quantas vezes a ação Voltar?");
                    int returnTimes = 0;
                    try{ returnTimes = Convert.ToInt32(Console.ReadLine()); }
                    catch(Exception e){
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Ocorreu um error: {e.Message}");
                        Console.WriteLine($"O programa será encerrado.");
                    }

                    for(; returnTimes != 0; returnTimes--){
                        player.Return();
                        Console.WriteLine($"[ {returnTimes} ] - Você andou.");
                        Thread.Sleep(800);
                    }
                    break;

                    case 3:
                    player.SeeStatus();
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
