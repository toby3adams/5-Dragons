using System;
using System.Collections.Generic;
using Dragons.Game.Casting;
using Dragons.Game.Services;

namespace Dragons.Game.Scripting{
    public class ProjectileCollisions : Action{




        public ProjectileCollisions(){}

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback){
            
            List<Projectile> projectiles = scene.GetAllActors<Projectile>("projectile");
            List<Projectile> trackers = scene.GetAllActors<Projectile>("tracker");

            wall_projectile_collision(scene, projectiles);
            player_projectile_collision(scene, projectiles);
            dragon_projectile_collision(scene, projectiles);

            wall_tracker_collision(scene, trackers);
            player_tracker_collision(scene, trackers);
            dragon_tracker_collision(scene, trackers);            

        }

        public void wall_projectile_collision(Scene scene, List<Projectile> projectiles){
            List<Wall> walls = scene.GetAllActors<Wall>("wall");
            
            foreach (Projectile projectile in projectiles){
                foreach (Wall wall in walls){
                    if (projectile.Overlaps(wall))
                    {
                        scene.RemoveActor("projectile", projectile);
                    }
                }
            }
        }

        public void wall_tracker_collision(Scene scene, List<Projectile> projectiles){
            List<Wall> walls = scene.GetAllActors<Wall>("wall");
            
            foreach (Projectile projectile in projectiles){
                foreach (Wall wall in walls){
                    if (projectile.Overlaps(wall))
                    {
                        scene.RemoveActor("tracker", projectile);
                    }
                }
            }
        }

        public void player_projectile_collision(Scene scene, List<Projectile> projectiles){
            Player player = scene.GetFirstActor<Player>("player");

            foreach (Projectile projectile in projectiles){
                if (projectile.Overlaps(player)){
                    player.takes_damage(projectile.damage);
                    scene.RemoveActor("projectile", projectile);
                }
            }
        }

        public void player_tracker_collision(Scene scene, List<Projectile> projectiles){
            Player player = scene.GetFirstActor<Player>("player");

            foreach (Projectile projectile in projectiles){
                if (projectile.Overlaps(player)){
                    player.takes_damage(projectile.damage);
                    scene.RemoveActor("tracker", projectile);
                }
            }
        }

        public void dragon_projectile_collision(Scene scene, List<Projectile> projectiles){

            List<Dragon> dragons = scene.GetAllActors<Dragon>("dragon");

            foreach (Dragon dragon in dragons){
                foreach(Projectile projectile in projectiles){
                    if (projectile.Overlaps(dragon)){
                        if (dragon.is_near_player){
                            dragon.takes_damage(projectile.damage);
                        }
                        scene.RemoveActor("projectile", projectile);
                    }

                }
            }
        }

        public void dragon_tracker_collision(Scene scene, List<Projectile> projectiles){

            List<Dragon> dragons = scene.GetAllActors<Dragon>("dragon");

            foreach (Dragon dragon in dragons){
                foreach(Projectile projectile in projectiles){
                    if (projectile.Overlaps(dragon)){
                        if (dragon.is_near_player){
                            dragon.takes_damage(projectile.damage);
                        }
                        scene.RemoveActor("tracker", projectile);
                    }

                }
            }
        }

    }
}