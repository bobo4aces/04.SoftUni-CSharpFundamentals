namespace SimpleSnake
{
    using SimpleSnake.GameObjects;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            Wall wall = new Wall(60, 20);
            ConsoleWindow.CustomizeConsole();
        }
    }
}
