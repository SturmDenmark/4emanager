namespace DnDGame.Data
{
    using System.Collections.Generic;

    public class Power
    {
        public Power()
        {
            this.Weapons = new List<Weapon>();    
        }

        public string Name { get; set; }

        public string Flavor { get; set; }

        public string PowerUsage { get; set; }

        public string Display { get; set; }

        public string Keywords { get; set; }

        public string ActionType { get; set; }

        public string Target { get; set; }

        public string Attack { get; set; }

        public string Hit { get; set; }

        public string Level21 { get; set; }

        public string Trigger { get; set; }

        public string Effect { get; set; }

        public int Level { get; set; }

        public string PowerType { get; set; }

        public string Requirement { get; set; }

        public string Miss { get; set; }

        public List<Weapon> Weapons { get; private set; }

        public override string ToString()
        {
            return string.Format("Power '{0}'", this.Name);
        }
    }
}