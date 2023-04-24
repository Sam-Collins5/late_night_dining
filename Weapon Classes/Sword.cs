using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_5.Weapon_Classes
{
    public class Sword : BaseWeapon
    {
        //Constructors
        //Default
        public Sword() : base (3, "Sword", "I don't know why this thing is here, but it looks sharp.")
        {

        }

        //Parameterized
        public Sword(string name, string description) : base(3, name, description)
        {

        }

        //Copy
        public Sword(Stick other) : base(other.BonusDamage, other.Name, other.Description)
        {

        }

        //Methods
        public override string ToString()
        {
            string SwordStr = string.Empty;
            SwordStr += $"\nName: {Name}";
            SwordStr += $"\nBonus Damage: {BonusDamage}";
            SwordStr += $"\nDescription: {Description}";
            return SwordStr;
        }
    }
}
