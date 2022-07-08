

namespace Dragons.Game.Casting{
    public class Dragon : Actor{

        public Dragon(int melee_range, int health, int melee_damage, int ranged_damage, int aggro_distance){
            this.melee_damage = melee_damage;
            this.melee_range = melee_range;
            this.dragon_health = health;
            this.ranged_damage = ranged_damage;
            this.aggro_distance = aggro_distance;
        }


        public int melee_range;
        public int dragon_health = 100;
        private int melee_damage;
        private int ranged_damage;
        public bool is_near_player;
        public int aggro_distance = 600;


        public void takes_damage(int damage){
            dragon_health -= damage;
        }


    }
}