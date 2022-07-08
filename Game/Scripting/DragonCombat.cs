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
                    attack_player(dragon, player);
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

        private void attack_player(Dragon dragon, Player player){

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

            if (spin_counter > 60){

            }

            if (melee_counter > 60){
                
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