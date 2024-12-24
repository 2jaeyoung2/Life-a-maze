using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace privateConsoleProject
{
    static class GameManager
    {
        // 창 세팅
        static public void Setting()
        {
            int height = 38;
            int width = 104;

            // 창 크기 조절
            Console.WindowHeight = height; // 높이
            Console.WindowWidth = width; // 넓이
            Console.CursorVisible = false; // 커서 지움
        }

        // 배너 이미지
        static public void Banner()
        {
            #region 배너           
            Console.WriteLine();
            Console.WriteLine("{1}{1}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}", "■", "　");
            Console.WriteLine("{1}{0}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{0}", "■", "　");
            Console.WriteLine("{0}{1}{1}{0}{1}{1}{1}{0}{1}{0}{0}{0}{0}{1}{0}{0}{0}{0}{1}{1}{1}{1}{1}{0}{0}{1}{1}{1}{1}{0}{1}{1}{1}{0}{1}{1}{0}{0}{1}{1}{0}{0}{0}{0}{1}{0}{0}{0}{0}{1}{1}{0}", "■", "　");
            Console.WriteLine("{0}{1}{1}{0}{1}{1}{1}{0}{1}{0}{1}{1}{1}{1}{0}{1}{1}{1}{1}{1}{1}{1}{0}{1}{1}{0}{1}{1}{1}{0}{0}{1}{0}{0}{1}{0}{1}{1}{0}{1}{1}{1}{1}{0}{1}{0}{1}{1}{1}{1}{1}{0}", "■", "　");
            Console.WriteLine("{0}{1}{1}{0}{1}{1}{1}{0}{1}{0}{0}{0}{1}{1}{0}{0}{0}{1}{1}{1}{1}{1}{0}{0}{0}{0}{1}{1}{1}{0}{1}{0}{1}{0}{1}{0}{0}{0}{0}{1}{1}{1}{0}{1}{1}{0}{0}{0}{1}{1}{1}{0}", "■", "　");
            Console.WriteLine("{0}{1}{1}{0}{1}{1}{1}{0}{1}{0}{1}{1}{1}{1}{0}{1}{1}{1}{1}{1}{1}{1}{0}{1}{1}{0}{1}{1}{1}{0}{1}{1}{1}{0}{1}{0}{1}{1}{0}{1}{1}{0}{1}{1}{1}{0}{1}{1}{1}{1}{1}{0}", "■", "　");
            Console.WriteLine("{0}{1}{1}{0}{0}{0}{1}{0}{1}{0}{1}{1}{1}{1}{0}{0}{0}{0}{1}{0}{1}{1}{0}{1}{1}{0}{1}{1}{1}{0}{1}{1}{1}{0}{1}{0}{1}{1}{0}{1}{0}{0}{0}{0}{1}{0}{0}{0}{0}{1}{1}{0}", "■", "　");
            Console.WriteLine("{1}{0}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{0}", "■", "　");
            Console.WriteLine("{1}{1}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}", "■", "　");
            #endregion
        }

        // 시작화면
        static public void SelectMenu()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + 1);
            Console.WriteLine("\"일생에 찾아오는 세 번의 기회\"");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 6, Console.WindowHeight / 2 + 10);
            Console.WriteLine("> 시작(Z) <");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 6, Console.WindowHeight / 2 + 12);
            Console.WriteLine("> 종료(Q) <");
        }

        // 엔딩
        static public void Ending()
        {
            Console.Clear();
            DashBoard.ShowAllRecords();
            Credit.ShowCredit();
        }

        // 끄기
        static public void QuitGame()
        {
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 2, Console.WindowHeight / 2);
            Console.WriteLine($"{StaticFields.playCount} END");
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}
