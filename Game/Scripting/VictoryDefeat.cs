using System.Collections.Generic;
using Dragons.Game.Casting;
using Dragons.Game.Services;
using System.Numerics;
using System;

namespace Dragons.Game.Scripting
{
    public class VictoryDefeat : Action
    {
        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            Player player = scene.GetFirstActor<Player>("player");

            if (player.Player_Life <= 0){
                player.is_dead = true;
                player.Display("Game/Assets/player_blood_splatter.png");


                Image loss_screen = new Image();
                loss_screen.SizeTo(600,150);
                loss_screen.MoveTo(630,340);
                scene.AddActor("win_loss", loss_screen);
            }


            List<Dragon> dragons = scene.GetAllActors<Dragon>("dragon");
            foreach(Dragon dragon in dragons){
                if (dragon.dragon_health <= 0 && !(dragon.type == "shadow")){
                    Image dead_dragon = new Image();
                    dead_dragon.SizeTo(100,100);
                    dead_dragon.MoveTo(dragon.GetLeft(), dragon.GetTop());
                    dead_dragon.Tint(dragon.GetTint());
                    dead_dragon.Display("Game/Assets/dragon_blood_splatter.png");
                    scene.AddActor("blood_splatter", dead_dragon);
                    scene.RemoveActor("dragon", dragon);
                }
                if (dragon.type == "shadow"){
                    if (dragon.dragon_health <= 0){
                        Image dead_dragon = new Image();
                        dead_dragon.SizeTo(100,100);
                        dead_dragon.MoveTo(dragon.GetLeft(), dragon.GetTop());
                        dead_dragon.Tint(dragon.GetTint());
                        dead_dragon.Display("Game/Assets/dragon_blood_splatter.png");
                        scene.AddActor("blood_splatter", dead_dragon);
                        scene.RemoveActor("dragon", dragon);
                        
                        Image win_screen = new Image();
                        win_screen.SizeTo(600,150);
                        win_screen.MoveTo(630,340);
                        scene.AddActor("win_loss", win_screen);
                    }
                }
                

                }
            }


        }

    }
