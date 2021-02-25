using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Konsole;

namespace CRPG
{
    class Player
    {
        public string nome { get; }
        public int playerAtk { get; private set; }
        public int playerDef { get; private set; }
        public bool playerDefendendo { get; private set; }
        public int playerHp { get; set; }
        public int palyerXp { get; set; }
        public int xpParaProximo { get; private set; }
        public int playerLevel { get; private set; }
        public int passos { get; private set; }
        public Player(string nome)
        {
            this.nome = nome;
            playerAtk = 4;
            playerDef = 2;
            playerDefendendo = false;
            playerHp = 20;
            palyerXp = 0;
            xpParaProximo = 12;
        }
        public void VerStatus()
        {
            var status = Window.OpenBox("Status", 40, 10, new BoxStyle {
                Title = new Colors( ConsoleColor.White, ConsoleColor.Blue),
                ThickNess = LineThickNess.Double
            });
            status.WriteLine($"Nome: {nome}");
            status.WriteLine($"Ataque: {playerAtk}");
            status.WriteLine($"Defesa: {playerDef}");
            status.WriteLine($"HP: {playerHp}");
            status.WriteLine($"Level: {playerLevel}");
            status.WriteLine($"XP: {palyerXp}. Faltam {xpParaProximo - palyerXp} para o próximo nivel.");
        }

        #region Ações
        public void Andar() => passos += 1; //Dar um passo
        public void Voltar() => passos -= 1;
        public Locais VerAoRedor()
        {
            //Ver onde o player está de acordo com a quantidade de passos dada
            return passos switch
            {
                >= 0 and <= 19 => Locais.Planices,
                >= 20 and <= 34 => Locais.Floresta,
                >= 35 and <= 44 => Locais.Pantano,
                >= 45 and <= 59 => Locais.Deserto,
                >= 60 => Locais.Piramide,
                _ => Locais.Void
            };
        }
        public int PlayerAttack() => playerAtk;
        public bool PlayerDefender() => playerDefendendo = true;
        public bool PlayerDesdefender() => playerDefendendo = false;
        public void AdicionarXp(int xpAmmount) => palyerXp += xpAmmount;
        public void LevelUp()
        {
            Console.Clear();
            while (palyerXp >= xpParaProximo)
            {
                playerLevel += 1;
                xpParaProximo *= 2;

                var winLevelUp = Window.OpenBox("Level UP",  50, 10, new BoxStyle
                {
                    Title = new Colors(ConsoleColor.White, ConsoleColor.Yellow),
                    ThickNess = LineThickNess.Double
                });
                winLevelUp.WriteLine($"Você passou de nivel!\nAgora você está no level: {this.playerLevel}");

                //Aumentar atributos
                playerAtk += 3;
                winLevelUp.WriteLine("Seu ataque aumentou em 3.");
                playerDef += 2;
                winLevelUp.WriteLine("Sua defesa aumentou em 2.");
                playerHp += 7;
                winLevelUp.WriteLine("Seu HP aumentou em 7.");
                Thread.Sleep(3000);
            }
        }
        #endregion
        public void PlayerDie()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Você morreu...");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Aqui está até onde você chegou:");
            VerStatus();
            Environment.Exit(0);
        }
    }
}
