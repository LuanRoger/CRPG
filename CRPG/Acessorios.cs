using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Konsole;

namespace CRPG
{
    public class Acessorios
    {
        private static int LuckFoundItem = 200;

        private static readonly string[] AcessoriosPlanices = new string[] { "Trevo" };
        private static readonly string[] AcessoriosFloresta = new string[] { "Olho de Ciclope", "Bracelete de Protecao", "Colar Amaldiçoado" };
        private static readonly string[] AcessorioPantano = new string[] { "Lanterna", "Veneno de Cobra", "Capacete de Mergulhador" };
        private static readonly string[] AcessorioDeserto = new string[] { "Pe de Coelho", "Bola de Cristal", "Balde", "Colar de Fogo" };
        private static readonly string[] AcessorioPiramide = new string[] { "Cajado", "Moeda Dourada", "Escaravelho", "Plasma" };
        private static readonly string[] AcessorioVoid = new string[] { "Buraco Negro", "Null" };

        public static void ProcurarItem(Locais localAtual, Player player)
        {
            int chance = new Random().Next(0, LuckFoundItem - player.playerSorte);

            switch(localAtual) 
            {
                case Locais.Planices:
                    ProcurarItemPlanice(chance, player);
                    break;
                case Locais.Floresta:
                    ProcurarItemFloresta(chance, player);
                    break;
                case Locais.Pantano:
                    ProcurarItemPantano(chance, player);
                    break;
                case Locais.Deserto:
                    ProcurarItemDeserto(chance, player);
                    break;
                case Locais.Piramide:
                    ProcurarItemPiramide(chance, player);
                    break;
                case Locais.Void:
                    ProcurarItemVoid(chance, player);
                    break;
            }
        }
        public static void AtivacaoItemPassivo(Player player)
        {
            foreach(string acessorio in player.AcessoriosPlayer)
            {
                if (new Random().Next(0, 100) <= 5 && acessorio == "Lanterna") 
                    player.AdicionarXp(1);
                else if(new Random().Next(0, 100) <= 7 && acessorio == "Plasma") 
                    player.AdicionarXp(3);
                else if (new Random().Next(0, 100) <= 10 && acessorio == AcessorioVoid[1])
                {
                    int itemGanhar = new Random().Next(0, 6);
                    switch (itemGanhar)
                    {
                        case 0:
                            player.AcessoriosPlayer.Add(AcessoriosPlanices[0]);
                            break;
                        case 1:
                            player.AcessoriosPlayer.Add(AcessoriosFloresta[new Random().Next(0, 2)]);
                            break;
                        case 2:
                            player.AcessoriosPlayer.Add(AcessorioPantano[new Random().Next(0, 2)]);
                            break;
                        case 3:
                            player.AcessoriosPlayer.Add(AcessorioDeserto[new Random().Next(0, 3)]);
                            break;
                        case 4:
                            player.AcessoriosPlayer.Add(AcessorioPiramide[new Random().Next(0, 3)]);
                            break;
                        case 5:
                            player.AcessoriosPlayer.Add(AcessorioVoid[new Random().Next(0, 1)]);
                            break;
                    }
                }
            }
        }
        public static List<string> AtivarItemPreBatalha(Player player, Monstros monstros)
        {
            List<string> itensAtivados = new List<string>();

            foreach(string acessorio in player.AcessoriosPlayer)
            {
                if (acessorio == AcessoriosFloresta[2] && monstros.monstroNome == "Árvore Amaldiçoada")
                {
                    player.playerAtk += 2;
                    player.vezesAtivadoColarAmaldicoado += 1;

                    itensAtivados.Add(AcessoriosFloresta[2]);
                }
                else if (acessorio == AcessoriosFloresta[0] && monstros.monstroNome == "Ciclope")
                {
                    player.playerAtk += 2;
                    player.vezesAtivadoOlhoCiclope += 1;

                    itensAtivados.Add(AcessoriosFloresta[0]);
                }
                else if (acessorio == AcessorioPantano[2] && monstros.monstroNome == "Mergulhador Antigo")
                {
                    player.playerAtk += 1;
                    player.vezesAtivadoCapaceteMergulhador += 1;

                    itensAtivados.Add(AcessorioPantano[2]);
                }
                else if (new Random().Next(0, 100) <= 50 && acessorio == AcessorioPantano[1])
                {
                    player.playerAtk += 1;
                    player.vezesAtivadoVenenoCobra += 1;

                    itensAtivados.Add(AcessorioPantano[1]);
                }
                else if (new Random().Next(0, 100) <= 20 && acessorio == AcessorioDeserto[3])
                {
                    monstros.monstroHp = monstros.monstroHp >= 3 ? monstros.monstroHp -= 2 : monstros.monstroHp;

                    itensAtivados.Add(AcessorioDeserto[3]);
                }
                else if (new Random().Next(0, 100) <= 30 && acessorio == AcessorioPiramide[2])
                {
                    player.playerAtk += 2;
                    player.vezesAtivadoEscaravelho += 1;

                    itensAtivados.Add(AcessorioPiramide[2]);
                }
                else if (new Random().Next(0, 100) <= 20 && acessorio == AcessorioVoid[0])
                {
                    monstros.monstroHp = 0;

                    itensAtivados.Add(AcessorioVoid[0]);
                }
            }
            return itensAtivados;
        }
        public static void DesativarItemPreBatalha(Player player)
        {
            for (; player.vezesAtivadoColarAmaldicoado != 0; player.vezesAtivadoColarAmaldicoado--) 
                player.playerAtk -= 2;
            for (;  player.vezesAtivadoOlhoCiclope != 0; player.vezesAtivadoOlhoCiclope--) 
                player.playerAtk -= 2;
            for (; player.vezesAtivadoCapaceteMergulhador != 0; player.vezesAtivadoCapaceteMergulhador--) 
                player.playerAtk -= 1;
            for (; player.vezesAtivadoVenenoCobra != 0; player.vezesAtivadoVenenoCobra--) 
                player.playerAtk -= 1;
            for (; player.vezesAtivadoEscaravelho != 0; player.vezesAtivadoEscaravelho--) 
                player.playerAtk -= 2;
        }

        private static void ApresentarItemGanho(string nomeItem, string descricaoItem)
        {
            var itemGanhoBox = Window.OpenBox("Novo item adquirido", 40, 20, new BoxStyle
            {
                Title = new Colors(ConsoleColor.White, ConsoleColor.Red),
                ThickNess = LineThickNess.Double
            });
            itemGanhoBox.WriteLine($"Você achou {nomeItem}:");
            itemGanhoBox.WriteLine(descricaoItem);
            Thread.Sleep(3000);
            Console.Clear();
        }
        private static void ProcurarItemPlanice(int chance, Player player)
        {
            switch (chance)
            {
                case >= 0 and <= 15: // Trevo
                    player.AcessoriosPlayer.Add(AcessoriosPlanices[0]);
                    player.playerSorte += 1;
                    ApresentarItemGanho(AcessoriosPlanices[0], 
                        "+1 de Sorte");
                    break;
            }
        }

        private static void ProcurarItemFloresta(int chance, Player player)
        {
            switch(chance)
            {
                case >= 0 and <= 20: // Bracelete de Protecao
                    player.AcessoriosPlayer.Add(AcessoriosFloresta[1]);
                    player.playerDef += 1;
                    ApresentarItemGanho(AcessoriosFloresta[1], 
                        "+1 de DEF");
                    break;
                case > 20 and <= 27: // Colar Amaldiçoado -> +2 de ATK quando lutar com Árvore Amaldiçoada
                    player.AcessoriosPlayer.Add(AcessoriosFloresta[2]);
                    ApresentarItemGanho(AcessoriosFloresta[2], "+2 de ATK quando lutar com Árvore Amaldiçoada");
                    break;
                case > 27 and <= 32: // Olho de Ciclope -> +2 de ATK quando lutar contra Ciclope
                    player.AcessoriosPlayer.Add(AcessoriosFloresta[0]);
                    ApresentarItemGanho(AcessoriosFloresta[0], "+2 de ATK quando lutar contra Ciclope");
                    break;
            }
        }
        private static void ProcurarItemPantano(int chance, Player player)
        {
            switch(chance)
            {
                case >= 0 and <= 12: // Lanterna -> Chance de +1 de XP a cada passo
                    player.AcessoriosPlayer.Add(AcessorioPantano[0]);
                    ApresentarItemGanho(AcessorioPantano[0], "Chance de +1 de XP a cada passo");
                    break;
                case > 12 and <= 17: // Veneno de Cobra -> Chance de entrar em uma batalha com +1 de ATK
                    player.AcessoriosPlayer.Add(AcessorioPantano[1]);
                    ApresentarItemGanho(AcessorioPantano[1], "Chance de entrar em uma batalha com +1 de ATK");
                    break;
                case > 17 and <= 24: // Capacete de Mergulhador -> +1 de ATK quando lutar contra Mergulhador Antigo
                    player.AcessoriosPlayer.Add(AcessorioPantano[2]);
                    ApresentarItemGanho(AcessorioPantano[2], "+1 de ATK quando lutar contra Mergulhador Antigo");
                    break;
            }
        }
        
        private static void ProcurarItemDeserto(int chance, Player player)
        {
            switch(chance)
            {
                case >= 0 and <= 7: // Pé de Coelho
                    player.AcessoriosPlayer.Add(AcessorioDeserto[0]);
                    player.playerSorte += 2;
                    ApresentarItemGanho(AcessorioDeserto[0], "+2 de Sorte");
                    break;
                case > 7 and <= 17: // Bola de Cristal
                    player.AcessoriosPlayer.Add(AcessorioDeserto[1]);
                    player.AdicionarXp(3);
                    ApresentarItemGanho(AcessorioDeserto[1], "+3 de XP");
                    break;
                case > 17 and <= 47: // Balde
                    player.AcessoriosPlayer.Add(AcessorioDeserto[2]);
                    player.playerDef += 2;
                    ApresentarItemGanho(AcessorioDeserto[2], "+2 de DEF");
                    break;
                case > 47 and <= 52: // Colar de Fogo -> +3 de ATK & Chance de Inimigo entrar na batalha com -2 de HP
                    player.AcessoriosPlayer.Add(AcessorioDeserto[3]);
                    player.playerAtk += 3;
                    ApresentarItemGanho(AcessorioDeserto[3], "+3 de ATK & Chance do inimigo entrar na batalha com -2 de HP");
                    break;
            }
        }
        private static void ProcurarItemPiramide(int chance, Player player)
        {
            switch(chance)
            {
                case >= 0 and <= 20: // Cajado
                    player.AcessoriosPlayer.Add(AcessorioPiramide[0]);
                    player.playerAtk += 2;
                    ApresentarItemGanho(AcessorioPiramide[0], "+2 de ATK");
                    break;
                case > 20 and <= 27: // Moeda Dourada
                    player.AcessoriosPlayer.Add(AcessorioPiramide[1]);
                    player.playerSorte += 3;
                    ApresentarItemGanho(AcessorioPiramide[1], "+3 de Sorte");
                    break;
                case > 27 and <= 37: // Escaravelho -> Chance de entrar em uma batalha com +2 de ATK
                    player.AcessoriosPlayer.Add(AcessorioPiramide[2]);
                    ApresentarItemGanho(AcessorioPiramide[2], "Chance de entrar em uma batalha com +2 de ATK");
                    break;
                case > 37 and <= 45: // Plasma -> Chance de +3 de XP a cada passo
                    player.AcessoriosPlayer.Add(AcessorioPiramide[3]);
                    ApresentarItemGanho(AcessorioPiramide[3], "Chance de +3 de XP a cada passo");
                    break;
            }
        }
        private static void ProcurarItemVoid(int chance, Player player)
        {
            switch(chance)
            {
                case >= 0 and <= 10: // Buraco Negro -> Chace de entrar na batalha com o inimigo já derrotado
                    player.AcessoriosPlayer.Add(AcessorioVoid[0]);
                    ApresentarItemGanho(AcessorioVoid[0], "Chace de entrar na batalha com o inimigo já derrotado");
                    break;
                case > 10 and <= 15: // Null -> Chance de receber um item aletorio de qualquer local.
                    player.AcessoriosPlayer.Add(AcessorioVoid[1]);
                    ApresentarItemGanho(AcessorioVoid[1], "Chance de receber um item aletorio de qualquer local.");
                    break;
            }
        }
    }
}
