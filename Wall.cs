using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace privateConsoleProject
{
    class Wall
    {
        int randomWall;
        int randomDestroy;
        Random random = new Random();

        public void MakeField(int distance, TileType[,] maze)
        {
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
        }

        public void MakeRandomWall(int distance, TileType[,] maze)
        {
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
        }

        public void EliminateIsolation(int distance, TileType[,] maze)
        {
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
                                    }
                                    break;
                                case 1:
                                    maze[i - 1, j].type = (int)MazeCompo.floor;
                                    if (maze[i - 1, j].type != (int)MazeCompo.staticWall)
                                    {
                                        maze[i - 1, j].type = (int)MazeCompo.floor;
                                    }
                                    break;
                                case 2:
                                    maze[i, j + 1].type = (int)MazeCompo.floor;
                                    if (maze[i, j + 1].type != (int)MazeCompo.staticWall)
                                    {
                                        maze[i, j + 1].type = (int)MazeCompo.floor;
                                    }
                                    break;
                                case 3:
                                    maze[i, j - 1].type = (int)MazeCompo.floor;
                                    if (maze[i, j - 1].type != (int)MazeCompo.staticWall)
                                    {
                                        maze[i, j - 1].type = (int)MazeCompo.floor;
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
}
