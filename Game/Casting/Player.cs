

namespace Dragons.Game.Casting
{
    public class Player : Actor 
    {
        private int Player_Life = 20; 
        private int Player_Armor = 12;
        public int damage = 5;
        public int melee_range = 40;


        // bool indicates if item has been unlocked
        private bool bow = false; //unlocks use of projectiles or just increases damage 
        private bool sword = false; //longer reach for melee and more damage
        private bool shield = false; //not sure what to do about this yet. Probably introduce a wall in front of you so projectiles get blocked
        private bool armor = false; // increases Player_Armor rating to reduce incoming damage



        public Player(){}

        public void takes_damage(int damage){
            this.Player_Life -= (damage * 1-(Player_Armor/100));

        }
    }
}