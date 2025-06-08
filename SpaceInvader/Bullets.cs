using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvader
{
    class Bullets
    {
        public Bullets()
        {
        }

        public void BulletsSpawnen(Space geefMap, int bulletX, int bulletY)
        {
            geefMap.GetGameMap()[bulletX - 1, bulletY] = "*  "; 
        }
    }
}