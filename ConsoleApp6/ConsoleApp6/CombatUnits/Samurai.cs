using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ConsoleApp6
{
    class Samurai
    {
        readonly IWeapon weapon;
        public Samurai (IWeapon weapon)
        {
            this.weapon = weapon;
        }

        public void Attack(string target)
        {
            this.weapon.Hit(target);
        }
    }
}
