using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static privateConsoleProject.Program;

namespace privateConsoleProject
{
    class Rendering
    {
            public void RenderMaze(int distance, ref Player player, ref TileType[,] maze)
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
                            if (maze[i, j].Score > 3)
                            {
                                Console.Write("Φ");
                            }
                            else if (maze[i, j].Score > 3)
                            {
                                Console.Write("Φ");
                            }
                            else if (maze[i, j].Score > 2.3)
                            {
                                Console.Write("Φ");
                            }
                            else if (maze[i, j].Score > 1.7)
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
        }
        // 시야 제한 로직
        public double CalculateDistance(int playerPosX, int playerPosY, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow(playerPosX - x2, 2) + Math.Pow(playerPosY - y2, 2));
        }
    }
}
