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

            instance.SetGame(new GameDemo()); //X implements AbstractGame

            instance.Run();

            //Clean up unmanaged resources
            instance.Dispose();
        }
    }
}
