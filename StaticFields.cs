using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace privateConsoleProject
{
    static class StaticFields
    {
        static public ConsoleKeyInfo keyInput;
        static public Stopwatch stopwatchBlink = new Stopwatch();

        static public Random random = new Random();

        static public bool isUpOrDown = true; // 시작 메뉴
        static public bool gameStart;
        static public bool firstGame = true; // 첫 게임인지 판별
        static public bool isRorQ; // 게임 끝난 후 재게임 여부 판별

        static public int height = 38;
        static public int width = 104;
        static public int selectMenuNum = 0;
        static public int playCount = 0;

        static public float tempScore = 0;
        static public float tempLocation;
        static public float tempHighestScore = 0;

        static public double distanceFromPlayer = 0;

        static public List<string> menuList = new List<string> {"시작", "종료", "임시"};

        // 발자국 좌표 큐
        static public Queue<int> posX = new Queue<int>();
        static public Queue<int> posY = new Queue<int>();

        static public Dictionary<int, string> creditList = new Dictionary<int, string>();

        static public List<float> recordMemo = new List<float>(new[] { 0f, 0f, 0f });
    }
}
