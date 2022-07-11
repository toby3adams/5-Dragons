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
        List<Actor> Traps = new List<Actor>();
        public BuildTraps(){}

        public void GenTraps()
        {
            //GenTrapsRoom_1();
            // GenTrapsRoom_2();
            //GenTrapsRoom_3();
            GenTrapsRoom_4();
            //GenTrapsRoom_5();
            //GenTrapsRoom_6();
        }

        public void GenTrapsRoom_4()
        {
            Trap_Room_Type = rnd.Next(1,3);
            if(Trap_Room_Type == 1) // Central pit, walk way, with wall traps that fire projectiles
            {
                Pit pit = new Pit(760,760,1120,3320);
                Traps.Add(pit);
            }
            if(Trap_Room_Type == 2) // + shaped walk way connecting rooms. lava in each corner. Mines spawning randomly on walkway.
            {
                Pit pit = new Pit(760,760,1120,3320);
                Traps.Add(pit);
            }
            if(Trap_Room_Type == 3)
            {
                Pit pit = new Pit(760,760,1120,3320);
                Traps.Add(pit);
            }
        }

        public List<Actor> GetAllTraps()
        {
            return Traps;
        }

       /* public void GenTrapsRoom_2()
        {
            Trap_Room_Type = rnd.Next(1,3);
            if(Trap_Room_Type == 1) // Central pit, walk way, with wall traps that fire projectiles
            {

            }
            if(Trap_Room_Type == 2) // + shaped walk way connecting rooms. lava in each corner. Mines spawning randomly on walkway.
            {

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

            }
            if(Trap_Room_Type == 2) // + shaped walk way connecting rooms. lava in each corner. Mines spawning randomly on walkway.
            {

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

            }
            if(Trap_Room_Type == 2) // + shaped walk way connecting rooms. lava in each corner. Mines spawning randomly on walkway.
            {

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

            }
            if(Trap_Room_Type == 2) // + shaped walk way connecting rooms. lava in each corner. Mines spawning randomly on walkway.
            {

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
            {

            }
            if(Trap_Room_Type == 2)// + shaped walk way connecting rooms. lava in each corner. Mines spawning randomly on walkway.
            {

            }
            if(Trap_Room_Type == 3)
            {
                
            }
            }
        } */  
    }
}