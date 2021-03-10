using System;
using AVRGame.NetStandardLibrary;

namespace AVRGame.OpenGL
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new AVRGame.NetStandardLibrary.FieryTale())
                game.Run();
        }
    }
}
