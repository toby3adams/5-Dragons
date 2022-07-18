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
            List<Trap> Lava = scene.GetAllActors<Trap>("lava");
            Player player = scene.GetFirstActor<Player>("player");
            List<Trap> wall_traps = scene.GetAllActors<Trap>("block_trap");
            List<Trap> walkway_disint_trigger = scene.GetAllActors<Trap>("invis_doors");
            List<Projectile> fireballs = scene.GetAllActors<Projectile>("fireball_trap");
            BuildTraps buildtraps = new BuildTraps();
            int block_trap_shift_counter = 3;
            foreach(Floor floor in Rooms)
            {    
                int Room_num = Rooms.IndexOf(floor);             
                if(player.FullyOverlaps(floor))
                {   
                    foreach(Trap lava in Lava)
                    {
                        float initial_dimension = lava.GetWidth(); 
                        if(lava.GetRoom() == Room_num)
                        {
                            int lava_grow_counter = 60;
                            float lava_width = lava.GetWidth();
                            float lava_height = lava.GetHeight();     
                            int max_dimension = 900;
                            lava_grow_counter++;                          
                            if(lava_grow_counter > 60)
                            {
                                for(int i = 0; i < 2; i++)
                                {
                                    if(lava_width < max_dimension)
                                    {
                                        lava.IncWidth(1);  
                                        lava.IncHeight(1); 
                                        lava.SizeTo(lava.GetWidth(), lava.GetHeight());                                 
                                    }                                  
                                }                             
                                if(lava_width < max_dimension)
                                {                                    
                                    lava.DecX(1,1);
                                    lava.DecY(1,1);
                                    lava.MoveTo(lava.GetX(), lava.GetY()); 
                                }
                            }
                            lava_grow_counter = 0;                              
                        }
                    }
                }   
                if(!player.FullyOverlaps(floor))
                    {
                        foreach(Trap lava in Lava)
                        {    
                            if(lava.GetRoom() == Room_num)
                            {
                                int lava_grow_counter = 60;
                                lava_grow_counter++;
                                int initial_dimension = 280;
                                if(lava_grow_counter > 60)
                                {
                                    for(int i = 0; i < 2; i++)
                                    {                                            
                                        if(lava.GetWidth() > initial_dimension)
                                        {
                                            lava.DecWidth(1);  
                                            lava.DecHeight(1);  
                                            lava.SizeTo(lava.GetWidth(), lava.GetHeight());                                
                                        }                                            
                                    }                             
                                    if(lava.GetWidth() > initial_dimension)
                                    {                                    
                                        lava.IncX(1,1);
                                        lava.IncY(1,1);
                                        lava.MoveTo(lava.GetX(), lava.GetY());
                                    }                                                                                              
                                }
                            }                        
                        }
                    } 
                if(player.FullyOverlaps(floor))
                {
                    int block_shift_interval = 5;
                    int block_shift_rate = 1;
                    foreach(Trap trap in wall_traps)
                    { 
                        if(trap.GetTrapType() == 3)
                        {                                   
                            if(((trap.GetX()==40||trap.GetX()==1040||(trap.GetX()==2040))&&(trap.GetY()!= 4200))){
                                trap.IncY(block_shift_interval, block_shift_rate);
                                trap.MoveTo(trap.GetX(), trap.GetY());                                   
                                } else if(((trap.GetX()!=40)||(trap.GetX()!=1040)||(trap.GetX()!=2040))&&(trap.GetY()==3540)){                                 
                                    trap.DecX(block_shift_interval, block_shift_rate);
                                    trap.MoveTo(trap.GetX(), trap.GetY());                                  
                                }                        
                            if(((trap.GetX()==40+960-trap.GetWidth())||(trap.GetX()==1040+960-trap.GetWidth())||(trap.GetX()==2040+960-trap.GetWidth()))&&(trap.GetY()!=3540)){
                                trap.DecY(block_shift_interval, block_shift_rate);
                                trap.MoveTo(trap.GetX(), trap.GetY());
                                
                            }else if(((trap.GetX()!=(40+960)-(trap.GetWidth()))||(trap.GetX()!=(1040+960-trap.GetWidth()))||(trap.GetX()!=(2040+960-trap.GetWidth())))&&(trap.GetY()==4200)){
                                trap.IncX(block_shift_interval, block_shift_rate);
                                trap.MoveTo(trap.GetX(), trap.GetY());
                            }
                        }
                    }                            
                }  
                foreach(Turret turret in Turrets)
                {
                    if(turret.GetRoom() == Room_num)                        
                    {
                        turret_attack(scene, turret, player);
                    } 
                }
                block_trap_shift_counter += 3;
            }      
            if (this.lava_counter > 1)
                {               
                foreach (Trap lavaBlock in Lava)
                {                       
                    if (player.Overlaps(lavaBlock)){
                          player.takes_damage(1);
                        }
                    }
                    this.lava_counter=0;
                }
                this.lava_counter++;                
                    List<Trap> pit_fall = scene.GetAllActors<Trap>("pit");
                    foreach (Trap pit_falls in pit_fall)
                    {
                        if(player.FullyOverlaps(pit_falls,pit_fallTop,pit_fallBottom,pit_fallLeft,pit_fallRight))
                        {
                           player.takes_damage(player.damage); 
                        }
                    }     
        }       
        public void turret_attack(Scene scene, Turret turret, Player player)
        {
            turret.turret_counter++;
            if(turret.turret_counter == turret.expect_count)
            {
                int fireball_direction = turret.GetTurretDirection();
                Projectile fireball = new Projectile(10, 5, fireball_direction);
                fireball.SizeTo(20,20);
                fireball.Tint(Color.Orange());
                scene.AddActor("fireball_trap", fireball);
                fireball.Display("Game/Assets/fireball.png");
                if(fireball_direction == 1){
                    fireball.MoveTo(turret.GetRight()+20, turret.GetCenterY());
                }
                if(fireball_direction == 2){
                    fireball.MoveTo(turret.GetCenterX(), turret.GetBottom()+20);
                }
                if(fireball_direction == 3){
                    fireball.MoveTo(turret.GetCenterX(), turret.GetTop()-20);
                }
                if(fireball_direction == 4){
                    fireball.MoveTo(turret.GetCenterX(), turret.GetBottom()+20);
                }
                if(fireball_direction == 5){
                    fireball.MoveTo(turret.GetLeft()-20, turret.GetCenterY());
                }
                if(fireball_direction == 6){
                    fireball.MoveTo(turret.GetCenterX(), turret.GetBottom()+20);
                }
                if(fireball_direction == 7){
                    fireball.MoveTo(turret.GetCenterX(), turret.GetBottom()+20);
                }
                if(fireball_direction == 8){
                    fireball.MoveTo(turret.GetCenterX(), turret.GetBottom()+20);
                }
                turret.turret_counter = 0;            
            }            
        }
    }
}