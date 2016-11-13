using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Transparancy_Test : AbstractGame
    {
        private double m_Timer = 0.0f;
        private int m_Rotation = 0;

        private Bitmap m_Bitmap;
        private Font m_Font;

        public override void GameStart()
        {
            m_Bitmap = new Bitmap("images/plane.png");
            m_Font = new Font("Times New Roman", 15);
        }

        public override void GameEnd()
        {

        }

        public override void Update()
        {
            if (GAME_ENGINE.GetKeyDown(Key.V))
            {
                GAME_ENGINE.SetVSync(!GAME_ENGINE.GetVSync());
            }

            m_Timer += GAME_ENGINE.GetDeltaTime();
            m_Rotation = (int)(Math.Sin(m_Timer) * 360);
        }

        public override void Paint()
        {
            GAME_ENGINE.SetRotation(0.0f);
            GAME_ENGINE.ResetScale();
            GAME_ENGINE.SetColor(Color.White);

            float fps = (int)(1.0f / GAME_ENGINE.GetDeltaTime());
            GAME_ENGINE.DrawString("FPS: " + fps, 10, 200, 100, 100);

            
            GAME_ENGINE.SetScale((float)Math.Abs(Math.Sin(m_Timer)) * 1.5f, 1.0f);
            GAME_ENGINE.DrawBitmap(m_Bitmap, 10, 10, 0.0f, 0.0f, 70.0f, 60.0f);

            GAME_ENGINE.SetScale(-(float)Math.Abs(Math.Sin(m_Timer)) * 1.5f, 1.0f);
            GAME_ENGINE.DrawBitmap(m_Bitmap, 80, 80, 0.0f, 0.0f, 70.0f, 60.0f);
            //GAME_ENGINE.SetRotation(0.0f);
            //GAME_ENGINE.SetColor(255, 0, 0);

            //GAME_ENGINE.SetScale(1.0f, 1.0f);
            //GAME_ENGINE.FillRectangle(10, 10, 200, 200);

            //GAME_ENGINE.SetScale(1.5f, 1.0f);
            //GAME_ENGINE.FillRectangle(10, 220, 200, 200);


            //GAME_ENGINE.SetRotation(m_Rotation);
            //GAME_ENGINE.SetScale(1.0f, 1.0f);
            //GAME_ENGINE.FillRectangle(320, 10, 200, 200);

            //GAME_ENGINE.SetRotation(0.0f);
            //GAME_ENGINE.SetScale((float)Math.Abs(Math.Sin(m_Timer)) * 1.5f, 1.0f);
            //GAME_ENGINE.FillRectangle(320, 220, 200, 200);
        }
    }
}
