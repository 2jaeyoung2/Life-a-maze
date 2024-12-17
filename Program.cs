using System;
using Microsoft.Win32;
using static privateConsoleProject.Program;
namespace privateConsoleProject
{
    //Struct & Enum
    public enum MazeCompo
    {
        floor, item, me, wall, staticWall = 99
    }
    public struct TileType
    {
        public float type;
        public float score;
    }
    public struct Player
    {
        public int playerPosX;
        public int playerPosY;
        public float playerScore;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Banner();
            StartMenu();
            StartGame();
        }
        //배너 함수
        static void Banner()
        {
            //위치 및 색상 조절
            Console.ForegroundColor = ConsoleColor.DarkGray;
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
            Console.ResetColor();
        }
        //시작메뉴
        static void StartMenu()
        {
            int height = 44;
            int width = 104;

            //창 크기 조절
            Console.WindowHeight = height; //높이
            Console.WindowWidth = width; //넓이
            Console.CursorVisible = false; //커서 지움
        }
        

        // 거리 계산 메서드
        static double CalculateDistance(int playerPosX, int playerPosY, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow(playerPosX - x2, 2) + Math.Pow(playerPosY - y2, 2));
        }

        static void StartGame()
        {
            //플레이어 생성
            Player player = new Player();

            //상황판 생성
            DashBoard dashBoard = new DashBoard();

            //미로 변수
            int distance = 25;
            Wall wall = new Wall();
            TileType[,] maze = new TileType[distance, distance];
            Rendering rendering = new Rendering();

            //임시보관 변수
            float tempLocation = 0;
            float tempScore = 0;

            //랜덤변수
            Random random = new Random();
            Fruit fruit = new Fruit();

            //카운트 변수
            int floorCount = 0;
            int stepCount = 200;
            int eatCount = 0;


            // 필드 생성
            wall.MakeField(distance, maze);
            
            //플레이어 위치 초기화
            maze[1, 1].type = (float)MazeCompo.me;
            player.playerPosX = 1;
            player.playerPosY = 1;

            // 랜덤 지형 만들기
            wall.MakeRandomWall(distance, maze);


            // 고립지역 없애기
            wall.EliminateIsolation(distance, maze);
            
            
            //바닥 개수 세기
            for (int i = 0; i < distance; i++)
            {
                for (int j = 0; j < distance; j++)
                {
                    if (maze[i, j].type == (int)MazeCompo.floor)
                    {
                        floorCount++;
                    }
                }
            }

            //랜덤 아이템 생성
            fruit.MakeRandomFruit(distance, floorCount, maze);


            //플레이
            while (stepCount > 0)
            {

                //↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓맵 랜더링(?)
                Console.SetCursorPosition(0, 12);

                for (int i = 0; i < distance; i++)
                {
                    Console.Write("　");

                    for (int j = 0; j < distance; j++)
                    {
                        // 시야 제한 로직 추가
                        double distanceFromPlayer = CalculateDistance(player.playerPosX, player.playerPosY, j, i);

                        if (distanceFromPlayer <= 3) // 반지름 n의 원 내부만 보이도록
                        {
                            //길
                            if (maze[i, j].type == (float)MazeCompo.floor)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write("□");
                                Console.ResetColor();
                            }
                            //플레이어
                            else if (maze[i, j].type == (float)MazeCompo.me)
                            {
                                Console.Write("●");
                                player.playerPosY = i;
                                player.playerPosX = j;
                            }
                            //벽
                            else if (maze[i, j].type == (float)MazeCompo.wall || maze[i, j].type == (float)MazeCompo.staticWall)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("▩");
                                Console.ResetColor();
                            }
                            //아이템
                            else if (maze[i, j].type == (float)MazeCompo.item)
                            {
                                if (maze[i, j].score > 3)
                                {
                                    Console.Write("Φ");
                                }
                                else if (maze[i, j].score > 3)
                                {
                                    Console.Write("Φ");
                                }
                                else if (maze[i, j].score > 2.3)
                                {
                                    Console.Write("Φ");
                                }
                                else if (maze[i, j].score > 1.7)
                                {
                                    Console.Write("Φ");
                                }
                                else
                                {
                                    Console.Write("Φ");
                                }
                            }
                        }
                        else
                        {
                            // 시야 밖은 공백으로 처리
                            Console.Write("　");
                        }
                    }
                    Console.WriteLine();
                }

                //↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

                //상황판
                dashBoard.Frame(distance);
                dashBoard.ShowInformation(distance, stepCount / 2, tempScore, player.playerScore, eatCount);
                dashBoard.GameRule(distance);



                //키 입력
                var keyInput = Console.ReadKey();

                // 'R' 키로 맵 재생성
                if (keyInput.Key == ConsoleKey.R)
                {
                    StartGame();
                    return;
                }

                //상↑
                if (keyInput.Key == ConsoleKey.UpArrow)
                {
                    //만약
                    if (maze[player.playerPosY, player.playerPosX].type > maze[player.playerPosY - 1, player.playerPosX].type)
                    {
                        //이동할 위치가 item이면 이 전 타일은 floor로 강제
                        if (maze[player.playerPosY - 1, player.playerPosX].type == (int)MazeCompo.item)
                        {
                            //열매 점수 임시보관
                            tempScore = maze[player.playerPosY - 1, player.playerPosX].score;

                            tempLocation = maze[player.playerPosY, player.playerPosX].type;
                            maze[player.playerPosY - 1, player.playerPosX].type = tempLocation;
                            maze[player.playerPosY, player.playerPosX].type = (int)MazeCompo.floor; //이동 전 타일도 바닥으로 바꿨음
                        }
                        else
                        {
                            tempLocation = maze[player.playerPosY, player.playerPosX].type;
                            maze[player.playerPosY, player.playerPosX] = maze[player.playerPosY - 1, player.playerPosX];
                            maze[player.playerPosY - 1, player.playerPosX].type = tempLocation;
                        }
                    }
                    else //못간다면
                    {
                        stepCount++; //카운트 안내려감
                    }
                    stepCount--;
                }

                //하↓
                else if (keyInput.Key == ConsoleKey.DownArrow)
                {
                    //만약
                    if (maze[player.playerPosY, player.playerPosX].type > maze[player.playerPosY + 1, player.playerPosX].type)
                    {
                        //이동할 위치가 item이면 이 전 타일은 floor로 강제
                        if (maze[player.playerPosY + 1, player.playerPosX].type == (int)MazeCompo.item)
                        {
                            //열매 점수 임시보관
                            tempScore = maze[player.playerPosY + 1, player.playerPosX].score;

                            tempLocation = maze[player.playerPosY, player.playerPosX].type;
                            maze[player.playerPosY + 1, player.playerPosX].type = tempLocation;
                            maze[player.playerPosY, player.playerPosX].type = (int)MazeCompo.floor; //이동 전 타일도 바닥으로 바꿨음
                        }
                        else
                        {
                            tempLocation = maze[player.playerPosY, player.playerPosX].type;
                            maze[player.playerPosY, player.playerPosX] = maze[player.playerPosY + 1, player.playerPosX];
                            maze[player.playerPosY + 1, player.playerPosX].type = tempLocation;
                        }
                    }
                    else
                    {
                        stepCount++;
                    }
                    stepCount--;
                }

                //좌←
                else if (keyInput.Key == ConsoleKey.LeftArrow)
                {
                    //만약
                    if (maze[player.playerPosY, player.playerPosX].type > maze[player.playerPosY, player.playerPosX - 1].type)
                    {
                        //이동할 위치가 item이면 이 전 타일은 floor로 강제
                        if (maze[player.playerPosY, player.playerPosX - 1].type == (int)MazeCompo.item)
                        {
                            //열매 점수 임시보관
                            tempScore = maze[player.playerPosY, player.playerPosX - 1].score;

                            tempLocation = maze[player.playerPosY, player.playerPosX].type;
                            maze[player.playerPosY, player.playerPosX - 1].type = tempLocation;
                            maze[player.playerPosY, player.playerPosX].type = (int)MazeCompo.floor; //이동 전 타일도 바닥으로 바꿨음
                        }
                        else
                        {
                            tempLocation = maze[player.playerPosY, player.playerPosX].type;
                            maze[player.playerPosY, player.playerPosX] = maze[player.playerPosY, player.playerPosX - 1];
                            maze[player.playerPosY, player.playerPosX - 1].type = tempLocation;
                        }
                    }
                    else
                    {
                        stepCount++;
                    }
                    stepCount--;
                }

                //우→
                else if (keyInput.Key == ConsoleKey.RightArrow)
                {
                    if (maze[player.playerPosY, player.playerPosX].type > maze[player.playerPosY, player.playerPosX + 1].type)
                    {
                        //이동할 위치가 item이면 이 전 타일은 floor로 강제
                        if (maze[player.playerPosY, player.playerPosX + 1].type == (int)MazeCompo.item)
                        {
                            //열매 점수 임시보관
                            tempScore = maze[player.playerPosY, player.playerPosX + 1].score;

                            tempLocation = maze[player.playerPosY, player.playerPosX].type;
                            maze[player.playerPosY, player.playerPosX + 1].type = tempLocation;
                            maze[player.playerPosY, player.playerPosX].type = (int)MazeCompo.floor; //이동 전 타일도 바닥으로 바꿨음
                        }
                        else
                        {
                            tempLocation = maze[player.playerPosY, player.playerPosX].type;
                            maze[player.playerPosY, player.playerPosX] = maze[player.playerPosY, player.playerPosX + 1];
                            maze[player.playerPosY, player.playerPosX + 1].type = tempLocation;
                        }
                    }
                    else
                    {
                        stepCount++;
                    }
                    stepCount--;
                }
                //'z'일경우 먹음
                else if (keyInput.Key == ConsoleKey.Z)
                {
                    if (maze[player.playerPosY, player.playerPosX].score != 0)
                    {
                        player.playerScore += tempScore;
                        maze[player.playerPosY, player.playerPosX].score = 0;
                        tempScore = maze[player.playerPosY, player.playerPosX].score;
                        eatCount++;
                    }
                }
                //열매를 세 개 다 먹었다면
                if (eatCount == 3)
                {
                    //ending();
                    //return;
                }
            }
        }
    }
}