using System;
using System.Collections.Generic;
using Dragons.Game.Casting;
using Dragons.Game.Services;


namespace Dragons.Game.Scripting
{
    /// <summary>
    /// Updates the status information at the top of the screen.
    /// </summary>
    public class UpdateStatusAction : Action
    {
        public UpdateStatusAction()
        {
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                // get the player and status actors from the cast
                Actor player = scene.GetFirstActor("player");
                Label status = scene.GetFirstActor<Label>("status");

                // update the status actor with the player info
                string newInfo = $"x:{player.GetPosition().X}, y:{player.GetPosition().Y}";
                status.Display(newInfo);
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't update status.", exception);
            }
        }
    }
}