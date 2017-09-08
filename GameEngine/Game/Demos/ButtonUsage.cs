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
        private Bitmap m_ButtonBitmap;

        private Bitmap m_Bitmap;
        private Font m_Font;
        private Audio m_ButtonClick;

        public override void GameStart()
        {
            //Everything that has to happen when the game starts happens here.
            //F.e. initializing objects.

            m_Button = new Button(OnClickCallBackNoArgs, "QUIT", 150, 50, 150, 50);
            m_Button.SetClickCallback(OnClickCallBack, "callback with args");
            m_Button.SetBeginHoverCallback(OnHoverBeginCallback, "begin hover");
            m_Button.SetEndHoverCallback(OnHoverEndCallback, "end hover");

            m_ButtonBitmap = new Bitmap("button.png");
            m_Button.SetBitmap(m_ButtonBitmap);

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
            GAME_ENGINE.DrawLine(0, 0, 200, 100, 1);
            GAME_ENGINE.DrawLine(0, 10, 200, 110, 2);
            GAME_ENGINE.DrawLine(0, 20, 200, 120, 3);
            GAME_ENGINE.DrawLine(0, 30, 200, 130, 4);
            GAME_ENGINE.DrawLine(0, 40, 200, 140, 5);

            //GAME_ENGINE.SetColor(Color.Green);
            //GAME_ENGINE.DrawString(m_Font, "Hallo", 100, 100, 200, 200);

            //GAME_ENGINE.SetColor(Color.Red);
            //GAME_ENGINE.Rotate(45);
            //GAME_ENGINE.DrawString(m_Font, "Hallo", 100, 100, 200, 200);
            //GAME_ENGINE.Rotate(-45);
        }

        private void OnClickCallBackNoArgs()
        {
            //GAME_ENGINE.Quit();
            GAME_ENGINE.Log("Callback without args");
            GAME_ENGINE.PlayAudio(m_ButtonClick);
        }

        private void OnClickCallBack(params object[] args)
        {
            GAME_ENGINE.Log(args[0].ToString());
        }

        private void OnHoverBeginCallback(params object[] args)
        {
            GAME_ENGINE.Log(args[0].ToString());
        }

        private void OnHoverEndCallback(params object[] args)
        {
            GAME_ENGINE.Log(args[0].ToString());
        }
    }
}
