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
        static public Queue<float> myRecords = new Queue<float>(new[] { 0f, 0f, 0f });
        static public int playCount = 0;
    }
}
