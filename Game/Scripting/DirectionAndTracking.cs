using System.Collections.Generic;
using Dragons.Game.Casting;
using Dragons.Game.Services;
using System.Numerics;
using System;


namespace Dragons.Game.Scripting{
    public class DirectionAndTracking{

        public DirectionAndTracking(){}

        public void projectile_tracking(List<Projectile> trackers, Actor target){
            
            foreach (Projectile projectile in trackers){
                    int player_direction = get_player_direction(target, projectile);

                    if (projectile.direction == 1){
                        if (player_direction == 1){
                            projectile.direction += 0;
                        }
                        if (player_direction == 2){
                            projectile.direction += 1;
                        }
                        if (player_direction == 3){
                            projectile.direction += 1;
                        }
                        if (player_direction == 4){
                            projectile.direction += 1;
                        }
                        if (player_direction == 5){
                            projectile.direction += 1;
                        }
                        if (player_direction == 6){
                            projectile.direction -= 1;
                        }
                        if (player_direction == 7){
                            projectile.direction -= 1;
                        }
                        if (player_direction == 8){
                            projectile.direction -= 1;
                        }
                    }
                    else if (projectile.direction == 2){
                        if (player_direction == 1){
                            projectile.direction -= 1;
                        }
                        if (player_direction == 2){
                            projectile.direction += 0;
                        }
                        if (player_direction == 3){
                            projectile.direction += 1;
                        }
                        if (player_direction == 4){
                            projectile.direction += 1;
                        }
                        if (player_direction == 5){
                            projectile.direction += 1;
                        }
                        if (player_direction == 6){
                            projectile.direction += 1;
                        }
                        if (player_direction == 7){
                            projectile.direction -= 1;
                        }
                        if (player_direction == 8){
                            projectile.direction -= 1;
                        }
                    }
                    else if (projectile.direction == 3){
                        if (player_direction == 1){
                            projectile.direction -= 1;
                        }
                        if (player_direction == 2){
                            projectile.direction -= 1;
                        }
                        if (player_direction == 3){
                            projectile.direction += 0;
                        }
                        if (player_direction == 4){
                            projectile.direction += 1;
                        }
                        if (player_direction == 5){
                            projectile.direction += 1;
                        }
                        if (player_direction == 6){
                            projectile.direction += 1;
                        }
                        if (player_direction == 7){
                            projectile.direction += 1;
                        }
                        if (player_direction == 8){
                            projectile.direction -= 1;
                        }
                    }               
                    else if (projectile.direction == 4){
                        if (player_direction == 1){
                            projectile.direction -= 1;
                        }
                        if (player_direction == 2){
                            projectile.direction -= 1;
                        }
                        if (player_direction == 3){
                            projectile.direction -= 1;
                        }
                        if (player_direction == 4){
                            projectile.direction += 0;
                        }
                        if (player_direction == 5){
                            projectile.direction += 1;
                        }
                        if (player_direction == 6){
                            projectile.direction += 1;
                        }
                        if (player_direction == 7){
                            projectile.direction += 1;
                        }
                        if (player_direction == 8){
                            projectile.direction += 1;
                        }
                    }
                    else if (projectile.direction == 5){
                        if (player_direction == 1){
                            projectile.direction += 1;
                        }
                        if (player_direction == 2){
                            projectile.direction -= 1;
                        }
                        if (player_direction == 3){
                            projectile.direction -= 1;
                        }
                        if (player_direction == 4){
                            projectile.direction -= 1;
                        }
                        if (player_direction == 5){
                            projectile.direction += 0;
                        }
                        if (player_direction == 6){
                            projectile.direction += 1;
                        }
                        if (player_direction == 7){
                            projectile.direction += 1;
                        }
                        if (player_direction == 8){
                            projectile.direction += 1;
                        }
                    }
                    else if (projectile.direction == 6){
                        if (player_direction == 1){
                            projectile.direction += 1;
                        }
                        if (player_direction == 2){
                            projectile.direction += 1;
                        }
                        if (player_direction == 3){
                            projectile.direction -= 1;
                        }
                        if (player_direction == 4){
                            projectile.direction -= 1;
                        }
                        if (player_direction == 5){
                            projectile.direction -= 1;
                        }
                        if (player_direction == 6){
                            projectile.direction += 0;
                        }
                        if (player_direction == 7){
                            projectile.direction += 1;
                        }
                        if (player_direction == 8){
                            projectile.direction += 1;
                        }
                    }
                    else if (projectile.direction == 7){
                        if (player_direction == 1){
                            projectile.direction += 1;
                        }
                        if (player_direction == 2){
                            projectile.direction += 1;
                        }
                        if (player_direction == 3){
                            projectile.direction += 1;
                        }
                        if (player_direction == 4){
                            projectile.direction -= 1;
                        }
                        if (player_direction == 5){
                            projectile.direction -= 1;
                        }
                        if (player_direction == 6){
                            projectile.direction -= 1;
                        }
                        if (player_direction == 7){
                            projectile.direction += 0;
                        }
                        if (player_direction == 8){
                            projectile.direction += 1;
                        }
                    }
                    else if (projectile.direction == 8){
                        if (player_direction == 1){
                            projectile.direction += 1;
                        }
                        if (player_direction == 2){
                            projectile.direction += 1;
                        }
                        if (player_direction == 3){
                            projectile.direction += 1;
                        }
                        if (player_direction == 4){
                            projectile.direction += 1;
                        }
                        if (player_direction == 5){
                            projectile.direction -= 1;
                        }
                        if (player_direction == 6){
                            projectile.direction -= 1;
                        }
                        if (player_direction == 7){
                            projectile.direction -= 1;
                        }
                        if (player_direction == 8){
                            projectile.direction += 0;
                        }
                    }


                    if (projectile.direction == 9){
                        projectile.direction = 1;
                    }
                    if (projectile.direction == 0){
                        projectile.direction = 8;
                    }
                    

                }          
        }


        public int get_player_direction(Actor player, Actor actor){


            if (player.GetLeft() >= actor.GetRight() && actor.GetTop()  < player.GetBottom() && actor.GetBottom() > player.GetTop()){
                return 1;
            }
            else if (player.GetBottom() <= actor.GetTop() && player.GetRight() > actor.GetLeft() && player.GetLeft() < actor.GetRight()){
                return 3;
            }
            else if (player.GetRight() <= actor.GetLeft() && actor.GetTop()  < player.GetBottom() && actor.GetBottom() > player.GetTop()){
                return 5;
            }
            else if (player.GetTop() >= actor.GetBottom() && player.GetRight() > actor.GetLeft() && player.GetLeft() < actor.GetRight()){
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