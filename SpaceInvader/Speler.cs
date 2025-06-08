using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvader
{
    class Speler
    {
        private int playerX = 2;
        private int playerY = 8;
        private int bulletX;
        private int bulletY;

        private bool bulletMove = false;
        private bool bulletVerwijderen = false;

        private int health = 3;

        private bool gameloop = false;
        private bool startScreen = true;
        private bool gameOver = false;
        public Speler()
        {
        }
        public int GetPlayerX()
        {
            return playerX;
        }
        public int GetPlayerY()
        {
            return playerY;
        }
        public bool GetGameLoop()
        {
            return gameloop;
        }
        public bool GetStartScreen()
        {
            return startScreen;
        }
        public bool GetGameOver()
        {
            return gameOver;
        }

        public int GetHealth()
        {
            return health;
        }

        public void SetGameOver(bool geefTrue)
        {
            gameOver = geefTrue;
        }

        public void Inputs(Space geefMap)
        {
            ConsoleKey bewegen;
            if (bulletVerwijderen)
            {
                geefMap.GetGameMap()[bulletX, bulletY] = "   ";
                bulletVerwijderen = false;
            }
            if (bulletMove)
            {
                geefMap.GetGameMap()[bulletX, bulletY] = "   ";
            }

            if (Console.KeyAvailable)
            {
                geefMap.GetGameMap()[playerX, playerY] = "   ";

                bewegen = Console.ReadKey().Key;

                if (bewegen == ConsoleKey.RightArrow && GetPlayerY() != 13 && startScreen == false)
                {
                    playerY = playerY + 1;
                    if (geefMap.GetGameMap()[GetPlayerX(), GetPlayerY()].Contains("*"))
                    {
                        Damage(geefMap);
                    }
                }
                if (bewegen == ConsoleKey.LeftArrow && playerY != 1 && startScreen == false)
                {
                    playerY = playerY - 1;
                    if (geefMap.GetGameMap()[GetPlayerX(), GetPlayerY()].Contains("*")) 
                    {
                        Damage(geefMap);
                    }
                }
                if (bewegen == ConsoleKey.Enter)
                {
                    gameloop = true;
                    startScreen = false;
                }
                if (bewegen == ConsoleKey.Spacebar && startScreen == false && !geefMap.GetGameMap()[playerX + 1, playerY].Contains("■") && bulletMove == false)
                {
                    bulletX = playerX;
                    bulletY = playerY;
                    bulletMove = true;
                }
            }
            if (bulletMove)
            {
                geefMap.GetGameMap()[bulletX + 1, bulletY] = "|  ";
                bulletX++;
                if (geefMap.GetGameMap()[bulletX + 1, bulletY].Contains("M") && !geefMap.GetGameMap()[bulletX - 1, bulletY].Contains("M"))
                {
                    bulletMove = false;
                    bulletVerwijderen = true;
                    geefMap.GetGameMap()[bulletX + 1, bulletY] = "   ";
                }
                if (geefMap.GetGameMap()[bulletX + 1, bulletY].Contains("*") || geefMap.GetGameMap()[bulletX, bulletY].Contains("*")) 
                {
                    bulletMove = false;
                    bulletVerwijderen = true;
                }
                if (bulletX >= 18)
                {
                    bulletMove = false;
                    bulletVerwijderen = true;
                }
            }
        }
        public void Damage(Space geefMap)
        {
            health -= 1;
            geefMap.SetDamaged(true);
            if (health <= 0)
            {
                gameOver = true;
                EndGame();
            }
        }
        public void EndGame()
        {
            gameloop = false;
        }

    }
}