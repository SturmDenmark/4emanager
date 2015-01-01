namespace RulesetE35.Class
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using DnDGame.Data;

    public class FighterE35 : ClassE35
    {
        public FighterE35()
            : base("Fighter", new SavingThrowScore(SavingThrow.Fortitude, true), new SavingThrowScore(SavingThrow.Reflex, false), new SavingThrowScore(SavingThrow.Will, false))
        {
            var skills = new Collection<Skill> { new Skill("Climb", Ability.Strength), new Skill("Craft", Ability.Intelligence), new Skill("Handle Animal", Ability.Charisma), new Skill("Intimidate", Ability.Charisma), new Skill("Jump", Ability.Strength), new Skill("Ride", Ability.Dexterity), new Skill("Swim", Ability.Strength) };
            this.ClassSkills = skills;
        }

        public override int BaseAttack
        {
            get
            {
                return this.Level;
            }
        }
    }
}