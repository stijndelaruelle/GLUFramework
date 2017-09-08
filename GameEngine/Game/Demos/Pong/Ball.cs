using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public delegate void ScoreDelegate(int playerID, int score);

    public class Ball : PhysicsObject
    {
        //Audio test
        private Audio m_Song;

        private Vector2f m_StartPosition;
        private Vector2 m_Size;
        private int m_StartSpeed = 250;

        private Vector2f m_Position;
        private int m_Speed;

        private Vector2f m_Direction = new Vector2f(0.0f, 0.0f);

        private ScoreDelegate m_ScoreEvent;
        public ScoreDelegate ScoreEvent
        {
            get { return m_ScoreEvent; }
            set { m_ScoreEvent = value; }
        }

        public Ball(Vector2f pos, Vector2 size)
        {
            m_StartPosition = pos;
            m_Size = size;

            Reset();

            //m_Song = new Audio("07_billy_talent_-_crooked_minds.mp3");
            //m_Song.SetLooping(true);
            //m_Song.SetVolume(1.0f);
            //GameEngine.GetInstance().PlayAudio(m_Song);
            //GameEngine.GetInstance().SetVolume(1.0f);
        }

        public void Update()
        {
            GameEngine gameEngine = GameEngine.GetInstance();

            //Movement
            m_Position.X += (m_Direction.X * m_Speed * gameEngine.GetDeltaTime());
            m_Position.Y += (m_Direction.Y * m_Speed * gameEngine.GetDeltaTime());

            //Reflect on the borders
            int screenWidth = gameEngine.GetScreenWidth();
            int screenHeight = gameEngine.GetScreenHeight();

            if (m_Position.Y < 0 && m_Direction.Y < 0)
            {
                m_Position.Y = 0;
                m_Direction.Y *= -1;
            }

            if (m_Position.Y > screenHeight - m_Size.Y && m_Direction.Y > 0)
            {
                m_Position.Y = screenHeight - m_Size.Y;
                m_Direction.Y *= -1;
            }

            //Scoring
            if (m_ScoreEvent == null)
                return;

            if (m_Position.X < 0 && m_Direction.X < 0)
            {
                m_ScoreEvent(1, 1);
                Reset();
            }

            if (m_Position.X > screenWidth - m_Size.X && m_Direction.X > 0)
            {
                m_ScoreEvent(0, 1);
                Reset();
            }
        }

        public void Paint()
        {
            GameEngine gameEngine = GameEngine.GetInstance();

            gameEngine.SetColor(Color.White);
            gameEngine.FillRectangle((int)m_Position.X, (int)m_Position.Y, m_Size.X, m_Size.Y);
        }

        private void Reset()
        {
            m_Position = m_StartPosition;
            m_Speed = m_StartSpeed;

            Random rand = new Random();
            int dirRand = rand.Next(0, 100);

            if (dirRand < 50)
                dirRand = -1;
            else
                dirRand = 1;

            float angleRand = rand.Next(25, 75) / 100.0f;

            if (dirRand < 50) angleRand *= -1;

            m_Direction.X = dirRand;
            m_Direction.Y = angleRand;

            m_Direction = Normalize(m_Direction);
        }

        //PhysicsObject
        public Rectanglef GetAABB()
        {
            return new Rectanglef((int)m_Position.X, (int)m_Position.Y, m_Size.X, m_Size.Y);
        }

        public void OnCollisionEnter(PhysicsObject otherObj)
        {
            Rectanglef otherAABB = otherObj.GetAABB();

            ////Top collision
            //if ((m_Position.Y + m_Size.Y) > otherAABB.Y &&
            //    (m_Position.Y + m_Size.Y) < (otherAABB.Y + 5))
            //{
            //    m_Direction.Y *= -1;
            //    m_Position.Y = otherAABB.Y - m_Size.Y;

            //    Console.WriteLine("Top collision");
            //}

            ////Bottom collision
            //else if (m_Position.Y < (otherAABB.Y + otherAABB.Height) &&
            //        (m_Position.Y > (otherAABB.Y + otherAABB.Height - 5)))
            //{
            //    m_Direction.Y *= -1;
            //    m_Position.Y = otherAABB.Y + otherAABB.Height;

            //    Console.WriteLine("Bottom collision");
            //}

            //Left
            if (m_Position.X < (otherAABB.X + otherAABB.Width) && m_Direction.X < 0)
            {
                m_Direction.X *= -1;
                m_Position.X = (otherAABB.X + otherAABB.Width);

                Console.WriteLine("Left");
            }

            else if ((m_Position.X + m_Size.X) > otherAABB.X && m_Direction.X > 0)
            {
                m_Direction.X *= -1;
                m_Position.X = otherAABB.X - m_Size.X;

                Console.WriteLine("Right");
            }

            m_Speed += 50;
            
        }

        //Some math that shouldn't be here
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
    }
}
