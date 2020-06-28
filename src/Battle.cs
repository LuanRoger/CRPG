using PlayerNS;
using MonstersNS;
using System;
using System.Threading;

namespace BattleNS {
    public class Battle{
        public Battle(Player player, Monster monster){
            while (player.playerHp > 0 || monster.monsterHp > 0)
            {
                BattleStatus(player, monster);
                PlayerTurn(player, monster);
                if(monster.monsterHp <= 0){ break; } //Casso o mostro morra antes da verificação do while 
                MonsterTurn(player, monster);
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
            Console.WriteLine("[ 1 ] - Atacar.     [ 2 ] - Defender.");
            int battleChoice = Convert.ToInt32(Console.ReadLine());

            switch(battleChoice){
                case 1:
                System.Console.WriteLine("Você ataca.");
                Thread.Sleep(2000);
                if(monsterAtributes.monsterIsDefending == true){ //Dividir o ataque do player por 2 casso o monstro esteja defendendo
                    monsterAtributes.monsterHp -= playerAtributes.PlayerAttackAction()/2;
                    Console.WriteLine($"Você deu {playerAtributes.PlayerAttackAction()/2} de dano.");
                    monsterAtributes.MosnterUndefenceAction();
                }else{
                    monsterAtributes.monsterHp -= playerAtributes.PlayerAttackAction();
                    Console.WriteLine($"Você deu {playerAtributes.PlayerAttackAction()} de dano.");
                }
                break;

                case 2:
                playerAtributes.PlayerDefenceAction();
                System.Console.WriteLine("Você esta se defendendo.");
                break;
                    
                case 3: //Teste, pois isso ira fazer com que player perca a vez.
                playerAtributes.SeeStatus();
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
                    Console.WriteLine($"Você recebeu {monsterAtributes.MosnterAttackAction()/2} de dano.");
                    playerAtributes.PlayerUndefenceAction();
                }else{
                    playerAtributes.playerHp -= monsterAtributes.MosnterAttackAction();
                    Thread.Sleep(2000);
                    Console.WriteLine($"Você recebeu {monsterAtributes.MosnterAttackAction()} de dano.");
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