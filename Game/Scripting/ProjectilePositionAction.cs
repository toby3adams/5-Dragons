using Dragons.Game.Casting;


namespace Dragons.Game.Scripting{
    public class ProjectilePositionAction : Action {



        public ProjectilePositionAction(){}

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback){
            
        }   

        void UpdateProjectilePosition(Cast cast){
            // List<Actor> Projectiles = cast.GetActors("Projectiles");
            // foreach (Projectile projectile in Projectiles){
                // ProjectileMovement movement = projectile.GetMovement();
                

            // }


        }

        void MoveProjectile(){}
        void HandleProjectileCollision(Cast cast){}

    }
}