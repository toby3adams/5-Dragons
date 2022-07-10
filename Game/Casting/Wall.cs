using System.Collections.Generic;
using System;
using System.Linq;

namespace Dragons.Game.Casting{
    public class Wall : Actor{

        public int wallNumb = 0; 
        private int SquareRoomSize = 400; // This will scale all of the structures on a map
        private int DoorSize = 100; // This must be a number that when subtracted from the squareRoomSize and divided by two equals a whole number.
        private int SpawnlocationX = 3000;
        private int SpawnlocationY = 3000;
        private int WallLength;
        private int DoorOffset;

        private int WallThickness = 20;


        private List<List<int>> WallVectorList = new List<List<int>>(); // creates a list for the positions of the map pieces.
        
        private List<List<int>> WallSizeList = new List<List<int>>();
        public Wall()
        {
            this.WallLength = (SquareRoomSize-DoorSize)/2;
            this.DoorOffset = WallLength+DoorSize;

            SpawnRoom();
            //2 Hallways above
            VerticalThrough(SpawnlocationX,SpawnlocationY-SquareRoomSize);
            VerticalThrough(SpawnlocationX,SpawnlocationY-2*SquareRoomSize); 

            // 2 Top Caps and 2 Bottom Caps 
            TopCap(SpawnlocationX-SquareRoomSize,SpawnlocationY+SquareRoomSize);
            TopCap(SpawnlocationX+SquareRoomSize,SpawnlocationY+SquareRoomSize);

            BottomCap(SpawnlocationX-SquareRoomSize,SpawnlocationY-SquareRoomSize);
            BottomCap(SpawnlocationX+SquareRoomSize,SpawnlocationY-SquareRoomSize);

            //Add 3 walls to block off exit. These Will be commented out.
            // WallVectorList.Add(new List<int>  {SpawnlocationX+SquareRoomSize*2,SpawnlocationY});  //Top Wall
            // WallSizeList.Add(new List<int>  {WallThickness,SquareRoomSize});  
                
            //  WallVectorList.Add(new List<int>  {SpawnlocationX-SquareRoomSize,SpawnlocationY}); 
            // WallSizeList.Add(new List<int>  {WallThickness,SquareRoomSize}); 

            //  WallVectorList.Add(new List<int>  {SpawnlocationX,SpawnlocationY+SquareRoomSize*2});//Bottom wall
            // WallSizeList.Add(new List<int>  {SquareRoomSize,WallThickness}); 

            //Final Boss Room 
            FinalBossRoom(SpawnlocationX-SquareRoomSize,SpawnlocationY-SquareRoomSize*4);

            // LeftCap(5000+SquareRoomSize,5000);
            // RightCap(5000-SquareRoomSize,5000);
            // TopCap(5000,5000+2*SquareRoomSize);
            // BottomCap(5000,5000-2*SquareRoomSize);

            //TopRightElbow(4500,5000-3*SquareRoomSize);
             
             
            //  WallVectorList.Add(new List<int>  {800,20}); // Wall 6 
            // WallSizeList.Add(new List<int>  {50,20}); // Wall 6
            //  WallVectorList.Add(new List<int>  {900,20}); // Wall 7 
            // WallSizeList.Add(new List<int>  {50,20}); // Wall 7
            //  WallVectorList.Add(new List<int>  {10,1000}); // Wall 8 
            // WallSizeList.Add(new List<int>  {1000,20}); // Wall 8 
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


        //spawn 4 doors
        //Left,Right,Up,Down Caps
        //Horizontal and Vertical Threw
        //(Bottom,Right),(Left,Top),(Top,Right) Elbows
// 500X500 Cubes  20x20 Matrix //10000/500 = 20  20x20  middle 5000,5000                                        //middle 5000,5000
        public void FinalBossRoom(int MatrixPositionX, int MatrixPositionY)
        {
            int WallLength = (SquareRoomSize*3-DoorSize)/2;
            int DoorOffset = WallLength+DoorSize;

            WallVectorList.Add(new List<int>  {MatrixPositionX,MatrixPositionY});  //Top Wall
            WallSizeList.Add(new List<int>  {SquareRoomSize*3,WallThickness});   

             WallVectorList.Add(new List<int>  {MatrixPositionX,MatrixPositionY+SquareRoomSize*2});//Bottom wall
            WallSizeList.Add(new List<int>  {WallLength,WallThickness}); 
             WallVectorList.Add(new List<int>  {MatrixPositionX+DoorOffset,MatrixPositionY+SquareRoomSize*2}); 
            WallSizeList.Add(new List<int>  {WallLength,WallThickness});


             WallVectorList.Add(new List<int>  {MatrixPositionX,MatrixPositionY});//Left Wall 
            WallSizeList.Add(new List<int>  {WallThickness,SquareRoomSize*2}); 

             WallVectorList.Add(new List<int>  {MatrixPositionX+SquareRoomSize*3,MatrixPositionY});// Right Upper Wall
            WallSizeList.Add(new List<int>  {WallThickness,SquareRoomSize*2+WallThickness}); 
        }
        public void SpawnRoom()
        {
             WallVectorList.Add(new List<int>  {SpawnlocationX,SpawnlocationY});  //Top Wall
            WallSizeList.Add(new List<int>  {WallLength,WallThickness});  
                
             WallVectorList.Add(new List<int>  {SpawnlocationX+DoorOffset,SpawnlocationY}); 
            WallSizeList.Add(new List<int>  {WallLength,WallThickness}); 

             WallVectorList.Add(new List<int>  {SpawnlocationX,SpawnlocationY+SquareRoomSize});//Bottom wall
            WallSizeList.Add(new List<int>  {WallLength,WallThickness}); 
             WallVectorList.Add(new List<int>  {SpawnlocationX+DoorOffset,SpawnlocationY+SquareRoomSize}); 
            WallSizeList.Add(new List<int>  {WallLength,WallThickness});


             WallVectorList.Add(new List<int>  {SpawnlocationX,SpawnlocationY});//Left Wall 
            WallSizeList.Add(new List<int>  {WallThickness,WallLength}); 
            WallVectorList.Add(new List<int>  {SpawnlocationX,SpawnlocationY+DoorOffset}); // LeftWall Lower
            WallSizeList.Add(new List<int>  {WallThickness,WallLength});


             WallVectorList.Add(new List<int>  {SpawnlocationX+SquareRoomSize,SpawnlocationY});// Right Upper Wall
            WallSizeList.Add(new List<int>  {WallThickness,WallLength}); 
             WallVectorList.Add(new List<int>  {SpawnlocationX+SquareRoomSize,SpawnlocationY+DoorOffset});// Right Lower Wall
            WallSizeList.Add(new List<int>  {WallThickness,WallLength+WallThickness});    
        }

        public void  LeftCap(int MatrixPositionX, int MatrixPositionY)      // test spot is 4500,5000
        {
            // Door ways are 60 x or y
             WallVectorList.Add(new List<int>  {MatrixPositionX,MatrixPositionY}); 
            WallSizeList.Add(new List<int>  {SquareRoomSize,WallThickness});  
                          //Top Left 

             WallVectorList.Add(new List<int>  {MatrixPositionX,MatrixPositionY+SquareRoomSize});//Bottom wall
            WallSizeList.Add(new List<int>  {SquareRoomSize,WallThickness});

             WallVectorList.Add(new List<int>  {MatrixPositionX,MatrixPositionY});//Left Wall // 500X500 Cubes  20x20 Matrix //10000/500 = WallThickness  20x20  middle MatrixPositionY,MatrixPositionY                                        //middle MatrixPositionY,MatrixPositionY
            WallSizeList.Add(new List<int>  {WallThickness,WallLength}); 
            WallVectorList.Add(new List<int>  {MatrixPositionX,MatrixPositionY+DoorOffset}); // LeftWall Lower
            WallSizeList.Add(new List<int>  {WallThickness,WallLength});


             WallVectorList.Add(new List<int>  {MatrixPositionX+SquareRoomSize,MatrixPositionY});// Right Upper Wall
            WallSizeList.Add(new List<int>  {WallThickness,SquareRoomSize+WallThickness}); 
        }

        public void  RightCap(int MatrixPositionX, int MatrixPositionY)
        {
            WallVectorList.Add(new List<int>  {MatrixPositionX,MatrixPositionY}); 
            WallSizeList.Add(new List<int>  {SquareRoomSize,WallThickness});  
                          //Top Left 

             WallVectorList.Add(new List<int>  {MatrixPositionX,MatrixPositionY+SquareRoomSize});//Bottom wall
            WallSizeList.Add(new List<int>  {SquareRoomSize,WallThickness}); 


             WallVectorList.Add(new List<int>  {MatrixPositionX,MatrixPositionY});//Left Wall 
            WallSizeList.Add(new List<int>  {WallThickness,SquareRoomSize}); 


             WallVectorList.Add(new List<int>  {MatrixPositionX+SquareRoomSize,MatrixPositionY});// Right Upper Wall
            WallSizeList.Add(new List<int>  {WallThickness,WallLength}); 
             WallVectorList.Add(new List<int>  {MatrixPositionX+SquareRoomSize,MatrixPositionY+DoorOffset});// Right Lower Wall
            WallSizeList.Add(new List<int>  {WallThickness,WallLength+WallThickness}); 
            
        }

        public void  TopCap(int MatrixPositionX, int MatrixPositionY)
        {
            WallVectorList.Add(new List<int>  {MatrixPositionX,MatrixPositionY}); 
            WallSizeList.Add(new List<int>  {WallLength,WallThickness});  
                          //Top Left 
             WallVectorList.Add(new List<int>  {MatrixPositionX+DoorOffset,MatrixPositionY}); 
            WallSizeList.Add(new List<int>  {WallLength,WallThickness}); 

             WallVectorList.Add(new List<int>  {MatrixPositionX,MatrixPositionY+SquareRoomSize});//Bottom wall
            WallSizeList.Add(new List<int>  {SquareRoomSize,WallThickness}); 
             

             WallVectorList.Add(new List<int>  {MatrixPositionX,MatrixPositionY});//Left Wall 
            WallSizeList.Add(new List<int>  {WallThickness,SquareRoomSize}); 
            
             WallVectorList.Add(new List<int>  {MatrixPositionX+SquareRoomSize,MatrixPositionY});// Right Upper Wall
            WallSizeList.Add(new List<int>  {WallThickness,SquareRoomSize+WallThickness}); 
        }

        public virtual void BottomCap(int MatrixPositionX, int MatrixPositionY)
        {
            WallVectorList.Add(new List<int>  {MatrixPositionX,MatrixPositionY}); 
            WallSizeList.Add(new List<int>  {SquareRoomSize,WallThickness});  
                          //Top Left 

             WallVectorList.Add(new List<int>  {MatrixPositionX,MatrixPositionY+SquareRoomSize});//Bottom wall
            WallSizeList.Add(new List<int>  {WallLength,WallThickness}); 
             WallVectorList.Add(new List<int>  {MatrixPositionX+DoorOffset,MatrixPositionY+SquareRoomSize}); //Bottom wall
            WallSizeList.Add(new List<int>  {WallLength,WallThickness});


             WallVectorList.Add(new List<int>  {MatrixPositionX,MatrixPositionY});//Left Wall // 500X500 Cubes  20x20 Matrix //10000/500 = WallThickness  20x20  middle 5000,5000                                        //middle 5000,5000
            WallSizeList.Add(new List<int>  {WallThickness,SquareRoomSize}); 


             WallVectorList.Add(new List<int>  {MatrixPositionX+SquareRoomSize,MatrixPositionY});// Right Upper Wall
            WallSizeList.Add(new List<int>  {WallThickness,SquareRoomSize+WallThickness}); 
            
        }

        public void  HorizontalThrough(int MatrixPositionX, int MatrixPositionY)
        {
            WallVectorList.Add(new List<int>  {MatrixPositionX,MatrixPositionY}); 
            WallSizeList.Add(new List<int>  {SquareRoomSize,WallThickness});  

             WallVectorList.Add(new List<int>  {MatrixPositionX,MatrixPositionY+SquareRoomSize});//Bottom wall
            WallSizeList.Add(new List<int>  {SquareRoomSize,WallThickness}); 
            


             WallVectorList.Add(new List<int>  {MatrixPositionX,MatrixPositionY});//Left Wall // 500X500 Cubes  20x20 Matrix //10000/500 = WallThickness  20x20  middle 5000,5000                                        //middle 5000,5000
            WallSizeList.Add(new List<int>  {WallThickness,WallLength}); 
            WallVectorList.Add(new List<int>  {MatrixPositionX,MatrixPositionY+DoorOffset}); // LeftWall Lower
            WallSizeList.Add(new List<int>  {WallThickness,WallLength});


             WallVectorList.Add(new List<int>  {MatrixPositionX+SquareRoomSize,MatrixPositionY});// Right Upper Wall
            WallSizeList.Add(new List<int>  {WallThickness,WallLength}); 
             WallVectorList.Add(new List<int>  {MatrixPositionX+SquareRoomSize,MatrixPositionY+DoorOffset});// Right Lower Wall
            WallSizeList.Add(new List<int>  {WallThickness,WallLength+WallThickness}); 
            
        }
        public void  VerticalThrough(int MatrixPositionX, int MatrixPositionY)
        {
            WallVectorList.Add(new List<int>  {MatrixPositionX,MatrixPositionY}); 
            WallSizeList.Add(new List<int>  {WallLength,WallThickness});  
                          //Top Left 
             WallVectorList.Add(new List<int>  {MatrixPositionX+DoorOffset,MatrixPositionY}); 
            WallSizeList.Add(new List<int>  {WallLength,WallThickness}); 

             WallVectorList.Add(new List<int>  {MatrixPositionX,MatrixPositionY+SquareRoomSize});//Bottom wall
            WallSizeList.Add(new List<int>  {WallLength,WallThickness}); 
             WallVectorList.Add(new List<int>  {MatrixPositionX+DoorOffset,MatrixPositionY+SquareRoomSize}); //Bottom wall
            WallSizeList.Add(new List<int>  {WallLength,WallThickness});


             WallVectorList.Add(new List<int>  {MatrixPositionX,MatrixPositionY});//Left Wall // 500X500 Cubes  20x20 Matrix //10000/500 = WallThickness  20x20  middle 5000,5000                                        //middle 5000,5000
            WallSizeList.Add(new List<int>  {WallThickness,SquareRoomSize}); 

             WallVectorList.Add(new List<int>  {MatrixPositionX+SquareRoomSize,MatrixPositionY});// Right Upper Wall
            WallSizeList.Add(new List<int>  {WallThickness,SquareRoomSize+WallThickness}); 
             
            
        }

        public void BottomRightElbow(int MatrixPositionX, int MatrixPositionY)
        {
            WallVectorList.Add(new List<int>  {MatrixPositionX,MatrixPositionY}); 
            WallSizeList.Add(new List<int>  {SquareRoomSize,WallThickness});  
                          //Top Left 
             WallVectorList.Add(new List<int>  {MatrixPositionX,MatrixPositionY+SquareRoomSize});//Bottom wall
            WallSizeList.Add(new List<int>  {WallLength,WallThickness}); 
             WallVectorList.Add(new List<int>  {MatrixPositionX+DoorOffset,MatrixPositionY+SquareRoomSize}); //Bottom wall
            WallSizeList.Add(new List<int>  {WallLength,WallThickness});


             WallVectorList.Add(new List<int>  {MatrixPositionX,MatrixPositionY});//Left Wall // 500X500 Cubes  20x20 Matrix //10000/500 = WallThickness  20x20  middle 5000,5000                                        //middle 5000,5000
            WallSizeList.Add(new List<int>  {WallThickness,SquareRoomSize}); 

             WallVectorList.Add(new List<int>  {MatrixPositionX+SquareRoomSize,MatrixPositionY});// Right Upper Wall
            WallSizeList.Add(new List<int>  {WallThickness,WallLength}); 
             WallVectorList.Add(new List<int>  {MatrixPositionX+SquareRoomSize,MatrixPositionY+DoorOffset});// Right Lower Wall
            WallSizeList.Add(new List<int>  {WallThickness,WallLength+WallThickness}); 

        }

        public void LeftTopElbow(int MatrixPositionX, int MatrixPositionY)
        {
            WallVectorList.Add(new List<int>  {MatrixPositionX,MatrixPositionY}); 
            WallSizeList.Add(new List<int>  {WallLength,WallThickness});  
             WallVectorList.Add(new List<int>  {MatrixPositionX+DoorOffset,MatrixPositionY}); 
            WallSizeList.Add(new List<int>  {WallLength,WallThickness}); 

             WallVectorList.Add(new List<int>  {MatrixPositionX,MatrixPositionY+SquareRoomSize});//Bottom wall
            WallSizeList.Add(new List<int>  {SquareRoomSize,WallThickness}); 

             WallVectorList.Add(new List<int>  {MatrixPositionX,MatrixPositionY});//Left Wall // 500X500 Cubes  20x20 Matrix //10000/500 = WallThickness  20x20  middle 5000,5000                                        //middle 5000,5000
            WallSizeList.Add(new List<int>  {WallThickness,WallLength}); 
            WallVectorList.Add(new List<int>  {MatrixPositionX,MatrixPositionY+DoorOffset}); // LeftWall Lower
            WallSizeList.Add(new List<int>  {WallThickness,WallLength});


             WallVectorList.Add(new List<int>  {MatrixPositionX+SquareRoomSize,MatrixPositionY});// Right Upper Wall
            WallSizeList.Add(new List<int>  {WallThickness,SquareRoomSize+WallThickness});  

        }

        public void TopRightElbow(int MatrixPositionX, int MatrixPositionY)
        {
             // Door ways are 60 x or y
             WallVectorList.Add(new List<int>  {MatrixPositionX,MatrixPositionY}); 
            WallSizeList.Add(new List<int>  {WallLength,WallThickness});  
                          //Top Left 
             WallVectorList.Add(new List<int>  {MatrixPositionX+DoorOffset,MatrixPositionY}); 
            WallSizeList.Add(new List<int>  {WallLength,WallThickness}); 

             WallVectorList.Add(new List<int>  {MatrixPositionX,MatrixPositionY+SquareRoomSize});//Bottom wall
            WallSizeList.Add(new List<int>  {SquareRoomSize,WallThickness}); 
           
             WallVectorList.Add(new List<int>  {MatrixPositionX,MatrixPositionY});//Left Wall // 500X500 Cubes  20x20 Matrix //10000/500 = WallThickness  20x20  middle 5000,5000                                        //middle 5000,5000
            WallSizeList.Add(new List<int>  {WallThickness,SquareRoomSize}); 

             WallVectorList.Add(new List<int>  {MatrixPositionX+SquareRoomSize,MatrixPositionY});// Right Upper Wall
            WallSizeList.Add(new List<int>  {WallThickness,WallLength}); 
             WallVectorList.Add(new List<int>  {MatrixPositionX+SquareRoomSize,MatrixPositionY+DoorOffset});// Right Lower Wall
            WallSizeList.Add(new List<int>  {WallThickness,WallLength+WallThickness}); 
        }


        //Could I initialize posisitons from here? 



    }
}
