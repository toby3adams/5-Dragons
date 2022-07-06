// using System.Collections.Generic;
// using Dragons.Game.Casting;
// using Dragons.Game.Services;

// namespace Dragons.Game.Scripting
// {
//     public class PlayerAttackAction : Action{

//         private IKeyboardService keyboardService;
        
//         public PlayerAttackAction(IServiceFactory serviceFactory)
//         {
//             keyboardService = serviceFactory.GetKeyboardService();
//         }


//         public override void Execute(Scene scene, float deltaTime, IActionCallback callback){
            


//         public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
//         {

//                 // declare basic speed and direction variables
//                 int playerSpeed = 5;
//                 int directionX = 0;
//                 int directionY = 0;

//                 // detect vertical or y-axis direction
//                 if (_keyboardService.IsKeyDown(KeyboardKey.W))
//                 {
//                     directionY = -playerSpeed;
//                 }
//                 else if (_keyboardService.IsKeyDown(KeyboardKey.S))
//                 {
//                     directionY = playerSpeed;
//                 }

//                 // detect horizontal or x-axis direction
//                 if (_keyboardService.IsKeyDown(KeyboardKey.A))
//                 {
//                     directionX = -playerSpeed;
//                 }
//                 else if (_keyboardService.IsKeyDown(KeyboardKey.D))
//                 {
//                     directionX = playerSpeed;
//                 }

//                 // steer the player in the desired direction
//                 Actor player = scene.GetFirstActor("player");
//                 player.Steer(directionX, directionY);

//         }




//         }

//     }
// }