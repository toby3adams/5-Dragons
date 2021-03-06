

namespace Dragons.Game.Casting{
    public class Dragon : Image {

        public Dragon(int melee_range, int health, int melee_damage, int ranged_damage, int aggro_distance){
            this.melee_damage = melee_damage;
            this.melee_range = melee_range;
            this.dragon_health = health;
            this.ranged_damage = ranged_damage;
            this.aggro_distance = aggro_distance;
        }


        public int melee_range;
        public int dragon_health;
        public int melee_damage;
        public int ranged_damage;
        public bool is_near_player;
        public int aggro_distance;
        private bool dragon_alive = true;
        public Image lava1;
        public Image lava2;
        public Image swing;
        public int ticks_since_displayed = 1;
        public bool attack_is_displayed = false;
        public bool first_placement = true;
        public bool first_placement2 = true;
        public string type;

        public bool CheckDragonDead()
        {
            if(dragon_health == 0)
            {
                dragon_alive = false;
            }
            return dragon_alive;
        }
        public void takes_damage(int damage){
            dragon_health -= damage;
        }

        public override int GetHealth()
        {
            return dragon_health;
        }

    }
}