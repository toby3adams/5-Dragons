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


                MoveProjectile(projectile, projectile.GetDirection());

            }
        }

        void MoveProjectile(Projectile projectile, int direction){
            if (direction == 1){
                projectile.MoveTo(projectile.GetLeft() + projectile.speed, projectile.GetTop());
            }
            else if (direction == 2){
                projectile.MoveTo(projectile.GetLeft() + projectile.speed, projectile.GetTop() - projectile.speed);
            }
            else if (direction == 3){
                projectile.MoveTo(projectile.GetLeft(), projectile.GetTop() - projectile.speed);
            }
            else if (direction == 4){
                projectile.MoveTo(projectile.GetLeft() - projectile.speed, projectile.GetTop() - projectile.speed);
            }
            else if (direction == 5){
                projectile.MoveTo(projectile.GetLeft() - projectile.speed, projectile.GetTop());
            }
            else if (direction == 6){
                projectile.MoveTo(projectile.GetLeft() - projectile.speed, projectile.GetTop() + projectile.speed);
            }
            else if (direction == 7){
                projectile.MoveTo(projectile.GetLeft(), projectile.GetTop() + projectile.speed);
            }
            else if (direction == 8){
                projectile.MoveTo(projectile.GetLeft() + projectile.speed, projectile.GetTop() + projectile.speed);
            }
        }


    }
}