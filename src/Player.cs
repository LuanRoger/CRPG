using LandsNS;
using System;

namespace PlayerNS{

    //Player class com seu atributos
    public class Player{
        public string name {get; private set;}
        public int playerAtk {get; private set;}
        public int playerDef {get; private set;}
        public bool playerIsDefending {get; set;}
        public int playerHp {get; set;}
        public int palyerXp {get; private set;}
        public int xpToUp {get; private set;}
        public int playerLevel {get; private set;}
        public int steps {get; private set;} = 0;

        public Player CreatePlayer(string playerName){
            Player player = new Player();
            this.name = playerName;
            this.playerAtk = 4; //ATK padrão
            this.playerDef = 2; //DEF padrão
            this.playerHp = 20;//Life padrão
            this.palyerXp = 0;
            this.xpToUp = 12;

            return player;
        }
        #region Metodos de ação
        public void Walk() => this.steps += 1; //Dar um passo
        public void Return() => this.steps -= 1;
        public string SeeArroud(){ //Ver onde o player está de acordo com a quantidade de passos dada
            Lands lands = new Lands();
            if(this.steps >= 0 && this.steps <= 19){
                return lands.places[0];
            }else if(this.steps >= 20 && this.steps <= 34){
                return lands.places[1];
            }else if(this.steps >= 35 && this.steps <= 44){
                return lands.places[2];
            }else if(this.steps >= 45 && this.steps <= 59){
                return lands.places[3];
            }else if(this.steps >= 60){
                return lands.places[4];
            }else{
                return "Void";
            }
        }
        public int PlayerAttackAction() => this.playerAtk;
        public bool PlayerDefenceAction() => this.playerIsDefending = true;
        public bool PlayerUndefenceAction() => this.playerIsDefending = false;
        public void AddXp(int xpAmmount) => this.palyerXp += xpAmmount;
        public void LevelUp(){
            if(this.palyerXp >= this.xpToUp){
                this.playerLevel += 1;
                this.xpToUp *= 2;
                Console.WriteLine("======================");
                Console.WriteLine($"Você passou de nivel!\nAgora você está no level: {this.playerLevel}");
                //Aumentar atributos
                this.playerAtk += 3;
                Console.WriteLine("Seu ataque aumentou em 3.");
                this.playerDef += 2;
                Console.WriteLine("Sua defesa aumentou em 2.");
                this.playerHp += 7;
                Console.WriteLine("Seu HP aumentou em 7.");
                Console.WriteLine("======================");
            }else{
                return;
            }
        }
        #endregion
        public void SeeStatus(){
            Console.WriteLine("=================================");
            Console.WriteLine($"Nome: {this.name}");
            Console.WriteLine($"Ataque: {this.playerAtk}");
            Console.WriteLine($"Defesa: {this.playerDef}");
            Console.WriteLine($"HP: {this.playerHp}");
            Console.WriteLine($"XP: {this.palyerXp}. Faltam {this.xpToUp - this.palyerXp} para o próximo nivel.");
            Console.WriteLine("=================================");

        }
        public void PlayerDie(){
            Console.WriteLine("Você morreu...");
            Console.WriteLine("Aqui está até onde você chegou:");
            SeeStatus();
            Environment.Exit(0);
        }
    }
}