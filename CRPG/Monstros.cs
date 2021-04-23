using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRPG
{
    public class Monstros
    {
        public string monstroNome { get; set; }
        public int monstroHp { get; set; }
        public int monstroAtk { get; set; }
        public int monstroXpDrop { get; set; }
        public bool monstroDefendendo { get; set; } = false;

        #region Monstros
        //Monstros da planice
        private readonly string[] monstroPlaniceNome = new string[]
            {"Ladrão", "Cavalo Louco", "Borboleta", "Lobo", "Alien Fraco", "Minhoca"};

        private readonly int[] monstroPlaniceHp = new int[] {6, 12, 1, 10, 8, 1};
        private readonly int[] monstroPlaniceAtk = new int[] {3, 6, 0, 6, 4, 0};
        private readonly int[] monstroPlaniceXpDrop = new int[] {4, 7, 1, 5, 5, 1};

        //Monstros da floreta
        private readonly string[] monstroFlorestaNome = new string[]
            {"Gnomo", "Ciclope", "Árvore Amaldiçoada", "Estranho", "Raiz Enfeitiçada", "Pássaro Perigosso"};

        private readonly int[] monstroFlorestaHp = new int[] {8, 18, 20, 13, 15, 7};
        private readonly int[] monstroFlorestaAtk = new int[] {5, 9, 5, 4, 6, 7};
        private readonly int[] monstroFlorestaXpDrop = new int[] {6, 12, 8, 5, 8, 5};

        //Mosntros do pantano
        private readonly string[] monstroPantanoNome = new string[]
            {"Jacaré Grande", "Ogro", "Piranha", "Monstro de Lodo", "Mergulhador Antigo", "Cobra Gigante"};

        private readonly int[] monstroPantanoHp = new int[] {17, 21, 14, 22, 19, 16};
        private readonly int[] monstroPantanoAtk = new int[] {11, 13, 11, 13, 10, 13};
        private readonly int[] monstroPantanoXpDrop = new int[] {15, 13, 15, 13, 12, 12};

        //Montros do deserto
        private readonly string[] monstroDesertoName = new string[]
            {"Elemento de Fogo", "Tempestade Viva", "Cacto", "Lobo do Deserto", "Zumbi de areia", "Serpente"};

        private readonly int[] monstroDesertoHp = new int[] {25, 29, 21, 27, 27, 24};
        private readonly int[] monstroDesertoAtk = new int[] {17, 18, 15, 20, 18, 19};
        private readonly int[] monstroDesertoXpDrop = new int[] {19, 21, 15, 20, 19, 19};

        //Monstros da piramide
        private readonly string[] monstroPiramideName = new string[]
            {"Besouro Antigo", "Múmia", "Parede com Rosto", "Fantasma", "Mímico", "Bicho de piramide"};

        private readonly int[] monstroPiramideHp = new int[] {33, 37, 42, 40, 39, 40};
        private readonly int[] monstroPiramideAtk = new int[] {22, 25, 26, 28, 29, 27};
        private readonly int[] monstroPiramideXpDrop = new int[] {24, 28, 30, 33, 32, 31};

        //Boss final
        private readonly string chefeFinalNome = "Crystal";
        private readonly int chefeHp = 128;
        private readonly int chefeAtk = 48;
        private readonly int chefeXpDrop = 500;

        //Void mosntro
        private readonly string voidNome = "Voider";
        private readonly int voiderHp = 999;
        private readonly int voiderAtk = 999;
        private readonly int voiderXpDrop = 999;
        #endregion

        public int MosnterAtacar() => monstroAtk;
        public bool MosnterDefender() => monstroDefendendo = true;
        public bool MosnterDesdefender() => monstroDefendendo = false;

        private readonly int ChanceFoundMonster = 100;

        public Monstros MonstroAchar(Locais locais)
        {
            int chance = new Random().Next(0, ChanceFoundMonster);
            return locais switch
            {
                Locais.Planices => MonstroPlanice(chance),
                Locais.Floresta => FlorestaMonstro(chance),
                Locais.Pantano => PantanoMonstro(chance),
                Locais.Deserto => DesertoMonstro(chance),
                Locais.Piramide => PiramideMosntro(chance),
                Locais.Void => Voider(),
                Locais.ChefeFinal => ChefeFinal(),
                _ => Voider(),
            };
        }

        #region MosntrosAtributos
        private Monstros MonstroPlanice(int chance)
        {
            int monstroIndex;
            switch(chance)
            {
                case <= 5:
                    monstroIndex = 0;
                    break;
                case > 5 and <= 10:
                    monstroIndex = 1;
                    break;
                case > 10 and <= 20:
                    monstroIndex = 2;
                    break;
                case > 20 and <= 30:
                    monstroIndex = 3;
                    break;
                case > 30 and <= 35:
                    monstroIndex = 4;
                    break;
                case > 35 and <= 40:
                    monstroIndex = 5;
                    break;
                default:
                    return null;
            }

            return new Monstros { monstroNome = monstroPlaniceNome[monstroIndex],
                monstroHp = monstroPlaniceHp[monstroIndex],
                monstroAtk = monstroPlaniceAtk[monstroIndex],
                monstroXpDrop = monstroPlaniceXpDrop[monstroIndex],
                monstroDefendendo = monstroDefendendo };
        }

        private Monstros FlorestaMonstro(int chance)
        {
            int monstroIndex;
            switch (chance)
            {
                case <= 5:
                    monstroIndex = 0;
                    break;
                case > 5 and <= 10:
                    monstroIndex = 1;
                    break;
                case > 10 and <= 20:
                    monstroIndex = 2;
                    break;
                case > 20 and <= 30:
                    monstroIndex = 3;
                    break;
                case > 30 and <= 35:
                    monstroIndex = 4;
                    break;
                case > 35 and <= 40:
                    monstroIndex = 5;
                    break;
                default:
                    return null;
            }

            return new Monstros { monstroNome = monstroFlorestaNome[monstroIndex],
                monstroHp = monstroFlorestaHp[monstroIndex],
                monstroAtk = monstroFlorestaAtk[monstroIndex],
                monstroXpDrop = monstroFlorestaXpDrop[monstroIndex],
                monstroDefendendo = monstroDefendendo };
        }

        private Monstros PantanoMonstro(int chance)
        {
            int monstroIndex;
            switch (chance)
            {
                case <= 5:
                    monstroIndex = 0;
                    break;
                case > 5 and <= 10:
                    monstroIndex = 1;
                    break;
                case > 10 and <= 20:
                    monstroIndex = 2;
                    break;
                case > 20 and <= 30:
                    monstroIndex = 3;
                    break;
                case > 30 and <= 35:
                    monstroIndex = 4;
                    break;
                case > 35 and <= 40:
                    monstroIndex = 5;
                    break;
                default:
                    return null;
            }

            return new Monstros { monstroNome = monstroPantanoNome[monstroIndex],
                monstroHp = monstroPantanoHp[monstroIndex],
                monstroAtk = monstroPantanoAtk[monstroIndex],
                monstroXpDrop = monstroPantanoXpDrop[monstroIndex],
                monstroDefendendo = monstroDefendendo };
        }

        private Monstros DesertoMonstro(int chance)
        {
            int monstroIndex;
            switch (chance)
            {
                case <= 5:
                    monstroIndex = 0;
                    break;
                case > 5 and <= 10:
                    monstroIndex = 1;
                    break;
                case > 10 and <= 20:
                    monstroIndex = 2;
                    break;
                case > 20 and <= 30:
                    monstroIndex = 3;
                    break;
                case > 30 and <= 35:
                    monstroIndex = 4;
                    break;
                case > 35 and <= 40:
                    monstroIndex = 5;
                    break;
                default:
                    return null;
            }

            return new Monstros { monstroNome = monstroDesertoName[monstroIndex],
                monstroHp = monstroDesertoHp[monstroIndex],
                monstroAtk = monstroDesertoAtk[monstroIndex],
                monstroXpDrop = monstroDesertoXpDrop[monstroIndex],
                monstroDefendendo = monstroDefendendo};
        }

        private Monstros PiramideMosntro(int chance)
        {
            int monstroIndex;
            switch (chance)
            {
                case <= 5:
                    monstroIndex = 0;
                    break;
                case > 5 and <= 10:
                    monstroIndex = 1;
                    break;
                case > 10 and <= 20:
                    monstroIndex = 2;
                    break;
                case > 20 and <= 30:
                    monstroIndex = 3;
                    break;
                case > 30 and <= 35:
                    monstroIndex = 4;
                    break;
                case > 35 and <= 40:
                    monstroIndex = 5;
                    break;
                default:
                    return null;
            }

            return new Monstros { monstroNome = monstroPiramideName[monstroIndex],
                monstroHp = monstroPiramideHp[monstroIndex],
                monstroAtk = monstroPiramideAtk[monstroIndex],
                monstroXpDrop = monstroPiramideXpDrop[monstroIndex],
                monstroDefendendo = monstroDefendendo};
        }

        private Monstros ChefeFinal() => new()
        { monstroNome = chefeFinalNome,
            monstroHp = chefeHp,
            monstroAtk = chefeAtk,
            monstroXpDrop = chefeXpDrop,
            monstroDefendendo = monstroDefendendo 
        };
        private Monstros Voider() => new()
        {
            monstroNome = voidNome,
            monstroHp = voiderHp,
            monstroAtk = voiderAtk,
            monstroXpDrop = voiderXpDrop,
            monstroDefendendo = monstroDefendendo
        };
        #endregion
    }
}
