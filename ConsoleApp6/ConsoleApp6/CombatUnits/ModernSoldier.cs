using ConsoleApp6.Weapons;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp6
{
    class ModernSoldier
    {
        IWeapon weapon;

        public ModernSoldier(IWeapon weapon)
        {
            this.weapon = weapon;
        }

        public void ChangeWeapon(IWeapon weapon)
        {
            this.weapon = weapon;
        } 

        public void Attack(string target)
        {
            this.weapon.Hit(target);
        }

    }
}
