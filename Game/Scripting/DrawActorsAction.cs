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
                List<Label> instructions = scene.GetAllActors<Label>("instructions");
                Image player = scene.GetFirstActor<Image>("player");
                List<Image> dragons = scene.GetAllActors<Image>("dragon");
                List<Image> projectiles = scene.GetAllActors<Image>("projectile");
                List<Image> trackers = scene.GetAllActors<Image>("tracker");
                List<Image> waves = scene.GetAllActors<Image>("wave");
                List<Image> fireball_traps = scene.GetAllActors<Image>("fireball_trap");
                List<Image> swing = scene.GetAllActors<Image>("swing");
                Label status = scene.GetFirstActor<Label>("status");
                Label dragon_life = scene.GetFirstActor<Label>("dragon_life");
                Label player_life = scene.GetFirstActor<Label>("player_life");
                List<Image> walls = scene.GetAllActors<Image>("wall");
                List<Image> floors = scene.GetAllActors<Image>("floor");

                List<Image> titlescreenbuttons = scene.GetAllActors<Image>("button"); 
                Image header = scene.GetFirstActor<Image>("header");
                Image StartBck = scene.GetFirstActor<Image>("stback");

                List<Image> pits = scene.GetAllActors<Image>("pit");
                List<Image> lava = scene.GetAllActors<Image>("lava"); // will need to be changed to Image for texture application
                List<Image> dragon_lava = scene.GetAllActors<Image>("dragon_lava");
                List<Image> dragon_swing = scene.GetAllActors<Image>("dragon_swing");
                List<Actor> ArrowTraps = scene.GetAllActors<Actor>("ArrowTrap");
                List<Actor> Arrows = scene.GetAllActors<Actor>("arrow");
                List<Image> WallTraps = scene.GetAllActors<Image>("wall_trap");
                List<Image> BlockTraps = scene.GetAllActors<Image>("block_trap");
                List<Image> Stationary_block_traps = scene.GetAllActors<Image>("stationary_block_trap");

                List<Image> invis_doors = scene.GetAllActors<Image>("invis_doors");
                List<Actor> pit_falls = scene.GetAllActors<Actor>("pit_fall");

                
                List<Image> win_loss = scene.GetAllActors<Image>("win_loss");
                List<Image> blood_splatters = scene.GetAllActors<Image>("blood_splatter");


                // Actor world = camera.GetWorld();
                // foreach (Actor dragon in dragons){
                //     dragon.ClampTo(world);
                // }
            
                // Draw the actors on the screen. Note we have provided the camera as a second 
                // parameter when drawing the player. The videoservice uses the camera to translate
                // the player's position within the world to its position on the screen.


                

                _videoService.ClearBuffer();
                // _videoService.DrawGrid(10, Color.Gray(), camera);   
                // _videoService.DrawGrid(50, Color.Red(), camera);      
                // _videoService.DrawGrid(100, Color.Blue(), camera);         
                
                if(header!=null)
                {_videoService.Draw(header);}

                if(header!=null)
                {_videoService.Draw(StartBck);}

                if(titlescreenbuttons!=null)
                {_videoService.Draw(titlescreenbuttons);}  



                if(floors!=null)
                {_videoService.Draw(floors, camera);}
                if(instructions!=null)
                {_videoService.Draw(instructions, camera);}
                if(pits!=null)
                {   //Console.WriteLine("Pits are not NULL");
                    _videoService.Draw(pits,camera);}
                if(pit_falls!=null)
                {
                    _videoService.Draw(pit_falls, camera);
                }
                if(lava!=null)
                {_videoService.Draw(lava, camera);}
                if (dragon_swing !=null){
                    _videoService.Draw(dragon_swing, camera);
                }

                

                if (dragon_lava!=null){
                    _videoService.Draw(dragon_lava, camera);
                }
                if(dragons!=null)
                {_videoService.Draw(dragons, camera);}
                if (blood_splatters != null){
                    _videoService.Draw(blood_splatters, camera);
                }
                if(WallTraps!=null)
                {_videoService.Draw(WallTraps, camera);}
                if(BlockTraps!=null)
                {_videoService.Draw(BlockTraps, camera);}
                if(Stationary_block_traps!=null)
                {_videoService.Draw(Stationary_block_traps,camera);}
                
                
                
                if(ArrowTraps!=null)
                {_videoService.Draw(ArrowTraps, camera);}
                if(walls!=null)
                {_videoService.Draw(walls, camera);}
                if(projectiles!=null)
                {_videoService.Draw(projectiles, camera);}
                if(fireball_traps!=null)
                {_videoService.Draw(fireball_traps, camera);}
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
                
                if(dragon_life!=null)
                {_videoService.Draw(dragon_life);}
                if(player_life!=null)
                {_videoService.Draw(player_life);}
                if (win_loss != null){
                    _videoService.Draw(win_loss);
                }

                
                
                
                                     
                _videoService.FlushBuffer();
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't draw actors.", exception);
            }
        }

    }
}