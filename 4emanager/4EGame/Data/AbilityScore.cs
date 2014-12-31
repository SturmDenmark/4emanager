namespace Game.Data
{
    using System.Collections.Generic;
    using System.Linq;

    public class AbilityScore
    {
        public AbilityScore()
        {
            this.AbilityAdds = new List<int>();
        }

        public ICollection<int> AbilityAdds { get; private set; }

        public int Base { get; set; }

        public int Score { get { return this.AbilityAdds.Sum(); } }

        public Ability Ability { get; set; }

        public int Modifier
        {
            get
            {
                return (this.Score - 10) / 2;
            }
        }
    }
}