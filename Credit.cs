using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace privateConsoleProject
{
    static class Credit
    {
        static public void AddCredit(int playCount)
        {
            StaticFields.creditList = new Dictionary<int, string>
            {
                { 1, $"당신은 {playCount} 번의 삶을 경험했습니다." },
                { 2, "하지만 당신의 인생은 한 번 뿐입니다." },
                { 3, "떠나간 기회는 다시 돌아오지 않습니다." },
                { 4, "Made by Lee Jaeyoung" },
                { 5, "Visual Studio<C#>, Github" },
                { 6, "Life is a mazing" }
            };
        }

        static public void ShowCredit()
        {
            AddCredit(StaticFields.playCount);

            for (int i = 0; i < StaticFields.creditList.Count; i++)
            {
                ColorChange(StaticFields.creditList, i);
            }
        }

        static public void ColorChange(Dictionary<int,String> list, int where)
        {
            int mentPosX = StaticFields.random.Next(-25, 26);
            int mentPosY = StaticFields.random.Next(-6, 7);

            Console.SetCursorPosition(Console.WindowWidth / 2 + mentPosX, Console.WindowHeight / 2 + mentPosY);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(list.ElementAt(where).Value);
            Thread.Sleep(1);
            Console.SetCursorPosition(Console.WindowWidth / 2 + mentPosX, Console.WindowHeight / 2 + mentPosY);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(list.ElementAt(where).Value);
            Thread.Sleep(250);
            Console.SetCursorPosition(Console.WindowWidth / 2 + mentPosX, Console.WindowHeight / 2 + mentPosY);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(list.ElementAt(where).Value);
            Thread.Sleep(250);
            Console.SetCursorPosition(Console.WindowWidth / 2 + mentPosX, Console.WindowHeight / 2 + mentPosY);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(list.ElementAt(where).Value);
            Thread.Sleep(1000);
            Console.SetCursorPosition(Console.WindowWidth / 2 + mentPosX, Console.WindowHeight / 2 + mentPosY);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(list.ElementAt(where).Value);
            Thread.Sleep(250);
            Console.SetCursorPosition(Console.WindowWidth / 2 + mentPosX, Console.WindowHeight / 2 + mentPosY);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(list.ElementAt(where).Value);
            Thread.Sleep(250);
            Console.SetCursorPosition(Console.WindowWidth / 2 + mentPosX, Console.WindowHeight / 2 + mentPosY);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(list.ElementAt(where).Value);
            Thread.Sleep(1);
        }
    }
}
