using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvader
{
    class Enemies
    {
        private bool rechts = false;
        private bool links = true;
        private bool rechtsCheck = false;
        private bool linksCheck = true;
        private bool boven = false;

        private int mapIsEmpty = 0;
        private bool spawnWave1 = true;
        private bool spawnWave2 = true;
        private bool spawnWave3 = true;

        private bool gameWon = false;

        private int timer;
        private int timerWave = 6;
        private int timerBullet;
        private int timerShoot = 3;

        Random rand = new Random();
        private int randomInt;
        private int randomMin = 1;
        private int randomMax = 6;
        public Enemies()
        {
        }

        public bool GetGameWon()
        {
            return gameWon;
        }

        public void Wave1(Space geefMap)
        {
            for (int x = 14; x < 19; x++)
            {
                for (int y = 5; y < 10; y++)
                {
                    geefMap.GetGameMap()[x, y] = "M  "; 
                }
            }
            spawnWave1 = false;
        }

        public void Wave2(Space geefMap)
        {
            for (int x = 14; x < 19; x++)
            {
                for (int y = 5; y < 11; y++)
                {
                    geefMap.GetGameMap()[x, y] = "M  "; 
                }
            }
            timerWave -= 1;
            spawnWave2 = false;
            randomMax -= 1;
            timerShoot -= 1;
        }

        public void Wave3(Space geefMap)
        {
            for (int x = 17; x < 19; x++)
            {
                for (int y = 4; y < 12; y++)
                {
                    geefMap.GetGameMap()[x, y] = "M  "; 
                }
            }
            timerWave -= 1;
            spawnWave3 = false;
        }
        public void EndGame(Speler player)
        {
            player.EndGame();

        }
        public void EnemiesBewegen(Space geefMap, Bullets geefBullets, Speler player)
        {
            mapIsEmpty = 0;
            for (int z = 0; z < geefMap.GetMapX() - 1; z++)
            {
                for (int y = 0; y < geefMap.GetMapY() - 1; y++)
                {
                    MovementChecks(geefMap, z, y);

                    WaveSpawner(geefMap, player, z, y);

                    Shieten(geefMap, geefBullets, z, y);

                    BulletMove(geefMap, player, z, y);

                    EndGameLoss(geefMap, player, y);


                }
            }
            if (boven)
            {
                BovenBewegen(geefMap);
            }
            if (links)
            {
                LinksBewegen(geefMap);
            }
            if (rechts)
            {
                RechtsBewegen(geefMap);
            }
        }

        public void MovementChecks(Space geefMap, int z, int y)
        {
            if (y <= 1 && geefMap.GetGameMap()[z, y].Contains("M")) 
            {
                boven = true;
                links = false;
                rechts = true;
                rechtsCheck = true;
                linksCheck = false;
            }
            if (y >= geefMap.GetMapY() - 3 && geefMap.GetGameMap()[z, y].Contains("M")) 
            {
                boven = true;
                rechts = false;
                links = true;
                linksCheck = true;
                rechtsCheck = false;
            }
            if (y < geefMap.GetMapY() - 3 && geefMap.GetGameMap()[z, y].Contains("M") && linksCheck == true) 
            {
                rechts = false;
                links = true;
            }
            if (y > 1 && geefMap.GetGameMap()[z, y].Contains("M") && rechtsCheck == true)
            {
                rechts = true;
                links = false;
            }
        }

        public void BovenBewegen(Space geefMap)
        {
            for (int a = 0; a < geefMap.GetMapX(); a++)
            {
                for (int b = 0; b < geefMap.GetMapY() - 1; b++)
                {
                    if (geefMap.GetGameMap()[a, b].Contains("M") && timer >= timerWave - 1)  
                    {

                        geefMap.GetGameMap()[a - 1, b] = "M  ";
                        geefMap.GetGameMap()[a, b] = "   ";
                    }
                }
            }
            boven = false;
        }

        public void LinksBewegen(Space geefMap)
        {
            for (int a = 0; a < geefMap.GetMapX(); a++)
            {
                for (int b = 0; b < geefMap.GetMapY() - 1; b++)
                {
                    if (geefMap.GetGameMap()[a, b].Contains("M") && timer >= timerWave - 1) 
                    {
                        geefMap.GetGameMap()[a, b - 1] = "M  ";  
                        geefMap.GetGameMap()[a, b] = "   ";
                    }
                }
            }
            links = false;
        }

        public void RechtsBewegen(Space geefMap)
        {
            bool eenKeerEnemyVerdwijnen;
            bool eenKeerEnemyBewegen;
            for (int a = 0; a < geefMap.GetMapX(); a++)
            {
                eenKeerEnemyVerdwijnen = true;
                eenKeerEnemyBewegen = true;
                for (int b = 0; b < geefMap.GetMapY() - 1; b++)
                {
                    if (geefMap.GetGameMap()[a, b].Contains("M") && timer >= timerWave - 1) 
                    {
                        if (geefMap.GetGameMap()[a, b + 1].Contains("   ") && eenKeerEnemyBewegen)
                        {
                            geefMap.GetGameMap()[a, b + 1] = "M  "; 
                            eenKeerEnemyBewegen = false;
                        }
                        if (geefMap.GetGameMap()[a, b - 1].Contains("   ") && eenKeerEnemyVerdwijnen || geefMap.GetGameMap()[a, b - 1].Contains("|"))
                        {
                            geefMap.GetGameMap()[a, b] = "   ";
                            eenKeerEnemyVerdwijnen = false;
                        }
                    }
                }

            }
            rechts = false;
        }

        public void WaveSpawner(Space geefMap, Speler player, int z, int y)
        {
            if (!geefMap.GetGameMap()[z, y].Contains("M"))
            {
                mapIsEmpty += 1;
                if (spawnWave1 && mapIsEmpty >= 285)
                {
                    Wave1(geefMap);
                    mapIsEmpty = 0;
                }
                if (spawnWave1 == false && spawnWave2 && mapIsEmpty >= 285)
                {
                    Wave2(geefMap);
                    mapIsEmpty = 0;
                }
                if (spawnWave1 == false && spawnWave2 == false && spawnWave3 && mapIsEmpty >= 285)
                {
                    Wave3(geefMap);
                    mapIsEmpty = 0;
                }
                if (spawnWave1 == false && spawnWave2 == false && spawnWave3 == false && mapIsEmpty >= 285)
                {
                    gameWon = true;
                    EndGame(player);
                }
            }
        }

        public void EndGameLoss(Space geefMap, Speler player, int y)
        {
            if (geefMap.GetGameMap()[3, y].Contains("M")) 
            {
                player.SetGameOver(true);
                player.EndGame();
            }
        }

        public void Shieten(Space geefMap, Bullets geefBullets, int z, int y)
        {
            if (geefMap.GetGameMap()[z, y].Contains("M") && timer >= timerWave - 1)
            {
                if (!geefMap.GetGameMap()[z - 1, y].Contains("M")) 
                {
                    if (!geefMap.GetGameMap()[z - 2, y + 1].Contains("M")) 
                    {
                        if (!geefMap.GetGameMap()[z - 2, y - 1].Contains("M"))
                        {
                            randomInt = rand.Next(randomMin, randomMax);
                            if (randomInt == 1)
                            {
                                EnemiesSchieten(geefMap, geefBullets, z - 1, y);
                            }
                        }
                    }
                }
            }
        }

        public void BulletMove(Space geefMap, Speler player, int z, int y)
        {
            if (timerBullet >= timerShoot - 1)
            {
                if (geefMap.GetGameMap()[z, y].Contains("*"))
                {
                    if (geefMap.GetGameMap()[z - 1, y].Contains("Y"))
                    {
                        player.Damage(geefMap);
                    }
                    geefMap.GetGameMap()[z - 1, y] = "*  ";
                    geefMap.GetGameMap()[z, y] = "   ";
                    if (z <= 2 || geefMap.GetGameMap()[z - 2, y].Contains("■"))
                    {
                        geefMap.GetGameMap()[z - 1, y] = "   ";
                    }
                }

            }
        }

        public void Timer(int geefFrames)
        {
            timer += geefFrames;
            timerBullet += geefFrames;
            if (timer >= timerWave)
            {
                timer = 0;
            }
            if (timerBullet >= timerShoot)
            {
                timerBullet = 0;
            }
        }

        public void EnemiesSchieten(Space geefMap, Bullets geefBullets, int x, int y)
        {
            geefBullets.BulletsSpawnen(geefMap, x, y);
        }
    }
}