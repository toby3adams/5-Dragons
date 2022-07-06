using System;
using System.Collections.Generic;
using Dragons.Game.Casting;
using Dragons.Game.Services;



namespace Dragons.Game.Scripting
{
    public class PlayerWallCollision
    {
        private bool collision;
        Scene scene;
        public PlayerWallCollision()
        {
            
        }
        public bool CheckPwc(Scene scene, Actor player)
        {
           
            List<Actor>walls = scene.GetAllActors("wall");
            foreach(Actor wall in walls)
            {
                if((player.GetTop() == wall.GetBottom() || player.GetBottom() == wall.GetTop() || player.GetLeft() == wall.GetRight() || player.GetRight() == wall.GetLeft()) && (player.GetLeft() > wall.GetLeft() || player.GetLeft() < wall.GetRight() && player.GetRight() > wall.GetLeft() || player.GetRight() < wall.GetRight()))
                {
                    collision = true;
                }
            }

            return collision;
        }
        

    }
}