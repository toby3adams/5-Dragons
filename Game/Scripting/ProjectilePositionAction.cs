using Dragons.Game.Casting;


namespace Dragons.Game.Scripting{
    public class ProjectilePositionAction : Action {



        public ProjectilePositionAction(){}

        void Execute(Cast cast, Script script){
            UpdateProjectilePosition(cast);
            HandleProjectileCollision(cast);
        }        

        void UpdateProjectilePosition(Cast cast){
            List<Actor> Projectiles = cast.GetActors("Projectiles");
            foreach (Projectile projectile in Projectiles){
                ProjectileMovement movement = projectile.GetMovement();
                

            }


        }

        void MoveProjectile(){}
        void HandleProjectileCollision(Cast cast){}

    }
}