using System;
namespace privateConsoleProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Banner();
            StartMenu();
        }
        //시작메뉴
        static void StartMenu()
        {
            int height = 44;
            int width = 104;

            //창 크기 조절
            Console.WindowHeight = height; //높이
            Console.WindowWidth = width; //넓이

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

        //Struct & Enum
        enum MazeCompo
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

        // 거리 계산 메서드
        static double CalculateDistance(int playerPosX, int playerPosY, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow(playerPosX - x2, 2) + Math.Pow(playerPosY - y2, 2));
        }

        static void StartGame()
        {
            //플레이어 생성
            Player player = new Player();

            //미로 크기변수
            int distance = 25; //나중에 태어난 년도 입력받아서 로직에 따라 사이즈 다르게
            TileType[,] maze = new TileType[distance, distance];

            //임시보관 변수
            float tempLocation = 0;
            float tempScore = 0;

            //랜덤변수
            Random random = new Random();
            int randomWall;
            int randomItemPlace;
            int randomDestroy;
            float randomScore;

            //카운트 변수
            int floorCount = 0;
            int stepCount = 200;
            int eatCount = 0;
            int[] howMany = new int[5] { 0, 0, 0, 0, 0 };



            //맵 초기화
            ////외곽 생성
            for (int i = 0; i < distance; i++)
            {
                for (int j = 0; j < distance; j++)
                {
                    maze[i, j].type = (float)MazeCompo.staticWall;
                }
            }
            ////나머지 바닥 생성
            for (int i = 1; i < distance - 1; i++)
            {
                for (int j = 1; j < distance - 1; j++)
                {
                    maze[i, j].type = (float)MazeCompo.floor;
                    maze[i, j].score = 0;
                }
            }

            //플레이어 위치 초기화
            maze[1, 1].type = (float)MazeCompo.me;
            player.playerPosX = 1;
            player.playerPosY = 1;

            #region 미로말고 맵 랜덤생성

            //랜덤 벽 생성
            for (int i = 0; i < distance; i++)
            {
                for (int j = 0; j < distance; j++)
                {
                    if (maze[i, j].type == (int)MazeCompo.floor)
                    {
                        randomWall = random.Next(0, 4); //벽 밀도 조절
                        if (randomWall == 2)
                        {
                            maze[i, j].type = (int)MazeCompo.wall;
                        }
                    }
                }
            }

            // 고립지역 없애기
            for (int i = 0; i < distance - 1; i++)
            {
                for (int j = 0; j < distance - 1; j++)
                {
                    //만약 어느 지점에서
                    if (maze[i, j].type == (int)MazeCompo.floor)
                    {
                        //주변이 벽으로 막혀있다면
                        if (maze[i + 1, j].type >= (int)MazeCompo.wall && maze[i - 1, j].type >= (int)MazeCompo.wall && maze[i, j + 1].type >= (int)MazeCompo.wall && maze[i, j - 1].type >= (int)MazeCompo.wall)
                        {
                            randomDestroy = random.Next(0, 4);
                            //랜덤으로 뚫어라
                            switch (randomDestroy)
                            {
                                case 0:
                                    if (maze[i + 1, j].type != (int)MazeCompo.staticWall)
                                    {
                                        maze[i + 1, j].type = (int)MazeCompo.floor;
                                        Console.WriteLine($"수정됨 {i}, {j}");
                                    }
                                    break;
                                case 1:
                                    maze[i - 1, j].type = (int)MazeCompo.floor;
                                    if (maze[i - 1, j].type != (int)MazeCompo.staticWall)
                                    {
                                        maze[i - 1, j].type = (int)MazeCompo.floor;
                                        Console.WriteLine($"수정됨 {i}, {j}");
                                    }
                                    break;
                                case 2:
                                    maze[i, j + 1].type = (int)MazeCompo.floor;
                                    if (maze[i, j + 1].type != (int)MazeCompo.staticWall)
                                    {
                                        maze[i, j + 1].type = (int)MazeCompo.floor;
                                        Console.WriteLine($"수정됨 {i}, {j}");
                                    }
                                    break;
                                case 3:
                                    maze[i, j - 1].type = (int)MazeCompo.floor;
                                    if (maze[i, j - 1].type != (int)MazeCompo.staticWall)
                                    {
                                        maze[i, j - 1].type = (int)MazeCompo.floor;
                                        Console.WriteLine($"수정됨 {i}, {j}");
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            
            #endregion
            
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
            for (int i = 0; i < distance; i++)
            {
                for (int j = 0; j < distance; j++)
                {
                    if (maze[i, j].type == (int)MazeCompo.floor)
                    {
                        randomItemPlace = random.Next(0, floorCount / distance);
                        randomScore = (float)random.Next(50, 351) / 100;

                        if (randomItemPlace == 0)
                        {
                            maze[i, j].type = (int)MazeCompo.item;
                            maze[i, j].score = randomScore;
                        }
                    }
                }
            }

            //플레이
            while (stepCount > 0)
            {
                
                //맵 랜더링(?)
                Console.SetCursorPosition(0, 12);
                Console.CursorVisible = false;

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
                                    Console.Write("※");
                                    howMany[0]++;
                                }
                                else if (maze[i, j].score > 3)
                                {
                                    Console.Write("※");
                                    howMany[1]++;
                                }
                                else if (maze[i, j].score > 2.3)
                                {
                                    Console.Write("※");
                                    howMany[2]++;
                                }
                                else if (maze[i, j].score > 1.7)
                                {
                                    Console.Write("※");
                                    howMany[3]++;
                                }
                                else
                                {
                                    Console.Write("※");
                                    howMany[4]++;
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

                ////상황판
                //Console.SetCursorPosition(distance * 2 + 4 , 12);
                //Console.WriteLine("――――――――――――――――");
                //키 입력
                var keyInput = Console.ReadKey();


                Console.WriteLine($"{stepCount / 2}걸음");  //※ 걸음음 으로 나오는 오류 수정해야됨
                Console.WriteLine($"현재 점수 >> {player.playerScore}");

                // 'R' 키로 맵 재생성
                if (keyInput.Key == ConsoleKey.R)
                {
                    StartGame();
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
                            Console.WriteLine($"해당 열매 점수 >> {tempScore}");
                        }
                        else
                        {
                            tempLocation = maze[player.playerPosY, player.playerPosX].type;
                            maze[player.playerPosY, player.playerPosX] = maze[player.playerPosY - 1, player.playerPosX];
                            maze[player.playerPosY - 1, player.playerPosX].type = tempLocation;
                        }
                        stepCount--;
                    }
                    else //못간다면
                    {
                        stepCount++; //카운트 안내려감
                    }
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
                            Console.WriteLine($"해당 열매 점수 >> {tempScore}");
                        }
                        else
                        {
                            tempLocation = maze[player.playerPosY, player.playerPosX].type;
                            maze[player.playerPosY, player.playerPosX] = maze[player.playerPosY + 1, player.playerPosX];
                            maze[player.playerPosY + 1, player.playerPosX].type = tempLocation;
                        }
                        stepCount--;
                    }
                    else
                    {
                        stepCount++;
                    }
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
                            Console.WriteLine($"해당 열매 점수 >> {tempScore}");
                        }
                        else
                        {
                            tempLocation = maze[player.playerPosY, player.playerPosX].type;
                            maze[player.playerPosY, player.playerPosX] = maze[player.playerPosY, player.playerPosX - 1];
                            maze[player.playerPosY, player.playerPosX - 1].type = tempLocation;
                        }
                        stepCount--;
                    }
                    else
                    {
                        stepCount++;
                    }
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
                            Console.WriteLine($"해당 열매 점수 >> {tempScore}");
                        }
                        else
                        {
                            tempLocation = maze[player.playerPosY, player.playerPosX].type;
                            maze[player.playerPosY, player.playerPosX] = maze[player.playerPosY, player.playerPosX + 1];
                            maze[player.playerPosY, player.playerPosX + 1].type = tempLocation;
                        }
                        stepCount--;
                    }
                    else
                    {
                        stepCount++;
                    }
                }
                //'z'일경우 먹음
                else if (keyInput.Key == ConsoleKey.Z)
                {
                    if (maze[player.playerPosY, player.playerPosX].score != 0)
                    {
                        player.playerScore += tempScore;
                        eatCount++;
                    }
                    stepCount++;
                }

                //방향키 아닐경우
                else
                {
                    stepCount++;
                    Console.WriteLine($"{stepCount}방향키를 입력해주세요.");
                }



                //열매 세 개 먹었을 경우 게임 끝
                if (eatCount == 3)
                {
                    //Ending();
                    Console.WriteLine("Ending()");
                    Console.WriteLine(player.playerScore);
                    if(keyInput.Key == ConsoleKey.Z)
                    {
                        break;
                    }
                }
            }
        }
    }
}