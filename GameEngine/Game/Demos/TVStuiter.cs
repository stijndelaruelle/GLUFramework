using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class TVStuiter : AbstractGame
    {
        private Vector2 m_Position = new Vector2(480, 330); // new Vector2(870, 0); //new Vector2(0, 660); //
        private Vector2 m_Size = new Vector2(270, 50);
        private Vector2 m_ScreenSize = new Vector2(1230, 710);

        private Vector2 m_Direction = new Vector2(1, 1);

        private int m_Bounces = 0;
        private int m_Ticks = 0;

        private Font m_Font;

        private List<Rectanglef> m_PositionList;

        public override void GameInitialize()
        {
            // Set the required values
            GAME_ENGINE.SetTitle("Televisie");
            GAME_ENGINE.SetIcon("../../Assets/icon.ico");

            // Set the optional values
            GAME_ENGINE.SetWidth(m_ScreenSize.X);
            GAME_ENGINE.SetHeight(m_ScreenSize.Y);
            GAME_ENGINE.SetBackgroundColor(20, 20, 20); //The Unity background color
        }

        public override void GameStart()
        {
            m_Font = new Font("Arial", 20);
            m_Font.SetHorizontalAlignment(Font.Alignment.Center);
            m_Font.SetVerticalAlignment(Font.Alignment.Center);

            m_PositionList = new List<Rectanglef>();
        }

        public override void GameEnd()
        {

        }

        public override void Update()
        {
            m_PositionList.Add(new Rectanglef(m_Position.X, m_Position.Y, m_Direction.X, m_Direction.Y));

            m_Position.X += m_Direction.X * 10;
            m_Position.Y += m_Direction.Y * 10;

            //Find location
            Rectanglef vecToFind = new Rectanglef(m_Position.X, m_Position.Y, m_Direction.X, m_Direction.Y);
            if (m_PositionList.Contains(vecToFind))
            {
                Console.WriteLine("DUPLICATE POSITION X=" + vecToFind.X + " Y=" + vecToFind.Y);
            }


            if (m_Position.X <= 0 && m_Direction.X < 0)
            {
                m_Direction.X *= -1;
                ++m_Bounces;
            }

            if (m_Position.X + m_Size.X >= m_ScreenSize.X && m_Direction.X > 0)
            {
                m_Direction.X *= -1;
                ++m_Bounces;
            }

            if (m_Position.Y <= 0 && m_Direction.Y < 0)
            {
                m_Direction.Y *= -1;
                ++m_Bounces;
            }

            if (m_Position.Y + m_Size.Y >= m_ScreenSize.Y && m_Direction.Y > 0)
            {
                m_Direction.Y *= -1;
                ++m_Bounces;
            }

            ++m_Ticks;

            if (m_Position.X == 0 && m_Position.Y == 0)
            {
                Console.WriteLine("HIT THE TOP LEFT CORNER AFTER " + m_Bounces + " BOUNCES & " + m_Ticks + " TICKS");
            }

            if (m_Position.X == m_ScreenSize.X - m_Size.X && m_Position.Y == 0)
            {
                Console.WriteLine("HIT THE TOP RIGHT CORNER AFTER " + m_Bounces + " BOUNCES & " + m_Ticks + " TICKS");
            }

            if (m_Position.X == 0 && m_Position.Y == m_ScreenSize.Y - m_Size.Y)
            {
                Console.WriteLine("HIT THE BOTTOM LEFT CORNER AFTER " + m_Bounces + " BOUNCES & " + m_Ticks + " TICKS");
            }

            if (m_Position.X == m_ScreenSize.X - m_Size.X && m_Position.Y == m_ScreenSize.Y - m_Size.Y)
            {
                Console.WriteLine("HIT THE BOTTOM RIGHT CORNER AFTER " + m_Bounces + " BOUNCES & " + m_Ticks + " TICKS");
            }
        }

        public override void Paint()
        {
            GAME_ENGINE.SetColor(new Color(250, 250, 250));
            GAME_ENGINE.FillRectangle(m_Position.X, m_Position.Y, m_Size.X, m_Size.Y);

            GAME_ENGINE.SetColor(new Color(20, 20, 20));
            GAME_ENGINE.DrawString(m_Font, "Alleen audio", new Rectanglef(m_Position.X, m_Position.Y, m_Size.X, m_Size.Y));
        }
    }
}
