using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace privateConsoleProject
{
    class Fruit
    {
        int randomItemPlace;
        float randomScore;
        int floorCount = 0;
        
        public void FloorCount(int distance, TileType[,] maze)
        {
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
        }

        public void MakeRandomFruit(int distance, TileType[,] maze)
        {
            for (int i = 0; i < distance; i++)
            {
                for (int j = 0; j < distance; j++)
                {
                    // 만약 특정 칸이 floor 타일인 곳에
                    if (maze[i, j].Type == (int)MazeCompo.floor)
                    {
                        randomItemPlace = StaticFields.random.Next(0, floorCount / distance);
                        randomScore = (float)StaticFields.random.Next(50, 351) / 100;

                        // randomItemPlace가 0이 나오면 아이템 타일로 교체
                        if (randomItemPlace == 0)
                        {
                            maze[i, j].Type = (int)MazeCompo.item;
                            maze[i, j].Score = randomScore;
                        }
                    }
                }
            }
        }
    }
}
