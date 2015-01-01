namespace DnDGame.Data
{
    public class AbilityScore
    {
        public int Base { get; set; }

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