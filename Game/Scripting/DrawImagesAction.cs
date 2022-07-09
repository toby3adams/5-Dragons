using System;
using System.Collections.Generic;
using Dragons.Game.Casting;
using Dragons.Game.Services;


namespace Dragons.Game.Scripting
{
    /// <summary>
    /// Draws the actors on the screen.
    /// </summary>
    public class DrawImageAction : Action
    {
        private IVideoService _videoService;

        public DrawImageAction(IServiceFactory serviceFactory)
        {
            _videoService = serviceFactory.GetVideoService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                // get the actors from the cast
                List<Image> player_texture = scene.GetAllActors<Image>("player_texture");

                // draw the actors on the screen using the video service
                _videoService.ClearBuffer();
                _videoService.Draw(player_texture);
                _videoService.FlushBuffer();
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't draw player_texture", exception);
            }
        }
    }
}