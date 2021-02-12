using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CRPG
{
    class Batalha
    {
        private Player playerBatalha { get; }
        private Monstros monstroBatalha { get; }
        public Batalha(Player player, Monstros monstro)
        {
            this.playerBatalha = player;
            this.monstroBatalha = monstro;

            while (true)
            {
                Thread.Sleep(1000);
                StatusBatalha();
                Thread.Sleep(500);
                PlayerTurno();

                if (monstro.monstroHp <= 0) break;

                MonsterTurno();

                if (player.playerHp <= 0) break;
            }
            if (player.playerHp >= 0)
            {
                Console.WriteLine("Você ganhou!");
                Thread.Sleep(500);
                player.AdicionarXp(monstroBatalha.monstroXpDrop);
                Console.WriteLine($"Você recebeu {monstroBatalha.monstroXpDrop} de Xp");
                Thread.Sleep(1000);
                player.LevelUp();
            }
            else player.PlayerDie();
        }
        private void StatusBatalha()
        {
            Console.WriteLine("===Batalha========================");
            Console.WriteLine("Player:");
            Console.WriteLine($"HP: {this.playerBatalha.playerHp}");
            Console.WriteLine($"ATK: {this.playerBatalha.playerAtk}");
            Console.WriteLine($"DEF: {this.playerBatalha.playerDef}");
            Console.WriteLine("=====================");
            Console.WriteLine("Monstro:");
            Console.WriteLine($"Nome: {monstroBatalha.monstroNome}");
            Console.WriteLine($"HP: {this.monstroBatalha.monstroHp}");
            Console.WriteLine($"ATK: {this.monstroBatalha.monstroAtk}");
            Console.WriteLine("==================================");
        }

        #region Turnos
        private void PlayerTurno()
        {
            Console.WriteLine("O que você vai fazer? ");
            Console.WriteLine("> [ 1 ] - Atacar.     [ 2 ] - Defender.");
            int battleChoice = 0;
            try { battleChoice = Convert.ToInt32(Console.ReadLine()); }
            catch (Exception e) { Error.ErrorFatal(e); }

            switch (battleChoice)
            {
                case 1:
                    Console.WriteLine("Você ataca.");
                    Thread.Sleep(2000);

                    int dano = playerBatalha.PlayerAttack();
                    if (monstroBatalha.monstroDefendendo)
                    {
                        monstroBatalha.monstroHp -= dano / 2;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"Você deu {dano/2} de dano.");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        monstroBatalha.MosnterDesdefender();
                    }
                    else
                    {
                        monstroBatalha.monstroHp -= dano;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"Você deu {dano} de dano.");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    break;

                case 2:
                    playerBatalha.PlayerDefender();
                    Console.WriteLine("Você esta se defendendo.");
                    break;
            }
        }
        private void MonsterTurno()
        {
            int escolhaMonstro = new Random().Next(0,2);
            switch (escolhaMonstro)
            {
                case 0:
                    Console.WriteLine("O monstro ataca você.");
                    Thread.Sleep(500);

                    int dano = monstroBatalha.MosnterAtacar();
                    if (playerBatalha.playerDefendendo)
                    {
                        playerBatalha.playerHp -= dano - playerBatalha.playerDef;
                        Thread.Sleep(2000);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Você recebeu {dano - playerBatalha.playerDef} de dano.");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        playerBatalha.PlayerDesdefender();
                    }
                    else
                    {
                        playerBatalha.playerHp -= dano;
                        Thread.Sleep(2000);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Você recebeu {dano} de dano.");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    break;

                case 1:
                    Console.WriteLine("O monstro está se defendendo.");
                    Thread.Sleep(2000);

                    monstroBatalha.MosnterDefender();
                    break;
            }
        }
        #endregion
    }
}
