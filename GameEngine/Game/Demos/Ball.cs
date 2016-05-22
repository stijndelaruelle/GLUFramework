using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class HappyBall : GameObject
    {
        Vector2f m_Position = Vector2f.zero;
        float m_Radius = 1.0f;

        Vector2f m_Direction = Vector2f.zero;
        float m_Speed = 100.0f;

        private Color m_Color = new Color(0, 0, 0);

        public HappyBall(float x, float y, float radius) : base()
        {
            m_Position.X = x;
            m_Position.Y = y;

            m_Radius = radius;
        }

        public void Update()
        {
            HandleInput();
            HandleMovement();
            HandleWallCollision();
        }

        private void HandleInput()
        {
            if (GAME_ENGINE.GetKey(Key.Add))
                m_Speed += 25.0f;

            if (GAME_ENGINE.GetKey(Key.Subtract))
                m_Speed -= 25.0f;

            if (m_Speed < 0.0f)
                m_Speed = 0.0f;

            if (m_Speed > 5000.0f)
                m_Speed = 5000.0f;
        }

        private void HandleMovement()
        {
            if (GAME_ENGINE.GetMouseButtonDown(0))
            {
                Vector2 clickedPosition = GAME_ENGINE.GetMousePosition();

                //Calculate delta vector
                m_Direction = new Vector2f(clickedPosition.X - m_Position.X, clickedPosition.Y - m_Position.Y);

                //Normalize
                m_Direction = Normalize(m_Direction);
            }

            //Move towards that direction
            float deltaTime = GAME_ENGINE.GetDeltaTime();

            m_Position.X += m_Direction.X * m_Speed * deltaTime;
            m_Position.Y += m_Direction.Y * m_Speed * deltaTime;

            //m_Position += new Vector2f(m_Direction.X * m_Speed * deltaTime, m_Direction.Y * m_Speed * deltaTime);
        }

        private void HandleWallCollision()
        {
            int screenWidth = GAME_ENGINE.GetScreenWidth();
            int screenHeight = GAME_ENGINE.GetScreenHeight();

            //Right (only check when going right 
            if (m_Direction.X > 0.0f)
            {
                if ((m_Position.X + m_Radius) > screenWidth)
                {
                    m_Direction.X *= -1.0f;
                }
            }
            else
            {
                //Left
                if ((m_Position.X - m_Radius) < 0)
                {
                    m_Direction.X *= -1.0f;
                }
            }

            //Top (only check when going top to avoid getting stuck)
            if (m_Direction.Y > 0.0f)
            {
                if ((m_Position.Y + m_Radius) > screenHeight)
                {
                    m_Direction.Y *= -1.0f;
                }
            }
            else
            {
                //Bottom
                if ((m_Position.Y - m_Radius) < 0)
                {
                    m_Direction.Y *= -1.0f;
                }
            }
        }

        public void Paint()
        {
            GAME_ENGINE.SetColor(m_Color);

            GAME_ENGINE.FillEllipse((int)(m_Position.X), (int)(m_Position.Y), (int)m_Radius, (int)m_Radius);
        }

        private Vector2f Normalize(Vector2f vec)
        {
            float length = VectorLength(vec);

            if (length > 0.0f)
            {
                vec.X /= length;
                vec.Y /= length;

                return vec;
            }

            return new Vector2f(0.0f, 0.0f);
        }

        private float VectorLength(Vector2f vec)
        {
            //Stelling van Pythagoras
            return (float)Math.Sqrt((double)((vec.X * vec.X) + (vec.Y * vec.Y)));
        }

        //Mutators & Accessors
        public void SetSpeed(float speed)
        {
            m_Speed = speed;
        }

        public void SetColor(int r, int g, int b)
        {
            m_Color = new Color(r, g, b);
        }

        public void SetColor(Color color)
        {
            m_Color = color;
        }
    }
}
