namespace DnDGame.Data
{
    public class SavingThrowScore
    {
        public SavingThrowScore(SavingThrow savingThrow, bool primary)
        {
            this.SavingThrow = savingThrow;
            this.IsPrimary = primary;
        }

        public bool IsPrimary { get; private set; }

        public SavingThrow SavingThrow { get; private set; }

        public Class Class { get; set; }

        public int Score { get { return this.CalculateScore(); } }

        private int CalculateScore()
        {
            int result;
            if (this.IsPrimary == false)
            {
                result = this.Class.Level / 3;
            }
            else
            {
                return 2 + this.Class.Level / 2;
            }

            return result;
        }
    }
}