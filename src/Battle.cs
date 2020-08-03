using PlayerNS;
using MonstersNS;
using System;
using System.Threading;

namespace BattleNS {
    public class Battle{
        public Battle(Player player, Monster monster){
            while (true)
            {
                BattleStatus(player, monster);
                Thread.Sleep(1500);

                PlayerTurn(player, monster);
                if(monster.monsterHp <= 0){ break; } //Casso o mostro morra antes da verificação do while 

                MonsterTurn(player, monster);
                if(player.playerHp <= 0) { break; }
            }

            if(player.playerHp >= 0){
                Console.WriteLine("Você ganhou!");
                player.AddXp(monster.monsterXpDrop);
                Console.WriteLine($"Você recebeu {monster.monsterXpDrop} de Xp");
                player.LevelUp();//Verificar se passou de level
            }else{
                player.PlayerDie();
            }
        }
        private void BattleStatus(Player playerAtributes, Monster monsterAtributes){
            Console.WriteLine("Player:");
            System.Console.WriteLine($"HP: {playerAtributes.playerHp}");
            System.Console.WriteLine($"ATK: {playerAtributes.playerAtk}");
            System.Console.WriteLine($"DEF: {playerAtributes.playerDef}");
            System.Console.WriteLine($"XP: {playerAtributes.palyerXp}");
            System.Console.WriteLine("============================");
            System.Console.WriteLine($"Monstro:");
            System.Console.WriteLine($"HP: {monsterAtributes.monsterHp}");
            System.Console.WriteLine($"ATK: {monsterAtributes.monsterAtk}");
        }
        #region TurnClass
        private void PlayerTurn(Player playerAtributes, Monster monsterAtributes){
            //Player turn
            Console.WriteLine("O que você vai fazer? ");
            Console.WriteLine("> [ 1 ] - Atacar.     [ 2 ] - Defender.");
            int battleChoice = 0;
            try { battleChoice = Convert.ToInt32(Console.ReadLine()); }
            catch(Exception e) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ocorreu um error: {e.Message}");
                Console.WriteLine($"O programa será encerrado.");
                Environment.Exit(1);
            }

            switch(battleChoice){
                case 1:
                System.Console.WriteLine("Você ataca.");
                Thread.Sleep(2000);
                if(monsterAtributes.monsterIsDefending == true){ //Dividir o ataque do player por 2 casso o monstro esteja defendendo
                    monsterAtributes.monsterHp -= playerAtributes.PlayerAttackAction()/2;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Você deu {playerAtributes.PlayerAttackAction()/2} de dano.");
                    Console.ForegroundColor = ConsoleColor.Black;
                    monsterAtributes.MosnterUndefenceAction();
                }else{
                    monsterAtributes.monsterHp -= playerAtributes.PlayerAttackAction();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Você deu {playerAtributes.PlayerAttackAction()} de dano.");
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                break;

                case 2:
                playerAtributes.PlayerDefenceAction();
                System.Console.WriteLine("Você esta se defendendo.");
                break;
            }
        }

        private void MonsterTurn(Player playerAtributes, Monster monsterAtributes){
            //Mosnter turn
            Random randMosnterChoice = new Random();
            int mosnterChoice = randMosnterChoice.Next(0, 2);
            switch(mosnterChoice){
                case 0:
                Console.WriteLine("O monstro ataca você.");
                Thread.Sleep(2000);

                if(playerAtributes.playerIsDefending == true){
                    playerAtributes.playerHp -= monsterAtributes.MosnterAttackAction()/2;
                    Thread.Sleep(2000);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Você recebeu {monsterAtributes.MosnterAttackAction()/2} de dano.");
                    Console.ForegroundColor = ConsoleColor.Black;
                    playerAtributes.PlayerUndefenceAction();
                }else{
                    playerAtributes.playerHp -= monsterAtributes.MosnterAttackAction();
                    Thread.Sleep(2000);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Você recebeu {monsterAtributes.MosnterAttackAction()} de dano.");
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                break;
                    
                case 1:
                Console.WriteLine("O monstro está se defendendo.");
                Thread.Sleep(2000);
                monsterAtributes.MosnterDefenceAction();
                break;
            }
        }
        #endregion
    }
}