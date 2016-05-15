using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class EntryPoint
    {
        [STAThread]
        static void Main(string[] args)
        {
            GameEngine instance = GameEngine.GetInstance();

            if (instance == null)
                return;

            new X(); //X implements AbstractGame and subscribes himself to the game engine

            instance.Run();

            //Clean up unmanaged resources
            instance.Dispose();
        }
    }
}
