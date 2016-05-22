using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class PongGame : AbstractGame
    {
        private PhysicsWorld m_PhysicsWorld;
        private ScoreManager m_ScoreManager;

        private Paddle m_Paddle;
        private Paddle m_Paddle2;
        private Ball m_Ball;

        public override void GameStart()
        {
            GAME_ENGINE.SetBackgroundColor(0, 0, 0);

            //Create both paddles
            Vector2f offset = new Vector2f(20.0f, 20.0f);
            Vector2 size = new Vector2(25, 100);
            int screenWidth = GAME_ENGINE.GetScreenWidth();
            int screenHeight = GAME_ENGINE.GetScreenHeight();

            m_Paddle = new Paddle(offset, size, Key.Z, Key.S);
            m_Paddle2 = new Paddle(new Vector2f(screenWidth - size.X - offset.X, offset.Y), size, Key.Up, Key.Down);

            //Create the ball
            m_Ball = new Ball(new Vector2f((float)screenWidth * 0.5f, (float)screenHeight * 0.5f), new Vector2(20, 20));

            //Create the PhysicsWorld
            m_PhysicsWorld = new PhysicsWorld();
            m_PhysicsWorld.SubscribeObject(m_Paddle);
            m_PhysicsWorld.SubscribeObject(m_Paddle2);
            m_PhysicsWorld.SubscribeObject(m_Ball);

            //Create the ScoreManager
            m_ScoreManager = new ScoreManager(m_Ball);
        }

        public override void GameEnd()
        {
            m_PhysicsWorld.UnSubscribeObject(m_Paddle);
            m_PhysicsWorld.UnSubscribeObject(m_Paddle2);
            m_PhysicsWorld.UnSubscribeObject(m_Ball);

            m_ScoreManager.GameEnd();
        }

        public override void Update()
        {
            m_Paddle.Update();
            m_Paddle2.Update();
            m_Ball.Update();

            m_PhysicsWorld.Update();
        }

        public override void Paint()
        {
            m_Paddle.Paint();
            m_Paddle2.Paint();
            m_Ball.Paint();
            m_ScoreManager.Paint();
        }
    }
}
