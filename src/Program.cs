using System;
using PlayerNS;
using System.Threading;
using MonstersNS;
using BattleNS;

namespace src
{
    class Program
    {
        static void Main(string[] args)
        {
            //Menu
            Console.WriteLine("==++== C# RPG v0.0.3 ==++==");
            Console.WriteLine("==Menu==");
            Console.WriteLine("[ 1 ] - Começar.    [ 2 ] - Sair");
            int menuChoice = Convert.ToInt32(Console.ReadLine());

            switch(menuChoice){//Processar escolha
                case 1:
                break;

                case 2:
                Environment.Exit(0);
                break;
                
                default:
                Console.WriteLine("Valor inválido.");
                Environment.Exit(1);
                break;
            }

            //Criar personagem
            Console.WriteLine("Digite o nome do seu personagem:");
            string playerName = Console.ReadLine().ToUpper();

            Player player = new Player();
            player.CreatePlayer(playerName);
            player.SeeStatus();//Ver status

            while(true){
                //Informações inicias
                Console.WriteLine($"Você está em: {player.SeeArroud()}, você já andou {player.steps} vezes.");

                Console.WriteLine("O que deseja fazer?");
                Console.WriteLine("[ 1 ] - Andar.    [ 2 ] - Voltar.    [ 3 ] - Ver status.");
                int playerChoice = Convert.ToInt32(Console.ReadLine());
                
                switch(playerChoice){//Processar escolha
                    case 1:
                    Console.WriteLine("Quer executar quantas vezes a ação Andar?");
                    int walkTimes = Convert.ToInt32(Console.ReadLine());

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
                        }
                        #endregion
                    }
                    break;

                    case 2:
                    Console.WriteLine("Quer executar quantas vezes a ação Voltar?");
                    int returnTimes = Convert.ToInt32(Console.ReadLine());

                    for(; returnTimes != 0; returnTimes--){
                        player.Return();
                        Console.WriteLine($"[ {returnTimes} ] - Você andou.");
                        Thread.Sleep(500);
                    }
                    break;

                    case 3:
                    player.SeeStatus();
                    break;
                }
            }
        }
    }
}
