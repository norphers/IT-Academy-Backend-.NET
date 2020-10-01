using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp6
{
    class Shuriken : IWeapon
    {
        public void Hit(string target)
        {
            Console.WriteLine("Pierced {0}'s armor.", target);
        }
    }
}
