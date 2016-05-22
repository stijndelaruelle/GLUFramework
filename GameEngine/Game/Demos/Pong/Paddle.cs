using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Paddle : PhysicsObject
    {
        private Vector2f m_Position;
        private Vector2 m_Size;
        private float m_Speed = 400.0f;

        private Key m_UpKey;
        private Key m_DownKey;

        public Paddle(Vector2f pos, Vector2 size, Key upKey, Key downKey)
        {
            m_Position = pos;
            m_Size = size;
            m_UpKey = upKey;
            m_DownKey = downKey;
        }

        public void Update()
        {
            GameEngine gameEngine = GameEngine.GetInstance();

            //Input handling
            int dir = 0;
            if (gameEngine.GetKey(m_UpKey)) { dir -= 1; }
            if (gameEngine.GetKey(m_DownKey)) { dir += 1; }

            //Movement
            m_Position.Y += (int)(dir * m_Speed * gameEngine.GetDeltaTime());

            //Restrict to screen
            int screenHeight = gameEngine.GetScreenHeight();

            if (m_Position.Y < 0) m_Position.Y = 0;
            if (m_Position.Y > screenHeight - m_Size.Y) m_Position.Y = screenHeight - m_Size.Y;
        }

        public void Paint()
        {
            GameEngine gameEngine = GameEngine.GetInstance();

            gameEngine.SetColor(Color.White);
            gameEngine.FillRectangle((int)m_Position.X, (int)m_Position.Y, m_Size.X, m_Size.Y);
        }

        //PhysicsObject
        public Rectangle GetAABB()
        {
            return new Rectangle((int)m_Position.X, (int)m_Position.Y, m_Size.X, m_Size.Y);
        }

        public void OnCollisionEnter(PhysicsObject otherObj)
        {

        }
    }
}
