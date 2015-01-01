namespace RulesetE4
{
    using System.Collections.ObjectModel;

    using DnDGame.Data;

    public class AbilityScoreE4 : AbilityScore
    {
        public AbilityScoreE4()
        {
            this.AbilityAdds = new Collection<int>();
        }

        public Collection<int> AbilityAdds { get; private set; }
    }
}
