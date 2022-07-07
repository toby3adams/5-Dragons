

namespace Dragons.Game.Casting{
    public class Dragon : Actor{

        public Dragon(){}


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