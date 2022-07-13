using System.Collections.Generic;
using Dragons.Game.Casting;
using Dragons.Game.Services;
using System.Numerics;
using System;

namespace Dragons.Game.Scripting
{

    public class TrapActions : Action
    {

        public TrapActions(){}

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            List<Trap>Traps = scene.GetAllActors<Trap>("Trap");
            List<Turret>Turrets = scene.GetAllActors<Turret>("turret");
            Player player = scene.GetFirstActor<Player>("player");
            

            foreach (Turret turret in Turrets)
            {
                turret_attack(scene, turret, player);
                Console.WriteLine("pow");
            }
        }

        public void attack_player(Scene scene, Trap trap, Player player)
        {

        }

        public void turret_attack(Scene scene, Turret turret, Player player)
        {
            int arrow_direction = turret.GetTurretDirection();
            Projectile arrow = new Projectile(10, 4, arrow_direction);
            arrow.SizeTo(10,10);
            arrow.Tint(Color.White());
            scene.AddActor("arrow", arrow);
            arrow.Display("Game/Assets/fireball.png");
            if(arrow_direction == 1){
                arrow.MoveTo(turret.GetRight()+15, turret.GetCenterY());
            }
            if(arrow_direction == 3){
                arrow.MoveTo(turret.GetCenterX(), turret.GetTop()-10);
            }
            if(arrow_direction == 5){
                arrow.MoveTo(turret.GetLeft()-15, turret.GetCenterY());
            }
            if(arrow_direction == 7){
                arrow.MoveTo(turret.GetCenterX(), turret.GetBottom()+10);
            }
        }

    }
}