using Dragons.Game.Casting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Dragons.Game.Scripting {

    public class BuildTraps
    {
        Random rnd = new Random();
        

        int Trap_Room_Type;
        List<Trap> Traps = new List<Trap>();
        //List<Trap> Lava = new List<Trap>();

        
        public BuildTraps(){}

        public void GenTraps()
        {
            //GenTrapsRoom_1();
            GenTrapsRoom_2();
            GenTrapsRoom_3();
            GenTrapsRoom_4();
            GenTrapsRoom_5();
            GenTrapsRoom_6();
        }
        
        //  1 = Pit,   2 = Lava, 3 = mine,   4 = turret,  5 = ?
        public void GenTrapsRoom_1()
        {
            Trap_Room_Type = rnd.Next(1,3);
            if(Trap_Room_Type == 1) // Central pit, walk way, with wall traps that fire projectiles
            {
                Trap pit = new Trap(740,740,1150,3650, 1);
                Traps.Add(pit);
            }
            if(Trap_Room_Type == 2) // + shaped walk way connecting rooms. lava in each corner. Mines spawning randomly on walkway.
            {
                
            }
            if(Trap_Room_Type == 3)
            {
                
            }
        }

        public List<Trap> GetAllTraps()
        {
            return Traps;
        }
        

        public void GenTrapsRoom_2()
        {
            Trap_Room_Type = rnd.Next(1,3);
            if(Trap_Room_Type == 1) // Central pit, walk way, with wall traps that fire projectiles
            {
                Trap pit = new Trap(750,750,1150,2650, 1);
                Traps.Add(pit);
            }
            if(Trap_Room_Type == 2) // + shaped walk way connecting rooms. lava in each corner. Mines spawning randomly on walkway.
            {
                Trap Lava_upper_left = new Trap(310, 310, 1040, 2540, 2);
                Traps.Add(Lava_upper_left);
                Trap Lava_upper_right = new Trap(350, 310, 1650, 2540, 2);
                Traps.Add(Lava_upper_right);
                Trap Lava_lower_left = new Trap(310, 350, 1040, 3150, 2);
                Traps.Add(Lava_lower_left);
                Trap Lava_lower_right = new Trap(350, 350, 1650, 3150, 2);
                Traps.Add(Lava_lower_right);

            }
            if(Trap_Room_Type == 3)
            {
                
            }
        }

        public void GenTrapsRoom_3()
        {
            Trap_Room_Type = rnd.Next(1,3);
            if(Trap_Room_Type == 1) // Central pit, walk way, with wall traps that fire projectiles
            {
                Trap pit = new Trap(740,740,150,3650, 1);
                Traps.Add(pit);
            }
            if(Trap_Room_Type == 2) // + shaped walk way connecting rooms. lava in each corner. Mines spawning randomly on walkway.
            {
               Trap Lava_upper_left = new Trap(310, 310, 40, 3540, 2);
                Traps.Add(Lava_upper_left);
                Trap Lava_upper_right = new Trap(350, 310, 650, 3540, 2);
                Traps.Add(Lava_upper_right);
                Trap Lava_lower_left = new Trap(310, 350, 040, 4150, 2);
                Traps.Add(Lava_lower_left);
                Trap Lava_lower_right = new Trap(350, 350, 650, 4150, 2);
                Traps.Add(Lava_lower_right);
            }
            if(Trap_Room_Type == 3)
            {
               
            }
        }

        public void GenTrapsRoom_4()
        {
            Trap_Room_Type = rnd.Next(1,3);
            if(Trap_Room_Type == 1)// Central pit, walk way, with wall traps that fire projectiles
            {
                Trap pit = new Trap(740,740,1150,3650, 1);
                Traps.Add(pit);
            }
            if(Trap_Room_Type == 2) // + shaped walk way connecting rooms. lava in each corner. Mines spawning randomly on walkway.
            {
                Trap Lava_upper_left = new Trap(310, 310, 1040, 3540, 2);
                Traps.Add(Lava_upper_left);
                Trap Lava_upper_right = new Trap(350, 310, 1650, 3540, 2);
                Traps.Add(Lava_upper_right);
                Trap Lava_lower_left = new Trap(310, 350, 1040, 4150, 2);
                Traps.Add(Lava_lower_left);
                Trap Lava_lower_right = new Trap(350, 350, 1650, 4150, 2);
                Traps.Add(Lava_lower_right);
            }
            if(Trap_Room_Type == 3)
            {
                
            }
        }

        public void GenTrapsRoom_5()
        {
            Trap_Room_Type = rnd.Next(1,3);
            if(Trap_Room_Type == 1)// Central pit, walk way, with wall traps that fire projectiles
            {
                Trap pit = new Trap(740,740,2150,3650, 1);
                Traps.Add(pit);
            }
            if(Trap_Room_Type == 2) // + shaped walk way connecting rooms. lava in each corner. Mines spawning randomly on walkway.
            {
                Trap Lava_upper_left = new Trap(310, 310, 2040, 3540, 2);
                Traps.Add(Lava_upper_left);
                Trap Lava_upper_right = new Trap(350, 310, 2650, 3540, 2);
                Traps.Add(Lava_upper_right);
                Trap Lava_lower_left = new Trap(310, 350, 2040, 4150, 2);
                Traps.Add(Lava_lower_left);
                Trap Lava_lower_right = new Trap(350, 350, 2650, 4150, 2);
                Traps.Add(Lava_lower_right);
            }
            if(Trap_Room_Type == 3)
            {
                
            }
        }

        public void GenTrapsRoom_6()
        {
            Trap_Room_Type = rnd.Next(1,3);
            if(Trap_Room_Type == 1)// Central pit, walk way, with wall traps that fire projectiles
            {
                Trap pit = new Trap(740,740,1150,4650, 1);
                Traps.Add(pit);
            }
            if(Trap_Room_Type == 2) // + shaped walk way connecting rooms. lava in each corner. Mines spawning randomly on walkway.
            {
                Trap Lava_upper_left = new Trap(310, 310, 1040, 4540, 2);
                Traps.Add(Lava_upper_left);
                Trap Lava_upper_right = new Trap(350, 310, 1650, 4540, 2);
                Traps.Add(Lava_upper_right);
                Trap Lava_lower_left = new Trap(310, 350, 1040, 5150, 2);
                Traps.Add(Lava_lower_left);
                Trap Lava_lower_right = new Trap(350, 350, 1650, 5150, 2);
                Traps.Add(Lava_lower_right);
            }
            if(Trap_Room_Type == 3)
            {
                
            }
        }
    }  
}
