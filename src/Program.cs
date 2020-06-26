using System;
using PlayerNS;
using System.Threading;

namespace src
{
    class Program
    {
        static void Main(string[] args)
        {
            //Menu
            Console.WriteLine("==++== C# RPG v0.0.1 ==++==");
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

            while(true){//Loop do jogo, não ira acabar até haver um 'break'
                //Informações inicias
                Console.WriteLine($"Você está em: {player.SeeArroud()}, você já deu {player.steps}");

                Console.WriteLine("O que deseja fazer?");
                Console.WriteLine("[ 1 ] - Andar. [ 2 ] - Ver status");
                int playerChoice = Convert.ToInt32(Console.ReadLine());
                
                switch(playerChoice){//Processar escolha
                    case 1:
                    Console.WriteLine("Quer executar quantas vezes a ação Andar?");
                    int walkTimes = Convert.ToInt32(Console.ReadLine());

                    for(; walkTimes != 0; walkTimes--){//Andar quantas vezes o usuário mandar
                        player.Walk();
                        Console.WriteLine($"[ {walkTimes} ] - Você andou.");
                        Thread.Sleep(500);//Tempo entre um e outro 'Andar'
                    }
                    break;
                    case 2:
                    player.SeeStatus();
                }
            }
        }
    }
}
