using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    //Enables the use of GAME_ENGINE. Otherwise pretty useless.
    public class GameObject
    {
        private GameEngine m_GameEngine;
        protected GameEngine GAME_ENGINE
        {
            get { return m_GameEngine; }
        }

        public GameObject()
        {
            m_GameEngine = GameEngine.GetInstance();
        }
    }
}
