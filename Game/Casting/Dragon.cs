

namespace Dragons.Game.Casting{
    public class Dragon : Actor {

        public Dragon(){}


        public int melee_range;
        public int dragon_health = 100;
        private int melee_damage;
        private int ranged_damage;
        public bool is_near_player;
        public int aggro_distance = 600;
        private bool dragon_alive = true;

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