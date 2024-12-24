using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using static privateConsoleProject.Program;
namespace privateConsoleProject
{
    enum MazeCompo
    {
        floor, item, me, step, wall, staticWall = 99
    }
    struct TileType
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
    struct Player
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
            GameManager.Banner();
            GameManager.Setting();
            GameManager.SelectMenu();

            while (StaticFields.gameStart)
            {
                // V 첫 게임
                if (StaticFields.again == false)
                {
                    StaticFields.playCount++;
                    StaticFields.keyInput = Console.ReadKey(true);
                    if (StaticFields.keyInput.Key == ConsoleKey.Z)
                    {
                        Console.Clear();
                        GameManager.Banner();
                        StartGame(ref StaticFields.gameStart);
                        StaticFields.again = true;
                    }
                    else if (StaticFields.keyInput.Key == ConsoleKey.Q)
                    {
                        StaticFields.playCount--;
                        StaticFields.gameStart = false;
                    }
                }
                // V 맵 재생성 후
                else
                {
                    Console.Clear();
                    GameManager.Banner();
                    StartGame(ref StaticFields.gameStart);
                }
            }
            GameManager.QuitGame();
        }

        // 게임 시작
        static bool StartGame(ref bool reStart)
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
            StaticFields.isRorQ = false;

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

            // 맵 랜더링
            Rendering.RenderMazeLimitedView(distance, ref player, ref maze);

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

                Rendering.RenderMazeLimitedView(distance, ref player, ref maze);

                // 열매를 세 개 다 먹었다면
                if (eatCount == 3 || stepCount == 0)
                {
                    Rendering.ShowSteps(StaticFields.posX, StaticFields.posY, ref maze);
                    Rendering.RenderMazeAll(distance, player, maze);
                    DashBoard.Recap(distance, stepCount / 2, player.PlayerScore, eatCount);
                    StaticFields.recordMemo.Add(player.PlayerScore);

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
                            GameManager.Ending();
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