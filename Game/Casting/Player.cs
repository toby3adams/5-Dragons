

namespace Dragons.Game.Casting
{
    public class Player : Image 
    {
        public int Player_Life = 20; 
        public int Player_Armor = 0;
        public int damage = 5;
        public int melee_range = 30;
        public int ticks_since_damage = 0;
        public Wall sheild_wall;
        public int ticks_since_swing = 1;
        public Image swing;
        public bool swing_is_displayed = false;


        // bool indicates if item has been unlocked
        public bool bow = false; //unlocks use of projectiles or just increases damage 
        public bool sword = false; //longer reach for melee and more damage
        public bool shield = false; //not sure what to do about this yet. Probably introduce a wall in front of you so projectiles get blocked
        public bool armor = false; // increases Player_Armor rating to reduce incoming damage



        public Player(){}

        public override int GetHealth()
        {
            return Player_Life;
        }

        public void takes_damage(int damage){
            if (damage - Player_Armor > 0){
                this.Player_Life -= (damage -Player_Armor);
                ticks_since_damage = 0;
            }
            
            
        }
    }
}