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
                if (StaticFields.firstGame == true)
                {
                    StaticFields.keyInput = Console.ReadKey(true);
                    if (StaticFields.keyInput.Key == ConsoleKey.Z)
                    {
                        Console.Clear();
                        GameManager.Banner();
                        GameManager.StartGame(ref StaticFields.gameStart);
                        StaticFields.firstGame = false;
                    }
                    else if (StaticFields.keyInput.Key == ConsoleKey.Q)
                    {
                        StaticFields.playCount--;
                        StaticFields.gameStart = false;
                    }
                }
                // V 두 번째 게임부터
                else
                {
                    Console.Clear();
                    GameManager.Banner();
                    GameManager.StartGame(ref StaticFields.gameStart);
                }
            }
            GameManager.QuitGame();
        }
        
    }
}