using System.Collections.Generic;
using System;
using System.Linq;

namespace Dragons.Game.Casting{
    public class Trap : Image
    {

        private int TrapType;
        private float Height;
        private float Width;
        private int x;
        private int y;
        private int damage;

        // constructor takes Pit Height, width, x position, and y position
        
        public Trap(int Width, int Height, int x, int y, int TrapType){
            this.Height = Height;
            this.Width = Width;
            this.x = x;
            this.y = y;
            this.TrapType = TrapType;
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