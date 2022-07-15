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
                List<Image> trackers = scene.GetAllActors<Image>("tracker");
                List<Image> waves = scene.GetAllActors<Image>("wave");
                List<Actor> swing = scene.GetAllActors("swing");
                Label status = scene.GetFirstActor<Label>("status");
                Label dragon_life = scene.GetFirstActor<Label>("dragon_life");
                Label player_life = scene.GetFirstActor<Label>("player_life");
                List<Image> walls = scene.GetAllActors<Image>("wall");
                List<Image> floors = scene.GetAllActors<Image>("floor");

                List<Image> titlescreenbuttons = scene.GetAllActors<Image>("button"); 
                Image header = scene.GetFirstActor<Image>("header");

                List<Actor> pits = scene.GetAllActors("pit");
                List<Image> lava = scene.GetAllActors<Image>("lava"); // will need to be changed to Image for texture application
                List<Actor> ArrowTraps = scene.GetAllActors<Actor>("ArrowTrap");
                List<Actor> Arrows = scene.GetAllActors<Actor>("arrow");
                List<Image> WallTraps = scene.GetAllActors<Image>("wall_trap");

                // Actor world = camera.GetWorld();
                // foreach (Actor dragon in dragons){
                //     dragon.ClampTo(world);
                // }
            
                // Draw the actors on the screen. Note we have provided the camera as a second 
                // parameter when drawing the player. The videoservice uses the camera to translate
                // the player's position within the world to its position on the screen.


                

                _videoService.ClearBuffer();
                _videoService.DrawGrid(10, Color.Gray(), camera);   
                _videoService.DrawGrid(50, Color.Red(), camera);      
                _videoService.DrawGrid(100, Color.Blue(), camera);         
                
                if(floors!=null)
                {_videoService.Draw(floors, camera);}
                if(pits!=null)
                {_videoService.Draw(pits,camera);}
                if(lava!=null)
                {_videoService.Draw(lava, camera);}
                if(dragons!=null)
                {_videoService.Draw(dragons, camera);}
                if(WallTraps!=null)
                {_videoService.Draw(WallTraps, camera);}
                
                
                
                if(ArrowTraps!=null)
                {_videoService.Draw(ArrowTraps, camera);}
                if(walls!=null)
                {_videoService.Draw(walls, camera);}
                if(projectiles!=null)
                {_videoService.Draw(projectiles, camera);}
                if(Arrows!=null)
                {_videoService.Draw(Arrows, camera);}
                if(trackers!=null)
                {_videoService.Draw(trackers, camera);}
                if(waves!=null)
                {_videoService.Draw(waves, camera);}
                if(swing!=null)
                {_videoService.Draw(swing, camera);}
                

                if(player!=null)
                {_videoService.Draw(player, camera);} 
                if(status!=null)
                {_videoService.Draw(status);}
                if(instructions!=null)
                {_videoService.Draw(instructions);}
                if(dragon_life!=null)
                {_videoService.Draw(dragon_life);}
                if(player_life!=null)
                {_videoService.Draw(player_life);} 
                if(header!=null)
                {_videoService.Draw(header);}
                if(titlescreenbuttons!=null)
                {_videoService.Draw(titlescreenbuttons);}                       
                _videoService.FlushBuffer();
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't draw actors.", exception);
            }
        }

    }
}