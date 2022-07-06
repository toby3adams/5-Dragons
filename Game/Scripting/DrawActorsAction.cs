using System;
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
                Actor player = scene.GetFirstActor("player");
                Actor dragon1 = scene.GetFirstActor("dragon1");
                Label status = scene.GetFirstActor<Label>("status");

                // Draw the actors on the screen. Note we have provided the camera as a second 
                // parameter when drawing the player. The videoservice uses the camera to translate
                // the player's position within the world to its position on the screen.
                _videoService.ClearBuffer();
                _videoService.DrawGrid(160, Color.Gray(), camera);
                _videoService.Draw(instructions);
                _videoService.Draw(player, camera);
                _videoService.Draw(dragon1, camera);
                _videoService.Draw(status);
                _videoService.FlushBuffer();
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't draw actors.", exception);
            }
        }

    }
}