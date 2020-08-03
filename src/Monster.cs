using System;

namespace MonstersNS{
    public class Monster{
        public int monsterId {get; set;}
        public string monsterName {get; set;}
        public int monsterHp {get; set;}
        public  int monsterAtk {get; set;}
        public  int monsterXpDrop {get; set;}
        public bool monsterIsDefending {get; set;} = false;

        public int MosnterAttackAction() => this.monsterAtk;
        public bool MosnterDefenceAction() => this.monsterIsDefending = true;
        public bool MosnterUndefenceAction() => this.monsterIsDefending = false;
        public static bool MonsterFound(){
            Random randMonsterChance = new Random();
            int monsterChance = randMonsterChance.Next(0, 26);

            bool isFounded = (monsterChance <= 6) ? true : false;
            return isFounded;
        }
    }
    public class PlaniceMonsters{

        private string[] monsterPlaniceName = new string[] {"Ladrão", "Cavalo Louco", "Borboleta", "Lobo", "Alien Fraco", "Minhoca"};
        private int[] monsterPlaniceHp = new int[] {6, 12, 1, 10, 8, 1};
        private int[] monsterPlaniceAtk = new int[] {3, 6, 0, 6, 4, 0};
        private int[] monsterPlaniceXpDrop = new int[] {4, 7, 1, 5, 5, 1};

        public Monster createPlaniceMonster(){
            Monster planiceMonster = new Monster();
            Random mosnterChoice = new Random();
            int monsterId = mosnterChoice.Next(0,6); //Vai escolher o index dos monstros

            //Atribuir de acordo com o index
            planiceMonster.monsterName = monsterPlaniceName[monsterId];
            planiceMonster.monsterHp = monsterPlaniceHp[monsterId];
            planiceMonster.monsterAtk = monsterPlaniceAtk[monsterId];
            planiceMonster.monsterXpDrop = monsterPlaniceXpDrop[monsterId];

            return planiceMonster;
        }
    }
    public class FlorestMonsters{
        private string[] monsterFlorestName = new string[] {"Gnomo", "Ciclope", "Árvore Amaldiçoada", "Estranho", "Raiz Enfeitiçada", "Pássaro Perigosso"};
        private int[] monsterFlorestHp = new int[] {8, 18, 20, 13, 15, 7};
        private int[] monsterFlorestAtk = new int[] {5, 9, 5, 4, 6, 7};
        private int[] monsterFlorestXpDrop = new int[] {6, 12, 8, 5, 8, 5};

        public Monster createFlorestMonster(){
            Monster florestMonster = new Monster();
            Random mosnterChoice = new Random();
            int monsterId = mosnterChoice.Next(0,6); //Vai escolher o index dos monstros

            //Atribuir de acordo com o index
            florestMonster.monsterName = monsterFlorestName[monsterId];
            florestMonster.monsterHp = monsterFlorestHp[monsterId];
            florestMonster.monsterAtk = monsterFlorestAtk[monsterId];
            florestMonster.monsterXpDrop = monsterFlorestXpDrop[monsterId];

            return florestMonster;
        }
    }
    public class SwampMonsters{
        private string[] monsterSwampName = new string[] {"Jacaré Grande", "Ogro", "Piranha", "Monstro de Lodo", "Mergulhador Antigo", "Cobra Gigante"};
        private int[] monsterSwampHp = new int[] {17, 21, 14, 22, 19, 16};
        private int[] monsterSwampAtk = new int[] {11, 13, 11, 13, 10, 13};
        private int[] monsterSwampXpDrop = new int[] {15, 13, 15, 13, 12, 12};

        public Monster createSwampMonster(){
            Monster swampMonster = new Monster();
            Random mosnterChoice = new Random();
            int monsterId = mosnterChoice.Next(0,6); //Vai escolher o index dos monstros

            //Atribuir de acordo com o index
            swampMonster.monsterName = monsterSwampName[monsterId];
            swampMonster.monsterHp = monsterSwampHp[monsterId];
            swampMonster.monsterAtk = monsterSwampAtk[monsterId];
            swampMonster.monsterXpDrop = monsterSwampXpDrop[monsterId];

            return swampMonster;
        }
    }
    public class DesertMonsters{
        private string[] monsterDesertName = new string[] {"Elemento de Fogo", "Tempestade Viva", "Cacto", "Lobo do Deserto", "Zumbi de areia", "Serpente"};
        private int[] monsterDesertHp = new int[] {25, 29, 21, 27, 27, 24};
        private int[] monsterDesertAtk = new int[] {17, 18, 15, 20, 18, 19};
        private int[] monsterDesertXpDrop = new int[] {19, 21, 15, 20, 19, 19};

        public Monster createDesertMonster(){
            Monster desertMonster = new Monster();
            Random mosnterChoice = new Random();
            int monsterId = mosnterChoice.Next(0,6); //Vai escolher o index dos monstros

            //Atribuir de acordo com o index
            desertMonster.monsterName = monsterDesertName[monsterId];
            desertMonster.monsterHp = monsterDesertHp[monsterId];
            desertMonster.monsterAtk = monsterDesertAtk[monsterId];
            desertMonster.monsterXpDrop = monsterDesertXpDrop[monsterId];

            return desertMonster;
        }
    }
    public class PyramidMonsters{
        private string[] monsterPyramidName = new string[] {"Besouro Antigo", "Múmia", "Parede com Rosto", "Fantasma", "Mímico", "Bicho de piramide"};
        private int[] monsterPyramidHp = new int[] {33, 37, 42, 40, 39, 40};
        private int[] monsterPyramidAtk = new int[] {22, 25, 26, 28, 29, 27};
        private int[] monsterPyramidXpDrop = new int[] {24, 28, 30, 33, 32, 31};

        public Monster createPyramidMonster(){
            Monster pyramidMonster = new Monster();
            Random mosnterChoice = new Random();
            int monsterId = mosnterChoice.Next(0,6); //Vai escolher o index dos monstros

            //Atribuir de acordo com o index
            pyramidMonster.monsterName = monsterPyramidName[monsterId];
            pyramidMonster.monsterHp = monsterPyramidHp[monsterId];
            pyramidMonster.monsterAtk = monsterPyramidAtk[monsterId];
            pyramidMonster.monsterXpDrop = monsterPyramidXpDrop[monsterId];

            return pyramidMonster;
        }
    }
    public class Boss{
        public Monster createFinalBoss(){
            Monster finalBoss = new Monster();
            finalBoss.monsterName = "Crystal";
            finalBoss.monsterHp = 128;
            finalBoss.monsterAtk = 48;
            finalBoss.monsterXpDrop = 500;

            return finalBoss;
        }
    }
}