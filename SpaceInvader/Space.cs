using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvader
{
    class Space
    {
        private int mapX = 20;
        private int mapY = 16;

        private string[,] gameMap;

        private bool damaged = false;

        public Space()
        {
            gameMap = new string[mapX, mapY];
        }

        public int GetMapX()
        {
            return mapX;
        }
        public int GetMapY()
        {
            return mapY;
        }

        public string[,] GetGameMap()
        {
            return gameMap;
        }

        public void CreateMap()
        {
            for(int x = 0; x < mapX; x++)
            {
                for(int y = 0; y < mapY - 1; y++)
                {
                    gameMap[x, y] = "   ";

                    if (x ==  3 && y ==3 || x == 3 && y == 6 || x == 3 && y == 9 || x == 3 && y == 12)
                    {
                        gameMap[x, y] = "■■ ";
                    }
                    if (x == GetMapX() - 1)
                    {
                        gameMap[x, y] = "___";
                    }
                }
            }
        }
        public void SetDamaged(bool geefDamaged)
        {
            damaged = geefDamaged;
        }
        public void PrintMap(Speler geefSpelerPosition)
        {
            for (int x = 0; x < mapX; x++)
            {
                for (int y = 0; y < mapY; y++)
                {
                    if (damaged)
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(gameMap[x, y]);
                    }
                    else
                    {
                        if (x > 3)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(gameMap[x, y]);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(gameMap[x, y]);
                        }
                    }
                }
                Console.WriteLine();
            }
            gameMap[geefSpelerPosition.GetPlayerX(), geefSpelerPosition.GetPlayerY()] = "Y  ";
            damaged = false;
            Console.ForegroundColor = ConsoleColor.Red;

            if (geefSpelerPosition.GetHealth() >= 3)
            {
                Console.WriteLine("   " + (char)3 + "   " + (char)3 + "   " + (char)3);
            }
            if (geefSpelerPosition.GetHealth() == 2)
            {
                Console.WriteLine("   " + (char)3 + "   " + (char)3);
            }
            if (geefSpelerPosition.GetHealth() == 1)
            {
                Console.WriteLine("   " + (char)3 + "   ");
            }
        }
    }
}
