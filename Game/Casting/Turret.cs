using Dragons.Game.Scripting;

namespace Dragons.Game.Casting{

    public class Turret : Image 
    {
        public int turret_counter = 0;
        public int expect_count = 60;
        private int TurretDirection;
        private float Height;
        private float Width;
        private int x;
        private int y;
        private int damage;
        private bool is_near_player;
        private int room;

        // constructor takes Pit Height, width, x position, and y position
        
        public Turret(int Width, int Height, int x, int y, int TurretDirection, int room){
            this.Height = Height;
            this.Width = Width;
            this.x = x;
            this.y = y;
            this.TurretDirection = TurretDirection;
            this.room = room;
        } 

        public override float GetHeight()
        {
            return Height;
        }

        public override float GetWidth()
        {
            return Width;
        }

        public override int GetX()
        {
            return x;
        }

        public override int GetY()
        {
            return y;
        }

        public int GetRoom()
        {
            return room;
        }

        public  override int GetTurretDirection()
        {
            return TurretDirection;
        }
    }
}