
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
        private int counter_sheild = 0;
        private int last_direction = 1;
        bool sheild_is_up = false;
        private int last_melee_direction;
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
            if (player.shield && !player.is_dead){
                if (counter_sheild > 60)
                {

                    if (_keyboardService.IsKeyDown(KeyboardKey.L)){

                        if (!sheild_is_up){

                        
                        player.sheild_wall = new Wall();
                        player.sheild_wall.Display("Game/Assets/shield.png");
                        // sheild.Tint(Color.Gray());
                        
                        scene.AddActor("wall", player.sheild_wall);
                        player.sheild_wall.SizeTo(15, 60);

                        if (last_direction == 1){
                            player.sheild_wall.MoveTo(player.GetRight(), player.GetTop()-5);
                            
                        }
                        if (last_direction == 2){
                            player.sheild_wall.MoveTo(player.GetRight(), player.GetTop()-35);
                            player.sheild_wall.RotateTo(-45);
                        }
                        if (last_direction == 3){
                            player.sheild_wall.RotateTo(-90);
                            player.sheild_wall.MoveTo(player.GetLeft()+20, player.GetTop()-40);
                        }
                        if (last_direction == 4){
                            player.sheild_wall.MoveTo(player.GetLeft()-15, player.GetTop()-35);
                            player.sheild_wall.Rotate(-135);
                        }
                        if (last_direction == 5){
                            player.sheild_wall.RotateTo(180);
                            player.sheild_wall.MoveTo(player.GetLeft()-15, player.GetTop()-5);
                        }
                        if (last_direction == 6){
                            player.sheild_wall.MoveTo(player.GetLeft()-15, player.GetBottom()-20);
                            player.sheild_wall.Rotate(-225);
                        }
                        if (last_direction == 7){
                            player.sheild_wall.MoveTo(player.GetLeft()+17, player.GetBottom()-15);
                            player.sheild_wall.RotateTo(90);
                        }
                        if (last_direction == 8){
                            player.sheild_wall.MoveTo(player.GetRight()-5, player.GetBottom()-15);
                            player.sheild_wall.Rotate(45);
                        }
                        first_sheild = false;
                        sheild_is_up = true;
                    }
                        player.Steer(0,0);
                    }
                }

                if (_keyboardService.IsKeyReleased(KeyboardKey.L)){
                    scene.RemoveActor("wall", player.sheild_wall);
                    if (sheild_is_up){
                        counter_sheild = 0;
                    }
                    sheild_is_up = false;
    
                }
                counter_sheild += 1;

            }
            



            




            // melee attacks
            if (counter_melee > 30 && !player.is_dead){

                if (_keyboardService.IsKeyDown(KeyboardKey.K)){

                    List<Dragon> dragons = scene.GetAllActors<Dragon>("dragon");
                    player.swing = new Image();
                    
                    scene.AddActor("swing", player.swing);

                    if (last_direction == 1){
                        player.swing.SizeTo(player.melee_range, 50);
                        player.swing.MoveTo(player.GetRight(), player.GetTop()); 
                        if (!player.sword){
                            player.swing.Display("Game/Assets/dagger_1.png");
                        }
                        else{
                            player.swing.Display("Game/Assets/sword_1.png");
                        }
                        last_melee_direction = 1;
                    }
                    if (last_direction == 2){
                        player.swing.SizeTo(player.melee_range+25, player.melee_range+25);
                        player.swing.MoveTo(player.GetRight()-25, player.GetTop()-player.melee_range);
                        if (!player.sword){
                            player.swing.Display("Game/Assets/dagger_2.png");
                        }
                        else{
                            player.swing.Display("Game/Assets/sword_2.png");
                        }
                        last_melee_direction = 2;
                    }
                    if (last_direction == 3){
                        player.swing.SizeTo(50, player.melee_range);
                        player.swing.MoveTo(player.GetLeft(), player.GetTop()-player.melee_range);
                        if (!player.sword){
                            player.swing.Display("Game/Assets/dagger_3.png");
                        }
                        else{
                            player.swing.Display("Game/Assets/sword_3.png");
                        }
                        last_melee_direction = 3;
                    }
                    if (last_direction == 4){
                        player.swing.SizeTo(player.melee_range+25, player.melee_range+25);
                        player.swing.MoveTo(player.GetLeft()-player.melee_range, player.GetTop()-player.melee_range);
                        if (!player.sword){
                            player.swing.Display("Game/Assets/dagger_4.png");
                        }
                        else{
                            player.swing.Display("Game/Assets/sword_4.png");
                        }
                        last_melee_direction = 4;
                    }
                    if (last_direction == 5){
                        player.swing.SizeTo(player.melee_range, 50);
                        player.swing.MoveTo(player.GetLeft()-player.melee_range, player.GetTop());
                        if (!player.sword){
                            player.swing.Display("Game/Assets/dagger_5.png");
                        }
                        else{
                            player.swing.Display("Game/Assets/sword_5.png");
                        }
                        last_melee_direction = 5;
                    }
                    if (last_direction == 6){
                        player.swing.SizeTo(player.melee_range+25, player.melee_range+25);
                        player.swing.MoveTo(player.GetLeft()-player.melee_range, player.GetBottom()-25);
                        if (!player.sword){
                            player.swing.Display("Game/Assets/dagger_6.png");
                        }
                        else{
                            player.swing.Display("Game/Assets/sword_6.png");
                        }
                        last_melee_direction = 6;
                    }
                    if (last_direction == 7){
                        player.swing.SizeTo(50, player.melee_range);
                        player.swing.MoveTo(player.GetLeft(), player.GetBottom());
                        if (!player.sword){
                            player.swing.Display("Game/Assets/dagger_7.png");
                        }
                        else{
                            player.swing.Display("Game/Assets/sword_7.png");
                        }
                        last_melee_direction = 7;
                    }
                    if (last_direction == 8){
                        player.swing.SizeTo(player.melee_range+25, player.melee_range+25);
                        player.swing.MoveTo(player.GetRight()-25, player.GetBottom()-25);
                        if (!player.sword){
                            player.swing.Display("Game/Assets/dagger_8.png");
                        }
                        else{
                            player.swing.Display("Game/Assets/sword_8.png");
                        }
                        
                        last_melee_direction = 8;
                    }
                    


                    foreach (Dragon dragon in dragons){
                        if (player.swing.Overlaps(dragon)){
                            dragon.takes_damage(player.damage);
                            Console.WriteLine(dragon.dragon_health); // debugging
                        }
                    }

                
                    
                    player.swing_is_displayed = true;
                    counter_melee = 0;
                }
                
            }
            counter_melee += 1;


            if (player.swing_is_displayed){
                if (last_melee_direction == 1){
                    player.swing.MoveTo(player.GetRight(), player.GetTop());   
                } 
                if (last_melee_direction == 2){
                    player.swing.MoveTo(player.GetRight()-25, player.GetTop()-player.melee_range);
                }
                if (last_melee_direction == 3){
                    player.swing.MoveTo(player.GetLeft(), player.GetTop()-player.melee_range);
                }
                if (last_melee_direction == 4){
                    player.swing.MoveTo(player.GetLeft()-player.melee_range, player.GetTop()-player.melee_range);
                }
                if (last_melee_direction == 5){
                    player.swing.MoveTo(player.GetLeft()-player.melee_range, player.GetTop());
                }
                if (last_melee_direction == 6){
                    player.swing.MoveTo(player.GetLeft()-player.melee_range, player.GetBottom()-25);
                }
                if (last_melee_direction == 7){
                    player.swing.MoveTo(player.GetLeft(), player.GetBottom());
                }
                if (last_melee_direction == 8){
                    player.swing.MoveTo(player.GetRight()-25, player.GetBottom()-25);
                }
            }
            
            
            if (player.swing_is_displayed){
                if (player.ticks_since_swing % 10 == 0){
                    scene.RemoveActor("swing", player.swing);
                    player.swing_is_displayed = false;
                }

                player.ticks_since_swing += 1;
            }
            

            //ranged attacks
            if (player.bow && !player.is_dead){
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



                player.ticks_since_damage +=1;

                if (player.ticks_since_damage > 600 && player.ticks_since_damage % 30 == 0 && !player.is_dead){
                    player.Player_Life +=1;
                    if (player.Player_Life > 30){
                        player.Player_Life = 30;
                    }
                }

        }

        }
    }
