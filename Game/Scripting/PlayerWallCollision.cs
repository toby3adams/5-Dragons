using System;
using System.Collections.Generic;
using Dragons.Game.Casting;
using Dragons.Game.Services;



namespace Dragons.Game.Scripting
{
    public class PlayerWallCollision
    {
        public bool collision_up = false;
        public bool collision_down = false;
        public bool collision_left = false;
        public bool collision_right = false;
    
        public PlayerWallCollision()
        {
            
        }
        public void CheckPwc(Scene scene, Actor player)
        {
           
            List<Actor>walls = scene.GetAllActors("wall");
            foreach(Actor wall in walls)
            {
                if (player.GetTop() == wall.GetBottom() && player.GetRight() > wall.GetLeft() && player.GetLeft() < wall.GetRight())
                {
                    collision_up = true;
                }
                if (player.GetLeft() == wall.GetRight() && player.GetBottom() > wall.GetTop() && player.GetTop() < wall.GetBottom()){
                    collision_left = true;
                }
                if (player.GetRight() == wall.GetLeft() && player.GetBottom() > wall.GetTop() && player.GetTop() < wall.GetBottom()){
                    collision_right = true;
                }
                if (player.GetBottom() == wall.GetTop() && player.GetRight() > wall.GetLeft() && player.GetLeft() < wall.GetRight()){
                    collision_down = true;
                }
                
                
                    
                
            }

        }
        

    }
}