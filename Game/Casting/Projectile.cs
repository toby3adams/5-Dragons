namespace Dragons.Game.Casting{
    public class Projectile : Image{

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