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
                List<Image> dragons = scene.GetAllActors<Image>("dragon");
                List<Image> projectiles = scene.GetAllActors<Image>("projectile");
                List<Actor> trackers = scene.GetAllActors("tracker");
                List<Actor> swing = scene.GetAllActors("swing");
                Label status = scene.GetFirstActor<Label>("status");
                Label dragon_life = scene.GetFirstActor<Label>("dragon_life");
                Label player_life = scene.GetFirstActor<Label>("player_life");
                List<Image> walls = scene.GetAllActors<Image>("wall");
                List<Image> floors = scene.GetAllActors<Image>("floor");
                List<Actor> pits = scene.GetAllActors("pit");
                List<Actor> lava = scene.GetAllActors<Actor>("lava"); // will need to be changed to Image for texture application
                List<Actor> ArrowTraps = scene.GetAllActors<Actor>("ArrowTrap");

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
                _videoService.DrawGrid(10, Color.Gray(), camera);   
                _videoService.DrawGrid(50, Color.Red(), camera);      
                _videoService.DrawGrid(100, Color.Blue(), camera);         
                _videoService.Draw(floors, camera);
                _videoService.Draw(pits,camera);
                _videoService.Draw(lava, camera);               
                _videoService.Draw(dragons, camera);
                _videoService.Draw(walls, camera);
                _videoService.Draw(ArrowTraps, camera);
                _videoService.Draw(projectiles, camera);
                _videoService.Draw(trackers, camera);
                _videoService.Draw(swing, camera);

                _videoService.Draw(player, camera); 
                _videoService.Draw(status);
                _videoService.Draw(instructions);
                _videoService.Draw(dragon_life);
                _videoService.Draw(player_life);                        
                _videoService.FlushBuffer();
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't draw actors.", exception);
            }
        }

    }
}