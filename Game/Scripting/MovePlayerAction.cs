using System;
using System.Collections.Generic;
using Dragons.Game.Casting;
using Dragons.Game.Services;
using System.Numerics;


namespace Dragons.Game.Scripting
{
    /// <summary>
    /// Moves the player within the game world while scrolling the screen.
    /// </summary>
    public class MovePlayerAction : Action
    {
        private int WallCollision;
        
        public MovePlayerAction()
        {
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            Player player = scene.GetFirstActor<Player>("player");
            PlayerCollisions player_collisions = new PlayerCollisions();
            player_collisions.CheckCollisions(scene, player);
            try
            {
                // get the actors, including the camera, from the cast
                Camera camera = scene.GetFirstActor<Camera>("camera");
                Actor world = camera.GetWorld();
                //Actor player = scene.GetFirstActor("player");
                
                // move the player and clamp it to the boundaries of the world.
                
                
 
                    Vector2 velocity = player.GetVelocity();
                    
                    if (player_collisions.collision_down){
                        if (velocity.Y > 0){
                            player.Steer(velocity.X, 0);
                            velocity.Y = 0;
                        }
                    }
                    if (player_collisions.collision_left){
                        if (velocity.X < 0){
                            player.Steer(0, velocity.Y);
                            velocity.X = 0;
                        }
                    }
                    if (player_collisions.collision_right){
                        if (velocity.X > 0){
                            player.Steer(0, velocity.Y);
                            velocity.X = 0;
                        }
                    }
                    if (player_collisions.collision_up){
                        if (velocity.Y < 0){
                            player.Steer(velocity.X, 0);
                            velocity.Y = 0;
                        }
                    }
                    if (!player.is_dead){
                        player.Move();
                        player.ClampTo(world);
                    }  
                    
                
                   
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't move player.", exception);
            }
        }
    }
}