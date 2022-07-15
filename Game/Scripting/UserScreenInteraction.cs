using System;
using Dragons.Game.Casting;
using Dragons.Game.Services;
using System.Collections.Generic;


namespace Dragons.Game.Scripting
{
    /// <summary>
    /// Steers the player left, right, up or down based on keyboard input.
    /// </summary>
    public class UserScreenInteraction : Action
    {
        private bool ExitMenu = false;
        private int  Iteration =1;
        private IKeyboardService _keyboardService;
        private IVideoService _videoService;
        
        public UserScreenInteraction(IServiceFactory serviceFactory)
        {
            _keyboardService = serviceFactory.GetKeyboardService();
            _videoService = serviceFactory.GetVideoService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
                   
            
                try
                    {
                        Camera camera = scene.GetFirstActor<Camera>("camera");
                        List<Image> floors = scene.GetAllActors<Image>("floor");

                        // detect if button is pushed.
                        if (_keyboardService.IsKeyPressed(KeyboardKey.Space))
                        {
                            ExitMenu = true;
                            
                        }
                       
                        if(ExitMenu&&Iteration==1)
                        {
                            
                     

                            bool AddToList = true; // used to Add generated Point to list in RandomPos class
                            bool DontAddToList = false; // used to indicate that point is NOT to be added to list in RandomPos class
                            
                            //Scene scene = new Scene();
                            TrapActions trap_actions = new TrapActions();

                            // Instantiate a service factory for other objects to use.
                            IServiceFactory serviceFactory = new RaylibServiceFactory();
                            Random rand = new Random();
                            // Instantiate the actors that are used in this example.
                            Label instructions = new Label();
                            instructions.Display("'w', 's', 'a', 'd' to move, j -ranged attk, k-melee attk, l-sheild");
                            instructions.MoveTo(25, 25);

                            Label status = new Label();
                            status.Display("x:-, y:-");
                            status.MoveTo(25, 55);

                            Label dragon_life = new Label();
                            dragon_life.Display("Dragon Life:-");
                            dragon_life.MoveTo(200, 55);

                            Label player_life = new Label();
                            player_life.Display("Player Life:-");
                            player_life.MoveTo(400, 55);


                            
                            Player player = new Player();
                            player.SizeTo(50, 50);
                            player.MoveTo(1480, 5000); //5250,5250 SpawnLocation
                            // player.Tint(Color.Red());
                            player.Display("Game/Assets/fighter.png");


                            RandomPos rdp = new RandomPos();
                            // params: min x value, max x value, min y value, max y value, Add to list for randomization, make number divisible by spec int.
                            // pos1            
                            rdp.GeneratePosition(465,465,2965,2965,AddToList,5); 
                            // pos 2
                            rdp.GeneratePosition(465,465,4975,4975,AddToList,5);
                            // pos 3
                            rdp.GeneratePosition(2480,2480,2965,2965,AddToList,5);
                            // pos 4
                            rdp.GeneratePosition(2480,2480,4975,4975,AddToList,5);
                            
                            rdp.ShufflePoints();
                            // water, earth, air, fire dragons added to list for randomzing of position.
                            Dragon dragon_water = new Dragon(40, 150, 12, 8, 550);
                            Point dragon_water_pos = rdp.GetPosition(); // retrieves randomized point, randomly placing dragon at one of 4 possible positions
                            dragon_water.SizeTo(100, 100);
                            dragon_water.MoveTo(dragon_water_pos.GetX(), dragon_water_pos.GetY());
                            dragon_water.Tint(Color.Blue());
                            dragon_water.Display("Game/Assets/dragon_2.png");
                            dragon_water.type = "water";

                            
                            Dragon dragon_earth = new Dragon(40, 150, 12, 8, 550);
                            Point dragon_earth_pos = rdp.GetPosition(); // retrieves randomized point, randomly placing dragon at one of 4 possible positions
                            dragon_earth.SizeTo(100, 100);
                            dragon_earth.MoveTo(dragon_earth_pos.GetX(), dragon_earth_pos.GetY());
                            dragon_earth.Tint(Color.Gray());
                            dragon_earth.Display("Game/Assets/dragon_2.png");
                            dragon_earth.type = "earth";
                            
                            Dragon dragon_air = new Dragon(40, 150, 12, 8, 550);
                            Point dragon_air_pos = rdp.GetPosition(); // retrieves randomized point, randomly placing dragon at one of 4 possible positions
                            dragon_air.SizeTo(100, 100);
                            //dragon_air.MoveTo(700, 700);
                            dragon_air.MoveTo(dragon_air_pos.GetX(), dragon_air_pos.GetY());
                            dragon_air.Tint(Color.Green());
                            dragon_air.Display("Game/Assets/dragon_2.png");
                            dragon_air.type = "air";
                            
                            Dragon dragon_fire = new Dragon(40, 150, 12, 8, 550);
                            Point dragon_fire_pos = rdp.GetPosition(); // retrieves randomized point, randomly placing dragon at one of 4 possible positions
                            dragon_fire.SizeTo(100, 100);
                            //dragon_fire.MoveTo(900, 900);
                            dragon_fire.MoveTo(dragon_fire_pos.GetX(), dragon_fire_pos.GetY());            
                            dragon_fire.Tint(Color.Orange());
                            dragon_fire.Display("Game/Assets/dragon_2.png");
                            dragon_fire.type = "fire";

                            // shadow dragon "Boss" static position
                            Dragon dragon_shadow = new Dragon(40, 150, 12, 8, 900);
                            Point dragon_shadow_pos = rdp.GeneratePosition(1400,1600,740,760,DontAddToList,5);
                            dragon_shadow.SizeTo(100, 100);
                            //dragon_shadow.MoveTo(2600, 1800);
                            dragon_shadow.MoveTo(dragon_shadow_pos.GetX(), dragon_shadow_pos.GetY());
                            dragon_shadow.Tint(Color.Purple());
                            dragon_shadow.Display("Game/Assets/dragon_2.png");
                            dragon_shadow.type = "shadow";



                            // Traps
                            BuildTraps traps = new BuildTraps();
                            traps.GenTraps();
                            List<Trap> AllTraps = traps.GetAllTraps();
                            List<Turret> AllTurrets = traps.GetTurrets();
                            List<Actor> Pits = new List<Actor>();
                            List<Actor> Lava = new List<Actor>();
                            List<Actor> ArrowTrap = new List<Actor>();
                            List<Actor> Wall_traps = new List<Actor>();
                            foreach(Image trap in AllTraps)
                            {
                                int TrapType = trap.GetTrapType();
                                trap.SizeTo(trap.GetWidth(), trap.GetHeight());
                                trap.MoveTo(trap.GetX(), trap.GetY());
                                if(TrapType == 1)
                                {
                                    trap.Tint(Color.Black());
                                    Pits.Add(trap);
                                    scene.AddActor("pit", trap);
                                }  
                                else if(TrapType == 2)              
                                {
                                    trap.Tint(Color.Yellow());
                                    Lava.Add(trap);
                                    trap.Display("Game/Assets/lava_2.png");
                                    scene.AddActor("lava", trap);                    
                                } else if(TrapType == 3)
                                {
                                    trap.Tint(Color.White());
                                    Wall_traps.Add(trap);
                                    trap.Display("Game/Assets/brick.png");
                                    scene.AddActor("wall_trap", trap);
                                }

                            }
                            foreach(Actor turret in AllTurrets)
                            {
                                turret.SizeTo(turret.GetWidth(), turret.GetHeight());
                                turret.MoveTo(turret.GetX(), turret.GetY());
                                turret.Tint(Color.Purple());
                                ArrowTrap.Add(turret);
                                scene.AddActor("ArrowTrap", turret);
                            }
                                    
                            
                            

                            

                            Wall GetNumberOfWalls = new Wall();
                            List<Wall> WallList = new List<Wall>(); // initializes a list of the walls in the program. 
                            int NumbWall = GetNumberOfWalls.wallNumb;//wall.NumberOfWalls(); need to set this to be related to the amount of wall that their are.
                            for (int i =0; i<NumbWall; i++)
                            {
                                Wall wall = new Wall(); 
                                List<int> WallInfo = wall.GetWallInformation(i);
                                int xVector = WallInfo[0];
                                int yVector = WallInfo[1];
                                int xSize = WallInfo[2];
                                int ySize = WallInfo[3];
                                wall.SizeTo(xSize,ySize);
                                wall.MoveTo(xVector,yVector);
                                // wall.Tint(Color.Gray());
                                wall.Display("Game/Assets/brick.png");
                                WallList.Add(wall);
                            }



                            TitleScreen header = new TitleScreen();
                            List<TitleScreen> HomeScreenButtons = new List<TitleScreen>();
                            int NumbHomeScreenActors = header.GetAssetNumber();//wall.NumberOfWalls(); need to set this to be related to the amount of wall that their are.
                            for (int i =0; i<NumbHomeScreenActors; i++)
                            {
                                TitleScreen titleScreen1 = new TitleScreen(); 
                                List<int> ScreenInfo = titleScreen1.ReturnHomeScreenInfo(i);
                                int xVector = ScreenInfo[0];
                                int yVector = ScreenInfo[1];
                                int xSize = ScreenInfo[2];
                                int ySize = ScreenInfo[3];

                                Console.WriteLine($"{xVector} and {yVector}"  );
                                Console.WriteLine($"{xSize} and {ySize}"  );

                                Console.WriteLine(i);
                                titleScreen1.MoveTo(xVector,yVector);
                                titleScreen1.SizeTo(xSize,ySize);
                                
                                if (i==0)
                                {
                                    
                                    header=titleScreen1;
                                    header.Tint(Color.Red());
                                    header.Display("Game/Assets/lava_2.png");
                                    Console.WriteLine(header);
                                }
                                else{
                                    titleScreen1.Tint(Color.Blue());
                                titleScreen1.Display("Game/Assets/lava_2.png");
                                    HomeScreenButtons.Add(titleScreen1);
                                    Console.WriteLine(HomeScreenButtons[i-1]);
                                }
                                
                                
                                //wall.Display("Game/Assets/brick.png");
                                
                            }





                            Floor GetNumberOfTiles = new Floor();
                            List<Floor> TileList = new List<Floor>(); // initializes a list of the walls in the program. 
                            int NumbTiles = GetNumberOfTiles.FloorNumb;//wall.NumberOfWalls(); need to set this to be related to the amount of wall that their are.
                            for (int i = 0; i<NumbTiles; i++)
                            {
                                Floor Tile = new Floor(); 
                                List<int> FloorInfo = Tile.GetFloorInformation(i);
                                int xVector = FloorInfo[0];
                                int yVector = FloorInfo[1];
                                int xSize = FloorInfo[2];
                                int ySize = FloorInfo[3];
                                Tile.SizeTo(xSize,ySize);
                                Tile.MoveTo(xVector,yVector);
                                //Tile.Tint(Color.Gray());
                                Tile.Display("Game/Assets/brick_floor.png");
                                TileList.Add(Tile);
                            }





                    scene.AddActor("camera", camera);
                    scene.AddActor("instructions", instructions);
                    scene.AddActor("status", status);
                    scene.AddActor("dragon_life", dragon_life);
                    scene.AddActor("player_life", player_life);
                    scene.AddActor("player", player);
                    scene.AddActor("dragon", dragon_water);
                    scene.AddActor("dragon", dragon_earth);
                    scene.AddActor("dragon", dragon_air);
                    scene.AddActor("dragon", dragon_shadow);
                    scene.AddActor("dragon", dragon_fire);            
                    // scene.AddActor("player_texture", player_texture);
                    foreach (Actor walled in WallList){   scene.AddActor("wall",walled);   }
                    foreach (Actor tile in TileList){   scene.AddActor("floor",tile);   }
                    foreach (Actor Button in HomeScreenButtons){   scene.AddActor("button",Button);   }
                    scene.AddActor("header", header);  



                    MovePlayerAction movePlayerAction = new MovePlayerAction();
                    scene.AddAction(Phase.Update, movePlayerAction);  
                


                    Iteration =2;
                }                               
                
            }
            catch (Exception exception)
            {
                callback.OnError("Could not StartGame.", exception);
            }       
            
        }

        public bool ReturnExitMenu()
        {
            return ExitMenu;
        }
    }
}