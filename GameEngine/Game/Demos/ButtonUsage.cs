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
        private Audio m_ButtonClick;

        private float m_Timer; 

        public override void GameStart()
        {
            //Everything that has to happen when the game starts happens here.
            //F.e. initializing objects.

            m_Button = new Button(CallBack, "Omgekeerd", 100, 100, -50, -50);
            m_Bitmap = new Bitmap("images/plane.png");
            m_Font = new Font("scorefont.TTF", 16);
            m_Font.SetVerticalAlignment(Font.Alignment.Center);
            m_Font.SetHorizontalAlignment(Font.Alignment.Center);

            m_ButtonClick = new Audio("ping.mp3");
        }

        public override void GameEnd()
        {
            m_Button.Dispose();

            //Clean up unmanaged objects here (F.e. bitmaps & fonts)

            //For example:
            //m_Bitmap.Dispose();
            //m_Font.Dispose();
        }

        public override void Update()
        {
            //if (m_Button.IsActive() == false)
            //{
            //    m_Timer += GAME_ENGINE.GetDeltaTime();

            //    if (m_Timer > 1.0f)
            //    {
            //        m_Button.SetActive(true);
            //        m_Timer = 0.0f;
            //    }
            //}
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
            GAME_ENGINE.PlayAudio(m_ButtonClick);

            m_Button.SetActive(false);
            m_Button.Dispose();
            m_Button = null;

            //m_Button.SetActive(false);
        }
    }
}
