using System.Numerics;


namespace Dragons.Game.Casting{
    public class Projectile : Actor{

        public Projectile(int damage, int speed, int direction){
            this.damage = damage;
            this.speed = speed;
            this.direction = direction;


        }

        public int damage;
        public int speed;
        public int direction;


        public int GetDirection(){
            return this.direction;
        }

    }
}