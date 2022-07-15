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
            int block_trap_shift_counter = 3;
            foreach(Floor floor in Rooms)
            {    
                
                //block trap shifting
                if(block_trap_shift_counter %  6 == 0)
                {
                    /*int block_shift_interval = 1;
                    int block_shift_rate = 1;
                    foreach(Trap trap in wall_traps)
                    { 
                        if(trap.GetTrapType() == 3)
                        {
                                //moves upper left block down
                            if(((trap.GetX()==40||trap.GetX()==1040||(trap.GetX()==2040))&&(trap.GetY()!= 4200))){
                                trap.IncY(block_shift_interval, block_shift_rate);
                                trap.MoveTo(trap.GetX(), trap.GetY());
                                
                            //moves upper right block left
                            }else if(((trap.GetX()!=40)||(trap.GetX()!=1040)||(trap.GetX()!=2040))&&(trap.GetY()==3540)){
                                Console.WriteLine("IF 2");
                                // trap.MoveTo(trap.GetX()-960+trap.GetWidth(),trap.GetHeight());
                                trap.DecX(block_shift_interval, block_shift_rate);
                                trap.MoveTo(trap.GetX(), trap.GetY());
                                
                            //moves lower left block right
                            }
                            //moves lower right block up
                            if(((trap.GetX()==40+960-trap.GetWidth())||(trap.GetX()==1040+960-trap.GetWidth())||(trap.GetX()==2040+960-trap.GetWidth()))&&(trap.GetY()!=3540)){
                                trap.DecY(block_shift_interval, block_shift_rate);
                                trap.MoveTo(trap.GetX(), trap.GetY());
                                
                            }else if(((trap.GetX()!=(40+960)-(trap.GetWidth()))||(trap.GetX()!=(1040+960-trap.GetWidth()))||(trap.GetX()!=(2040+960-trap.GetWidth())))&&(trap.GetY()==4200)){
                                
                                //trap.MoveTo(trap.GetX()+960-trap.GetWidth(),trap.GetWidth());
                                trap.IncX(block_shift_interval, block_shift_rate);
                                trap.MoveTo(trap.GetX(), trap.GetY());
                            }
                        }
                            
                    }    */
                }
                
                int Room_num = Rooms.IndexOf(floor);
                // grow lava
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
                                        lava.IncWidth(2);                                    
                                    }
                                    if(lava_width < max_dimension)
                                    {
                                        lava.IncHeight(2);                                        
                                    } 
                                    lava.SizeTo(lava.GetWidth(), lava.GetHeight()); 
                                }                             
                                if(lava_width < max_dimension)
                                {                                    
                                    lava.DecX(2,1);
                                }
                                if(lava_width < max_dimension)
                                {                                    
                                    lava.DecY(2,1);
                                }                                        
                                lava.MoveTo(lava.GetX(), lava.GetY());                                                       
                            }
                            lava_grow_counter = 0;                              
                        }
                    }
                }   // lava grow end bracket    
                    // lava trap shrinks
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
                                            }
                                            if(lava.GetWidth() > initial_dimension)
                                            {
                                                lava.DecHeight(1);                                        
                                            } 
                                            lava.SizeTo(lava.GetWidth(), lava.GetHeight()); 
                                        }                             
                                        if(lava.GetWidth() > initial_dimension)
                                        {                                    
                                            lava.IncX(1,1);
                                        }
                                        if(lava.GetWidth() > initial_dimension)
                                        {                                    
                                            lava.IncY(1,1);
                                        }                                        
                                        lava.MoveTo(lava.GetX(), lava.GetY());                                                       
                                    }
                                }                        
                            }
                        } // lava shrink end bracket
                    // Block trap shifting
                    if(player.FullyOverlaps(floor))
                    {
                        int block_shift_interval = 5;
                        int block_shift_rate = 1;
                        foreach(Trap trap in wall_traps)
                        { 
                            if(trap.GetTrapType() == 3)
                            {
                                    //moves upper left block down
                                if(((trap.GetX()==40||trap.GetX()==1040||(trap.GetX()==2040))&&(trap.GetY()!= 4200))){
                                    trap.IncY(block_shift_interval, block_shift_rate);
                                    trap.MoveTo(trap.GetX(), trap.GetY());
                                    
                                //moves upper right block left
                                }else if(((trap.GetX()!=40)||(trap.GetX()!=1040)||(trap.GetX()!=2040))&&(trap.GetY()==3540)){
                                    Console.WriteLine("IF 2");
                                    // trap.MoveTo(trap.GetX()-960+trap.GetWidth(),trap.GetHeight());
                                    trap.DecX(block_shift_interval, block_shift_rate);
                                    trap.MoveTo(trap.GetX(), trap.GetY());
                                    
                                //moves lower left block right
                                }
                                //moves lower right block up
                                if(((trap.GetX()==40+960-trap.GetWidth())||(trap.GetX()==1040+960-trap.GetWidth())||(trap.GetX()==2040+960-trap.GetWidth()))&&(trap.GetY()!=3540)){
                                    trap.DecY(block_shift_interval, block_shift_rate);
                                    trap.MoveTo(trap.GetX(), trap.GetY());
                                    
                                }else if(((trap.GetX()!=(40+960)-(trap.GetWidth()))||(trap.GetX()!=(1040+960-trap.GetWidth()))||(trap.GetX()!=(2040+960-trap.GetWidth())))&&(trap.GetY()==4200)){
                                    
                                    //trap.MoveTo(trap.GetX()+960-trap.GetWidth(),trap.GetWidth());
                                    trap.IncX(block_shift_interval, block_shift_rate);
                                    trap.MoveTo(trap.GetX(), trap.GetY());
                                }
                            }
                        }                            
                }    
            
                foreach (Turret turret in Turrets)
                {
                    
                    if(turret.GetRoom() == Room_num && player.FullyOverlaps(floor))
                    {
                        turret_attack(scene, turret, player);
                    }                
                
                }
                block_trap_shift_counter += 3;
            } // foreach Floor end bracket      
            if (this.lava_counter > 45)
                {               
                foreach (Trap lavaBlock in Lava)
                {                       
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
            //turret.expect_count = rnd.Next(75,90);
            }
            
        }

    }
}