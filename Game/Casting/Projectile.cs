namespace Dragons.Game.Casting{
    public class Projectile : Actor{

        public Projectile(int damage, ProjectileMovement movement){
            this.damage = damage;
            this.movement = movement;
        }

        int damage;
        ProjectileMovement movement;


        public ProjectileMovement GetMovement(){
            return this.movement;
        }

    }
}