namespace RulesetE35.Class
{
    using DnDGame.Data;

    public abstract class ClassE35 : Class
    {
        protected ClassE35(string className, SavingThrowScore fortitude, SavingThrowScore reflex, SavingThrowScore will)
            : base(className, fortitude, reflex, will)
        {
        }
    }
}
