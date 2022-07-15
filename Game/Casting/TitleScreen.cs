using System.Collections.Generic;
using System;
using System.Linq;

namespace Dragons.Game.Casting{
    public class TitleScreen : Image{

        private int screenAssetNumber=0;
        private int ButtonSizeX=100;
        private int ButtonSizeY=100;
        // private int ButtonPositionX=0;
        // private int ButtonPositionY=0;

        private int HeaderSizeX=100;
        private int HeaderSizeY=100;

        private int HeaderPositionX=200;
        private int HeaderPositionY=200;
        private List<List<int>> HomeScreenActorDimensions= new List<List<int>>();
        private List<List<int>> HomeScreenActorPositions= new List<List<int>>();

        private int ScreenActorNumb =0;

        //Allign the middle of the Header to be in the middle of the camera.
        public TitleScreen()
        {   //Header will always be the starting position on the list for the HomeScreen.
            CreateHeader();
            CreateStartmenuButtons(400,400);
            CreateStartmenuButtons(600,200);
        }

        private void CreateHeader()
        {   //X Variable are position 0 and Y variables are position 1
            HomeScreenActorDimensions.Add(new List<int>  {HeaderSizeX,HeaderSizeY}); 
            HomeScreenActorPositions.Add(new List<int>  {HeaderPositionX,HeaderPositionY}); 
        }

        private void CreateStartmenuButtons(int ButtonPositionX,int ButtonPositionY)
        {

            //#0 1 is Easy #2 is Hard 
             HomeScreenActorDimensions.Add(new List<int>  {ButtonSizeX,ButtonSizeY}); 
            HomeScreenActorPositions.Add(new List<int>  {ButtonPositionX,ButtonPositionY});  
        }

        private void StartMenuBackGround()
        {

        }

        public int GetAssetNumber()
        {
            screenAssetNumber = HomeScreenActorPositions.Count();
            return screenAssetNumber;
        }

        public List<int> ReturnHomeScreenInfo(int i)
        {
            List<int> Info = HomeScreenActorPositions[i].Concat(HomeScreenActorDimensions[i]).ToList();
            return Info; // 0 -> x 1-> y 2 -> sizeX 3 -> sizeY
        }


    }
}