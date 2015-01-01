namespace DnDGame.Data
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public abstract class Class
    {
        protected Class(string className, SavingThrowScore fortitude, SavingThrowScore reflex, SavingThrowScore will)
        {
            this.Name = className;
            this.ClassSkills = new Collection<Skill>();

            this.Fortitude = fortitude;
            this.Fortitude.Class = this;

            this.Reflex = reflex;
            this.Reflex.Class = this;

            this.Will = will;
            this.Will.Class = this;
        }

        public string Name { get; private set; }

        public int Level { get; set; }

        public Collection<Skill> ClassSkills { get; protected set; }

        public abstract int BaseAttack { get; }

        public SavingThrowScore Fortitude { get; private set; }

        public SavingThrowScore Reflex { get; private set; }

        public SavingThrowScore Will { get; private set; }
    }
}