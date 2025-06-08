using System;

namespace SpaceInvader
{
    class Program
    {
        static void Main(string[] args)
        {
            Space map = new Space();
            Speler player = new Speler();
            Enemies enemiesSpawnen = new Enemies();
            Bullets kogels = new Bullets();

            bool startingGame = false;
            int startGame = 0;

            while (player.GetStartScreen())
            {
                player.GetStartScreen();
                player.Inputs(map);
                Console.WriteLine();
                Console.WriteLine("                       @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                Console.WriteLine("                       @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                Console.WriteLine("                       @@@@@@@@@@@@@@**//*@@@@@@@@@@@@@@@@@@@@@@@@@@@/////@@@@@@@@@@@@@@");
                Console.WriteLine("                       @@@@@@@@@@@@@@*****@@@@@@@@@@@@@@@@@@@@@@@@@@@*****@@@@@@@@@@@@@@");
                Console.WriteLine("                       @@@@@@@@@@@@@@*****@@@@@@@@@@@@@@@@@@@@@@@@@@@*****@@@@@@@@@@@@@@");
                Console.WriteLine("                       @@@@@@@@@@@@@@@@@@@*****&@@@@@@@@@@@@@@@/*****@@@@@@@@@@@@@@@@@@@");
                Console.WriteLine("                       @@@@@@@@@@@@@@@@@@@*****&@@@@@@@@@@@@@@@/*****@@@@@@@@@@@@@@@@@@@");
                Console.WriteLine("                       @@@@@@@@@@@@@@*************************************@@@@@@@@@@@@@@");
                Console.WriteLine("                       @@@@@@@@@@@@@@*************************************@@@@@@@@@@@@@@");
                Console.WriteLine("                       @@@@@@@@/**********@@@@@/***************&@@@@@**********%@@@@@@@@");
                Console.WriteLine("                       @@@@@@@@/**********@@@@@/***************&@@@@@**********%@@@@@@@@");
                Console.WriteLine("                       @@@***********************************************************@@@");
                Console.WriteLine("                       @@@***********************************************************@@@");
                Console.WriteLine("                       @@@*****&@@@@@*************************************@@@@@(*****@@@");
                Console.WriteLine("                       @@@*****&@@@@@*************************************@@@@@(*****@@@");
                Console.WriteLine("                       @@@*****&@@@@@*****@@@@@@@@@@@@@@@@@@@@@@@@@@@*****@@@@@(*****@@@");
                Console.WriteLine("                       @@@*****&@@@@@*****@@@@@@@@@@@@@@@@@@@@@@@@@@@*****@@@@@(*****@@@");
                Console.WriteLine("                       @@@@@@@@@@@@@@@@@@@***********@@@@@***********@@@@@@@@@@@@@@@@@@@");
                Console.WriteLine("                       @@@@@@@@@@@@@@@@@@@***********@@@@@***********@@@@@@@@@@@@@@@@@@@");
                Console.WriteLine("                       @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                Console.WriteLine("                       @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");

                Console.WriteLine("              _______  _______  _______  ______    _______    _______  _______  __   __  _______ ");
                Console.WriteLine("             |       ||       ||   _   ||    _ |  |       |  |       ||   _   ||  |_|  ||       |");
                Console.WriteLine("             |  _____||_     _||  |_|  ||   | ||  |_     _|  |    ___||  |_|  ||       ||    ___|");
                Console.WriteLine("             | |_____   |   |  |       ||   |_||_   |   |    |   | __ |       ||       ||   |___ ");
                Console.WriteLine("             |_____  |  |   |  |       ||    __  |  |   |    |   ||  ||       ||       ||    ___|");
                Console.WriteLine("              _____| |  |   |  |   _   ||   |  | |  |   |    |   |_| ||   _   || ||_|| ||   |___ ");
                Console.WriteLine("             |_______|  |___|  |__| |__||___|  |_|  |___|    |_______||__| |__||_|   |_||_______|");
                Console.WriteLine("                                              PRESS ENTER TO START");
                System.Threading.Thread.Sleep(1000);
                if (player.GetGameLoop())
                {
                    startingGame = true;
                }
                Console.Clear();
            }

            while (startingGame)
            {
                Console.WriteLine("    _______  _______  _______  ______    _______  ___   __    _  _______     _______  _______  __   __  _______ ");
                Console.WriteLine("   |       ||       ||   _   ||    _ |  |       ||   | |  |  | ||       |   |       ||   _   ||  |_|  ||       |");
                Console.WriteLine("   |  _____||_     _||  |_|  ||   | ||  |_     _||   | |   |_| ||    ___|   |    ___||  |_|  ||       ||    ___|");
                Console.WriteLine("   | |_____   |   |  |       ||   |_||_   |   |  |   | |       ||   | __    |   | __ |       ||       ||   |___ ");
                Console.WriteLine("   |_____  |  |   |  |       ||    __  |  |   |  |   | |  _    ||   ||  |   |   ||  ||       ||       ||    ___|");
                Console.WriteLine("    _____| |  |   |  |   _   ||   |  | |  |   |  |   | | | |   ||   |_| |   |   |_| ||   _   || ||_|| ||   |___ ");
                Console.WriteLine("   |_______|  |___|  |__| |__||___|  |_|  |___|  |___| |_|  |__||_______|   |_______||__| |__||_|   |_||_______|");
                System.Threading.Thread.Sleep(400);
                Console.Clear();
                System.Threading.Thread.Sleep(50);

                startGame += 1;

                if (startGame >= 6)
                {
                    startingGame = false;
                }
            }

            map.CreateMap();

            while (player.GetGameLoop())
            {
                Console.Clear();

                // First, update the timer for enemies
                enemiesSpawnen.Timer(1);

                // Then, spawn/move enemies
                enemiesSpawnen.EnemiesBewegen(map, kogels, player);

                // Then, handle player input
                player.Inputs(map);

                // Finally, print everything
                map.PrintMap(player);

                System.Threading.Thread.Sleep(50);
            }

            if (enemiesSpawnen.GetGameWon())
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("                      _______  _______  __   __  _______    _     _  _______  __    _ ");
                Console.WriteLine("                     |       ||   _   ||  |_|  ||       |  | | _ | ||       ||  |  | |");
                Console.WriteLine("                     |    ___||  |_|  ||       ||    ___|  | || || ||   _   ||   |_| |");
                Console.WriteLine("                     |   | __ |       ||       ||   |___   |       ||  | |  ||       |");
                Console.WriteLine("                     |   ||  ||       ||       ||    ___|  |       ||  |_|  ||  _    |");
                Console.WriteLine("                     |   |_| ||   _   || ||_|| ||   |___   |   _   ||       || | |   |");
                Console.WriteLine("                     |_______||__| |__||_|   |_||_______|  |__| |__||_______||_|  |__|");
                Console.ReadLine();
            }

            if (player.GetGameOver())
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("                   _______  _______  __   __  _______    _______  __   __  _______  ______   ");
                Console.WriteLine("                  |       ||   _   ||  |_|  ||       |  |       ||  | |  ||       ||    _ |  ");
                Console.WriteLine("                  |    ___||  |_|  ||       ||    ___|  |   _   ||  |_|  ||    ___||   | ||  ");
                Console.WriteLine("                  |   | __ |       ||       ||   |___   |  | |  ||       ||   |___ |   |_||_ ");
                Console.WriteLine("                  |   ||  ||       ||       ||    ___|  |  |_|  ||       ||    ___||    __  |");
                Console.WriteLine("                  |   |_| ||   _   || ||_|| ||   |___   |       | |     | |   |___ |   |  | |");
                Console.WriteLine("                  |_______||__| |__||_|   |_||_______|  |_______|  |___|  |_______||___|  |_|");
                Console.ReadLine();
            }
        }
    }
}