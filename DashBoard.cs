using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace privateConsoleProject
{
    static class DashBoard
    {
        // 상황판 프레임
        static public void InGameFrame(int howLong)
        {
            // 상단 : 실상황
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

            // 중간 : 규칙
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(howLong * 2 + 4, 23);
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━┓ ");
            for (int i = 24; i < 29; i++)
            {
                Console.SetCursorPosition(howLong * 2 + 4, i);
                Console.WriteLine("┃　　　　　　　　　　┃ ");
            }
            Console.SetCursorPosition(howLong * 2 + 4, 29);
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━┛ ");
            Console.ResetColor();

            // 하단 : 기록
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(howLong * 2 + 4, 30);
            Console.WriteLine("┏━━━━━━━━━━┓ ");
            for (int i = 31; i < 36; i++)
            {
                Console.SetCursorPosition(howLong * 2 + 4, i);
                Console.WriteLine("┃　　　　　┃ ");
            }
            Console.SetCursorPosition(howLong * 2 + 4, 36);
            Console.WriteLine("┗━━━━━━━━━━┛ ");
            Console.ResetColor();
        }

        static public void ReOrFin(int howLong)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(howLong * 2 + 4, 23);
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━┓ ");
            for (int i = 24; i < 29; i++)
            {
                Console.SetCursorPosition(howLong * 2 + 4, i);
                Console.WriteLine("┃　　　　　　　　　　┃ ");
            }
            Console.SetCursorPosition(howLong * 2 + 4, 29);
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━┛ ");
            Console.ResetColor();

            Console.SetCursorPosition(howLong * 2 + 7, 25);
            Console.WriteLine("※ 다시하기(R)");
            Console.SetCursorPosition(howLong * 2 + 7, 27);
            Console.WriteLine("※ 종료(Q)");
        }

        // 정보
        static public void ShowInformation(int howLong, int leftSteps, float thisPoint, float sumPoint, int eatCount)
        {
            Console.SetCursorPosition(howLong * 2 + 7, 14);
            Console.WriteLine($"> 남은 발걸음 : {leftSteps} ");
            Console.SetCursorPosition(howLong * 2 + 7, 16);
            Console.WriteLine($"> 열매 점수 : {thisPoint}");
            Console.SetCursorPosition(howLong * 2 + 7, 18);
            Console.WriteLine($"> 열매 개수 : {eatCount}/3");
            Console.SetCursorPosition(howLong * 2 + 7, 20);
            Console.WriteLine($"> 현재 점수 : {sumPoint}");
        }

        // 요약
        static public void Recap(int howLong, int stepCount, float sumPoint, int eatCount)
        {
            Console.SetCursorPosition(howLong * 2 + 14, 12);
            Console.WriteLine(" < Recap > ");
            Console.SetCursorPosition(howLong * 2 + 7, 14);
            Console.WriteLine($"당신은 총 {100 - stepCount}걸음을 걸으며");
            Console.SetCursorPosition(howLong * 2 + 7, 16);
            Console.WriteLine($"{eatCount}개의 기회를 붙잡아");
            Console.SetCursorPosition(howLong * 2 + 7, 18);
            Console.WriteLine($"{sumPoint:F2}점을 얻으셨습니다.");
            Console.SetCursorPosition(howLong * 2 + 7, 20);
            Console.WriteLine($"후회없는 선택을 하셨나요?");
        }

        // 조작법
        static public void GameRule(int howLong)
        {
            Console.SetCursorPosition(howLong * 2 + 7, 24);
            Console.WriteLine("※ 방향키로 이동");
            Console.SetCursorPosition(howLong * 2 + 7, 26);
            Console.WriteLine("※ Z - 열매 먹기");
            Console.SetCursorPosition(howLong * 2 + 7, 28);
            Console.WriteLine("※ R - 맵 재생성");
            Console.SetCursorPosition(Console.WindowWidth / 2 + 3, 37);
            Console.WriteLine("※ Φ [최소 0.50 - 최대 3.50]");
        }

        // 최고기록
        static public void ShowRecords(int howLong)
        {
            GameManager.RecordManager();
            float max = StaticFields.myRecords.Max();

            Console.SetCursorPosition(howLong * 2 + 7, 31);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"{max}");
            Console.ResetColor();
            Console.WriteLine(" Max");
            Console.SetCursorPosition(howLong * 2 + 7, 32);
            Console.WriteLine("\bㅡ");

            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(howLong * 2 + 7, 33 + i);
                Console.WriteLine($"{StaticFields.myRecords.ElementAt(i)}");
            }
        }
    }
}