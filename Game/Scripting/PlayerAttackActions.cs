using System.Collections.Generic;
using Dragons.Game.Casting;
using Dragons.Game.Services;
using System.Numerics;

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
        private int last_direction;

    

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
            Actor player = scene.GetFirstActor<Actor>("player");
            Vector2 velocity = player.GetVelocity();
            int direction = check_for_directions_stuff(velocity);
            
            if (direction != 0){
                this.last_direction = direction;
            }


            if (counter_melee > 30){

                if (_keyboardService.IsKeyDown(KeyboardKey.K)){
                    if (direction != 0){
                        
                        counter_melee = 0;
                    }
                    else {
                        
                        counter_melee = 0;
                    }
                }
                counter_melee += 1;
            }
            
            if (counter_ranged > 60){

                if (_keyboardService.IsKeyDown(KeyboardKey.J))
                {
                    if (direction != 0){
                        Projectile projectile1 = new Projectile(10, 7, direction);
                        projectile1.MoveTo(player.GetCenterX(), player.GetCenterY());
                        projectile1.SizeTo(4, 4);
                        scene.AddActor("projectile", projectile1);
                        counter_ranged = 0;
                    }
                    else {
                        Projectile projectile1 = new Projectile(10, 7, last_direction);
                        projectile1.MoveTo(player.GetCenterX(), player.GetCenterY());
                        projectile1.SizeTo(4, 4);
                        scene.AddActor("projectile", projectile1);
                        counter_ranged = 0;
                    }
                   
                }
                }
                counter_ranged += 1;
            }

        }
    }

