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


        public override void Execute(Scene scene, float deltaTime, IActionCallback callback){

            List<Dragon> dragons = scene.GetAllActors<Dragon>("dragon");
            Player player = scene.GetFirstActor<Player>("player");

                

            foreach (Dragon dragon in dragons){
                check_health_death(scene, dragon);
                check_for_player(dragon, player);
                if (dragon.is_near_player){
                    // Console.WriteLine(get_player_direction(player, dragon));
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

            // Console.WriteLine(dragon.is_near_player); //debugging
        }

        private void attack_player(Scene scene, Dragon dragon, Player player){

            spin_counter +=1;
            tracking_counter +=1;
            wave_counter +=1;
            melee_counter +=1;

            if (tracking_counter > 60){
                int players_direction = get_player_direction(player, dragon);
                // shoot_tracking_projectile(players_direction, dragon.ranged_damage);
            }

            if (wave_counter > 60){

            }



            if (spin_counter > 250){
                spin_counter = 0;
            }
            if (spin_counter == 190){
                Projectile projectile = new Projectile(10, 6, 1);
                projectile.SizeTo(8,8);
                projectile.MoveTo(dragon.GetRight()+2, dragon.GetCenterY());
                projectile.Tint(dragon.GetTint());
                scene.AddActor("projectile", projectile);
            }
            if (spin_counter == 195){
                Projectile projectile = new Projectile(10, 6, 2);
                projectile.SizeTo(8,8);
                projectile.MoveTo(dragon.GetRight()+2, dragon.GetTop()-2);
                projectile.Tint(dragon.GetTint());
                scene.AddActor("projectile", projectile);
            }
            if (spin_counter == 200){
                Projectile projectile = new Projectile(10, 6, 3);
                projectile.SizeTo(8,8);
                projectile.MoveTo(dragon.GetCenterX(), dragon.GetTop()-2);
                projectile.Tint(dragon.GetTint());
                scene.AddActor("projectile", projectile);                
            }
            if (spin_counter == 205){
                Projectile projectile = new Projectile(10, 6, 4);
                projectile.SizeTo(8,8);
                projectile.MoveTo(dragon.GetLeft()-2, dragon.GetTop()-2);
                projectile.Tint(dragon.GetTint());
                scene.AddActor("projectile", projectile);                
            }
            if (spin_counter == 210){
                Projectile projectile = new Projectile(10, 6, 5);
                projectile.SizeTo(8,8);
                projectile.MoveTo(dragon.GetLeft()-2, dragon.GetCenterY());
                projectile.Tint(dragon.GetTint());
                scene.AddActor("projectile", projectile);                
            }
            if (spin_counter == 215){
                Projectile projectile = new Projectile(10, 6, 6);
                projectile.SizeTo(8,8);
                projectile.MoveTo(dragon.GetLeft()-2, dragon.GetBottom()+2);
                projectile.Tint(dragon.GetTint());
                scene.AddActor("projectile", projectile);                
            }
            if (spin_counter == 220){
                Projectile projectile = new Projectile(10, 6, 7);
                projectile.SizeTo(8,8);
                projectile.MoveTo(dragon.GetCenterX(), dragon.GetBottom()+2);
                projectile.Tint(dragon.GetTint());
                scene.AddActor("projectile", projectile);                
            }
            if (spin_counter == 225){
                Projectile projectile = new Projectile(10, 6, 8);
                projectile.SizeTo(8,8);
                projectile.MoveTo(dragon.GetRight()+2, dragon.GetBottom()+2);
                projectile.Tint(dragon.GetTint());
                scene.AddActor("projectile", projectile);                
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
            

            // spin projectiles that dont track
            // melee
            // tracking projectiles
            // weakening wave blasts


        }

        private void check_health_death(Scene scene, Dragon dragon){
            if (dragon.dragon_health <= 0){
                scene.RemoveActor("dragon", dragon);
            }
        }


        private int get_player_direction(Player player, Dragon dragon){


            if (player.GetLeft() > dragon.GetRight() && dragon.GetTop() - 25 < player.GetBottom() && dragon.GetBottom() +25 > player.GetTop()){
                return 1;
            }
            else if (player.GetBottom() < dragon.GetTop() && player.GetRight() > dragon.GetLeft() -25 && player.GetLeft() < dragon.GetRight() +25){
                return 3;
            }
            else if (player.GetRight() < dragon.GetLeft() && dragon.GetTop() - 25 < player.GetBottom() && dragon.GetBottom() +25 > player.GetTop()){
                return 5;
            }
            else if (player.GetTop() > dragon.GetBottom() && player.GetRight() > dragon.GetLeft() -25 && player.GetLeft() < dragon.GetRight() +25){
                return 7;
            }
            else if (player.GetBottom() < dragon.GetTop() && player.GetLeft() > dragon.GetRight()){
                return 2;
            }
            else if (player.GetBottom() < dragon.GetTop() && player.GetRight() < dragon.GetLeft()){
                return 4;
            }
            else if (player.GetTop() > dragon.GetBottom() && player.GetRight() < dragon.GetLeft()){
                return 6;
            }
            else if (player.GetTop() > dragon.GetBottom() && player.GetLeft() > dragon.GetRight()){
                return 8;
            }
            else{
                return 0;
            }

            

        
        }



    }
}