using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class PortedGame : AbstractGame
    {
        //Images
        Bitmap m_bmpLevel = null;
        Bitmap m_bmpChar = null;
        Bitmap m_bmpPlane = null;
        Bitmap m_bmpBomb = null;

        //Player variables
        int m_iPlayerX = 320;           //center the player
        int m_iPlayerDir = 1;           //the player faces right
        int m_iPlayerFrame = 0;         //first frame
        int m_iPlayerSpeed = 250;       //pixels per second
        bool m_bMoving = false;

        //NPC variables
        int m_iNpcX = 150;              //spawn the npc somewhere left
        int m_iNpcDir = 1;              //npc moves right
        int m_iNpcFrame = 0;
        int m_iNpcSpeed = 200;
        int m_iNpcThink = 100;          //every sec

        //Bomb variables
        int m_iBombSpeed = 1000;        //pixels down per second
        int m_iBombDropChance = 5;		//dropchange per frame
        int[] m_iBombX = new int[50];
        int[] m_iBombY = new int[50];
        int[] m_iBombFrame = new int[50];

        //Tick counters
        int m_iTickCount = 0;
        int m_iTickPlayerMove = 0;
        int m_iTickNpcMove = 0;
        int m_iTickNpcThink = 100;
        int[] m_iTickBombMove = new int[50];

        public override void GameInitialize()
        {
            // Set the required values
            GAME_ENGINE.SetTitle("Random game from 2011");
            GAME_ENGINE.SetIcon("../../Assets/icon.ico");

            // Set the optional values
            GAME_ENGINE.SetWidth(640);
            GAME_ENGINE.SetHeight(480);
            GAME_ENGINE.SetBackgroundColor(49, 77, 121); //The Unity background color
        }

        public override void GameStart()
        {
            // Game Init
            m_bmpLevel = new Bitmap("images/level.bmp");
            m_bmpChar = new Bitmap("images/char.png");
            m_bmpPlane = new Bitmap("images/plane.png");
            m_bmpBomb = new Bitmap("images/bomb.png");

            //m_bmpChar->SetTransparencyColor(RGB(0, 255, 0));
            //m_bmpPlane->SetTransparencyColor(RGB(0, 255, 0));
            //m_bmpBomb->SetTransparencyColor(RGB(0, 255, 0));
        }

        public override void GameEnd()
        {
            m_bmpLevel.Dispose();
            m_bmpChar.Dispose();
            m_bmpPlane.Dispose();
            m_bmpBomb.Dispose();
        }

        public override void Update()
        {
            // Insert the code that needs to be executed every frame, EXCEPT for paint commands (see next method)

            HandleInput();
            MovePlayer(); //Player movement
            MoveNpc(); //NPC movement
            SpawnBombs(); //Bomb spawning
            MoveBombs(); //Bomb movement

            //increase the tickcounter!
            m_iTickCount++;
        }

        public override void Paint()
        {
            //background
            GAME_ENGINE.DrawBitmap(m_bmpLevel, 0, 0);

            //draw character
            Rectangle frame = new Rectangle();
            if (m_iPlayerDir == -1) frame.Y = 0; else frame.Y = m_bmpChar.GetHeight() / 2; //32
            frame.Height = m_bmpChar.GetHeight() / 2; //32
            frame.X = m_bmpChar.GetWidth() / 7 * m_iPlayerFrame; //32
            frame.Width = m_bmpChar.GetWidth() / 7; //32

            GAME_ENGINE.DrawBitmap(m_bmpChar, m_iPlayerX, 380, frame);
            //GAME_ENGINE.FillEllipse(m_iPlayerX + 7, 383, 16, 16);
            //GAME_ENGINE.FillEllipse(m_iPlayerX + 23, 395, 8, 8);

            //draw plane
            if (m_iNpcDir == -1) frame.Y = 0; else frame.Y = m_bmpPlane.GetHeight() / 2; //60
            frame.Height = m_bmpPlane.GetHeight() / 2; //60
            frame.X = (m_bmpPlane.GetWidth()) / 4 * m_iNpcFrame; //70
            frame.Width = m_bmpPlane.GetWidth() / 4; //70

            GAME_ENGINE.DrawBitmap(m_bmpPlane, m_iNpcX, 25, frame);

            //draw bombs
            for (int j = 1; j < 50; j++)
            {
                if (m_iBombX[j] > 0) //there is a bomb in this slot
                {
                    frame.Y = 0;
                    frame.Height = m_bmpBomb.GetHeight();
                    frame.X = (m_bmpBomb.GetWidth() / 12) * m_iBombFrame[j];
                    frame.Width = m_bmpBomb.GetWidth() / 12;

                    GAME_ENGINE.DrawBitmap(m_bmpBomb, m_iBombX[j], m_iBombY[j], frame);
                    //GAME_ENGINE.FillEllipse(m_iBombX[j] + 1, m_iBombY[j] + 13, 13, 13);
                }
            }

            //test circles

        }

        private void HandleInput()
        {
            //Movement
            if (GAME_ENGINE.GetKey(Key.Left))
            {
                m_iPlayerDir = -1;
                m_bMoving = true;
            }

            if (GAME_ENGINE.GetKey(Key.Right))
            {
                m_iPlayerDir = 1;
                m_bMoving = true;
            }

            if (!GAME_ENGINE.GetKey(Key.Left) && !GAME_ENGINE.GetKey(Key.Right))
            {
                //don't move
                m_bMoving = false;
            }

            //Difficulty
            if (GAME_ENGINE.GetKeyDown(Key.Add))
            {
                m_iNpcSpeed += 100;
            }

            if (GAME_ENGINE.GetKeyDown(Key.Subtract))
            {
                m_iNpcSpeed -= 100;
                if (m_iNpcSpeed <= 10) m_iNpcSpeed = 100;
            }
        }

        private void MovePlayer()
        {
            if (m_bMoving == true)
            {
                //set the new X-Coord
                m_iPlayerX += (m_iPlayerSpeed / 100) * m_iPlayerDir;

                //block the range
                if (m_iPlayerX <= 110) m_iPlayerX = 110;
                if (m_iPlayerX >= 540) m_iPlayerX = 540;

                //animation (doesn't change frame 100 times a second duh!)
                if (m_iTickCount >= m_iTickPlayerMove)
                {
                    //Set next animation frame
                    m_iPlayerFrame++;
                    if (m_iPlayerFrame >= 5) m_iPlayerFrame = 0;

                    //reset tick
                    m_iTickPlayerMove = m_iTickCount + 10;
                }
            }
            else
            {
                //display the idle frame
                m_iPlayerFrame = 6;
            }
        }

        private void MoveNpc()
        {
            //AI: check if the player is left of you, turn right!
            if (m_iTickCount >= m_iTickNpcThink) //he shouldn't think every frame..
            {
                if (m_iNpcX < m_iPlayerX) m_iNpcDir = 1;
                if (m_iNpcX > m_iPlayerX) m_iNpcDir = -1;

                m_iTickNpcThink = m_iTickCount + m_iNpcThink;
            }

            //set the new X-Coord
            m_iNpcX += (m_iNpcSpeed / 100) * m_iNpcDir;

            //block the npc range
            if (m_iNpcX <= 10)
            {
                m_iNpcX = 10;
                m_iNpcDir *= -1; //change direction
            }

            if (m_iNpcX >= 560)
            {
                m_iNpcX = 560;
                m_iNpcDir *= -1; //change direction
            }

            //animation
            if (m_iTickCount >= m_iTickNpcMove)
            {
                //Set next animation frame
                m_iNpcFrame++;
                if (m_iNpcFrame >= 3) m_iNpcFrame = 0;

                //reset tick
                m_iTickNpcMove = m_iTickCount + 10; //framerate / 10
            }
        }

        private void SpawnBombs()
        {
            int iRand = 0;

            System.Random rand = new Random();
            iRand = rand.Next(1, 100); //generate random no. from 1 to 100

            if (iRand <= m_iBombDropChance)
            {
                //let's drop a bomb!
                for (int j = 0; j < 50; j++)
                {
                    if (m_iBombX[j] == 0)
                    {
                        //this array slot is free, USE IT!
                        m_iBombX[j] = m_iNpcX;
                        m_iBombY[j] = 60;
                        break;
                    }
                }
            }
        }

        private void MoveBombs()
        {
            float sumR, distanceM; //a= som stralen, b = afstand middelpunten
            float XPlayer, YPlayer, XBomb, YBomb, RPlayer, RBomb;

            for (int j = 0; j < 50; j++)
            {
                if (m_iBombX[j] > 0) //there is a bomb here
                {
                    //Set new Y coord
                    m_iBombY[j] += m_iBombSpeed / 100;

                    //remove them once they hit the gound
                    if (m_iBombY[j] >= 400)
                    {
                        m_iBombX[j] = 0;
                        m_iBombY[j] = 0;
                        m_iBombFrame[j] = 0;
                    }

                    //ANIMATE BOMBS
                    if (m_iTickCount >= m_iTickBombMove[j])
                    {
                        //Set next animation frame
                        m_iBombFrame[j]++;
                        if (m_iBombFrame[j] >= 11) m_iBombFrame[j] = 0;

                        //reset bomb tick
                        m_iTickBombMove[j] = m_iTickCount + 3;
                    }

                    //check for collision between the bomb and the player
                    XPlayer = (float)m_iPlayerX + 7 + 8;                    //x middelpunt char
                    YPlayer = 383 + 8;                                      //y middelpunt char
                    XBomb = (float)m_iBombX[j] + 1 + (float)6.5;            //x middelpunt boms
                    YBomb = (float)m_iBombY[j] + 13 + (float)6.5;           //y middelpunt bom
                    RPlayer = 8;                                            //Straal cirkel speler
                    RBomb = (float)6.5;                                     //straal cirkel bom

                    sumR = RPlayer + RBomb;
                    distanceM = (float)Math.Sqrt(((XPlayer - XBomb) * (XPlayer - XBomb)) + ((YPlayer - YBomb) * (YPlayer - YBomb)));

                    if (distanceM <= sumR)
                    {
                        //COLLISION
                        Console.WriteLine("Een nog niet zo grafisch uitgewerkte BOOM!");
                        //GAME_ENGINE->MessageBox("Een nog niet zo grafisch uitgewerkte BOOM!");
                    }
                }
            }
        }
    }
}
