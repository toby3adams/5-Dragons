using System;
using System.Collections.Generic;
using Dragons.Game.Casting;
using Dragons.Game.Services;


namespace Dragons.Game.Scripting
{
    /// <summary>
    /// Draws the actors on the screen.
    /// </summary>
    public class DrawActorsAction : Action
    {
        private IVideoService _videoService;

        public DrawActorsAction(IServiceFactory serviceFactory)
        {
            _videoService = serviceFactory.GetVideoService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                // Get the actors from the cast.
                Camera camera = scene.GetFirstActor<Camera>("camera");
                Label instructions = scene.GetFirstActor<Label>("instructions");
                Image player = scene.GetFirstActor<Image>("player");
                List<Actor> dragons = scene.GetAllActors("dragon");
                List<Actor> projectiles = scene.GetAllActors("projectile");
                List<Actor> swing = scene.GetAllActors("swing");
                Label status = scene.GetFirstActor<Label>("status");
                Label dragon_life = scene.GetFirstActor<Label>("dragon_life");
                List<Actor> walls = scene.GetAllActors("wall");


                Actor world = camera.GetWorld();
                foreach (Actor dragon in dragons){
                    dragon.ClampTo(world);
                }
                
                /*foreach(Actor wall in walls)
                {
                    wall.ClampTo(world);
                }*/


                // Draw the actors on the screen. Note we have provided the camera as a second 
                // parameter when drawing the player. The videoservice uses the camera to translate
                // the player's position within the world to its position on the screen.
                _videoService.ClearBuffer();
                _videoService.DrawGrid(100, Color.Gray(), camera);
                _videoService.Draw(instructions);

                _videoService.Draw(dragons, camera);
                _videoService.Draw(walls, camera);
                _videoService.Draw(projectiles, camera);
                _videoService.Draw(status);
                _videoService.Draw(dragon_life);
                _videoService.Draw(swing, camera);
                _videoService.Draw(player, camera);
                _videoService.FlushBuffer();
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't draw actors.", exception);
            }
        }

    }
}