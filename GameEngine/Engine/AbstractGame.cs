using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class AbstractGame : GameObject
    {
        public virtual void GameInitialize()
        {
            // Set the required values
            GAME_ENGINE.SetTitle("Game Engine v1.0");
            GAME_ENGINE.SetIcon("../../icon.ico");

            // Set the optional values
            GAME_ENGINE.SetWidth(640);
            GAME_ENGINE.SetHeight(480);
            GAME_ENGINE.SetBackgroundColor(49, 77, 121); //The Unity background color
        }

        public virtual void GameStart() {}
        public virtual void GameEnd() {}
        public virtual void Update() {}
        public virtual void Paint() {}
    }
}
