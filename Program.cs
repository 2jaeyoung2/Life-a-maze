using System;
using Microsoft.Win32;
using static privateConsoleProject.Program;
namespace privateConsoleProject
{
    public enum MazeCompo
    {
        floor, item, me, wall, staticWall = 99
    }
    public struct TileType
    {
        float _type;
        float _score;

        public float Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public float Score
        {
            get { return _score; }
            set { _score = value; }
        }
    }
    public struct Player
    {
        int _playerPosX;
        int _playerPosY;
        float _playerScore;

        public int PlayerPosX
        {
            get { return _playerPosX; }
            set { _playerPosX = value; }
        }
        public int PlayerPosY
        {
            get { return _playerPosY; }
            set { _playerPosY = value; }
        }
        public float PlayerScore
        {
            get { return _playerScore; }
            set { _playerScore = value; }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Banner();
            StartMenu();
            StartGame();
        }
        // 배너 함수
        static void Banner()
        {
            // 위치 및 색상 조절
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
        // 시작메뉴
        static void StartMenu()
        {
            int height = 44;
            int width = 104;

            // 창 크기 조절
            Console.WindowHeight = height; // 높이
            Console.WindowWidth = width; // 넓이
            Console.CursorVisible = false; // 커서 지움
        }

        // 게임 시작
        static void StartGame()
        {
            // 플레이어 생성
            Player player = new Player();

            // 상황판 생성
            DashBoard dashBoard = new DashBoard();

            // 미로 변수
            int distance = 25;
            Wall wall = new Wall();
            TileType[,] maze = new TileType[distance, distance];
            Rendering rendering = new Rendering();

            // 임시보관 변수
            float tempLocation;
            float tempScore = 0;

            // 열매 생성
            Fruit fruit = new Fruit();

            // 카운트 변수
            int floorCount = 0;
            int stepCount = 200;
            int eatCount = 0;


            // 필드 생성
            wall.MakeField(distance, maze);
            
            // 플레이어 위치 초기화
            maze[1, 1].Type = (float)MazeCompo.me;
            player.PlayerPosX = 1;
            player.PlayerPosY = 1;

            // 랜덤 지형 만들기
            wall.MakeRandomWall(distance, maze);


            // 고립지역 없애기
            wall.EliminateIsolation(distance, maze);
            
            
            // 바닥 개수 세기
            for (int i = 0; i < distance; i++)
            {
                for (int j = 0; j < distance; j++)
                {
                    if (maze[i, j].Type == (int)MazeCompo.floor)
                    {
                        floorCount++;
                    }
                }
            }

            // 랜덤 아이템 생성
            fruit.MakeRandomFruit(distance, floorCount, maze);


            // 플레이
            while (stepCount > 0)
            {
                // 맵 랜더링
                rendering.RenderMaze(distance, ref player, ref maze);

                // 상황판
                dashBoard.Frame(distance);
                dashBoard.ShowInformation(distance, stepCount / 2, tempScore, player.PlayerScore, eatCount);
                dashBoard.GameRule(distance);



                // 키 입력
                var keyInput = Console.ReadKey();

                // 'R' 키로 맵 재생성
                if (keyInput.Key == ConsoleKey.R)
                {
                    StartGame();
                    return;
                }

                // 상↑
                if (keyInput.Key == ConsoleKey.UpArrow)
                {
                    // 만약
                    if (maze[player.PlayerPosY, player.PlayerPosX].Type > maze[player.PlayerPosY - 1, player.PlayerPosX].Type)
                    {
                        // 이동할 위치가 item이면 이 전 타일은 floor로 강제
                        if (maze[player.PlayerPosY - 1, player.PlayerPosX].Type == (int)MazeCompo.item)
                        {
                            // 열매 점수 임시보관
                            tempScore = maze[player.PlayerPosY - 1, player.PlayerPosX].Score;

                            tempLocation = maze[player.PlayerPosY, player.PlayerPosX].Type;
                            maze[player.PlayerPosY - 1, player.PlayerPosX].Type = tempLocation;
                            maze[player.PlayerPosY, player.PlayerPosX].Type = (int)MazeCompo.floor; // 이동 전 타일도 바닥으로 바꿨음
                        }
                        else
                        {
                            tempLocation = maze[player.PlayerPosY, player.PlayerPosX].Type;
                            maze[player.PlayerPosY, player.PlayerPosX] = maze[player.PlayerPosY - 1, player.PlayerPosX];
                            maze[player.PlayerPosY - 1, player.PlayerPosX].Type = tempLocation;
                        }
                    }
                    else // 못간다면
                    {
                        stepCount++; // 카운트 안내려감
                    }
                    stepCount--;
                }

                // 하↓
                else if (keyInput.Key == ConsoleKey.DownArrow)
                {
                    // 만약
                    if (maze[player.PlayerPosY, player.PlayerPosX].Type > maze[player.PlayerPosY + 1, player.PlayerPosX].Type)
                    {
                        // 이동할 위치가 item이면 이 전 타일은 floor로 강제
                        if (maze[player.PlayerPosY + 1, player.PlayerPosX].Type == (int)MazeCompo.item)
                        {
                            // 열매 점수 임시보관
                            tempScore = maze[player.PlayerPosY + 1, player.PlayerPosX].Score;

                            tempLocation = maze[player.PlayerPosY, player.PlayerPosX].Type;
                            maze[player.PlayerPosY + 1, player.PlayerPosX].Type = tempLocation;
                            maze[player.PlayerPosY, player.PlayerPosX].Type = (int)MazeCompo.floor; // 이동 전 타일도 바닥으로 바꿨음
                        }
                        else
                        {
                            tempLocation = maze[player.PlayerPosY, player.PlayerPosX].Type;
                            maze[player.PlayerPosY, player.PlayerPosX] = maze[player.PlayerPosY + 1, player.PlayerPosX];
                            maze[player.PlayerPosY + 1, player.PlayerPosX].Type = tempLocation;
                        }
                    }
                    else
                    {
                        stepCount++;
                    }
                    stepCount--;
                }

                // 좌←
                else if (keyInput.Key == ConsoleKey.LeftArrow)
                {
                    // 만약
                    if (maze[player.PlayerPosY, player.PlayerPosX].Type > maze[player.PlayerPosY, player.PlayerPosX - 1].Type)
                    {
                        // 이동할 위치가 item이면 이 전 타일은 floor로 강제
                        if (maze[player.PlayerPosY, player.PlayerPosX - 1].Type == (int)MazeCompo.item)
                        {
                            // 열매 점수 임시보관
                            tempScore = maze[player.PlayerPosY, player.PlayerPosX - 1].Score;

                            tempLocation = maze[player.PlayerPosY, player.PlayerPosX].Type;
                            maze[player.PlayerPosY, player.PlayerPosX - 1].Type = tempLocation;
                            maze[player.PlayerPosY, player.PlayerPosX].Type = (int)MazeCompo.floor; // 이동 전 타일도 바닥으로 바꿨음
                        }
                        else
                        {
                            tempLocation = maze[player.PlayerPosY, player.PlayerPosX].Type;
                            maze[player.PlayerPosY, player.PlayerPosX] = maze[player.PlayerPosY, player.PlayerPosX - 1];
                            maze[player.PlayerPosY, player.PlayerPosX - 1].Type = tempLocation;
                        }
                    }
                    else
                    {
                        stepCount++;
                    }
                    stepCount--;
                }

                // 우→
                else if (keyInput.Key == ConsoleKey.RightArrow)
                {
                    if (maze[player.PlayerPosY, player.PlayerPosX].Type > maze[player.PlayerPosY, player.PlayerPosX + 1].Type)
                    {
                        // 이동할 위치가 item이면 이 전 타일은 floor로 강제
                        if (maze[player.PlayerPosY, player.PlayerPosX + 1].Type == (int)MazeCompo.item)
                        {
                            // 열매 점수 임시보관
                            tempScore = maze[player.PlayerPosY, player.PlayerPosX + 1].Score;

                            tempLocation = maze[player.PlayerPosY, player.PlayerPosX].Type;
                            maze[player.PlayerPosY, player.PlayerPosX + 1].Type = tempLocation;
                            maze[player.PlayerPosY, player.PlayerPosX].Type = (int)MazeCompo.floor; // 이동 전 타일도 바닥으로 바꿨음
                        }
                        else
                        {
                            tempLocation = maze[player.PlayerPosY, player.PlayerPosX].Type;
                            maze[player.PlayerPosY, player.PlayerPosX] = maze[player.PlayerPosY, player.PlayerPosX + 1];
                            maze[player.PlayerPosY, player.PlayerPosX + 1].Type = tempLocation;
                        }
                    }
                    else
                    {
                        stepCount++;
                    }
                    stepCount--;
                }
                // 'z'일경우 먹음
                else if (keyInput.Key == ConsoleKey.Z)
                {
                    if (maze[player.PlayerPosY, player.PlayerPosX].Score != 0)
                    {
                        player.PlayerScore += tempScore;
                        maze[player.PlayerPosY, player.PlayerPosX].Score = 0;
                        tempScore = maze[player.PlayerPosY, player.PlayerPosX].Score;
                        eatCount++;
                    }
                }
                // 열매를 세 개 다 먹었다면
                if (eatCount == 3)
                {
                    // ending();
                    // return;
                }
            }
        }
    }
}