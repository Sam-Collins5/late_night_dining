using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_5.Weapon_Classes
{
    public class PepperSpray : BaseWeapon
    {
        //Properties
        public bool SprayLeft { get; private set; }
        public bool UsedSpray { get; private set; }

        //Constructors
        //Default
        public PepperSpray() : base (0, "Pepper Spray", "A small pink bejeweled canister full of spicy juice.")
        {
            SprayLeft = true;
            UsedSpray = false;
        }

        //Parameterized
        public PepperSpray(string name, string description) : base (0, name, description)
        {
            SprayLeft = true;
            UsedSpray = false;
        }

        //Copy
        public PepperSpray(PepperSpray other) : base (other.BonusDamage, other.Name, other.Description)
        { 
            SprayLeft = other.SprayLeft;
            UsedSpray = other.UsedSpray;
        }

        //Methods
        //Used when attacking to empty the spray bottle and bool a blinding effect in the Battle class.
        public void AttackedWithSpray()
        {
            SprayLeft = false;
            UsedSpray = true;
        }

        public void FillSpray()
        {
            SprayLeft = true;
            UsedSpray = false;
        }

        public override string ToString()
        {
            string sprayStr = string.Empty;
            sprayStr += $"\nName: {Name}";
            sprayStr += $"\nBonus Damage: {BonusDamage}";
            sprayStr += $"\nDescription: {Description}";
            sprayStr += $"\nSpray Left: {SprayLeft}";
            return sprayStr;
        }
    }
}
