using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace privateConsoleProject
{
    static class StaticFields
    {
        static public ConsoleKeyInfo keyInput;

        static public Random random = new Random();

        static public bool firstGame = true;
        static public bool gameStart = true;
        static public bool isRorQ;

        static public int height = 38;
        static public int width = 104;
        static public int playCount = 0;

        static public float tempScore = 0;
        static public float tempLocation;
        static public float tempHighestScore = 0;

        static public Queue<int> posX = new Queue<int>();
        static public Queue<int> posY = new Queue<int>();

        static public Dictionary<int, string> creditList = new Dictionary<int, string>();

        static public List<float> recordMemo = new List<float>(new[] { 0f, 0f, 0f });
    }
}
