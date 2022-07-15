using System;
using System.Collections.Generic;
using Dragons.Game.Casting;
using Dragons.Game.Services;



namespace Dragons.Game.Scripting
{
    public class PlayerCollisions
    {
        public bool collision_up = false;
        public bool collision_down = false;
        public bool collision_left = false;
        public bool collision_right = false;
    
        public PlayerCollisions()
        {
            
        }
        public void CheckCollisions(Scene scene, Player player)
        {
           
            List<Actor>walls = scene.GetAllActors("wall");
            foreach(Actor wall in walls)
            {
                if (player.GetTop() <= wall.GetBottom() && player.GetBottom() > wall.GetBottom() && player.GetRight() > wall.GetLeft() && player.GetLeft() < wall.GetRight())
                {
                    collision_up = true;
                }
                if (player.GetLeft() <= wall.GetRight() && player.GetRight() > wall.GetRight() && player.GetBottom() > wall.GetTop() && player.GetTop() < wall.GetBottom()){
                    collision_left = true;
                }
                if (player.GetRight() >= wall.GetLeft() && player.GetLeft() < wall.GetLeft() && player.GetBottom() > wall.GetTop() && player.GetTop() < wall.GetBottom()){
                    collision_right = true;
                }
                if (player.GetBottom() >= wall.GetTop() && player.GetTop() < wall.GetTop() && player.GetRight() > wall.GetLeft() && player.GetLeft() < wall.GetRight()){
                    collision_down = true;
                }    
            }
            List<Actor>Block_traps = scene.GetAllActors("block_trap");
            foreach(Actor trap in Block_traps)
            {
                if(player.Overlaps(trap))
                    {
                        player.takes_damage(100);
                    }
                if (player.GetTop() <= trap.GetBottom() && player.GetBottom() > trap.GetBottom() && player.GetRight() > trap.GetLeft() && player.GetLeft() < trap.GetRight())
                {
                    collision_up = true;
                    player.MoveTo(player.GetLeft(), player.GetTop()+5);
                    
                    
                }
                if (player.GetLeft() <= trap.GetRight() && player.GetRight() > trap.GetRight() && player.GetBottom() > trap.GetTop() && player.GetTop() < trap.GetBottom()){
                    collision_left = true;
                    player.MoveTo(player.GetLeft()+5,player.GetTop());
                }
                if (player.GetRight() >= trap.GetLeft() && player.GetLeft() < trap.GetLeft() && player.GetBottom() > trap.GetTop() && player.GetTop() < trap.GetBottom()){
                    collision_right = true;
                    player.MoveTo(player.GetLeft()-5,player.GetTop());
                }
                if (player.GetBottom() >= trap.GetTop() && player.GetTop() < trap.GetTop() && player.GetRight() > trap.GetLeft() && player.GetLeft() < trap.GetRight()){
                    collision_down = true;
                    player.MoveTo(player.GetLeft(),player.GetTop()-5);
                }    
            }
             List<Actor>stationary_block_traps = scene.GetAllActors("stationary_block_trap");
            foreach(Actor trap in stationary_block_traps)
            {
                if (player.GetTop() <= trap.GetBottom() && player.GetBottom() > trap.GetBottom() && player.GetRight() > trap.GetLeft() && player.GetLeft() < trap.GetRight())
                {
                    collision_up = true;
                    player.MoveTo(player.GetLeft(), player.GetTop()+5);
                }
                if (player.GetLeft() <= trap.GetRight() && player.GetRight() > trap.GetRight() && player.GetBottom() > trap.GetTop() && player.GetTop() < trap.GetBottom()){
                    collision_left = true;
                    player.MoveTo(player.GetLeft()+5,player.GetTop());
                }
                if (player.GetRight() >= trap.GetLeft() && player.GetLeft() < trap.GetLeft() && player.GetBottom() > trap.GetTop() && player.GetTop() < trap.GetBottom()){
                    collision_right = true;
                    player.MoveTo(player.GetLeft()-5,player.GetTop());
                }
                if (player.GetBottom() >= trap.GetTop() && player.GetTop() < trap.GetTop() && player.GetRight() > trap.GetLeft() && player.GetLeft() < trap.GetRight()){
                    collision_down = true;
                    player.MoveTo(player.GetLeft(),player.GetTop()-5);
                }    
            }
             List<Actor>destroy_walkway_trigger = scene.GetAllActors("invis_door");
            foreach(Actor trap in stationary_block_traps)
            {
                if (player.GetTop() <= trap.GetBottom() && player.GetBottom() > trap.GetBottom() && player.GetRight() > trap.GetLeft() && player.GetLeft() < trap.GetRight())
                {
                    collision_up = true;
                    player.MoveTo(player.GetLeft(), player.GetTop()+5);
                }
                if (player.GetLeft() <= trap.GetRight() && player.GetRight() > trap.GetRight() && player.GetBottom() > trap.GetTop() && player.GetTop() < trap.GetBottom()){
                    collision_left = true;
                    player.MoveTo(player.GetLeft()+5,player.GetTop());
                }
                if (player.GetRight() >= trap.GetLeft() && player.GetLeft() < trap.GetLeft() && player.GetBottom() > trap.GetTop() && player.GetTop() < trap.GetBottom()){
                    collision_right = true;
                    player.MoveTo(player.GetLeft()-5,player.GetTop());
                }
                if (player.GetBottom() >= trap.GetTop() && player.GetTop() < trap.GetTop() && player.GetRight() > trap.GetLeft() && player.GetLeft() < trap.GetRight()){
                    collision_down = true;
                    player.MoveTo(player.GetLeft(),player.GetTop()-5);
                }    
            }

            List<Actor> dragons = scene.GetAllActors("dragon");
            foreach (Actor dragon in dragons){

                if (player.GetTop() <= dragon.GetBottom() && player.GetBottom() > dragon.GetBottom() && player.GetRight() > dragon.GetLeft() && player.GetLeft() < dragon.GetRight())
                {
                    collision_up = true;
                }
                if (player.GetLeft() <= dragon.GetRight() && player.GetRight() > dragon.GetRight() && player.GetBottom() > dragon.GetTop() && player.GetTop() < dragon.GetBottom()){
                    collision_left = true;
                }
                if (player.GetRight() >= dragon.GetLeft() && player.GetLeft() < dragon.GetLeft() && player.GetBottom() > dragon.GetTop() && player.GetTop() < dragon.GetBottom()){
                    collision_right = true;
                }
                if (player.GetBottom() >= dragon.GetTop() && player.GetTop() < dragon.GetTop() && player.GetRight() > dragon.GetLeft() && player.GetLeft() < dragon.GetRight()){
                    collision_down = true;
                } 


               
            }

        }
        

    }
}