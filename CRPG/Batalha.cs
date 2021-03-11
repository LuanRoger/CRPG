using System;
using System.Threading;
using Konsole;

namespace CRPG
{
    class Batalha
    {
        private Player playerBatalha { get; }
        private Monstros monstroBatalha { get; }
        private IConsole[] telaMeioAndarConsole { get; }
        private IConsole telaStatusAndarConsole { get; }

        public Batalha(Player player, Monstros monstro, IConsole telaMeioAndarConsole, IConsole telaStatusAndarConsole)
        {
            playerBatalha = player;
            monstroBatalha = monstro;
            this.telaMeioAndarConsole = telaMeioAndarConsole.SplitColumns(new Split(0), new Split(50));
            this.telaStatusAndarConsole = telaStatusAndarConsole;

            Acessorios.AtivarItemPreBatalha(player, monstro).ForEach(acessorio =>
            {
                telaStatusAndarConsole.WriteLine($"{acessorio} foram ativados");
                Thread.Sleep(350);
            });

            while (true)
            {
                Thread.Sleep(1000);

                AtualizarStatusBatalha();

                Thread.Sleep(500);

                PlayerTurno();

                if (monstro.monstroHp <= 0) break;

                MonsterTurno();

                if (player.playerHp <= 0) break;

                this.telaMeioAndarConsole[0].Clear();
                this.telaMeioAndarConsole[1].Clear();
            }
            if (player.playerHp >= 0)
            {
                telaStatusAndarConsole.WriteLine("Você ganhou!");

                Thread.Sleep(600);

                telaStatusAndarConsole.WriteLine($"Você recebeu {monstroBatalha.monstroXpDrop} de Xp");

                Thread.Sleep(1000);

                player.AdicionarXp(monstroBatalha.monstroXpDrop);

                Acessorios.DesativarItemPreBatalha(player);

                this.telaMeioAndarConsole[0].Clear();
                this.telaMeioAndarConsole[1].Clear();
                this.telaStatusAndarConsole.Clear();
            }
            else player.PlayerDie();
        }

        private void AtualizarStatusBatalha()
        {
            var telaStatusMonstro = telaMeioAndarConsole[0].OpenBox("Monstro",  1, 0, 30, 7);
            var telaStatusPlayer = telaMeioAndarConsole[1].OpenBox("Player", 30, 7);

            telaStatusPlayer.WriteLine($"HP: {this.playerBatalha.playerHp}");
            telaStatusPlayer.WriteLine($"ATK: {this.playerBatalha.playerAtk}");
            telaStatusPlayer.WriteLine($"DEF: {this.playerBatalha.playerDef}");

            telaStatusMonstro.WriteLine($"Nome: {monstroBatalha.monstroNome}");
            telaStatusMonstro.WriteLine($"HP: {this.monstroBatalha.monstroHp}");
            telaStatusMonstro.WriteLine($"ATK: {this.monstroBatalha.monstroAtk}");
        }

        #region Turnos
        private void PlayerTurno()
        {
            var mnuAtacar = new MenuItem("Atacar", () =>
            {
                telaStatusAndarConsole.ForegroundColor = ConsoleColor.Yellow;
                telaStatusAndarConsole.WriteLine("Você ataca.");
                telaStatusAndarConsole.ForegroundColor = ConsoleColor.Gray;

                Thread.Sleep(1000);

                int dano = playerBatalha.PlayerAttack();
                if (monstroBatalha.monstroDefendendo)
                {
                    monstroBatalha.monstroHp -= dano / 2;

                    telaStatusAndarConsole.ForegroundColor = ConsoleColor.Yellow;
                    telaStatusAndarConsole.WriteLine($"Você deu {dano / 2} de dano.");
                    telaStatusAndarConsole.ForegroundColor = ConsoleColor.Gray;

                    monstroBatalha.MosnterDesdefender();
                }
                else
                {
                    monstroBatalha.monstroHp -= dano;

                    telaStatusAndarConsole.ForegroundColor = ConsoleColor.Yellow;
                    telaStatusAndarConsole.WriteLine($"Você deu {dano} de dano.");
                    telaStatusAndarConsole.ForegroundColor = ConsoleColor.Gray;
                }
            });
            var mnuDefender = new MenuItem("Defender", () =>
            {
                playerBatalha.PlayerDefender();
                telaStatusAndarConsole.WriteLine("Você esta se defendendo.");
            });
            var batalhaMenu = new Menu(telaMeioAndarConsole[1], "O que deseja fazer? (ESC para pular)",
                ConsoleKey.Escape, 45,
                mnuAtacar, mnuDefender)
            {
                OnAfterMenuItem = delegate
                {
                    mnuAtacar.Enabled = false;
                    mnuDefender.Enabled = false;
                    telaMeioAndarConsole[1].WriteLine("Aperte ESC para continuar");
                }
            };
            batalhaMenu.Run();

        }
        private void MonsterTurno()
        {
            int escolhaMonstro = new Random().Next(0,2);
            switch (escolhaMonstro)
            {
                case 0:

                    telaStatusAndarConsole.ForegroundColor = ConsoleColor.Red;
                    telaStatusAndarConsole.WriteLine($" {monstroBatalha.monstroNome} ataca você.");
                    telaStatusAndarConsole.ForegroundColor = ConsoleColor.Gray;

                    Thread.Sleep(500);

                    int dano = monstroBatalha.MosnterAtacar();
                    if (playerBatalha.playerDefendendo)
                    {
                        int danoDefendendo = dano - playerBatalha.playerDef < 0 ? 0 : dano - playerBatalha.playerDef;
                        playerBatalha.playerHp -= danoDefendendo;
                        Thread.Sleep(2000);

                        telaStatusAndarConsole.ForegroundColor = ConsoleColor.Red;
                        telaStatusAndarConsole.WriteLine($"Você recebeu {danoDefendendo} de dano.");
                        telaStatusAndarConsole.ForegroundColor = ConsoleColor.Gray;

                        playerBatalha.PlayerDesdefender();
                    }
                    else
                    {
                        playerBatalha.playerHp -= dano;
                        Thread.Sleep(2000);

                        telaStatusAndarConsole.ForegroundColor = ConsoleColor.Red;
                        telaStatusAndarConsole.WriteLine($"Você recebeu {dano} de dano.");
                        telaStatusAndarConsole.ForegroundColor = ConsoleColor.Gray;
                    }
                    break;

                case 1:
                    telaStatusAndarConsole.ForegroundColor = ConsoleColor.Red;
                    telaStatusAndarConsole.WriteLine($"{monstroBatalha.monstroNome} está se defendendo.");
                    telaStatusAndarConsole.ForegroundColor = ConsoleColor.Gray;

                    Thread.Sleep(2000);

                    monstroBatalha.MosnterDefender();
                    break;
            }
        }
        #endregion
    }
}
