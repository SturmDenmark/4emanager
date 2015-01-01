namespace DnDGame.Data
{
    public class Skill
    {
        public Skill(string name, Ability ability)
        {
            this.Name = name;
            this.Ability = ability;
        }

        public string Name { get; private set; }

        public Ability Ability { get; private set; }

        public Character Character { get; set; }

        public bool ClassSkill { get; set; }

        public int Total
        {
            get
            {
                var result = this.Misc + (this.ClassSkill == true ? this.Rank : this.Rank / 2);
                if (this.Character != null)
                {
                    result += this.Character.GetAbilityScore(this.Ability).Modifier;
                }

                return result;
            }
        }

        public int Rank { get; set; }

        public int Misc { get; set; }
    }
}