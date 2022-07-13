using System;
using System.Collections.Generic;
using Dragons.Game.Casting;
using Dragons.Game.Services;


namespace Dragons.Game.Scripting{

    public class TrapActions : Action
    {
        private int lava_counter;

        private int pit_fallBottom =-20;
        private int pit_fallTop =-21;

        private int pit_fallLeft=0;
        private int pit_fallRight =0;
        public TrapActions()
        {
        
        }

         public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            Player player = scene.GetFirstActor<Player>("player");
            

                if (this.lava_counter > 65)
                {
                    List<Trap> Lava = scene.GetAllActors<Trap>("lava"); 


                    foreach (Trap lavaBlock in Lava){
                        if (player.Overlaps(lavaBlock)){
                            player.takes_damage(player.damage);
                        }
                    }
                    this.lava_counter=0;
                }
                this.lava_counter++;

                //Doesn't need counter
                    List<Trap> pit_fall = scene.GetAllActors<Trap>("pit");

                    foreach (Trap pit_falls in pit_fall)
                    {
                        if(player.FullyOverlaps(pit_falls,pit_fallTop,pit_fallBottom,pit_fallLeft,pit_fallRight))
                        {
                           player.takes_damage(player.damage); 
                        }



                    }

    }
}
}