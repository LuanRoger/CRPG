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
}