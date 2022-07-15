using System.Collections.Generic;
using System;
using System.Linq;

namespace Dragons.Game.Casting{
    public class Trap : Wall
    {

        private int TrapType;
        private float Height;
        private float Width;
        private int x;
        private int y;
        private int damage;
        private int Room;

        // constructor takes Pit Height, width, x position, and y position
        
        public Trap(int Width, int Height, int x, int y, int TrapType, int Room){
            this.Height = Height;
            this.Width = Width;
            this.x = x;
            this.y = y;
            this.TrapType = TrapType;
            this.Room = Room;
        } 

        public override float GetHeight()
        {
            return Height;
        }

        public override float GetWidth()
        {
            return Width;
        }

        public override int GetX()
        {
            return x;
        }

        public override int GetY()
        {
            return y;
        }
        public void IncWidth(int growth_index)
        {
            for(int i = 0; i < growth_index; i++)
            {
                Width++;
            }
            
        }

        public void IncHeight(int growth_index)
        {
            for(int i = 0; i < growth_index; i++)
            {
                Height++;
            }
            
        }
        public void DecWidth(int shrink_index)
        {
            for(int i = 0; i < shrink_index; i++)
            {
                Width -= 1;
            }
            
        }

        public void DecHeight(int shrink_index)
        {
            for(int i = 0; i < shrink_index; i++)
            {
                Height -= 1;
            }
            
        }
        public int GetRoom()
        {
            return Room;
        }
        public void IncX(int growth_interval, int growth_rate)
        {
            for(int i = 0; i < growth_interval; i++)
            {
                x+=growth_rate;
            }
            
        }
        public void IncY(int growth_interval, int growth_rate)
        {
            for(int i = 0; i < growth_interval; i++)
            {
                y+=growth_rate;
            }
            
        }
        public void DecX(int shrink_interval, int shrink_rate)
        {
            for(int i = 0; i < shrink_interval; i++)
            {
               x -= shrink_rate;
            }
            
        }
        public void DecY(int shrink_interval, int shrink_rate)
        {
             for(int i = 0; i < shrink_interval; i++)
            {
               y -= shrink_rate;
            }
        }

        public  override int GetTrapType()
        {
            return TrapType;
        }

        


        // public void LavaTrap(int Xposition,int Yposition) // This is just Lava on the floor
        // {
        //     TrapVectorList.Add(new List<int>  {Xposition,Yposition});  //Top Wall
        //     TrapSizeList.Add(new List<int>  {200,100});   

        // }

        // public void BearTrap()
        // {

        // }

        // public void ArrowTrap()
        // {
            
        // }

    }
}