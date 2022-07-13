using Dragons.Game.Scripting;

namespace Dragons.Game.Casting{

    public class Turret : Image 
    {
        
        private int TurretDirection;
        private float Height;
        private float Width;
        private int x;
        private int y;
        private int damage;
        private bool is_near_player;

        // constructor takes Pit Height, width, x position, and y position
        
        public Turret(int Width, int Height, int x, int y, int TurretDirection){
            this.Height = Height;
            this.Width = Width;
            this.x = x;
            this.y = y;
            this.TurretDirection = TurretDirection;
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

        public  override int GetTurretDirection()
        {
            return TurretDirection;
        }
    }
}