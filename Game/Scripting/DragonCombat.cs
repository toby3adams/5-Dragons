using System.Collections.Generic;
using Dragons.Game.Casting;
using Dragons.Game.Services;
using System.Numerics;
using System;


namespace Dragons.Game.Scripting{
    public class DragonCombat : Action{


        public DragonCombat(){}

        int spin_counter = 0;
        int tracking_counter = 0;
        int melee_counter = 0;
        int wave_counter = 0;
        int lava_counter = 0;
        int lava_counter_remove = 0;
        bool first_placement = true;
        bool first_placement2 = true;
        bool initial = true;
        DirectionAndTracking tracking = new DirectionAndTracking();
        


        public override void Execute(Scene scene, float deltaTime, IActionCallback callback){

            List<Dragon> dragons = scene.GetAllActors<Dragon>("dragon");
            Player player = scene.GetFirstActor<Player>("player");

            if (initial){
                // foreach()

                initial = false;
            }

            foreach (Dragon dragon in dragons){
                check_health_death(scene, dragon, player);
                check_for_player(dragon, player);
                if (dragon.is_near_player){
                    
                    attack_player(scene, dragon, player);
                }
                
            }




        }


        private void check_for_player(Dragon dragon, Player player){
            
            if (player.GetCenterX() - dragon.aggro_distance < dragon.GetCenterX() && dragon.GetCenterX() < player.GetCenterX() + dragon.aggro_distance){
                if (player.GetCenterY()-dragon.aggro_distance < dragon.GetCenterY() && dragon.GetCenterY() < player.GetCenterY()+dragon.aggro_distance){
                    dragon.is_near_player = true;
                }
                else{
                    dragon.is_near_player = false;
                }                
            }
            else{
                    dragon.is_near_player = false;
            }

        }

        private void attack_player(Scene scene, Dragon dragon, Player player){

            spin_counter +=1;
            tracking_counter +=1;
            wave_counter +=1;
            melee_counter +=1;
            lava_counter +=1;
            lava_counter_remove +=1;

            if (tracking_counter > 360){
                int players_direction = tracking.get_player_direction(player, dragon);
                
                Projectile tracker = new Projectile(dragon.ranged_damage, 4, players_direction);
                tracker.SizeTo(20,20);
                tracker.Tint(dragon.GetTint());
                tracker.Display("Game/Assets/fireball.png");
                scene.AddActor("tracker", tracker);

                if (players_direction == 1){
                    tracker.MoveTo(dragon.GetRight()+2, dragon.GetCenterY());
                }
                if (players_direction == 2){
                    tracker.MoveTo(dragon.GetRight()+2, dragon.GetTop()-20);
                }
                if (players_direction == 3){
                    tracker.MoveTo(dragon.GetCenterX(), dragon.GetTop()-20);
                }
                if (players_direction == 4){
                    tracker.MoveTo(dragon.GetLeft()-20, dragon.GetTop()-20);
                }
                if (players_direction == 5){
                    tracker.MoveTo(dragon.GetLeft()-20, dragon.GetCenterY());
                }
                if (players_direction == 6){
                    tracker.MoveTo(dragon.GetLeft()-20, dragon.GetBottom()+2);
                }
                if (players_direction == 7){
                    tracker.MoveTo(dragon.GetCenterX(), dragon.GetBottom()+2);
                }
                if (players_direction == 8){
                    tracker.MoveTo(dragon.GetRight()+2, dragon.GetBottom()+2);
                }
                tracking_counter = 0;
            }

            if (tracking_counter % 10 == 0){
                List<Projectile> trackers = scene.GetAllActors<Projectile>("tracker");
                tracking.projectile_tracking(trackers, player);

            }






            if (lava_counter > 600 && dragon.dragon_health < 75){
                dragon.lava1 = new Trap(1,1,1,1,2);
                dragon.lava1.MoveTo(dragon.GetCenterX()-(960/2), dragon.GetCenterY()-25);
                dragon.lava1.SizeTo(960,50);
                dragon.lava1.Display("Game/Assets/lava.png");
                scene.AddActor("lava", dragon.lava1);
                first_placement = false;
                
                if (dragon.dragon_health < 50){
                    dragon.lava2 = new Trap(30,980,1,1,2);
                    dragon.lava2.MoveTo(dragon.GetCenterX()-25, dragon.GetCenterY()-(960/2));
                    dragon.lava2.SizeTo(50,960);
                    dragon.lava2.Display("Game/Assets/lava.png");
                    scene.AddActor("lava", dragon.lava2);
                    first_placement2 = false;
                }
                lava_counter = 0;
            }



            if (lava_counter >= 450 && !first_placement){
                scene.RemoveActor("lava", dragon.lava1);
                
                if (!first_placement2){
                    scene.RemoveActor("lava", dragon.lava2);
                }
            }





            // if (wave_counter > 120){
            //     int players_direction = tracking.get_player_direction(player, dragon);
                
            //     Projectile wave = new Projectile(dragon.ranged_damage, 1, players_direction);
            //     wave.SizeTo(20,20);
            //     wave.Tint(dragon.GetTint());
            //     wave.Display("Game/Assets/fireball.png");
            //     scene.AddActor("wave", wave);

            //     if (players_direction == 1){
            //         wave.MoveTo(dragon.GetRight()+2, dragon.GetCenterY());
            //     }
            //     if (players_direction == 2){
            //         wave.MoveTo(dragon.GetRight()+2, dragon.GetTop()-20);
            //     }
            //     if (players_direction == 3){
            //         wave.MoveTo(dragon.GetCenterX(), dragon.GetTop()-20);
            //     }
            //     if (players_direction == 4){
            //         wave.MoveTo(dragon.GetLeft()-20, dragon.GetTop()-20);
            //     }
            //     if (players_direction == 5){
            //         wave.MoveTo(dragon.GetLeft()-20, dragon.GetCenterY());
            //     }
            //     if (players_direction == 6){
            //         wave.MoveTo(dragon.GetLeft()-20, dragon.GetBottom()+2);
            //     }
            //     if (players_direction == 7){
            //         wave.MoveTo(dragon.GetCenterX(), dragon.GetBottom()+2);
            //     }
            //     if (players_direction == 8){
            //         wave.MoveTo(dragon.GetRight()+2, dragon.GetBottom()+2);
            //     }
            //     wave_counter = 0;
            // }

            // List<Projectile> waves = scene.GetAllActors<Projectile>("wave");
            // foreach (Projectile wave in waves){
            //     wave.SizeTo(wave.GetWidth()+2, wave.GetHeight()+2);
            //     wave.MoveTo(wave.GetLeft()-1, wave.GetTop()-1);
            // }
            



            if (spin_counter == 190){
                Projectile projectile = new Projectile(dragon.ranged_damage, 6, 1);
                projectile.SizeTo(20,20);
                projectile.MoveTo(dragon.GetRight()+2, dragon.GetCenterY());
                projectile.Tint(dragon.GetTint());
                projectile.Display("Game/Assets/fireball.png");
                scene.AddActor("projectile", projectile);
            }
            if (spin_counter == 195){
                Projectile projectile = new Projectile(dragon.ranged_damage, 6, 2);
                projectile.SizeTo(20,20);
                projectile.MoveTo(dragon.GetRight()+2, dragon.GetTop()-20);
                projectile.Tint(dragon.GetTint());
                projectile.Display("Game/Assets/fireball.png");
                scene.AddActor("projectile", projectile);
            }
            if (spin_counter == 200){
                Projectile projectile = new Projectile(dragon.ranged_damage, 6, 3);
                projectile.SizeTo(20,20);
                projectile.MoveTo(dragon.GetCenterX(), dragon.GetTop()-20);
                projectile.Tint(dragon.GetTint());
                projectile.Display("Game/Assets/fireball.png");
                scene.AddActor("projectile", projectile);                
            }
            if (spin_counter == 205){
                Projectile projectile = new Projectile(dragon.ranged_damage, 6, 4);
                projectile.SizeTo(20,20);
                projectile.MoveTo(dragon.GetLeft()-20, dragon.GetTop()-20);
                projectile.Tint(dragon.GetTint());
                projectile.Display("Game/Assets/fireball.png");
                scene.AddActor("projectile", projectile);                
            }
            if (spin_counter == 210){
                Projectile projectile = new Projectile(dragon.ranged_damage, 6, 5);
                projectile.SizeTo(20,20);
                projectile.MoveTo(dragon.GetLeft()-20, dragon.GetCenterY());
                projectile.Tint(dragon.GetTint());
                projectile.Display("Game/Assets/fireball.png");
                scene.AddActor("projectile", projectile);                
            }
            if (spin_counter == 215){
                Projectile projectile = new Projectile(dragon.ranged_damage, 6, 6);
                projectile.SizeTo(20,20);
                projectile.MoveTo(dragon.GetLeft()-20, dragon.GetBottom()+2);
                projectile.Tint(dragon.GetTint());
                projectile.Display("Game/Assets/fireball.png");
                scene.AddActor("projectile", projectile);                
            }
            if (spin_counter == 220){
                Projectile projectile = new Projectile(dragon.ranged_damage, 6, 7);
                projectile.SizeTo(20,20);
                projectile.MoveTo(dragon.GetCenterX(), dragon.GetBottom()+2);
                projectile.Tint(dragon.GetTint());
                projectile.Display("Game/Assets/fireball.png");
                scene.AddActor("projectile", projectile);                
            }
            if (spin_counter == 225){
                Projectile projectile = new Projectile(dragon.ranged_damage, 6, 8);
                projectile.SizeTo(20,20);
                projectile.MoveTo(dragon.GetRight()+2, dragon.GetBottom()+2);
                projectile.Tint(dragon.GetTint());
                projectile.Display("Game/Assets/fireball.png");
                scene.AddActor("projectile", projectile);  
                spin_counter = 0;              
            }



            if (melee_counter > 60){
                if (player.GetCenterX() < dragon.GetCenterX() + 150 && player.GetCenterX() > dragon.GetCenterX() -150){
                    if (player.GetCenterY() < dragon.GetCenterY() + 150 && player.GetCenterY() > dragon.GetCenterY() -150){
                        Actor swing = new Actor();
                        scene.AddActor("swing", swing);
                        swing.MoveTo(dragon.GetLeft()-50, dragon.GetTop()-50);
                        swing.SizeTo(200,200);
                        if (swing.Overlaps(player)){
                            player.takes_damage(dragon.melee_damage);
                        }
                        scene.RemoveActor("swing",swing);
                        melee_counter = 0;
                    }
                }
            }
            if (!(player.GetCenterX() < dragon.GetCenterX() + 150 && player.GetCenterX() > dragon.GetCenterX() -150) || (!(player.GetCenterY() < dragon.GetCenterY() + 150 && player.GetCenterY() > dragon.GetCenterY() -150))){
                    melee_counter = 0;
            }
        }



        private void check_health_death(Scene scene, Dragon dragon, Player player){
            if (dragon.dragon_health <= 0){
                if (dragon.GetTint() == Color.Blue()){
                    player.armor = true;
                }
                if (dragon.GetTint() == Color.Gray()){
                    player.shield = true;
                }
                if (dragon.GetTint() == Color.Orange()){
                    player.sword = true;
                }
                if (dragon.GetTint() == Color.Green()){
                    player.bow = true;
                }
                scene.RemoveActor("dragon", dragon);
            }
        }








    }
}