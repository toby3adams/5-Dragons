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
        
        private int max_x;
        private int max_y;
        private int rand_dimension;
        private int rand_x;
        private int rand_y;
        int Trap_Room_Type;
        List<Trap> Traps = new List<Trap>();
        List<Turret> Turrets = new List<Turret>();
        //List<Trap> Lava = new List<Trap>();

        
        public BuildTraps(){}

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
            //GenTrapsRoom_1();
           // GenTrapsRoom_2();
            //GenTrapsRoom_3();
            GenTrapsRoom_4();
            //GenTrapsRoom_5();
            //GenTrapsRoom_6();
        }
        
        //  1 = Pit,   2 = Lava, 3 = mine,   4 = turret,  5 = ?
        public void GenTrapsRoom_1()
        {
            Trap_Room_Type = rnd.Next(1,3);
            if(Trap_Room_Type == 1) // Central pit, walk way, with wall traps that fire projectiles
            {
                Trap pit = new Trap(740,740,1150,3650, 1, 0);
                Traps.Add(pit);
            }
            if(Trap_Room_Type == 2) // + shaped walk way connecting rooms. lava in each corner. Mines spawning randomly on walkway.
            {
                
            }
            if(Trap_Room_Type == 3)
            {
                
            }
        }    
        

        public void GenTrapsRoom_2()
        {
            Trap_Room_Type = rnd.Next(1,1);
            int bottom_arrow_x_start = 1040;
            int left_arrow_y_start = 2540;
            int right_arrow_y_start = 2540;
            int top_arrow_x_start = 1040;
            int top_door_offset_counter = 0;
            //int left_door_offset_counter = 0; unused in this room
            //int right_door_offset_counter = 0; unused in this room
            int bottom__door_offset_counter = 0;
            if(Trap_Room_Type == 1) // Central pit, walk way, with wall traps that fire projectiles
            {
                //Trap pit = new Trap(750,750,1150,2650, 1, 4);
                //Traps.Add(pit);
                Trap Lava_upper_left = new Trap(280, 280, 1380, 2880, 2, 4);
                Traps.Add(Lava_upper_left);
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
                // left arrow traps             
                
                for(int i = 0; i < 4; i++)
                {                    
                    Turret arrow_left = new Turret(40,110,1000,left_arrow_y_start, 1, 4);
                    Turrets.Add(arrow_left);                    
                    left_arrow_y_start += 210;                     
                }
                Turret Arrow_left_2 = new Turret(40,110,1000,3390,1, 4);
                Turrets.Add(Arrow_left_2);
                // top arrow trap
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
                //right arrow traps
                
                 for(int i = 0; i < 4; i++)
                {                    
                    Turret arrow_right = new Turret(40,110,2000,right_arrow_y_start, 5, 4);
                    Turrets.Add(arrow_right);                    
                    right_arrow_y_start += 210;                       
                 }
                Turret Arrow_right_2 = new Turret(40,110,2000,3390, 5, 4);
                Turrets.Add(Arrow_right_2);
            }
            if(Trap_Room_Type == 2) // + shaped walk way connecting rooms. lava in each corner. Mines spawning randomly on walkway.
            {
                Trap Lava_upper_left = new Trap(310, 310, 1040, 2540, 2, 4);
                Traps.Add(Lava_upper_left);
               /* Trap Lava_upper_right = new Trap(350, 310, 1650, 2540, 2, 4);
                Traps.Add(Lava_upper_right);
                Trap Lava_lower_left = new Trap(310, 350, 1040, 3150, 2, 4);
                Traps.Add(Lava_lower_left);
                Trap Lava_lower_right = new Trap(350, 350, 1650, 3150, 2, 4);
                Traps.Add(Lava_lower_right);*/

            }
            if(Trap_Room_Type == 3)
            {
                
            }
        }

        public void GenTrapsRoom_3()
        {
            Trap_Room_Type = rnd.Next(1,1);
            int bottom_arrow_x_start = 40;
            int left_arrow_y_start = 3540;
            int right_arrow_y_start = 3540;
            int top_arrow_x_start = 40;
            int top_door_offset_counter = 0;
            //int left_door_offset_counter = 0;    unused in room 3
            int right_door_offset_counter = 0;
            int bottom__door_offset_counter = 0;            
            if(Trap_Room_Type == 1) // Central pit, walk way, with wall traps that fire projectiles
            {
                /*Trap pit = new Trap(740,740,150,3650, 1, 2);
                Traps.Add(pit);*/
                Trap Lava_upper_left = new Trap(280, 280, 380, 3880, 2, 2);
                Traps.Add(Lava_upper_left);
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
                // left arrow traps             
                
                for(int i = 0; i < 4; i++)
                {                    
                    Turret arrow_left = new Turret(40,110,0,left_arrow_y_start, 1, 2);
                    Turrets.Add(arrow_left);
                    left_arrow_y_start += 210;                   
                }
                Turret Arrow_left_2 = new Turret(40,110,0,4390,1, 2);
                Turrets.Add(Arrow_left_2);
                // top arrow trap
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
                //right arrow traps
                
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
            if(Trap_Room_Type == 2) // + shaped walk way connecting rooms. lava in each corner. Mines spawning randomly on walkway.
            {
                Trap Lava_upper_left = new Trap(310, 310, 40, 3540, 2, 2);
                Traps.Add(Lava_upper_left);
                /*Trap Lava_upper_right = new Trap(350, 310, 650, 3540, 2, 2);
                Traps.Add(Lava_upper_right);
                Trap Lava_lower_left = new Trap(310, 350, 040, 4150, 2, 2);
                Traps.Add(Lava_lower_left);
                Trap Lava_lower_right = new Trap(350, 350, 650, 4150, 2, 2);
                Traps.Add(Lava_lower_right);*/
            }
            if(Trap_Room_Type == 3)
            {
               
            }
        }

        public void GenTrapsRoom_4()
        {
            Trap_Room_Type = rnd.Next(2,2);
            int bottom_arrow_x_start = 1040;
            int left_arrow_y_start = 3540;
            int right_arrow_y_start = 3540;
            int top_arrow_x_start = 1040;
            int top_door_offset_counter = 0;
            int left_door_offset_counter = 0;
            int right_door_offset_counter = 0;
            int bottom__door_offset_counter = 0;
            if(Trap_Room_Type == 1)// Central pit, walk way, with wall traps that fire projectiles
            {
                //Trap pit = new Trap(740,740,1150,3650, 1);
                //Traps.Add(pit);
                Trap Lava_upper_left = new Trap(280, 280, 1380, 3880, 2, 5);
                Traps.Add(Lava_upper_left);
                //Trap Lava_upper_left = new Trap(320, 320, 1040, 3540, 2, 5);
                //Traps.Add(Lava_upper_left);
                /*Trap Lava_upper_right = new Trap(350, 310, 1650, 3540, 2, 5);
                Traps.Add(Lava_upper_right);
                Trap Lava_lower_left = new Trap(310, 350, 1040, 4150, 2, 5);
                Traps.Add(Lava_lower_left);
                Trap Lava_lower_right = new Trap(350, 350, 1650, 4150, 2, 5);
                Traps.Add(Lava_lower_right);*/
                    // Lava
                    //Quadrant 1
                
                // Wall fire ball turrets
                for(int i = 0; i < 3; i++)
                {                    
                    Turret arrow_bottom = new Turret(110,40,bottom_arrow_x_start,4500, 3, 5);
                    Turrets.Add(arrow_bottom);
                    if(bottom__door_offset_counter == 0)
                    {
                        bottom_arrow_x_start += 210;                       
                    } else {
                        bottom_arrow_x_start += 410;                       
                    }                       
                    bottom__door_offset_counter++;                    
                }
                Turret Arrow_bottom_2 = new Turret(110,40,1890,4500, 3, 5);
                Turrets.Add(Arrow_bottom_2);   
                // left arrow traps             
                
                for(int i = 0; i < 3; i++)
                {                    
                    Turret arrow_left = new Turret(40,110,1000,left_arrow_y_start, 1, 5);
                    Turrets.Add(arrow_left);
                    if(left_door_offset_counter == 0)
                    {
                        left_arrow_y_start += 210;                       
                    } else {
                        left_arrow_y_start += 410;                       
                    }                       
                    left_door_offset_counter++;                    
                }
                Turret Arrow_left_2 = new Turret(40,110,1000,4390,1, 5);
                Turrets.Add(Arrow_left_2);
                // top arrow trap
                for(int i = 0; i < 3; i++)
                {                    
                    Turret arrow_top = new Turret(110,40,top_arrow_x_start,3500, 7, 5);
                    Turrets.Add(arrow_top);
                    if(top_door_offset_counter == 0)
                    {
                        top_arrow_x_start += 210;                       
                    } else {
                        top_arrow_x_start += 410;                       
                    }                       
                    top_door_offset_counter++;                    
                }
                Turret Arrow_Top_2 = new Turret(110,40,1890,3500,7, 5);
                Turrets.Add(Arrow_Top_2);              
                //right arrow traps
                
                 for(int i = 0; i < 3; i++)
                {                    
                    Turret arrow_right = new Turret(40,110,2000,right_arrow_y_start, 5, 5);
                    Turrets.Add(arrow_right);
                    if(right_door_offset_counter == 0)
                    {
                        right_arrow_y_start += 210;                       
                    } else {
                        right_arrow_y_start += 410;                       
                    }                       
                    right_door_offset_counter++;                    
                }
                Turret Arrow_right_2 = new Turret(40,110,2000,4390, 5, 5);
                Turrets.Add(Arrow_right_2);
            }
            if(Trap_Room_Type == 2) // + shaped walk way connecting rooms. lava in each corner. Mines spawning randomly on walkway.
            {
                int coord_shift_index = 0;
                int wall_trap_x = 1040;
                int wall_trap_y = 3540;
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
            if(Trap_Room_Type == 3)
            {
                
            }
        }

        public void GenTrapsRoom_5()
        {
            Trap_Room_Type = rnd.Next(1,1);
            int bottom_arrow_x_start = 2040;
            int left_arrow_y_start = 3540;
            int right_arrow_y_start = 3540;
            int top_arrow_x_start = 2040;
            int top_door_offset_counter = 0;
            int left_door_offset_counter = 0;
            //int right_door_offset_counter = 0; unused in this room
            int bottom__door_offset_counter = 0;
            if(Trap_Room_Type == 1)// Central pit, walk way, with wall traps that fire projectiles
            {
                /*Trap pit = new Trap(740,740,2150,3650, 1, 8);
                Traps.Add(pit);*/
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
                // left arrow traps             
                
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
                // top arrow trap
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
                //right arrow traps
                
                 for(int i = 0; i < 4; i++)
                {                    
                    Turret arrow_right = new Turret(40,110,3000,right_arrow_y_start, 5, 8);
                    Turrets.Add(arrow_right);
                    right_arrow_y_start += 210;                     
                }
                Turret Arrow_right_2 = new Turret(40,110,3000,4390, 5, 8);
                Turrets.Add(Arrow_right_2);
            }
            if(Trap_Room_Type == 2) // + shaped walk way connecting rooms. lava in each corner. Mines spawning randomly on walkway.
            {
                Trap Lava_upper_left = new Trap(280, 280, 2040, 3540, 2, 8);
                Traps.Add(Lava_upper_left);
                /*Trap Lava_upper_right = new Trap(350, 310, 2650, 3540, 2, 8);
                Traps.Add(Lava_upper_right);
                Trap Lava_lower_left = new Trap(310, 350, 2040, 4150, 2, 8);
                Traps.Add(Lava_lower_left);
                Trap Lava_lower_right = new Trap(350, 350, 2650, 4150, 2, 8);
                Traps.Add(Lava_lower_right);*/
            }
            if(Trap_Room_Type == 3)
            {
                
            }
        }

        public void GenTrapsRoom_6()
        {
            Trap_Room_Type = rnd.Next(1,1);
            if(Trap_Room_Type == 1)// Central pit, walk way, with wall traps that fire projectiles
            {
                int bottom_arrow_x_start = 1040;
                int left_arrow_y_start = 4540;
                int right_arrow_y_start = 4540;
                int top_arrow_x_start = 1040;
                int top_arrow_counter = 0;
                //Trap pit = new Trap(740,740,1150,4650, 1);
                //Traps.Add(pit);  
                Trap Lava_upper_left = new Trap(280, 280, 1040, 4540, 2, 6);
                Traps.Add(Lava_upper_left);
                /*Trap Lava_upper_right = new Trap(350, 310, 1650, 4540, 2, 6);
                Traps.Add(Lava_upper_right);
                Trap Lava_lower_left = new Trap(310, 350, 1040, 5150, 2, 6);
                Traps.Add(Lava_lower_left);
                Trap Lava_lower_right = new Trap(350, 350, 1650, 5150, 2, 6);
                Traps.Add(Lava_lower_right);*/
                //Trap arrow_bottom = new Trap(110,40,bottom_arrow_x_start,5500, 1); // 1 = positive verticle projectile
                //Traps.Add(arrow_bottom);              
                for(int i = 0; i < 4; i++)
                {
                    Turret arrow_bottom = new Turret(110,40,bottom_arrow_x_start,5500, 1, 6); // 1 = positive verticle projectile
                    Turrets.Add(arrow_bottom);
                    bottom_arrow_x_start += 210;
                }
                Turret Arrow_bottom_2 = new Turret(110,40,1890,5500, 3, 6);
                Turrets.Add(Arrow_bottom_2);                
                for(int i = 0; i < 4; i++)
                {
                    Turret arrow_left = new Turret(40,110,1000,left_arrow_y_start, 1, 6); // 2 = positive horizontal projectile
                    Turrets.Add(arrow_left);
                    left_arrow_y_start += 210;
                }
                Turret Arrow_left_2 = new Turret(40,110,1000,5390, 1, 6);
                Turrets.Add(Arrow_left_2);
                for(int i = 0; i < 3; i++)
                {                    
                    Turret arrow_top = new Turret(110,40,top_arrow_x_start,4500, 7, 6); // 3 = negative vertical projectile
                    Turrets.Add(arrow_top);
                    if(top_arrow_counter == 0)
                    {
                        top_arrow_x_start += 210;                       
                    } else {
                        top_arrow_x_start += 410;                       
                    }                       
                    top_arrow_counter++;                    
                }
                Turret Arrow_Top_2 = new Turret(110,40,1890,4500,7, 6);
                Turrets.Add(Arrow_Top_2);              
                for(int i = 0; i < 4; i++)
                {
                    Turret arrow_right = new Turret(40,110,2000,right_arrow_y_start, 5, 6); // negative horizontal projectile
                    Turrets.Add(arrow_right);
                    right_arrow_y_start += 210;
                }
                Turret Arrow_right_2 = new Turret(40,110,2000,5390, 5, 6);
                Turrets.Add(Arrow_right_2);
            }
            if(Trap_Room_Type == 2) // + shaped walk way connecting rooms. lava in each corner. Mines spawning randomly on walkway.
            {
                Trap Lava_upper_left = new Trap(310, 310, 1040, 4540, 2, 6);
                Traps.Add(Lava_upper_left);
                Trap Lava_upper_right = new Trap(350, 310, 1650, 4540, 2, 6);
                Traps.Add(Lava_upper_right);
                Trap Lava_lower_left = new Trap(310, 350, 1040, 5150, 2, 6);
                Traps.Add(Lava_lower_left);
                Trap Lava_lower_right = new Trap(350, 350, 1650, 5150, 2, 6);
                Traps.Add(Lava_lower_right);
                
            }
            if(Trap_Room_Type == 3)
            {
                
            }
        }
    }
    /*code for randomly placing lava in room
for(int i = 0; i < 10; i++)
                {   
                     max_x = 1450;
                     max_y = 3950;
                    int rand_dimension = rnd.Next(50,200);
                    int rand_x = rnd.Next(1100,1450);
                    if(rand_dimension + rand_x > max_x)
                    {
                        rand_x = rand_x - rand_dimension;
                    }                    
                    int rand_y = rnd.Next(3600,3950);
                    if(rand_dimension + rand_y > max_y)
                    {
                        rand_y = rand_y - rand_dimension;
                    }
                    Trap Lava = new Trap(rand_dimension, rand_dimension, rand_x, rand_y, 2);
                    Traps.Add(Lava);
                }
                //Quadrant 2
                for(int i = 0; i < 10; i++)
                {   
                     max_x = 1950;
                     max_y = 3950;
                     rand_dimension = rnd.Next(50,200);
                     rand_x = rnd.Next(1550,1950);
                    if(rand_dimension + rand_x > max_x)
                    {
                        rand_x = rand_x - rand_dimension;
                    }                    
                     rand_y = rnd.Next(3600,3950);
                    if(rand_dimension + rand_y > max_y)
                    {
                        rand_y = rand_y - rand_dimension;
                    }
                    Trap Lava2 = new Trap(rand_dimension, rand_dimension, rand_x, rand_y, 2);
                    Traps.Add(Lava2);
                }
                //Quardrant 3
                for(int i = 0; i < 10; i++)
                {   
                     max_x = 1450;
                     max_y = 3950;
                     rand_dimension = rnd.Next(50,200);
                     rand_x = rnd.Next(1100,1450);
                    if(rand_dimension + rand_x > max_x)
                    {
                        rand_x = rand_x - rand_dimension;
                    }                    
                     rand_y = rnd.Next(4050,4450);
                    if(rand_dimension + rand_y > max_y)
                    {
                        rand_y = rand_y - rand_dimension;
                    }
                    Trap Lava3 = new Trap(rand_dimension, rand_dimension, rand_x, rand_y, 2);
                    Traps.Add(Lava3);
                }
                //Quadrant 4
                for(int i = 0; i < 10; i++)
                {   
                     max_x = 1950;
                     max_y = 4450;
                     rand_dimension = rnd.Next(50,200);
                     rand_x = rnd.Next(1550,1950);
                    if(rand_dimension + rand_x > max_x)
                    {
                        rand_x = rand_x - rand_dimension;
                    }                    
                     rand_y = rnd.Next(4050,4450);
                    if(rand_dimension + rand_y > max_y)
                    {
                        rand_y = rand_y - rand_dimension;
                    }
                    Trap Lava4 = new Trap(rand_dimension, rand_dimension, rand_x, rand_y, 2);
                    Traps.Add(Lava4);
                }*/ 
    
}

