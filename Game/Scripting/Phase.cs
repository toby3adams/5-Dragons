using System;


namespace Dragons.Game.Scripting
{
    /// <summary>
    /// Defines game phases.
    /// </summary>
    public class Phase
    {
        public const int Input = 0;
        public const int Update = 1;
        public const int Output = 2;
        
        private Phase() {}
    }
}