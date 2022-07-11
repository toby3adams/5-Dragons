using System.Collections.Generic;
using System;
using System.Linq;

namespace Dragons.Game.Casting{
    public class Floor : Actor{

        public int FloorNumb = 0; 
        private int RoomSize = 1000; // This will scale all of the structures on a map
        private int SpawnlocationX = 1000;
        private int SpawnlocationY = 3500;
        private int WallThickness = 40;


        private List<List<int>> FloorVectorList = new List<List<int>>(); // creates a list for the positions of the map pieces.
        
        private List<List<int>> FloorSizeList = new List<List<int>>();
        public Floor()
        {
            

            for (int i=0; i<=2;i++)
            {
                for(int b = 0; b<3; b++)
            {    
                CreateFloor(SpawnlocationX-RoomSize+RoomSize*i,SpawnlocationY-RoomSize+RoomSize*b);
            }
            }
            
            CreateFloor(SpawnlocationX,SpawnlocationY-RoomSize*2);

            for (int i=0; i<=1;i++)
            {
                for(int b = 0; b<1; b++)
            {    
                CreateFloor(SpawnlocationX-RoomSize/2+RoomSize*i,SpawnlocationY-RoomSize*3+RoomSize*b);
            }
            }

            for (int i=0; i<=1;i++)
            {
                for(int b = 0; b<1; b++)
            {    
                CreateFloor(SpawnlocationX-RoomSize/2+RoomSize*i,SpawnlocationY-RoomSize*3-500+RoomSize*b);
            }
            }

             
            FloorNumb = FloorVectorList.Count();
        }

        public int NumberOfTiles()              // sets the amount of walls based on the initialized amount of walls. 
        {
            FloorNumb = FloorVectorList.Count();
            return FloorNumb;
        }

        public List<int> GetFloorInformation(int i) // i for iteration
        {
            List<int> Info = FloorVectorList[i].Concat(FloorSizeList[i]).ToList();
            return Info; // 0 -> x 1-> y 2 -> sizeX 3 -> sizeY
        }

        public void CreateFloor(int Xposition,int Yposition)
        {
            FloorVectorList.Add(new List<int>{Xposition,Yposition});  //Top Wall
            FloorSizeList.Add(new List<int>  {RoomSize,RoomSize});   
        }

    }
}