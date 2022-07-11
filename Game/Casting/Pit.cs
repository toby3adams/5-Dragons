using Dragons.Game.Scripting;
namespace Dragons.Game.Casting{


    public class Pit : Actor
    {
        private float Height;
        private float Width;
        private int x;
        private int y;
        private int damage;

        // constructor takes Pit Height, width, x position, and y position
        
        public Pit(int Height, int Width, int x, int y){
            this.Height = Height;
            this.Width = Width;
            this.x = x;
            this.y = y;
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




    }
}