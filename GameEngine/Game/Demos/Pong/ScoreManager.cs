using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class ScoreManager
    {
        private Ball m_Ball;
        private Font m_Font;
        private int[] m_Score = new int[2];

        public ScoreManager(Ball ball)
        {
            m_Font = new Font("04b_19", 50);

            m_Ball = ball;
            ball.ScoreEvent += OnScore;
        }

        public void GameEnd()
        {
            m_Ball.ScoreEvent -= OnScore;
        }

        public void Paint()
        {
            GameEngine gameEngine = GameEngine.GetInstance();

            int halfScreenWidth = (int)(gameEngine.GetScreenWidth() * 0.5f);
            int offset = 30;

            m_Font.SetHorizontalAlignment(Font.Alignment.Right);
            gameEngine.DrawString(m_Font, m_Score[0].ToString(), 0, 0, halfScreenWidth - offset, 100);

            m_Font.SetHorizontalAlignment(Font.Alignment.Left);
            gameEngine.DrawString(m_Font, m_Score[1].ToString(), halfScreenWidth + offset, 0, halfScreenWidth - offset, 100);
        }

        public void OnScore(int playerID, int score)
        {
            m_Score[playerID] += score;
        }
    }
}
