using Dragons.Game.Casting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Dragons.Game.Scripting 
{

    public class BuildTraps
    {
        Random rnd = new Random();
        
        
        private int max_y;
        
        
        private int rand_y;
        int Trap_Room_Type;
        private bool walkway_disintigrate = false;
        
        List<Trap> Traps = new List<Trap>();
        List<Turret> Turrets = new List<Turret>();
        //List<Trap> Lava = new List<Trap>();

        
        public BuildTraps(){
            
        }
        public List<Trap> GetAllTraps()
        {
            return Traps;
        }
        public List<Turret> GetTurrets()
        {
            return Turrets;
        }
        public void GenTraps()
        {
            GenTrapsRoom_1();
            GenTrapsRoom_2();
            GenTrapsRoom_3();
            GenTrapsRoom_4();
            GenTrapsRoom_5();
            
            Trap invis_door_left = new Trap(80,100,1000,3950,0,0);
            Traps.Add(invis_door_left);
            invis_door_left.MoveTo(invis_door_left.GetX(), invis_door_left.GetY());
            Trap invis_door_right = new Trap(80,100,2000,3950,0,0);
            Traps.Add(invis_door_right);
            invis_door_right.MoveTo(invis_door_right.GetX(), invis_door_right.GetY());
        }        
        public void GenTrapsRoom_1()
        {
            Trap walkway_disint_trigger = new Trap(100,700,1450,1540,0,0);
            Traps.Add(walkway_disint_trigger);
            Trap pit_left = new Trap(410,960,1040,1540, 1, 0);
            Traps.Add(pit_left);
            Trap pit_right = new Trap(450,960,1040+510,1540, 1, 0);
            Traps.Add(pit_right);                
        }        

        public void GenTrapsRoom_2()
        {
            int bottom_arrow_x_start = 1040;
            int left_arrow_y_start = 2540;
            int right_arrow_y_start = 2540;
            int top_arrow_x_start = 1040;
            int top_door_offset_counter = 0;
           
            int bottom__door_offset_counter = 0;
            
                Trap Lava = new Trap(280, 280, 1380, 2880, 2, 4);
                Traps.Add(Lava);
                for(int i = 0; i < 3; i++)
                {                    
                    Turret arrow_bottom = new Turret(110,40,bottom_arrow_x_start,3500, 3, 4);
                    Turrets.Add(arrow_bottom);
                    if(bottom__door_offset_counter == 0)
                    {
                        bottom_arrow_x_start += 210;                       
                    } else {
                        bottom_arrow_x_start += 410;                       
                    }                       
                    bottom__door_offset_counter++;                    
                }
                Turret Arrow_bottom_2 = new Turret(110,40,1890,3500, 3, 4);
                Turrets.Add(Arrow_bottom_2);   
               
                for(int i = 0; i < 4; i++)
                {                    
                    Turret arrow_left = new Turret(40,110,1000,left_arrow_y_start, 1, 4);
                    Turrets.Add(arrow_left);                    
                    left_arrow_y_start += 210;                     
                }
                Turret Arrow_left_2 = new Turret(40,110,1000,3390,1, 4);
                Turrets.Add(Arrow_left_2);
                for(int i = 0; i < 3; i++)
                {                    
                    Turret arrow_top = new Turret(110,40,top_arrow_x_start,2500, 7, 4);
                    Turrets.Add(arrow_top);
                    if(top_door_offset_counter == 0)
                    {
                        top_arrow_x_start += 210;                       
                    } else {
                        top_arrow_x_start += 410;                       
                    }                       
                    top_door_offset_counter++;                    
                }
                Turret Arrow_Top_2 = new Turret(110,40,1890,2500,7, 4);
                Turrets.Add(Arrow_Top_2);              
                for(int i = 0; i < 4; i++)
                {                    
                    Turret arrow_right = new Turret(40,110,2000,right_arrow_y_start, 5, 4);
                    Turrets.Add(arrow_right);                    
                    right_arrow_y_start += 210;                       
                 }
                Turret Arrow_right_2 = new Turret(40,110,2000,3390, 5, 4);
                Turrets.Add(Arrow_right_2);       
        }
        public void GenTrapsRoom_3()
        {            
            int bottom_arrow_x_start = 40;
            int left_arrow_y_start = 3540;
            int right_arrow_y_start = 3540;
            int top_arrow_x_start = 40;
            int top_door_offset_counter = 0;
            int right_door_offset_counter = 0;
            int bottom__door_offset_counter = 0;            
            
                Trap Lava = new Trap(280, 280, 380, 3880, 2, 2);
                Traps.Add(Lava);
                for(int i = 0; i < 3; i++)
                {                    
                    Turret arrow_bottom = new Turret(110,40,bottom_arrow_x_start,4500, 3, 2);
                    Turrets.Add(arrow_bottom);
                    if(bottom__door_offset_counter == 0)
                    {
                        bottom_arrow_x_start += 210;                       
                    } else {
                        bottom_arrow_x_start += 410;                       
                    }                       
                    bottom__door_offset_counter++;                    
                }
                Turret Arrow_bottom_2 = new Turret(110,40,890,4500, 3, 2);
                Turrets.Add(Arrow_bottom_2);                           
                for(int i = 0; i < 4; i++)
                {                    
                    Turret arrow_left = new Turret(40,110,0,left_arrow_y_start, 1, 2);
                    Turrets.Add(arrow_left);
                    left_arrow_y_start += 210;                   
                }
                Turret Arrow_left_2 = new Turret(40,110,0,4390,1, 2);
                Turrets.Add(Arrow_left_2);
                for(int i = 0; i < 3; i++)
                {                    
                    Turret arrow_top = new Turret(110,40,top_arrow_x_start,3500, 7, 2);
                    Turrets.Add(arrow_top);
                    if(top_door_offset_counter == 0)
                    {
                        top_arrow_x_start += 210;                       
                    } else {
                        top_arrow_x_start += 410;                       
                    }                       
                    top_door_offset_counter++;                    
                }
                Turret Arrow_Top_2 = new Turret(110,40,890,3500,7, 2);
                Turrets.Add(Arrow_Top_2);              
                for(int i = 0; i < 3; i++)
                {                    
                    Turret arrow_right = new Turret(40,110,1000,right_arrow_y_start, 5, 2);
                    Turrets.Add(arrow_right);
                    if(right_door_offset_counter == 0)
                    {
                        right_arrow_y_start += 210;                       
                    } else {
                        right_arrow_y_start += 410;                       
                    }                       
                    right_door_offset_counter++;                    
                }
                Turret Arrow_right_2 = new Turret(40,110,1000,4390, 5, 2);
                Turrets.Add(Arrow_right_2);          
        }
        public void GenTrapsRoom_4()
        {
            Trap_Room_Type = rnd.Next(2,2);   
            if(Trap_Room_Type == 2) 
            {
                int coord_shift_index = 0;
                int wall_trap_x = 1040;
                int wall_trap_y = 3540;
                Trap Center_Block = new Trap(360,360,wall_trap_x+300,wall_trap_y+300,4,5);
                Traps.Add(Center_Block);
                Trap Left_Block_Top = new Trap(200,410,wall_trap_x,wall_trap_y,4,5);
                Traps.Add(Left_Block_Top);
                Trap Left_Block_Bottom = new Trap(200,450,wall_trap_x,wall_trap_y+510,4,5);
                Traps.Add(Left_Block_Bottom);
                Trap Top_Block_Left = new Trap(410,200,wall_trap_x, wall_trap_y,4,5);
                Traps.Add(Top_Block_Left);
                Trap Top_Block_Right = new Trap(450,200,wall_trap_x+510,wall_trap_y,4,5);
                Traps.Add(Top_Block_Right);
                Trap Bottom_Block_Left = new Trap(410,200,wall_trap_x,wall_trap_y+760,4,5);
                Traps.Add(Bottom_Block_Left);
                Trap Bottom_Block_Right = new Trap(450,200,wall_trap_x+510,wall_trap_y+760,4,5);
                Traps.Add(Bottom_Block_Right);
                Trap Right_Block_Top = new Trap(200,410,wall_trap_x+760,wall_trap_y,4,5);
                Traps.Add(Right_Block_Top);
                Trap Right_Block_Bottom = new Trap(200,450,wall_trap_x+760,wall_trap_y+510,4,5);
                Traps.Add(Right_Block_Bottom);
                for(int i = 0; i < 4; i++)
                {
                    Trap wall_trap_left = new Trap(300,300,wall_trap_x, wall_trap_y, 3, 5);                    
                    if(coord_shift_index == 0){
                        wall_trap_y += 660;
                    } if(coord_shift_index == 1){
                        wall_trap_x += 660;
                    } if(coord_shift_index == 2){
                     wall_trap_y -= 660;
                    }
                    Traps.Add(wall_trap_left);
                    coord_shift_index++;                 
                }
            }
        }
        public void GenTrapsRoom_5()
        {
            int bottom_arrow_x_start = 2040;
            int left_arrow_y_start = 3540;
            int right_arrow_y_start = 3540;
            int top_arrow_x_start = 2040;
            int top_door_offset_counter = 0;
            int left_door_offset_counter = 0;
           
            int bottom__door_offset_counter = 0;
                Trap Lava_upper_left = new Trap(280, 280, 2385, 3880, 2, 8);
                Traps.Add(Lava_upper_left);
                for(int i = 0; i < 3; i++)
                {                    
                    Turret arrow_bottom = new Turret(110,40,bottom_arrow_x_start,4500, 3, 8);
                    Turrets.Add(arrow_bottom);
                    if(bottom__door_offset_counter == 0)
                    {
                        bottom_arrow_x_start += 210;                       
                    } else {
                        bottom_arrow_x_start += 410;                       
                    }                       
                    bottom__door_offset_counter++;                    
                }
                Turret Arrow_bottom_2 = new Turret(110,40,2890,4500, 3, 8);
                Turrets.Add(Arrow_bottom_2);   
                for(int i = 0; i < 3; i++)
                {                    
                    Turret arrow_left = new Turret(40,110,2000,left_arrow_y_start, 1, 8);
                    Turrets.Add(arrow_left);
                    if(left_door_offset_counter == 0)
                    {
                        left_arrow_y_start += 210;                       
                    } else {
                        left_arrow_y_start += 410;                       
                    }                       
                    left_door_offset_counter++;                    
                }
                Turret Arrow_left_2 = new Turret(40,110,2000,4390,1, 8);
                Turrets.Add(Arrow_left_2);
                for(int i = 0; i < 3; i++)
                {                    
                    Turret arrow_top = new Turret(110,40,top_arrow_x_start,3500, 7, 8);
                    Turrets.Add(arrow_top);
                    if(top_door_offset_counter == 0)
                    {
                        top_arrow_x_start += 210;                       
                    } else {
                        top_arrow_x_start += 410;                       
                    }                       
                    top_door_offset_counter++;                    
                }
                Turret Arrow_Top_2 = new Turret(110,40,2890,3500,7, 8);
                Turrets.Add(Arrow_Top_2);              
                for(int i = 0; i < 4; i++)
                {                    
                    Turret arrow_right = new Turret(40,110,3000,right_arrow_y_start, 5, 8);
                    Turrets.Add(arrow_right);
                    right_arrow_y_start += 210;                     
                }
                Turret Arrow_right_2 = new Turret(40,110,3000,4390, 5, 8);
                Turrets.Add(Arrow_right_2);           
        }        
    }
}

