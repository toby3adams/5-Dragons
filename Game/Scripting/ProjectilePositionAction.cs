using Dragons.Game.Casting;
using System.Collections.Generic;



namespace Dragons.Game.Scripting{
    public class ProjectilePositionAction : Action {



        public ProjectilePositionAction(){}

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback){
            UpdateProjectilePosition(scene);
        }   


        void UpdateProjectilePosition(Scene scene){
            List<Projectile> Projectiles = scene.GetAllActors<Projectile>("projectile");
            foreach (Projectile projectile in Projectiles){
                MoveProjectile(projectile, projectile.GetDirection());
                update_projectile_image(projectile);
            }

            List<Projectile> trackers = scene.GetAllActors<Projectile>("tracker");
            foreach (Projectile projectile in trackers){
                MoveProjectile(projectile, projectile.GetDirection());
                update_projectile_image(projectile);
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


        private void update_projectile_image(Projectile projectile){
            if (projectile.direction == 1){
                projectile.RotateTo(0);
            }
            else if (projectile.direction == 2){
                projectile.RotateTo(-45);
            }
            else if (projectile.direction == 3){
                projectile.RotateTo(-90);
            }
            else if (projectile.direction == 4){
                projectile.RotateTo(-135);
            }
            else if (projectile.direction == 5){
                projectile.RotateTo(-180);
            }
            else if (projectile.direction == 6){
                projectile.RotateTo(-225);
            }
            else if (projectile.direction == 7){
                projectile.RotateTo(-270);
            }
            else if (projectile.direction == 8){
                projectile.RotateTo(-315);
            }
        }


    }
}