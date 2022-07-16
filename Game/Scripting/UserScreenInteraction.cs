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

                        if (_keyboardService.IsKeyPressed(KeyboardKey.Enter)){
                            Image button = scene.GetFirstActor<Image>("button");
                            button.Display("Game/Assets/easy_out_of_order_button.png");
                        }

                        // detect if button is pushed.
                        if (_keyboardService.IsKeyPressed(KeyboardKey.Space))
                        {
                            ExitMenu = true;
                            
                        }
                       
                        if(ExitMenu&&Iteration==1)
                        {
                            
                            Actor header = scene.GetFirstActor<Actor>("header");
                            scene.RemoveActor("header", header);
                            Actor stBack = scene.GetFirstActor<Actor>("stback");
                            scene.RemoveActor("stback", stBack);
                            List<Actor> buttons = scene.GetAllActors<Actor>("button");
                            foreach(Actor button in buttons)
                            {
                               scene.RemoveActor("button", button); 
                            }  



                            bool AddToList = true; // used to Add generated Point to list in RandomPos class
                            bool DontAddToList = false; // used to indicate that point is NOT to be added to list in RandomPos class
                            
                            //Scene scene = new Scene();
                            TrapActions trap_actions = new TrapActions();

                            // Instantiate a service factory for other objects to use.
                            IServiceFactory serviceFactory = new RaylibServiceFactory();
                            Random rand = new Random();
                            // Instantiate the actors that are used in this example.
                            Label instructions = new Label();
                            instructions.Display("'W', 'A', 'S', 'D' to move, 'J' - ranged attack, 'K' - melee attack, 'L' - shield");
                            instructions.MoveTo(1100, 4700);

                            Label instructions_2 = new Label();
                            instructions_2.Display("Defeat the Shadow dragon to win. Defeating each of the lesser dragons unlocks\ngreater power for the player.\n        - Bow\n         - Sword\n      - Armor\n      - Shield");
                            instructions_2.MoveTo(1100, 4800);

                            Image instructions_3 = new Image();
                            instructions_3.Display("Game/Assets/warning_sign.png");
                            instructions_3.MoveTo(1350, 4900);
                            instructions_3.SizeTo(300,75);

                            Image green = new Image();
                            green.Display("Game/Assets/green_word.png");
                            green.MoveTo(1095,4850);
                            green.SizeTo(55,25);

                            Image orange = new Image();
                            orange.Display("Game/Assets/orange_word.png");
                            orange.MoveTo(1095,4877);
                            orange.SizeTo(65,25);

                            Image blue = new Image();
                            blue.Display("Game/Assets/blue_word.png");
                            blue.MoveTo(1095,4905);
                            blue.SizeTo(55,25);

                            Image gray = new Image();
                            gray.Display("Game/Assets/gray_word.png");
                            gray.MoveTo(1095,4930);
                            gray.SizeTo(55,25);
                            


                            // Label status = new Label();
                            // status.Display("x:-, y:-");
                            // status.MoveTo(25, 55);

                            Label dragon_life = new Label();
                            dragon_life.Display("Dragon Life:-");
                            dragon_life.MoveTo(25, 25);

                            Label player_life = new Label();
                            player_life.Display("Player Life:-");
                            player_life.MoveTo(225, 25);

                            

                            

                            
                            
                            // Player player = new Player();
                            // player.SizeTo(50, 50);
                            // player.MoveTo(1480, 5000); //5250,5250 SpawnLocation
                            // // player.Tint(Color.Red());
                            // player.Display("Game/Assets/fighter.png");


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
                            Point dragon_shadow_pos = rdp.GeneratePosition(1480,1480,750,750,DontAddToList,5);
                            dragon_shadow.SizeTo(100, 100);
                            //dragon_shadow.MoveTo(2600, 1800);
                            dragon_shadow.MoveTo(dragon_shadow_pos.GetX(), dragon_shadow_pos.GetY());
                            dragon_shadow.Tint(Color.Purple());
                            dragon_shadow.Display("Game/Assets/dragon_2.png");
                            dragon_shadow.type = "shadow";



                            // Traps
                            BuildTraps traps = new BuildTraps(scene);
                            traps.GenTraps();
                            List<Trap> AllTraps = traps.GetAllTraps();
                            List<Turret> AllTurrets = traps.GetTurrets();
                            List<Actor> Pits = new List<Actor>();
                            List<Actor> Lava = new List<Actor>();
                            List<Actor> ArrowTrap = new List<Actor>();
                            List<Actor> Wall_traps = new List<Actor>();
                            List<Actor> invis_doors = new List<Actor>();
                            foreach(Image trap in AllTraps)
                            {
                                int TrapType = trap.GetTrapType();
                                trap.SizeTo(trap.GetWidth(), trap.GetHeight());
                                trap.MoveTo(trap.GetX(), trap.GetY());
                                if(TrapType == 1)
                                {
                                    
                                    trap.Tint(Color.Black());
                                    Pits.Add(trap);
                                    trap.Display("Game/Assets/lava_2.png");
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
                                    trap.Tint(Color.Gray());
                                    Wall_traps.Add(trap);
                                    trap.Display("Game/Assets/brick.png");
                                    scene.AddActor("block_trap", trap);
                                } 
                                else if(TrapType == 4)
                                {
                                    trap.Tint(Color.Gray());
                                    Wall_traps.Add(trap);
                                    trap.Display("Game/Assets/brick.png");
                                    scene.AddActor("stationary_block_trap", trap);
                                } else if(TrapType == 0)
                                {
                                    invis_doors.Add(trap);
                                    trap.Tint(Color.White());
                                    //trap.Display("Game/Assets/brick.png");
                                    scene.AddActor("invis_doors", trap);
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
                                wall.Tint(Color.Gray());
                                wall.SizeTo(xSize,ySize);
                                wall.MoveTo(xVector,yVector);
                                // wall.Tint(Color.Gray());
                                wall.Display("Game/Assets/brick.png");
                                WallList.Add(wall);
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
                    scene.AddActor("instructions", instructions_2);
                    scene.AddActor("blood_splatter", instructions_3);
                    scene.AddActor("blood_splatter", green);
                    scene.AddActor("blood_splatter", orange);
                    scene.AddActor("blood_splatter", blue);
                    scene.AddActor("blood_splatter", gray);
                    // scene.AddActor("status", status);
                    scene.AddActor("dragon_life", dragon_life);
                    scene.AddActor("player_life", player_life);
                    
                    // scene.AddActor("player", player);
                    scene.AddActor("dragon", dragon_water);
                    scene.AddActor("dragon", dragon_earth);
                    scene.AddActor("dragon", dragon_air);
                    scene.AddActor("dragon", dragon_shadow);
                    scene.AddActor("dragon", dragon_fire);            
                    // scene.AddActor("player_texture", player_texture);
                    foreach (Actor walled in WallList){   scene.AddActor("wall",walled);   }
                    foreach (Actor tile in TileList){   scene.AddActor("floor",tile);   }
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