using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class ButtonUsage : AbstractGame
    {
        private Button m_Button;
        private Bitmap m_Bitmap;
        private Font m_Font;
        public override void GameStart()
        {
            //Everything that has to happen when the game starts happens here.
            //F.e. initializing objects.

            m_Button = new Button(CallBack);
            m_Bitmap = new Bitmap("images/plane.png");
            m_Font = new Font("scorefont.TTF", 16);
            m_Font.SetVerticalAlignment(Font.Alignment.Center);
            m_Font.SetHorizontalAlignment(Font.Alignment.Center);
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
            GAME_ENGINE.SetColor(Color.Green);
            GAME_ENGINE.DrawString(m_Font, "Hallo", 100, 100, 200, 200);

            GAME_ENGINE.SetColor(Color.Red);
            GAME_ENGINE.Rotate(45);
            GAME_ENGINE.DrawString(m_Font, "Hallo", 100, 100, 200, 200);
            GAME_ENGINE.Rotate(-45);
        }

        private void CallBack()
        {
            GAME_ENGINE.Log("Clicked!");
        }
    }
}
