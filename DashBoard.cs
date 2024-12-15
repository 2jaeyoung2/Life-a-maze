using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace privateConsoleProject
{
    class DashBoard
    {

        // 상황판 프레임
        public void Frame(int howLong)
        {
            //상단 : 실상황
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(howLong * 2 + 4, 12);
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓ ");
            for (int i = 13; i < 22; i++)
            {
                Console.SetCursorPosition(howLong * 2 + 4, i);
                Console.WriteLine("┃　　　　　　　　　　　　　　┃ ");
            }
            Console.SetCursorPosition(howLong * 2 + 4, 22);
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛ ");
            Console.ResetColor();

            //중앙 : 멘트
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(howLong * 2 + 4, 23);
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓ ");
            for (int i = 24; i < 35; i++)
            {
                Console.SetCursorPosition(howLong * 2 + 4, i);
                Console.WriteLine("┃　　　　　　　　　　　　　　┃ ");
            }
            Console.SetCursorPosition(howLong * 2 + 4, 35);
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛ ");
            Console.ResetColor();

            //하단 : 규칙
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(howLong * 2 + 4, howLong + 11);
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━┓ ");
            for (int i = 12; i < 17; i++)
            {
                Console.SetCursorPosition(howLong * 2 + 4, howLong + i);
                Console.WriteLine("┃　　　　　　　　　　┃ ");
            }
            Console.SetCursorPosition(howLong * 2 + 4, howLong + 17);
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━┛ ");
            Console.ResetColor();
        }

        // 정보
        public void ShowInformation(int howLong, int leftSteps, float thisPoint, float sumPoint, int eatCount)
        {
            Console.SetCursorPosition(howLong * 2 + 5, 14);
            Console.WriteLine($"\t > 남은 발걸음 : {leftSteps}");
            Console.SetCursorPosition(howLong * 2 + 5, 16);
            Console.WriteLine($"\t > 열매 점수 : {thisPoint}");
            Console.SetCursorPosition(howLong * 2 + 5, 18);
            Console.WriteLine($"\t > 열매 개수 : {eatCount}/3");
            Console.SetCursorPosition(howLong * 2 + 5, 20);
            Console.WriteLine($"\t > 현재 점수 : {sumPoint}");
        }

        // 조작법
        public void GameRule(int howLong)
        {
            Console.SetCursorPosition(howLong * 2 + 5, howLong + 12);
            Console.WriteLine("\t ※ 방향키로 이동");
            Console.SetCursorPosition(howLong * 2 + 5, howLong + 14);
            Console.WriteLine("\t ※ Z - 열매 먹기");
            Console.SetCursorPosition(howLong * 2 + 5, howLong + 16);
            Console.WriteLine("\t ※ R - 맵 재생성");
        }

        // 키입력 경고
        public void Alert(int howLong)
        {
            Console.SetCursorPosition(howLong * 2 + 5, 21);
            Console.WriteLine(" ");
        }
    }
}
