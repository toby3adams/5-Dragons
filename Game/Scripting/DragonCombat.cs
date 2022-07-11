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

            // Console.WriteLine(dragon.is_near_player); //debugging
        }

        private void attack_player(Scene scene, Dragon dragon, Player player){

            spin_counter +=1;
            tracking_counter +=1;
            wave_counter +=1;
            melee_counter +=1;

            if (tracking_counter > 120){
                int players_direction = get_player_direction(player, dragon);
                
                Projectile tracker = new Projectile(dragon.ranged_damage, 6, players_direction);
                tracker.SizeTo(8,8);
                tracker.Tint(dragon.GetTint());
                scene.AddActor("tracker", tracker);

                if (players_direction == 1){
                    tracker.MoveTo(dragon.GetRight()+2, dragon.GetCenterY());
                }
                if (players_direction == 2){
                    tracker.MoveTo(dragon.GetRight()+2, dragon.GetTop()-2);
                }
                if (players_direction == 3){
                    tracker.MoveTo(dragon.GetCenterX(), dragon.GetTop()-2);
                }
                if (players_direction == 4){
                    tracker.MoveTo(dragon.GetLeft()-2, dragon.GetTop()-2);
                }
                if (players_direction == 5){
                    tracker.MoveTo(dragon.GetLeft()-2, dragon.GetCenterY());
                }
                if (players_direction == 6){
                    tracker.MoveTo(dragon.GetLeft()-2, dragon.GetBottom()+2);
                }
                if (players_direction == 7){
                    tracker.MoveTo(dragon.GetCenterX(), dragon.GetBottom()+2);
                }
                if (players_direction == 8){
                    tracker.MoveTo(dragon.GetRight()+2, dragon.GetBottom()+2);
                }
                tracking_counter = 0;
            }

            if (tracking_counter % 20 == 0){
                List<Projectile> trackers = scene.GetAllActors<Projectile>("tracker");
                foreach (Projectile projectile in trackers){
                    int player_direction = get_player_direction(player, projectile);
                    projectile.direction = player_direction;
                }
            }





            if (wave_counter > 60){

            }
            



            if (spin_counter == 190){
                Projectile projectile = new Projectile(dragon.ranged_damage, 6, 1);
                projectile.SizeTo(8,8);
                projectile.MoveTo(dragon.GetRight()+2, dragon.GetCenterY());
                projectile.Tint(dragon.GetTint());
                scene.AddActor("projectile", projectile);
            }
            if (spin_counter == 195){
                Projectile projectile = new Projectile(dragon.ranged_damage, 6, 2);
                projectile.SizeTo(8,8);
                projectile.MoveTo(dragon.GetRight()+2, dragon.GetTop()-2);
                projectile.Tint(dragon.GetTint());
                scene.AddActor("projectile", projectile);
            }
            if (spin_counter == 200){
                Projectile projectile = new Projectile(dragon.ranged_damage, 6, 3);
                projectile.SizeTo(8,8);
                projectile.MoveTo(dragon.GetCenterX(), dragon.GetTop()-2);
                projectile.Tint(dragon.GetTint());
                scene.AddActor("projectile", projectile);                
            }
            if (spin_counter == 205){
                Projectile projectile = new Projectile(dragon.ranged_damage, 6, 4);
                projectile.SizeTo(8,8);
                projectile.MoveTo(dragon.GetLeft()-2, dragon.GetTop()-2);
                projectile.Tint(dragon.GetTint());
                scene.AddActor("projectile", projectile);                
            }
            if (spin_counter == 210){
                Projectile projectile = new Projectile(dragon.ranged_damage, 6, 5);
                projectile.SizeTo(8,8);
                projectile.MoveTo(dragon.GetLeft()-2, dragon.GetCenterY());
                projectile.Tint(dragon.GetTint());
                scene.AddActor("projectile", projectile);                
            }
            if (spin_counter == 215){
                Projectile projectile = new Projectile(dragon.ranged_damage, 6, 6);
                projectile.SizeTo(8,8);
                projectile.MoveTo(dragon.GetLeft()-2, dragon.GetBottom()+2);
                projectile.Tint(dragon.GetTint());
                scene.AddActor("projectile", projectile);                
            }
            if (spin_counter == 220){
                Projectile projectile = new Projectile(dragon.ranged_damage, 6, 7);
                projectile.SizeTo(8,8);
                projectile.MoveTo(dragon.GetCenterX(), dragon.GetBottom()+2);
                projectile.Tint(dragon.GetTint());
                scene.AddActor("projectile", projectile);                
            }
            if (spin_counter == 225){
                Projectile projectile = new Projectile(dragon.ranged_damage, 6, 8);
                projectile.SizeTo(8,8);
                projectile.MoveTo(dragon.GetRight()+2, dragon.GetBottom()+2);
                projectile.Tint(dragon.GetTint());
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




        private int get_player_direction(Player player, Actor actor){


            if (player.GetLeft() > actor.GetRight() && actor.GetTop() - 25 < player.GetBottom() && actor.GetBottom() +25 > player.GetTop()){
                return 1;
            }
            else if (player.GetBottom() < actor.GetTop() && player.GetRight() > actor.GetLeft() -25 && player.GetLeft() < actor.GetRight() +25){
                return 3;
            }
            else if (player.GetRight() < actor.GetLeft() && actor.GetTop() - 25 < player.GetBottom() && actor.GetBottom() +25 > player.GetTop()){
                return 5;
            }
            else if (player.GetTop() > actor.GetBottom() && player.GetRight() > actor.GetLeft() -25 && player.GetLeft() < actor.GetRight() +25){
                return 7;
            }
            else if (player.GetBottom() < actor.GetTop() && player.GetLeft() > actor.GetRight()){
                return 2;
            }
            else if (player.GetBottom() < actor.GetTop() && player.GetRight() < actor.GetLeft()){
                return 4;
            }
            else if (player.GetTop() > actor.GetBottom() && player.GetRight() < actor.GetLeft()){
                return 6;
            }
            else if (player.GetTop() > actor.GetBottom() && player.GetLeft() > actor.GetRight()){
                return 8;
            }
            else{
                return 0;
            }

            

        
        }



    }
}