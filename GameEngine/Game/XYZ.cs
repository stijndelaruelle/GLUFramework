using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class XYZ : AbstractGame
    {
        public override void GameStart()
        {
            //Everything that has to happen when the game starts happens here.
            //F.e. initializing objects.
        }

        public override void GameEnd()
        {
            //Clean up unmanaged objects here (F.e. bitmaps & fonts)

            //For example:
            //m_Bitmap.Dispose();
            //m_Font.Dispose();
        }

        public override void Update()
        {
            //Update everything here.
            //F.e. get input, move objects, etc...

            //For example:
            //float deltaTime = GAME_ENGINE.GetDeltaTime();
            //bool isDown = GAME_ENGINE.GetKeyDown(Key.Right);
        }

        public override void Paint()
        {
            //Draw everything here.

            //For example:
            //GAME_ENGINE.DrawRectangle(10, 10, 150, 25);
            //GAME_ENGINE.FillEllipse(50, 75, 50, 50);
        }
    }
}
