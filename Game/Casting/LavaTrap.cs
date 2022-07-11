using System.Collections.Generic;
using System;
using System.Linq;

namespace Dragons.Game.Casting{
    public class Lava : Actor{

        public int LavaNumb = 0; 
        private int WallSize = 20;
        private int TileSize = 400/20; // This will scale all of the structures on a map
        private int SpawnlocationX = 1000;
        private int SpawnlocationY = 3500;

        


        private List<List<int>> LavaVectorList = new List<List<int>>(); // creates a list for the positions of the map pieces.
        
        private List<List<int>> LavaSizeList = new List<List<int>>();
        public Lava()
        {
            // keep the size of the trap perportional to the wall size. off set right wallLava by the size / 20 = x, remove x from for loop
            // goes around the Top Left Room
            // it may be easier to dispaly floor above lava so that we can fill an entire room with lava???? Collision may not work like that.
            for (int i =0; i<=17;i+=17)
            {
                for(int b =0; b<20; b++)
                {
                    CreateLava(2600+TileSize*i+WallSize,2600+TileSize*b,40,40); 
                }
            }

            LavaNumb = LavaVectorList.Count();
        }

        public int NumberOfTiles()              // sets the amount of walls based on the initialized amount of walls. 
        {
            LavaNumb = LavaVectorList.Count();
            return LavaNumb;
        }

        public List<int> GetLavaInformation(int i) // i for iteration
        {
            List<int> Info = LavaVectorList[i].Concat(LavaSizeList[i]).ToList();
            return Info; // 0 -> x 1-> y 2 -> sizeX 3 -> sizeY
        }

        public void CreateLava(int Xposition,int Yposition,int trapHeight, int trapLength)
        {
            LavaVectorList.Add(new List<int>{Xposition,Yposition});  //Top Wall
            LavaSizeList.Add(new List<int>  {trapHeight,trapLength});   
        }

    }
}