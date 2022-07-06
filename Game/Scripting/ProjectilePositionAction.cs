using Dragons.Game.Casting;
using System.Collections.Generic;


namespace Dragons.Game.Scripting{
    public class ProjectilePositionAction : Action {



        public ProjectilePositionAction(){}

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback){
            UpdateProjectilePosition(scene);
        }   

        void UpdateProjectilePosition(Scene scene){
            List<Actor> Projectiles = scene.GetAllActors("projectile");
            foreach (Projectile projectile in Projectiles){
                ProjectileMovement movement = projectile.GetMovement();

                MoveProjectile(projectile, movement);

            }
        }

        void MoveProjectile(Actor projectile, ProjectileMovement movement){
            if (movement.direction == "left"){
                projectile.MoveTo(projectile.GetCenterX() - movement.speed, projectile.GetCenterY());
            }
            else if (movement.direction == "right"){
                projectile.MoveTo(projectile.GetCenterX()+ movement.speed, projectile.GetCenterY());
            }
            else if (movement.direction == "up"){
                projectile.MoveTo(projectile.GetCenterX(), projectile.GetCenterY() + movement.speed);
            }
            else if (movement.direction == "down"){
                projectile.MoveTo(projectile.GetCenterX(), projectile.GetCenterY() - movement.speed);
            }

        }

    }
}