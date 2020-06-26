using LandsNS;
using System;

namespace PlayerNS{

    //Player class com seu atributos
    class Player{
        public string name {get; private set;}
        public int playerAtk {get; private set;}
        public int playerDef {get; private set;}
        public int playerLife {get; set;} = 20;
        public int palyerXp {get; private set;}
        public int steps {get; private set;} = 0;

        public Player CreatePlayer(string playerName){
            Player player = new Player();
            this.name = playerName;
            this.playerAtk = 4; //ATK padrão
            this.playerDef = 2; //DEF padrão
            
            return player;
        }
        #region Metodos de ação
        public void Walk() => this.steps += 1; //Dar um passo
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
        #endregion
        public void SeeStatus(){ //Metodo de informação, tendo que conter 'WriteLine()'
            Console.WriteLine("=================================");
            Console.WriteLine($"Nome: {this.name}");
            Console.WriteLine($"Ataque: {this.playerAtk}");
            Console.WriteLine($"Defesa: {this.playerDef}");
            Console.WriteLine($"Vida: {this.playerLife}");
            Console.WriteLine($"XP: {this.palyerXp}");
            Console.WriteLine("=================================");

        }
    }
}