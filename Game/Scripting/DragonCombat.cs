using System.Collections.Generic;
using Dragons.Game.Casting;
using Dragons.Game.Services;
using System.Numerics;
using System;


namespace Dragons.Game.Scripting{
    public class DragonCombat : Action{


        public DragonCombat(){}

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback){

            List<Dragon> dragons = scene.GetAllActors<Dragon>("dragon");
            Player player = scene.GetFirstActor<Player>("player");

                check_health_death(scene);

            foreach (Dragon dragon in dragons){

                check_for_player(dragon, player);
                attack_player(dragon, player);
            }




        }


        private void check_for_player(Dragon dragon, Player player){
            
            if (player.GetCenterX() - dragon.aggro_distance < dragon.GetCenterX() && dragon.GetCenterX() < player.GetCenterX() + dragon.aggro_distance){
                if (player.GetCenterY()-dragon.aggro_distance < dragon.GetCenterY() && dragon.GetCenterY() < player.GetCenterY()+dragon.aggro_distance){
                    dragon.is_near_player = true; 
                }
            }
            else{
            dragon.is_near_player = false;
            }
            // Console.WriteLine(dragon.is_near_player); //debugging
        }

        private void attack_player(Dragon dragon, Player player){

        }

        private void check_health_death(Scene scene){

        }



    }
}