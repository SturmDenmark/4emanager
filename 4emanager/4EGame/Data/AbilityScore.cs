namespace Game.Data
{
    using System;

    public class AbilityScore
    {
        public int Score { get; set; }

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