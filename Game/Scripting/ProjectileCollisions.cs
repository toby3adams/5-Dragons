using System;
using System.Collections.Generic;
using Dragons.Game.Casting;
using Dragons.Game.Services;

namespace Dragons.Game.Scripting{
    public class ProjectileCollisions : Action{
        public bool collision;



        public ProjectileCollisions(){}

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback){
            
            List<Projectile> projectiles = scene.GetAllActors<Projectile>("projectile");

            foreach (Projectile projectile in projectiles){
                collision = false;
                wall_projectile_collision(scene, projectile);

                if (collision){
                    scene.RemoveActor("projectile", projectile);
                }
            }


            player_projectile_collision(scene, projectiles);

        }

        public void wall_projectile_collision(Scene scene, Projectile projectile){
            List<Wall> walls = scene.GetAllActors<Wall>("wall");
            

                foreach (Wall wall in walls){
                    if (projectile.Overlaps(wall))
                    {
                        collision = true;
                    }
                }
        }

        public void player_projectile_collision(Scene scene, List<Projectile> projectiles){
            Actor player = scene.GetFirstActor("player");

            foreach (Projectile projectile in projectiles){
                if (projectile.Overlaps(player)){
                    // player_takes_damage(projectile.damage);
                }
            }
        }

    }
}