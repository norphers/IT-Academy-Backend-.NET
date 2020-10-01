using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp6
{
    class Tank
    {
        readonly IWeapon weapon;
        public Tank(IWeapon weapon)
        {
            this.weapon = weapon;
        }

        public void Attack(string target)
        {
            this.weapon.Hit(target);
        }
    }
}
