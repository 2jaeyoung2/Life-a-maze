﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static privateConsoleProject.Program;

namespace privateConsoleProject
{
    static class Rendering
    {
        // 시야 제한 로직
        static public double CalculateDistance(int playerPosX, int playerPosY, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow(playerPosX - x2, 2) + Math.Pow(playerPosY - y2, 2));
        }

        // 시야제한 랜더링
        static public void RenderMazeLimitedView(int distance, ref Player player, ref TileType[,] maze)
        {
            Console.SetCursorPosition(0, 12);
            for (int i = 0; i < distance; i++)
            {
                Console.Write("　");

                for (int j = 0; j < distance; j++)
                {
                    // 시야 제한 로직 추가
                    double distanceFromPlayer = CalculateDistance(player.PlayerPosX, player.PlayerPosY, j, i);

                    if (distanceFromPlayer <= 3) // 반지름 n의 원 내부만 보이도록
                    {
                        //길
                        if (maze[i, j].Type == (float)MazeCompo.floor)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("□");
                            Console.ResetColor();
                        }
                        //플레이어
                        else if (maze[i, j].Type == (float)MazeCompo.me)
                        {
                            Console.Write("●");
                            player.PlayerPosY = i;
                            player.PlayerPosX = j;
                        }
                        //벽
                        else if (maze[i, j].Type == (float)MazeCompo.wall || maze[i, j].Type == (float)MazeCompo.staticWall)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("▩");
                            Console.ResetColor();
                        }
                        //아이템
                        else if (maze[i, j].Type == (float)MazeCompo.item)
                        {
                            Console.Write("Φ");
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
        }

        // 전체 렌더링
        static public void RenderMazeAll(int distance, Player player, TileType[,] maze)
        {
            Console.SetCursorPosition(0, 12);

            for (int i = 0; i < distance; i++)
            {
                Console.Write("　");

                for (int j = 0; j < distance; j++)
                {
                    //길
                    if (maze[i, j].Type == (float)MazeCompo.floor)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("□");
                        Console.ResetColor();

                    }
                    else if (maze[i, j].Type == (float)MazeCompo.step)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("□");
                        Console.ResetColor();
                    }
                    //플레이어
                    else if (maze[i, j].Type == (float)MazeCompo.me)
                    {
                        Console.Write("●");
                        player.PlayerPosY = i;
                        player.PlayerPosX = j;
                    }
                    //벽
                    else if (maze[i, j].Type == (float)MazeCompo.wall || maze[i, j].Type == (float)MazeCompo.staticWall)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("▩");
                        Console.ResetColor();
                    }
                    //아이템
                    else if (maze[i, j].Type == (float)MazeCompo.item)
                    {
                        Console.Write("Φ");
                    }
                }
                Console.WriteLine();
            }


        }

        // 발자국 남기기
        static public void RenderSteps(int distance, Player player, TileType[,] maze)
        {
            while(StaticFields.posX.Count > 0)
            {
                Console.SetCursorPosition(2 + StaticFields.posX.Dequeue() * 2, 12 + StaticFields.posY.Dequeue());
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Thread.Sleep(100);
                Console.Write("回");
                Console.ResetColor();
            }
        }
    }
}