namespace Dragons.Game.Services
{
    public interface IKeyboardService
    {
        bool IsKeyDown(KeyboardKey key);
        bool IsKeyPressed(KeyboardKey key);
        bool IsKeyReleased(KeyboardKey key);
        bool IsKeyUp(KeyboardKey key);
    }
}