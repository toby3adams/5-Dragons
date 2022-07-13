using System.Collections.Generic;
using Dragons.Game.Casting;
using Dragons.Game.Services;
using System.Numerics;
using System;

namespace Dragons.Game.Scripting
{
    public class PlayerAttackAction : Action{

        private IKeyboardService _keyboardService;
        
        public PlayerAttackAction(IServiceFactory serviceFactory)
        {
            _keyboardService = serviceFactory.GetKeyboardService();
        }
            
        private int counter_ranged;
        private int counter_melee;
        private int counter_sheild = 65;
        private int last_direction = 1;
        private int last_sheild_direction = 1;
        Wall sheild;
        private bool first_sheild = true;

    

        public int check_for_directions_stuff(Vector2 player_velocity){
            if (player_velocity.X > 0 && player_velocity.Y == 0){
                return 1;
            }
            else if (player_velocity.X < 0 && player_velocity.Y == 0){
                return 5;
            }
            else if (player_velocity.X == 0 && player_velocity.Y > 0){
                return 7;
            }
            else if (player_velocity.X == 0 && player_velocity.Y < 0){
                return 3;
            }
            else if (player_velocity.X < 0 && player_velocity.Y < 0){
                return 4;
            }
            else if (player_velocity.X < 0 && player_velocity.Y > 0){
                return 6;
            }
            else if (player_velocity.X > 0 && player_velocity.Y > 0){
                return 8;
            }
            else if (player_velocity.X > 0 && player_velocity.Y < 0){
                return 2;
            }
            else{
                return 0;
            }

        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            Player player = scene.GetFirstActor<Player>("player");
            Vector2 velocity = player.GetVelocity();
            int direction = check_for_directions_stuff(velocity);
            
            if (direction != 0){
                this.last_direction = direction;
            }


            //sheild
            if (counter_sheild > 65)//has to be larger than the amount required before it is removed
            {

                if (_keyboardService.IsKeyDown(KeyboardKey.L)){

                    this.sheild = new Wall();
                    sheild.Tint(Color.Gray());
                    
                    scene.AddActor("wall", sheild);

                    if (last_direction == 1){
                        sheild.SizeTo(15, 60);
                        sheild.MoveTo(player.GetRight(), player.GetTop()-5);
                        
                    }
                    if (last_direction == 2){
                        sheild.SizeTo(15, 60);
                        sheild.MoveTo(player.GetRight(), player.GetTop()-35);
                        sheild.Rotate(-45);
                    }
                    if (last_direction == 3){
                        sheild.SizeTo(60, 15);
                        sheild.MoveTo(player.GetLeft()-5, player.GetTop()-15);
                    }
                    if (last_direction == 4){
                        sheild.SizeTo(15, 60);
                        sheild.MoveTo(player.GetLeft()-15, player.GetTop()-35);
                        sheild.Rotate(45);
                    }
                    if (last_direction == 5){
                        sheild.SizeTo(15, 60);
                        sheild.MoveTo(player.GetLeft()-15, player.GetTop()-5);
                    }
                    if (last_direction == 6){
                        sheild.SizeTo(15, 60);
                        sheild.MoveTo(player.GetLeft()-15, player.GetBottom()-25);
                        sheild.Rotate(-45);
                    }
                    if (last_direction == 7){
                        sheild.SizeTo(60, 15);
                        sheild.MoveTo(player.GetLeft()-5, player.GetBottom());
                    }
                    if (last_direction == 8){
                        sheild.SizeTo(15, 60);
                        sheild.MoveTo(player.GetRight(), player.GetBottom()-20);
                        sheild.Rotate(45);
                    }
                    counter_sheild = 0;
                    first_sheild = false;
                }
            }
            if (counter_sheild < 60){
                player.Steer(0,0);
            }
            if (!first_sheild){
            if (counter_sheild > 60){
                scene.RemoveActor("wall", this.sheild);
            }
            }
            counter_sheild += 1;




            // melee attacks
            if (counter_melee > 30){

                if (_keyboardService.IsKeyDown(KeyboardKey.K)){

                    List<Dragon> dragons = scene.GetAllActors<Dragon>("dragon");
                    Actor swing = new Actor();
                    
                    scene.AddActor("swing", swing);

                    if (last_direction == 1){
                        swing.SizeTo(player.melee_range, 50);
                        swing.MoveTo(player.GetRight(), player.GetTop());
                        
                    }
                    if (last_direction == 2){
                        swing.SizeTo(player.melee_range+25, player.melee_range+25);
                        swing.MoveTo(player.GetRight()-25, player.GetTop()-player.melee_range);
                    }
                    if (last_direction == 3){
                        swing.SizeTo(50, player.melee_range);
                        swing.MoveTo(player.GetLeft(), player.GetTop()-player.melee_range);
                    }
                    if (last_direction == 4){
                        swing.SizeTo(player.melee_range+25, player.melee_range+25);
                        swing.MoveTo(player.GetLeft()-player.melee_range, player.GetTop()-player.melee_range);
                    }
                    if (last_direction == 5){
                        swing.SizeTo(player.melee_range, 50);
                        swing.MoveTo(player.GetLeft()-player.melee_range, player.GetTop());
                    }
                    if (last_direction == 6){
                        swing.SizeTo(player.melee_range+25, player.melee_range+25);
                        swing.MoveTo(player.GetLeft()-player.melee_range, player.GetBottom()-25);
                    }
                    if (last_direction == 7){
                        swing.SizeTo(50, player.melee_range);
                        swing.MoveTo(player.GetLeft(), player.GetBottom());
                    }
                    if (last_direction == 8){
                        swing.SizeTo(player.melee_range+25, player.melee_range+25);
                        swing.MoveTo(player.GetRight()-25, player.GetBottom()-25);
                    }
                    


                    foreach (Dragon dragon in dragons){
                        if (swing.Overlaps(dragon)){
                            dragon.takes_damage(player.damage);
                            // Console.WriteLine(dragon.dragon_health); // debugging
                        }
                    }
                    scene.RemoveActor("swing", swing);

                    counter_melee = 0;
                }
                
            }
            counter_melee += 1;
            

            //ranged attacks
            if (counter_ranged > 60){

                if (_keyboardService.IsKeyDown(KeyboardKey.J))
                {
              
                        Projectile projectile1 = new Projectile(5, 7, last_direction);
                        
                        if (last_direction == 1){
                            projectile1.MoveTo(player.GetRight()+2, player.GetCenterY());
                        }
                        if (last_direction == 2){
                            projectile1.MoveTo(player.GetRight()+2, player.GetTop()-5);
                            projectile1.Rotate(-45);
                        }
                        if (last_direction == 3){
                            projectile1.MoveTo(player.GetCenterX(), player.GetTop()-5);
                            projectile1.Rotate(-90);
                        }
                        if (last_direction == 4){
                            projectile1.MoveTo(player.GetLeft()-5, player.GetTop()-5);
                            projectile1.Rotate(-135);
                        }
                        if (last_direction == 5){
                            projectile1.MoveTo(player.GetLeft()-8, player.GetCenterY());
                            projectile1.Rotate(-180);
                        }
                        if (last_direction == 6){
                            projectile1.MoveTo(player.GetLeft()-5, player.GetBottom()+2);
                            projectile1.Rotate(-225);
                        }
                        if (last_direction == 7){
                            projectile1.MoveTo(player.GetCenterX(), player.GetBottom()+2);
                            projectile1.Rotate(-270);
                        }
                        if (last_direction == 8){
                            projectile1.MoveTo(player.GetRight()+2, player.GetBottom()+2);
                            projectile1.Rotate(-315);
                        }
                        projectile1.SizeTo(10, 5);
                        scene.AddActor("projectile", projectile1);
                        projectile1.Display("Game/Assets/arrow.png");
                        counter_ranged = 0;
                }
                }
                counter_ranged += 1;
            }

        }
    }

