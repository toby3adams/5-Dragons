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
        public void CheckCollisions(Scene scene, Actor player)
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