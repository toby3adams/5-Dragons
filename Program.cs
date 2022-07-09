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

            
            Player player = new Player();
            player.SizeTo(50, 50);
            player.MoveTo(1000, 1000); //5250,5250 SpawnLocation
            player.Tint(Color.Red());

            
            RandomDragPos rdp = new RandomDragPos();
            rdp.GeneratePositions();

            Dragon dragon_water = new Dragon(40, 150, 12, 8, 100);
            Point dragon_water_pos = rdp.GetPosition();
            dragon_water.SizeTo(60, 60);
            dragon_water.MoveTo(dragon_water_pos.GetX(), dragon_water_pos.GetY());
            dragon_water.Tint(Color.Blue());

            
            Dragon dragon_earth = new Dragon(40, 150, 12, 8, 100);
            Point dragon_earth_pos = rdp.GetPosition();
            dragon_earth.SizeTo(60, 60);
            
            dragon_earth.MoveTo(dragon_earth_pos.GetX(), dragon_earth_pos.GetY());
            dragon_earth.Tint(Color.Gray());

            
            Dragon dragon_air = new Dragon(40, 150, 12, 8, 100);
            Point dragon_air_pos = rdp.GetPosition();
            dragon_air.SizeTo(60, 60);
            //dragon_air.MoveTo(700, 700);
            dragon_air.MoveTo(dragon_air_pos.GetX(), dragon_air_pos.GetY());
            dragon_air.Tint(Color.Green());

            
            Dragon dragon_fire = new Dragon(40, 150, 12, 8, 100);
            Point dragon_fire_pos = rdp.GetPosition();
            dragon_fire.SizeTo(60, 60);
            //dragon_fire.MoveTo(900, 900);
            dragon_fire.MoveTo(dragon_fire_pos.GetX(), dragon_fire_pos.GetY());
            dragon_fire.Tint(Color.Orange());

            
            Dragon dragon_shadow = new Dragon(40, 150, 12, 8, 900);
            Point dragon_shadow_pos = rdp.GetPosition();
            dragon_shadow.SizeTo(60, 60);
            //dragon_shadow.MoveTo(2600, 1800);
            dragon_shadow.MoveTo(dragon_shadow_pos.GetX(), dragon_shadow_pos.GetY());
            dragon_shadow.Tint(Color.Purple());
            

            Wall ProbsABadIdea = new Wall();
            List<Wall> WallList = new List<Wall>(); // initializes a list of the walls in the program. 
            int NumbWall = ProbsABadIdea.wallNumb;//wall.NumberOfWalls(); need to set this to be related to the amount of wall that their are.
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
                wall.Tint(Color.Orange());
                WallList.Add(wall);
            }
            //This is a test code. 






            Actor screen = new Actor();
            screen.SizeTo(1860, 980);
            screen.MoveTo(0, 0);

            Actor world = new Actor();
            world.SizeTo(10000, 10000);
            world.MoveTo(0, 0);


            Camera camera = new Camera(player, screen, world);


            // Instantiate the actions that use the actors.
            SteerPlayerAction steerPlayerAction = new SteerPlayerAction(serviceFactory);
            MovePlayerAction movePlayerAction = new MovePlayerAction();
            UpdateStatusAction updateStatusAction = new UpdateStatusAction();
            DrawActorsAction drawActorsAction = new DrawActorsAction(serviceFactory);
            PlayerAttackAction player_attacks = new PlayerAttackAction(serviceFactory);
            ProjectilePositionAction projectile_movement = new ProjectilePositionAction();
            ProjectileCollisions projectile_collisions = new ProjectileCollisions();
            DragonCombat dragon_combat = new DragonCombat();


            // Instantiate a new scene, add the actors and actions.
            Scene scene = new Scene();
            scene.AddActor("instructions", instructions);
            scene.AddActor("status", status);
            scene.AddActor("dragon_life", dragon_life);
            scene.AddActor("player", player);
            scene.AddActor("camera", camera);
            scene.AddActor("dragon", dragon_water);
            scene.AddActor("dragon", dragon_earth);
            scene.AddActor("dragon", dragon_air);
            scene.AddActor("dragon", dragon_shadow);
            scene.AddActor("dragon", dragon_fire);
            foreach (Actor walled in WallList){   scene.AddActor("wall",walled);   }





            scene.AddAction(Phase.Input, steerPlayerAction);
            scene.AddAction(Phase.Input, player_attacks);
            scene.AddAction(Phase.Update, movePlayerAction);
            scene.AddAction(Phase.Update, updateStatusAction);
            scene.AddAction(Phase.Update, projectile_movement);
            scene.AddAction(Phase.Output, drawActorsAction);
            scene.AddAction(Phase.Update, projectile_collisions);
            scene.AddAction(Phase.Update, dragon_combat);

            // Start the game.
            Director director = new Director(serviceFactory);
            director.Direct(scene);
        }
    }
}
