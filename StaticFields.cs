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

        static public bool again = false;
        static public bool gameStart = true;
        static public bool isRorQ;

        static public int playCount = 0;

        static public float tempScore = 0;
        static public float tempLocation;

        static public Queue<int> posX = new Queue<int>();
        static public Queue<int> posY = new Queue<int>();
        static public List<float> recordMemo = new List<float>(new[] { 0f, 0f, 0f });
    }
}
