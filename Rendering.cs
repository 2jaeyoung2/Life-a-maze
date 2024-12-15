//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using static privateConsoleProject.Program;

//namespace privateConsoleProject
//{
//    public struct TileType
//    {
//        public float type;
//        public float score;
//    }
//    class Rendering
//    {
//        TileType[,] maze = new TileType[25, 25];


//        public void RenderMaze(int distance, Player player)
//        {
//            Console.SetCursorPosition(0, 12);
//            for (int i = 0; i < distance; i++)
//            {
//                Console.Write("　");

//                for (int j = 0; j < distance; j++)
//                {
//                    // 시야 제한 로직 추가
//                    double distanceFromPlayer = CalculateDistance(player.playerPosX, player.playerPosY, j, i);

//                    if (distanceFromPlayer <= 3) // 반지름 n의 원 내부만 보이도록
//                    {
//                        //길
//                        if (maze[i, j].type == (float)MazeCompo.floor)
//                        {
//                            Console.ForegroundColor = ConsoleColor.DarkGray;
//                            Console.Write("□");
//                            Console.ResetColor();
//                        }
//                        //플레이어
//                        else if (maze[i, j].type == (float)MazeCompo.me)
//                        {
//                            Console.Write("●");
//                            player.playerPosY = i;
//                            player.playerPosX = j;
//                        }
//                        //벽
//                        else if (maze[i, j].type == (float)MazeCompo.wall || maze[i, j].type == (float)MazeCompo.staticWall)
//                        {
//                            Console.ForegroundColor = ConsoleColor.Red;
//                            Console.Write("▩");
//                            Console.ResetColor();
//                        }
//                        //아이템
//                        else if (maze[i, j].type == (float)MazeCompo.item)
//                        {
//                            if (maze[i, j].score > 3)
//                            {
//                                Console.Write("Φ");
//                            }
//                            else if (maze[i, j].score > 3)
//                            {
//                                Console.Write("Φ");
//                            }
//                            else if (maze[i, j].score > 2.3)
//                            {
//                                Console.Write("Φ");
//                            }
//                            else if (maze[i, j].score > 1.7)
//                            {
//                                Console.Write("Φ");
//                            }
//                            else
//                            {
//                                Console.Write("Φ");
//                            }
//                        }
//                    }
//                    else
//                    {
//                        // 시야 밖은 공백으로 처리
//                        Console.Write("　");
//                    }
//                }
//                Console.WriteLine();
//            }


//        }
//        // 시야 제한 로직
//        public double CalculateDistance(int playerPosX, int playerPosY, int x2, int y2)
//        {
//            return Math.Sqrt(Math.Pow(playerPosX - x2, 2) + Math.Pow(playerPosY - y2, 2));
//        }
//    }
//}
