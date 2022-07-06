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
            


        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {


                if (_keyboardService.IsKeyDown(KeyboardKey.J))
                {
                    Actor player = scene.GetFirstActor<Actor>("player");
                    Vector2 velocity = player.GetVelocity();
                    
                    if (velocity.X > 0){
                        ProjectileMovement movement = new ProjectileMovement("right", 7);
                        Projectile projectile1 = new Projectile(10, movement);
                        projectile1.MoveTo(player.GetCenterX(), player.GetCenterY());
                        projectile1.SizeTo(1, 1);
                        scene.AddActor("projectile", projectile1);
                    }
                    else if (velocity.X < 0){
                        ProjectileMovement movement = new ProjectileMovement("left", 7);
                        Projectile projectile1 = new Projectile(10, movement);
                        projectile1.MoveTo(player.GetCenterX(), player.GetCenterY());
                        projectile1.SizeTo(1, 1);
                        scene.AddActor("projectile", projectile1);
                    }
                    else if (velocity.Y > 0){
                        ProjectileMovement movement = new ProjectileMovement("up", 7);
                        Projectile projectile1 = new Projectile(10, movement);
                        projectile1.MoveTo(player.GetCenterX(), player.GetCenterY());
                        projectile1.SizeTo(1, 1);
                        scene.AddActor("projectile", projectile1);
                    }
                    else if (velocity.Y < 0){
                        ProjectileMovement movement = new ProjectileMovement("down", 7);
                        Projectile projectile1 = new Projectile(10, movement);
                        projectile1.MoveTo(player.GetCenterX(), player.GetCenterY());
                        projectile1.SizeTo(1, 1);
                        scene.AddActor("projectile", projectile1);
                    }


                }

        }
    }
    }
