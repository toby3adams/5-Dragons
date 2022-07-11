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
                List<Dragon> dragons = scene.GetAllActors<Dragon>("dragon");
                Label status = scene.GetFirstActor<Label>("status");
                Label dragon_life = scene.GetFirstActor<Label>("dragon_life");
                Label player_life = scene.GetFirstActor<Label>("player_life");


                int dragons_in_range = 0;

                foreach (Dragon dragon in dragons){
                    if (dragon.is_near_player){
                        string new_drag_life = $"Dragon Life:{dragon.GetHealth().ToString()}";
                        dragon_life.Display(new_drag_life);  
                        dragons_in_range += 1;                      
                    }
                }
                if (dragons_in_range == 0){
                    string new_drag_life = $"Dragon Life: - ";
                    dragon_life.Display(new_drag_life); 
                }

                string new_player_life = $"Player Life:{player.GetHealth().ToString()}";
                        player_life.Display(new_player_life);  



                // update the status actor with the player info
                string newInfo = $"x:{player.GetPosition().X}, y:{player.GetPosition().Y}";
                status.Display(newInfo);
                // update Dragon health
                

            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't update status.", exception);
            }
        }
    }
}