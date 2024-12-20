using System;
using System.Collections.Generic;
using Microsoft.Win32;
using static privateConsoleProject.Program;
namespace privateConsoleProject
{
    public enum MazeCompo
    {
        floor, item, me, step, wall, staticWall = 99
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
    // ▼ 메인 ▼
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo keyInput;

            GameManager.Banner();
            GameManager.Setting();
            GameManager.SelectMenu();

            while (StaticFields.gameStart)
            {
                if(StaticFields.again == false)
                {
                    keyInput = Console.ReadKey(true);
                    StaticFields.again = true;
                    if (keyInput.Key == ConsoleKey.Z)
                    {
                        Console.Clear();
                        GameManager.Banner();
                        StartGame(ref StaticFields.gameStart);
                    }
                    else if (keyInput.Key == ConsoleKey.Q)
                    {
                        return;
                    }
                }
                else
                {
                    Console.Clear();
                    GameManager.Banner();
                    StartGame(ref StaticFields.gameStart);
                }
            }
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("끝");
            //GameManager.QuitGame();
        }
        
        // 게임 시작
        static bool StartGame(ref bool reStart)
        {
            // 플레이어 생성
            Player player = new Player();

            // 미로 변수
            int distance = 25;
            Wall wall = new Wall();
            TileType[,] maze = new TileType[distance, distance];

            // 임시보관 변수
            float tempLocation;
            float tempScore = 0;

            // 열매 생성
            Fruit fruit = new Fruit();

            // 카운트 변수
            int stepCount = 200;
            int eatCount = 0;
            Queue<int> posX = new Queue<int>();
            Queue<int> posY = new Queue<int>();

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
            StaticFields.itemCount = fruit.MakeRandomFruit(distance, maze);

            // 상황판
            DashBoard.InGameFrame(distance);
            DashBoard.GameRule(distance);

            // 플레이
            while (stepCount > 0)
            {
                // 맵 랜더링
                Rendering.RenderMazeLimitedView(distance, ref player, ref maze);

                // 현재 정보
                DashBoard.ShowInformation(distance, stepCount / 2, tempScore, player.PlayerScore, eatCount);
                

                // 키 입력
                var keyInput = Console.ReadKey(true);

                // 'R' 키로 맵 재생성
                if (keyInput.Key == ConsoleKey.R)
                {
                    reStart = true;
                    return reStart;
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
                            posX.Enqueue(player.PlayerPosX);
                            posY.Enqueue(player.PlayerPosY);
                        }
                        else
                        {
                            tempLocation = maze[player.PlayerPosY, player.PlayerPosX].Type;
                            maze[player.PlayerPosY, player.PlayerPosX] = maze[player.PlayerPosY - 1, player.PlayerPosX];
                            maze[player.PlayerPosY - 1, player.PlayerPosX].Type = tempLocation;
                            posX.Enqueue(player.PlayerPosX);
                            posY.Enqueue(player.PlayerPosY);
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
                            posX.Enqueue(player.PlayerPosX);
                            posY.Enqueue(player.PlayerPosY);
                        }
                        else
                        {
                            tempLocation = maze[player.PlayerPosY, player.PlayerPosX].Type;
                            maze[player.PlayerPosY, player.PlayerPosX] = maze[player.PlayerPosY + 1, player.PlayerPosX];
                            maze[player.PlayerPosY + 1, player.PlayerPosX].Type = tempLocation;
                            posX.Enqueue(player.PlayerPosX);
                            posY.Enqueue(player.PlayerPosY);
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
                            posX.Enqueue(player.PlayerPosX);
                            posY.Enqueue(player.PlayerPosY);
                        }
                        else
                        {
                            tempLocation = maze[player.PlayerPosY, player.PlayerPosX].Type;
                            maze[player.PlayerPosY, player.PlayerPosX] = maze[player.PlayerPosY, player.PlayerPosX - 1];
                            maze[player.PlayerPosY, player.PlayerPosX - 1].Type = tempLocation;
                            posX.Enqueue(player.PlayerPosX);
                            posY.Enqueue(player.PlayerPosY);
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
                            posX.Enqueue(player.PlayerPosX);
                            posY.Enqueue(player.PlayerPosY);
                        }
                        else
                        {
                            tempLocation = maze[player.PlayerPosY, player.PlayerPosX].Type;
                            maze[player.PlayerPosY, player.PlayerPosX] = maze[player.PlayerPosY, player.PlayerPosX + 1];
                            maze[player.PlayerPosY, player.PlayerPosX + 1].Type = tempLocation;
                            posX.Enqueue(player.PlayerPosX);
                            posY.Enqueue(player.PlayerPosY);
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
                if (eatCount == 3 || stepCount == 0)
                {
                    Rendering.ShowSteps(posX, posY, ref maze);
                    Rendering.RenderMazeAll(distance, player, maze);
                    DashBoard.Recap(distance, stepCount / 2, player.PlayerScore, eatCount);
                    break;
                }
            }
            Console.SetCursorPosition(0, Console.WindowHeight);
            reStart = false;
            return reStart;
        }
    }
}