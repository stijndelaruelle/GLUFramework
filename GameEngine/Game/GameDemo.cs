using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class GameDemo : AbstractGame
    {
        private Ball m_Ball;
        private Ball m_Ball2;
        private Hero m_Hero;

        public override void GameStart()
        {
            m_Ball = new Ball(150.0f, 150.0f, 20.0f);
            m_Ball.SetColor(Color.Green);
            m_Ball.SetSpeed(1000.0f);

            m_Ball2 = new Ball(300.0f, 250.0f, 50.0f);
            m_Ball2.SetColor(255, 255, 0);
            m_Ball2.SetSpeed(500.0f);

            m_Hero = new Hero(250, 250);
        }

        public override void Update()
        {
            m_Ball.Update();
            m_Ball2.Update();

            m_Hero.Update();
        }

        public override void Paint()
        {
            m_Ball.Paint();
            m_Ball2.Paint();

            m_Hero.Paint();
        }
    }
}
