using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace privateConsoleProject
{
    static class PlayerAction
    {
        static public void MoveUp(ref Player player, ref TileType[,] maze, ref int stepCount)
        {
            // 만약
            if (maze[player.PlayerPosY, player.PlayerPosX].Type > maze[player.PlayerPosY - 1, player.PlayerPosX].Type)
            {
                // 이동할 위치가 item이면 이 전 타일은 floor로 강제
                if (maze[player.PlayerPosY - 1, player.PlayerPosX].Type == (int)MazeCompo.item)
                {
                    // 열매 점수 임시보관
                    StaticFields.tempScore = maze[player.PlayerPosY - 1, player.PlayerPosX].Score;

                    StaticFields.tempLocation = maze[player.PlayerPosY, player.PlayerPosX].Type;
                    maze[player.PlayerPosY - 1, player.PlayerPosX].Type = StaticFields.tempLocation;
                    maze[player.PlayerPosY, player.PlayerPosX].Type = (int)MazeCompo.floor; // 이동 전 타일도 바닥으로 바꿨음
                    StaticFields.posX.Enqueue(player.PlayerPosX);
                    StaticFields.posY.Enqueue(player.PlayerPosY);
                }
                else
                {
                    StaticFields.tempLocation = maze[player.PlayerPosY, player.PlayerPosX].Type;
                    maze[player.PlayerPosY, player.PlayerPosX] = maze[player.PlayerPosY - 1, player.PlayerPosX];
                    maze[player.PlayerPosY - 1, player.PlayerPosX].Type = StaticFields.tempLocation;
                    StaticFields.posX.Enqueue(player.PlayerPosX);
                    StaticFields.posY.Enqueue(player.PlayerPosY);
                }
            }
            else // 못간다면
            {
                stepCount++; // 카운트 안내려감
            }
            stepCount--;
        }

        static public void MoveDown(ref Player player, ref TileType[,] maze, ref int stepCount)
        {
            // 만약
            if (maze[player.PlayerPosY, player.PlayerPosX].Type > maze[player.PlayerPosY + 1, player.PlayerPosX].Type)
            {
                // 이동할 위치가 item이면 이 전 타일은 floor로 강제
                if (maze[player.PlayerPosY + 1, player.PlayerPosX].Type == (int)MazeCompo.item)
                {
                    // 열매 점수 임시보관
                    StaticFields.tempScore = maze[player.PlayerPosY + 1, player.PlayerPosX].Score;

                    StaticFields.tempLocation = maze[player.PlayerPosY, player.PlayerPosX].Type;
                    maze[player.PlayerPosY + 1, player.PlayerPosX].Type = StaticFields.tempLocation;
                    maze[player.PlayerPosY, player.PlayerPosX].Type = (int)MazeCompo.floor; // 이동 전 타일도 바닥으로 바꿨음
                    StaticFields.posX.Enqueue(player.PlayerPosX);
                    StaticFields.posY.Enqueue(player.PlayerPosY);
                }
                else
                {
                    StaticFields.tempLocation = maze[player.PlayerPosY, player.PlayerPosX].Type;
                    maze[player.PlayerPosY, player.PlayerPosX] = maze[player.PlayerPosY + 1, player.PlayerPosX];
                    maze[player.PlayerPosY + 1, player.PlayerPosX].Type = StaticFields.tempLocation;
                    StaticFields.posX.Enqueue(player.PlayerPosX);
                    StaticFields.posY.Enqueue(player.PlayerPosY);
                }
            }
            else
            {
                stepCount++;
            }
            stepCount--;
        }

        static public void MoveLeft(ref Player player, ref TileType[,] maze, ref int stepCount)
        {
            // 만약
            if (maze[player.PlayerPosY, player.PlayerPosX].Type > maze[player.PlayerPosY, player.PlayerPosX - 1].Type)
            {
                // 이동할 위치가 item이면 이 전 타일은 floor로 강제
                if (maze[player.PlayerPosY, player.PlayerPosX - 1].Type == (int)MazeCompo.item)
                {
                    // 열매 점수 임시보관
                    StaticFields.tempScore = maze[player.PlayerPosY, player.PlayerPosX - 1].Score;

                    StaticFields.tempLocation = maze[player.PlayerPosY, player.PlayerPosX].Type;
                    maze[player.PlayerPosY, player.PlayerPosX - 1].Type = StaticFields.tempLocation;
                    maze[player.PlayerPosY, player.PlayerPosX].Type = (int)MazeCompo.floor; // 이동 전 타일도 바닥으로 바꿨음
                    StaticFields.posX.Enqueue(player.PlayerPosX);
                    StaticFields.posY.Enqueue(player.PlayerPosY);
                }
                else
                {
                    StaticFields.tempLocation = maze[player.PlayerPosY, player.PlayerPosX].Type;
                    maze[player.PlayerPosY, player.PlayerPosX] = maze[player.PlayerPosY, player.PlayerPosX - 1];
                    maze[player.PlayerPosY, player.PlayerPosX - 1].Type = StaticFields.tempLocation;
                    StaticFields.posX.Enqueue(player.PlayerPosX);
                    StaticFields.posY.Enqueue(player.PlayerPosY);
                }
            }
            else
            {
                stepCount++;
            }
            stepCount--;
        }

        static public void MoveRight(ref Player player, ref TileType[,] maze, ref int stepCount)
        {
            if (maze[player.PlayerPosY, player.PlayerPosX].Type > maze[player.PlayerPosY, player.PlayerPosX + 1].Type)
            {
                // 이동할 위치가 item이면 이 전 타일은 floor로 강제
                if (maze[player.PlayerPosY, player.PlayerPosX + 1].Type == (int)MazeCompo.item)
                {
                    // 열매 점수 임시보관
                    StaticFields.tempScore = maze[player.PlayerPosY, player.PlayerPosX + 1].Score;

                    StaticFields.tempLocation = maze[player.PlayerPosY, player.PlayerPosX].Type;
                    maze[player.PlayerPosY, player.PlayerPosX + 1].Type = StaticFields.tempLocation;
                    maze[player.PlayerPosY, player.PlayerPosX].Type = (int)MazeCompo.floor; // 이동 전 타일도 바닥으로 바꿨음
                    StaticFields.posX.Enqueue(player.PlayerPosX);
                    StaticFields.posY.Enqueue(player.PlayerPosY);
                }
                else
                {
                    StaticFields.tempLocation = maze[player.PlayerPosY, player.PlayerPosX].Type;
                    maze[player.PlayerPosY, player.PlayerPosX] = maze[player.PlayerPosY, player.PlayerPosX + 1];
                    maze[player.PlayerPosY, player.PlayerPosX + 1].Type = StaticFields.tempLocation;
                    StaticFields.posX.Enqueue(player.PlayerPosX);
                    StaticFields.posY.Enqueue(player.PlayerPosY);
                }
            }
            else
            {
                stepCount++;
            }
            stepCount--;
        }

        // 열매 먹기
        static public void EatFruit(ref Player player, ref TileType[,] maze, ref int eatCount)
        {
            if (maze[player.PlayerPosY, player.PlayerPosX].Score != 0)
            {
                player.PlayerScore += StaticFields.tempScore;
                maze[player.PlayerPosY, player.PlayerPosX].Score = 0;
                StaticFields.tempScore = maze[player.PlayerPosY, player.PlayerPosX].Score;
                eatCount++;
            }
        }
    }
}
