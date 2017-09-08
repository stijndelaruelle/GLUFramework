using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class WordPuzzleSolver : AbstractGame
    {
        public static string ROW_SEPARATOR = "\n";
        public static string COLUMN_SEPARATOR = ",";

        private string[,] m_CharArray;

        public override void GameStart()
        {
            m_CharArray = ParseCSV("/puzzel.txt");
        }

        public override void GameEnd()
        {

        }

        public override void Update()
        {

        }

        public override void Paint()
        {

        }

        public string[,] ParseCSV(string filename)
        {
            string fileText = "";
            try
            {
                fileText = File.ReadAllText(filename, System.Text.Encoding.UTF8);
            }
            catch (Exception e)
            {
                //The file was not found, but that shouldn't crash the game!
                GAME_ENGINE.LogError(e.Message);
                return null;
            }

            string[,] result = new string[0, 0];

            //Split the text in rows
            string[] srcRows = fileText.Split(new string[] { ROW_SEPARATOR }, StringSplitOptions.None); //new char[] { '\r', '\n' }
            List<string> rows = new List<string>(srcRows);
            rows.RemoveAll(rowName => rowName == "");

            //Split the rows in colmuns
            for (int y = 0; y < rows.Count; ++y)
            {
                string[] srcColumns = rows[y].Split(new string[] { COLUMN_SEPARATOR }, StringSplitOptions.None); //new char[] { ';' }

                //Create new 2 dimensional array if required (we only now know the size)
                if (result.Length == 0)
                    result = new string[srcColumns.Length, rows.Count];

                for (int x = 0; x < srcColumns.Length; ++x)
                {
                    //Pretty much impossible, just an extra safety net
                    if (x >= result.GetLength(0))
                    {
                        GAME_ENGINE.LogError("Row consists of more columns than the first row of the table! Source: " + rows[y]);
                        return null;
                    }

                    result[x, y] = srcColumns[x];
                }
            }

            return result;
        }
    }
}
