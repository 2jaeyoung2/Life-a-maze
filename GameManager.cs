using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace privateConsoleProject
{
    static class GameManager
    {
        // 창 세팅
        static public void Setting()
        {
            int height = 44;
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

        // 선택
        static public void SelectMenu()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight - 12);
            Console.WriteLine("> 시작(Z) <");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight - 10);
            Console.WriteLine("> 종료(Q) <");
        }

        // 지우기(야매)
        static public void Erase()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight - 12);
            Console.WriteLine("　　　　　");
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight - 10);
            Console.WriteLine("　　　　　");
        }

        // 끄기
        static public void Ending()
        {
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight);
            Console.WriteLine("끝");
            Console.SetCursorPosition(Console.WindowWidth, Console.WindowHeight);
        }
    }
}
