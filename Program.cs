using Dragons.Game.Casting;
using Dragons.Game.Directing;
using Dragons.Game.Scripting;
using Dragons.Game.Services;
using System.Collections.Generic;
using System;


namespace Dragons
{
    /// <summary>
    /// The entry point for the program.
    /// </summary>
    /// <remarks>
    /// The purpose of this program is to demonstrate how Actors, Actions, Services and a Director 
    /// work together to scroll a world while the player moves.
    /// </remarks>
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            Scene scene = new Scene();
            TrapActions trap_actions = new TrapActions();

            // Instantiate a service factory for other objects to use.
            IServiceFactory serviceFactory = new RaylibServiceFactory();

            //Label status = new Label();
            // status.Display("x:-, y:-");
            // status.MoveTo(25, 55);

            // Label dragon_life = new Label();
            // dragon_life.Display("Dragon Life:-");
            // dragon_life.MoveTo(200, 55);

            // Label player_life = new Label();
            // player_life.Display("Player Life:-");
            // player_life.MoveTo(400, 55);


            
            Player player = new Player();
            player.SizeTo(50, 50);
            player.MoveTo(1480, 5000); //5250,5250 SpawnLocation
            // player.Tint(Color.Red());
            player.Display("Game/Assets/fighter.png");


            
            TitleScreen header = new TitleScreen();
            TitleScreen StartBackground = new TitleScreen();
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
                titleScreen1.MoveTo(xVector,yVector);
                titleScreen1.SizeTo(xSize,ySize);
                
                if (i==0)
                {
                    
                    header=titleScreen1;
                    header.Tint(Color.Red());
                    header.Display("Game/Assets/lava_2.png");
                }
                else if (i==3)
                {
                    StartBackground =titleScreen1;
                    StartBackground.Tint(Color.Yellow());
                    StartBackground.Display("Game/Assets/lava_2.png");
                }
                else
                {
                    titleScreen1.Tint(Color.Blue());
                    titleScreen1.Display("Game/Assets/lava_2.png");
                    HomeScreenButtons.Add(titleScreen1);
                }
                
                
                //wall.Display("Game/Assets/brick.png");
                
            }


            Actor screen = new Actor();
            screen.SizeTo(1860, 980); //1860 x 980
            screen.MoveTo(0, 0);

            Actor world = new Actor();
            world.SizeTo(3040, 5540);  // 5500 / 500 = 11x11  Mid = 6,6 
            world.MoveTo(0, 0);


            Camera camera = new Camera(player, screen, world);


            // Instantiate the actions that use the actors.
            UserScreenInteraction userScreenInteraction = new UserScreenInteraction(serviceFactory);
            SteerPlayerAction steerPlayerAction = new SteerPlayerAction(serviceFactory);
            UpdateStatusAction updateStatusAction = new UpdateStatusAction();
            DrawActorsAction drawActorsAction = new DrawActorsAction(serviceFactory);
            PlayerAttackAction player_attacks = new PlayerAttackAction(serviceFactory);
            ProjectilePositionAction projectile_movement = new ProjectilePositionAction();
            ProjectileCollisions projectile_collisions = new ProjectileCollisions();
            DragonCombat dragon_combat = new DragonCombat();
            TrapActions trap_action = new TrapActions();
            PlayMusicAction playMusicAction = new PlayMusicAction(serviceFactory);
            VictoryDefeat victory_defeat = new VictoryDefeat();


//            DrawImageAction drawImageAction = new DrawImageAction(serviceFactory);


            // Instantiate a new scene, add the actors and actions.
            scene.AddActor("camera", camera);
            //scene.AddActor("instructions", instructions);
            //scene.AddActor("status", status);
            //scene.AddActor("dragon_life", dragon_life);
            //scene.AddActor("player_life", player_life);
            scene.AddActor("player", player);

            foreach (Actor Button in HomeScreenButtons){   scene.AddActor("button",Button);   }
            scene.AddActor("header", header);  
            scene.AddActor("stback", StartBackground);  



            scene.AddAction(Phase.Input, userScreenInteraction); // updates the actor lists so that after space is hit all actors will display.
            scene.AddAction(Phase.Input, steerPlayerAction);
            scene.AddAction(Phase.Input, player_attacks);
                    //scene.AddAction(Phase.Update, UpdateScreen);
            
            scene.AddAction(Phase.Update, updateStatusAction);
            scene.AddAction(Phase.Update, victory_defeat);
            scene.AddAction(Phase.Update, projectile_movement);
            scene.AddAction(Phase.Update, projectile_collisions);
            scene.AddAction(Phase.Update, dragon_combat);
            scene.AddAction(Phase.Update, trap_action);
            scene.AddAction(Phase.Output, drawActorsAction);
            scene.AddAction(Phase.Output, playMusicAction);
            
            
//          scene.AddAction(Phase.Update, drawImageAction);

            // Start the game.
            Director director = new Director(serviceFactory);
            director.Direct(scene);
        }
    }
}
