using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace privateConsoleProject
{
    class Fruit
    {
        Random random = new Random();
        int randomItemPlace;
        float randomScore;
        public void MakeRandomFruit(int distance, int floorCount, TileType[,] maze)
        {
            for (int i = 0; i < distance; i++)
            {
                for (int j = 0; j < distance; j++)
                {
                    if (maze[i, j].Type == (int)MazeCompo.floor)
                    {
                        randomItemPlace = random.Next(0, floorCount / distance);
                        randomScore = (float)random.Next(50, 351) / 100;

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
