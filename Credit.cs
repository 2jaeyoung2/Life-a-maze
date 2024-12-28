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
            int i = 0;
            StaticFields.creditList = new Dictionary<int, string>
            {
                { i++, $"당신은 {playCount} 번의 삶을 경험했습니다." },
                { i++, "떠나간 기회는 다시 돌아오지 않습니다." },
                { i++, "Made by Lee Jaeyoung" },
                { i++, "12/3 - 12/26(Average: 1H per Day)" },
                { i++, "Visual Studio<C#> & Github" },
                { i++, "Life is amazing." }
            };
        }

        static public void ShowCredit()
        {
            AddCredit(StaticFields.playCount);

            for (int i = 0; i < StaticFields.creditList.Count; i++)
            {
                int mentPosX = StaticFields.random.Next(-18, 5);
                int mentPosY = StaticFields.random.Next(-6, 7);

                if(i != StaticFields.creditList.Count - 1)
                {
                    ColorChange(StaticFields.creditList, i, mentPosX, mentPosY);
                }
                else
                {
                    Thread.Sleep(2000);
                    ColorChange(StaticFields.creditList, StaticFields.creditList.Count - 1, -7, 0);
                }                
            }
        }

        static public void ColorChange(Dictionary<int,String> list, int where, int mentPosX, int mentPosY)
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 + mentPosX, Console.WindowHeight / 2 + mentPosY);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(list.ElementAt(where).Value);
            Thread.Sleep(10);
            Console.SetCursorPosition(Console.WindowWidth / 2 + mentPosX, Console.WindowHeight / 2 + mentPosY);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(list.ElementAt(where).Value);
            Thread.Sleep(200);
            Console.SetCursorPosition(Console.WindowWidth / 2 + mentPosX, Console.WindowHeight / 2 + mentPosY);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(list.ElementAt(where).Value);
            Thread.Sleep(200);
            Console.SetCursorPosition(Console.WindowWidth / 2 + mentPosX, Console.WindowHeight / 2 + mentPosY);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(list.ElementAt(where).Value);
            Thread.Sleep(1100);
            Console.SetCursorPosition(Console.WindowWidth / 2 + mentPosX, Console.WindowHeight / 2 + mentPosY);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(list.ElementAt(where).Value);
            Thread.Sleep(200);
            Console.SetCursorPosition(Console.WindowWidth / 2 + mentPosX, Console.WindowHeight / 2 + mentPosY);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(list.ElementAt(where).Value);
            Thread.Sleep(200);
            Console.SetCursorPosition(Console.WindowWidth / 2 + mentPosX, Console.WindowHeight / 2 + mentPosY);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(list.ElementAt(where).Value);
            Thread.Sleep(10);

            Console.ResetColor();
        }
    }
}
