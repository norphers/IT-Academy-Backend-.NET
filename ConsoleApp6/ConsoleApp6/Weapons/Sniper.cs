using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp6.Weapons
{
    class Sniper : IWeapon
    {
        public void Hit(string target)
        {
            Console.WriteLine("{0} get headshot.", target);
        }

    }
}
