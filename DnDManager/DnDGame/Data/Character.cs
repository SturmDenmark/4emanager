namespace Game.Data
{
    using System.Collections.Generic;

    /// <summary>
    /// This class contains data on a 
    /// </summary>
    public class Character
    {
        public Character()
        {
            this.Powers = new List<Power>();
        }

        public string Name { get; set; }

        public string Player { get; set; }

        public int Level { get; set; }

        public AbilityScore Strength { get; set; }
        public AbilityScore Constitution { get; set; }
        public AbilityScore Dexteriry { get; set; }
        public AbilityScore Intelligence { get; set; }
        public AbilityScore Wisdom { get; set; }
        public AbilityScore Charisma { get; set; }

        public List<Power> Powers { get; set; }
    }
}
