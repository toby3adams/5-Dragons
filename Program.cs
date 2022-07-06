﻿using Dragons.Game.Casting;
using Dragons.Game.Directing;
using Dragons.Game.Scripting;
using Dragons.Game.Services;


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

            // Instantiate the actors that are used in this example.
            Label instructions = new Label();
            instructions.Display("'w', 's', 'a', 'd' to move");
            instructions.MoveTo(25, 25);

            Label status = new Label();
            status.Display("x:-, y:-");
            status.MoveTo(25, 55);
            
            Player player = new Player();
            player.SizeTo(50, 50);
            player.MoveTo(640, 480);
            player.Tint(Color.Red());

            Dragon dragon1 = new Dragon();
            dragon1.SizeTo(60, 60);
            dragon1.MoveTo(400, 400);
            dragon1.Tint(Color.Green());

            Dragon dragon2 = new Dragon();
            dragon2.SizeTo(60, 60);
            dragon2.MoveTo(500, 500);
            dragon2.Tint(Color.Orange());

            Actor screen = new Actor();
            screen.SizeTo(640, 480);
            screen.MoveTo(0, 0);

            Actor world = new Actor();
            world.SizeTo(1280, 960);
            world.MoveTo(0, 0);


            Camera camera = new Camera(player, screen, world);


            // Instantiate the actions that use the actors.
            SteerPlayerAction steerPlayerAction = new SteerPlayerAction(serviceFactory);
            MovePlayerAction movePlayerAction = new MovePlayerAction();
            UpdateStatusAction updateStatusAction = new UpdateStatusAction();
            DrawActorsAction drawActorsAction = new DrawActorsAction(serviceFactory);

            // Instantiate a new scene, add the actors and actions.
            Scene scene = new Scene();
            scene.AddActor("instructions", instructions);
            scene.AddActor("status", status);
            scene.AddActor("player", player);
            scene.AddActor("camera", camera);
            scene.AddActor("dragon", dragon1);
            scene.AddActor("dragon", dragon2);

            scene.AddAction(Phase.Input, steerPlayerAction);
            scene.AddAction(Phase.Update, movePlayerAction);
            scene.AddAction(Phase.Update, updateStatusAction);
            scene.AddAction(Phase.Output, drawActorsAction);

            // Start the game.
            Director director = new Director(serviceFactory);
            director.Direct(scene);
        }
    }
}
