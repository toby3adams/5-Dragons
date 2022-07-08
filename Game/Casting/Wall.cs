using System.Collections.Generic;
using System;
using System.Linq;

namespace Dragons.Game.Casting{
    public class Wall : Actor{

        private int wallNumb = 0; 
        private List<List<int>> WallVectorList = new List<List<int>>(); // creates a list for the positions of the map pieces.
        
        private List<List<int>> WallSizeList = new List<List<int>>();
        public Wall()
        {
            WallVectorList.Add(new List<int>  {200,600}); // Wall 1 // MoveTo(200, 600);          //There has got to be a better way to create the walls.
            WallSizeList.Add(new List<int>  {1000,20}); // Wall 1 // SizeTo(1000, 20);
             WallVectorList.Add(new List<int>  {220,1000}); // Wall 2 // MoveTo(220, 1000);      //This is a test. 
            WallSizeList.Add(new List<int>  {1000,20}); // Wall 2  // SizeTo(960, 20)
             WallVectorList.Add(new List<int>  {200,620}); // Wall 3 // MoveTo(200, 620);       //Left Wall
            WallSizeList.Add(new List<int>  {20,400}); // Wall 3 // SizeTo(20, 400);
             WallVectorList.Add(new List<int>  {1180,620}); // Wall 4 // MoveTo(1180, 620);    // Right Upper Wall
            WallSizeList.Add(new List<int>  {20,160}); // Wall 4 // SizeTo(20, 160);
             WallVectorList.Add(new List<int>  {1180,860}); // Wall 5 // MoveTo(1180, 860);    // Right Lower Wall
            WallSizeList.Add(new List<int>  {20,160}); // Wall 5 // SizeTo(20, 160);
             WallVectorList.Add(new List<int>  {800,20}); // Wall 6 
            WallSizeList.Add(new List<int>  {50,20}); // Wall 6
             WallVectorList.Add(new List<int>  {900,20}); // Wall 7 
            WallSizeList.Add(new List<int>  {50,20}); // Wall 7
             WallVectorList.Add(new List<int>  {10,1000}); // Wall 8 
            WallSizeList.Add(new List<int>  {1000,20}); // Wall 8 
            wallNumb = WallVectorList.Count();
        }

        public int NumberOfWalls()              // sets the amount of walls based on the initialized amount of walls. 
        {
            wallNumb = WallVectorList.Count();
            return wallNumb;
        }

        public List<int> GetWallInformation(int i) // i for iteration
        {
            List<int> Info = WallVectorList[i].Concat(WallSizeList[i]).ToList();
            return Info; // 0 -> x 1-> y 2 -> sizeX 3 -> sizeY
            // We can either create a list of coordinates or try makeing an equation to fit our positions.
        }




        //Could I initialize posisitons from here? 



    }
}
