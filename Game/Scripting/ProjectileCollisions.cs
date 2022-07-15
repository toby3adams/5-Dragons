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
            List<Projectile> waves = scene.GetAllActors<Projectile>("wave");
            List<Projectile> fireballs = scene.GetAllActors<Projectile>("fireball_trap");
            List<Actor>invis_doors = scene.GetAllActors<Actor>("invis_doors");


            wall_projectile_collision(scene, projectiles);
            player_projectile_collision(scene, projectiles, fireballs);
            dragon_projectile_collision(scene, projectiles);
            fireball_trap_collision(scene, fireballs, invis_doors);

            wall_tracker_collision(scene, trackers);
            player_tracker_collision(scene, trackers);
            dragon_tracker_collision(scene, trackers);

            wall_wave_collision(scene, waves);
            player_wave_collision(scene, waves);

        }
        public void fireball_trap_collision(Scene scene, List<Projectile> fireballs, List<Actor> invis_doors)
        {
            List<Wall> walls = scene.GetAllActors<Wall>("wall");            
               
                foreach(Projectile projectile in fireballs){
                    
                    foreach(Trap invis_door in invis_doors){
                        // Console.WriteLine("Invisible door recognized");
                        if(projectile.Overlaps(invis_door)){
                        scene.RemoveActor("fireball_trap", projectile);
                        }
                    } foreach(Wall wall in walls){
                        if(projectile.Overlaps(wall)){
                            scene.RemoveActor("fireball_trap", projectile);
                        }
                    }
                }             
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

        public void wall_wave_collision(Scene scene, List<Projectile> projectiles){
            List<Wall> walls = scene.GetAllActors<Wall>("wall");
            Player player = scene.GetFirstActor<Player>("player");
            
            foreach (Projectile projectile in projectiles){
                foreach (Wall wall in walls){
                    if (wall != player.sheild_wall){
                        if (projectile.Overlaps(wall))
                        {
                            scene.RemoveActor("wave", projectile);
                        }
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

        public void player_projectile_collision(Scene scene, List<Projectile> projectiles, List<Projectile> fireball_trap){
            Player player = scene.GetFirstActor<Player>("player");

            foreach (Projectile projectile in projectiles){
                if (projectile.Overlaps(player)){
                    player.takes_damage(projectile.damage);
                    scene.RemoveActor("projectile", projectile);
                }
            } foreach (Projectile projectile in fireball_trap){
                if (projectile.Overlaps(player)){
                    player.takes_damage(projectile.damage);
                    scene.RemoveActor("fireball_trap", projectile);
                }
            }
        }

        public void player_wave_collision(Scene scene, List<Projectile> projectiles){
            Player player = scene.GetFirstActor<Player>("player");

            foreach (Projectile projectile in projectiles){
                if (projectile.Overlaps(player)){
                    player.takes_damage(projectile.damage);
                    scene.RemoveActor("wave", projectile);
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