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
            Actor player = scene.GetFirstActor("player");
            PlayerWallCollision pwc = new PlayerWallCollision();
            pwc.CheckPwc(scene, player);
            try
            {
                // get the actors, including the camera, from the cast
                Camera camera = scene.GetFirstActor<Camera>("camera");
                Actor world = camera.GetWorld();
                //Actor player = scene.GetFirstActor("player");
                
                // move the player and clamp it to the boundaries of the world.
                
                
 
                    Vector2 velocity = player.GetVelocity();
                    
                    if (pwc.collision_down){
                        if (velocity.Y > 0){
                            player.Steer(velocity.X, 0);
                            velocity.Y = 0;
                        }
                    }
                    if (pwc.collision_left){
                        if (velocity.X < 0){
                            player.Steer(0, velocity.Y);
                            velocity.Y = 0;
                        }
                    }
                    if (pwc.collision_right){
                        if (velocity.X > 0){
                            player.Steer(0, velocity.Y);
                            velocity.X = 0;
                        }
                    }
                    if (pwc.collision_up){
                        if (velocity.Y < 0){
                            player.Steer(velocity.X, 0);
                            velocity.X = 0;
                        }
                    }              
                    player.Move();
                    player.ClampTo(world);
                
                   
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't move player.", exception);
            }
        }
    }
}