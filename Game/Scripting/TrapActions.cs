using System.Collections.Generic;
using Dragons.Game.Casting;
using Dragons.Game.Services;
using System.Numerics;
using System;

namespace Dragons.Game.Scripting
{

    public class TrapActions : Action

    {   
        private int lava_counter;

        private int pit_fallBottom = -20;
        private int pit_fallTop = -21;

        private int pit_fallLeft = 0;
        private int pit_fallRight = 0;

        Random rnd = new Random();
        public TrapActions(){}


        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            List<Floor>Rooms = scene.GetAllActors<Floor>("floor");
            List<Trap>Traps = scene.GetAllActors<Trap>("Trap");
            List<Turret>Turrets = scene.GetAllActors<Turret>("ArrowTrap");
            Player player = scene.GetFirstActor<Player>("player");
            
            foreach(Floor floor in Rooms)
            {
                
                int Room_num = Rooms.IndexOf(floor);
                foreach (Turret turret in Turrets)
                {
                    
                    if(turret.GetRoom() == Room_num && player.FullyOverlaps(floor))
                    {
                        Console.WriteLine("Test");
                        turret_attack(scene, turret, player);
                    }                
                
                }
            }

             if (this.lava_counter > 65)
                {
                    List<Trap> Lava = scene.GetAllActors<Trap>("lava"); 


                    foreach (Trap lavaBlock in Lava){
                        if (player.Overlaps(lavaBlock)){
                            player.takes_damage(player.damage);
                        }
                    }
                    this.lava_counter=0;
                }
                this.lava_counter++;

                //Doesn't need counter
                    List<Trap> pit_fall = scene.GetAllActors<Trap>("pit");

                    foreach (Trap pit_falls in pit_fall)
                    {
                        if(player.FullyOverlaps(pit_falls,pit_fallTop,pit_fallBottom,pit_fallLeft,pit_fallRight))
                        {
                           player.takes_damage(player.damage); 
                        }
                    }         

                
        }

        public void attack_player(Scene scene, Trap trap, Player player)
        {

        }

        public void turret_attack(Scene scene, Turret turret, Player player)
        {
            turret.turret_counter++;
            if(turret.turret_counter == turret.expect_count)
            {
                int arrow_direction = turret.GetTurretDirection();
            Projectile arrow = new Projectile(10, 4, arrow_direction);
            arrow.SizeTo(20,20);
            arrow.Tint(Color.Orange());
            scene.AddActor("projectile", arrow);
            arrow.Display("Game/Assets/fireball.png");
            if(arrow_direction == 1){
                arrow.MoveTo(turret.GetRight()+20, turret.GetCenterY());
            }
            if(arrow_direction == 2){
                arrow.MoveTo(turret.GetCenterX(), turret.GetBottom()+20);
            }
            if(arrow_direction == 3){
                arrow.MoveTo(turret.GetCenterX(), turret.GetTop()-20);
            }
            if(arrow_direction == 4){
                arrow.MoveTo(turret.GetCenterX(), turret.GetBottom()+20);
            }
            if(arrow_direction == 5){
                arrow.MoveTo(turret.GetLeft()-20, turret.GetCenterY());
            }
            if(arrow_direction == 6){
                arrow.MoveTo(turret.GetCenterX(), turret.GetBottom()+20);
            }
            if(arrow_direction == 7){
                arrow.MoveTo(turret.GetCenterX(), turret.GetBottom()+20);
            }
            if(arrow_direction == 8){
                arrow.MoveTo(turret.GetCenterX(), turret.GetBottom()+20);
            }
            turret.turret_counter = 0;
            turret.expect_count = rnd.Next(45,90);
            }
            
        }

    }
}