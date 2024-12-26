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
            // 창 크기 조절
            Console.WindowHeight = StaticFields.height; // 높이
            Console.WindowWidth = StaticFields.width; // 넓이
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

            for(int i = 0; i < StaticFields.menuList.Count; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 2, Console.WindowHeight / 2 + 10 + i * 2);
                Console.WriteLine(StaticFields.menuList.ElementAt(i));
            }

            Console.SetCursorPosition(2, Console.WindowHeight - 3);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("↑, ↓, [Enter]");
            Console.ResetColor();

            while (true)
            {

                if(StaticFields.keyInput.Key == ConsoleKey.UpArrow)
                {
                    StaticFields.selectMenuNum--;
                    StaticFields.isUpOrDown = true;

                    if (StaticFields.selectMenuNum <= 0)
                    {
                        StaticFields.selectMenuNum = 0;
                    }
                }
                else if(StaticFields.keyInput.Key == ConsoleKey.DownArrow)
                {
                    StaticFields.selectMenuNum++;
                    StaticFields.isUpOrDown = false;

                    if (StaticFields.selectMenuNum >= StaticFields.menuList.Count - 1)
                    {
                        StaticFields.selectMenuNum = StaticFields.menuList.Count - 1;
                    }
                }

                if(StaticFields.isUpOrDown == true)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.SetCursorPosition(Console.WindowWidth / 2 + 2, Console.WindowHeight / 2 + 8 - StaticFields.selectMenuNum * 2);
                    Console.WriteLine("   ");
                    Console.SetCursorPosition(Console.WindowWidth / 2 + 2, Console.WindowHeight / 2 + 10 - StaticFields.selectMenuNum * 2);
                    Console.WriteLine(" ◁");
                    Console.SetCursorPosition(Console.WindowWidth / 2 + 2, Console.WindowHeight / 2 + 12 - StaticFields.selectMenuNum * 2);
                    Console.WriteLine("   ");
                    Console.ResetColor();
                }
                else if(StaticFields.isUpOrDown == false)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.SetCursorPosition(Console.WindowWidth / 2 + 2, Console.WindowHeight / 2 + 8 + StaticFields.selectMenuNum * 2);
                    Console.WriteLine("   ");
                    Console.SetCursorPosition(Console.WindowWidth / 2 + 2, Console.WindowHeight / 2 + 10 + StaticFields.selectMenuNum * 2);
                    Console.WriteLine(" ◁");
                    Console.SetCursorPosition(Console.WindowWidth / 2 + 2, Console.WindowHeight / 2 + 12 + StaticFields.selectMenuNum * 2);
                    Console.WriteLine("   ");
                    Console.ResetColor();
                }


                if (StaticFields.keyInput.Key == ConsoleKey.Enter && StaticFields.isUpOrDown == true)
                {
                    StaticFields.gameStart = true;
                    break;
                }
                else if (StaticFields.keyInput.Key == ConsoleKey.Enter && StaticFields.isUpOrDown == false)
                {
                    StaticFields.gameStart = false;
                    break;
                }

                StaticFields.keyInput = Console.ReadKey(true);

            }
        }

        // 깜빡임
        static public void Blink(int howLong, float max)
        {
            for(int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(howLong * 2 + 7, 31);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write($"{max:F2}");
                Thread.Sleep(400);
                Console.SetCursorPosition(howLong * 2 + 7, 31);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"{max:F2}");
                Thread.Sleep(400);
            }
        }

        // 엔딩
        static public void Ending()
        {
            Console.Clear();
            DashBoard.ShowAllRecords();
            Console.Clear();
            Credit.ShowCredit();
        }

        // 끄기
        static public void QuitGame()
        {
            Console.Clear();
            Console.SetCursorPosition(0, Console.WindowHeight / 2 - 5);
            Banner();
            Console.ForegroundColor = ConsoleColor.Black;
        }

        // 게임 시작
        static public bool StartGame(ref bool reStart)
        {
            // 플레이어 생성
            Player player = new Player();

            // 미로 변수 & 객체 생성
            int distance = 25;
            Wall wall = new Wall();
            TileType[,] maze = new TileType[distance, distance];

            // 열매 생성
            Fruit fruit = new Fruit();

            // 초기 세팅
            int stepCount = 200;
            int eatCount = 0;
            StaticFields.isRorQ = false; // 새 게임 시작될 때 마다 false

            // 1. 필드 생성
            wall.MakeField(distance, maze);

            // 2. 플레이어 위치 초기화
            maze[1, 1].Type = (float)MazeCompo.me;
            player.PlayerPosX = 1;
            player.PlayerPosY = 1;

            // 3. 랜덤 지형 만들기
            wall.MakeRandomWall(distance, maze);

            // 4. 고립지역 없애기
            wall.EliminateIsolation(distance, maze);

            // 5. 바닥 개수 세기
            fruit.FloorCount(distance, maze);

            // 6. 랜덤 아이템 생성
            fruit.MakeRandomFruit(distance, maze);

            // 상황판
            DashBoard.InGameFrame(distance);
            DashBoard.GameRule(distance);
            DashBoard.ShowLastThreeRecords(distance);

            // 초기 맵 랜더링
            Rendering.RenderMazeLimitedView(distance, ref player, ref maze);

            // 플레이 카운트 +1
            StaticFields.playCount++;

            // 플레이
            while (stepCount > 0)
            {
                // 현재 정보
                DashBoard.ShowInformation(distance, stepCount / 2, StaticFields.tempScore, player.PlayerScore, eatCount);

                // 키 입력
                StaticFields.keyInput = Console.ReadKey(true);

                // 'R' 키로 맵 재생성
                if (StaticFields.keyInput.Key == ConsoleKey.R)
                {
                    StaticFields.posX.Clear();
                    StaticFields.posY.Clear();
                    return reStart = true;
                }

                // 상↑
                if (StaticFields.keyInput.Key == ConsoleKey.UpArrow)
                {
                    PlayerAction.MoveUp(ref player, ref maze, ref stepCount);
                }

                // 하↓
                else if (StaticFields.keyInput.Key == ConsoleKey.DownArrow)
                {
                    PlayerAction.MoveDown(ref player, ref maze, ref stepCount);
                }

                // 좌←
                else if (StaticFields.keyInput.Key == ConsoleKey.LeftArrow)
                {
                    PlayerAction.MoveLeft(ref player, ref maze, ref stepCount);
                }

                // 우→
                else if (StaticFields.keyInput.Key == ConsoleKey.RightArrow)
                {
                    PlayerAction.MoveRight(ref player, ref maze, ref stepCount);
                }

                // 아이템 획득 z
                else if (StaticFields.keyInput.Key == ConsoleKey.Z)
                {
                    PlayerAction.EatFruit(ref player, ref maze, ref eatCount);
                }

                // 반복 맵 랜더링
                Rendering.RenderMazeLimitedView(distance, ref player, ref maze);

                // 열매를 세 개 다 먹었다면
                if (eatCount == 3 || stepCount == 0)
                {
                    Rendering.RenderMazeAll(distance, player, maze);
                    DashBoard.Recap(distance, stepCount / 2, player.PlayerScore, eatCount);
                    Rendering.RenderSteps();
                    StaticFields.recordMemo.Add(player.PlayerScore);

                    // 기록 업데이트
                    DashBoard.ShowLastThreeRecords(distance);

                    // 다시하기 or 종료 안내창
                    DashBoard.ReOrFin(distance);

                    while (!StaticFields.isRorQ)
                    {
                        StaticFields.keyInput = Console.ReadKey(true);

                        if (StaticFields.keyInput.Key == ConsoleKey.R) // 다시하기
                        {
                            StaticFields.isRorQ = true;
                            return reStart = true;
                        }
                        else if (StaticFields.keyInput.Key == ConsoleKey.Q) // 종료
                        {
                            StaticFields.isRorQ = true;
                            Ending();
                        }
                    }
                    break;
                }
            }
            reStart = false;
            return reStart;
        }
    }
}
