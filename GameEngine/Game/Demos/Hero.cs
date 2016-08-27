using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Hero : AbstractGame
    {
        private Bitmap m_Bitmap;
        private Font m_Font;

        private Vector2 m_Position = new Vector2(0, 0);
        private float m_Speed = 200.0f;

        public Hero(int x, int y)
        {
            m_Position.X = x;
            m_Position.Y = y;

            m_Bitmap = new Bitmap("../../jazz.png");
            m_Font = new Font("Times New Roman", 15);
        }

        public override void Update()
        {
            int dir = 0;
            if (GAME_ENGINE.GetKey(Key.A) || GAME_ENGINE.GetKey(Key.Left)) dir -= 1;
            if (GAME_ENGINE.GetKey(Key.D) || GAME_ENGINE.GetKey(Key.Right)) dir += 1;

            if (GAME_ENGINE.GetKeyDown(Key.Enter))
                Console.WriteLine("ENTER!");

            m_Position.X += (int)(dir * m_Speed * GAME_ENGINE.GetDeltaTime());
        }

        public override void Paint()
        {
            //Draw Jazz
            GAME_ENGINE.DrawBitmap(m_Bitmap, m_Position.X, m_Position.Y, 0, 0, 32, 36);

            //Text
            GAME_ENGINE.SetColor(255, 0, 255);
            GAME_ENGINE.DrawString(m_Font, "Hello!", m_Position.X, m_Position.Y - 25, 100, 100);
        }
    }
}
