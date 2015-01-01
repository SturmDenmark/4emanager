namespace RulesetE35Test
{
    using DnDGame.Data;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using RulesetE35;
    using RulesetE35.Class;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ExportCharacterTest()
        {
            var character = new Character { Charisma = new AbilityScore { Base = 10, Ability = Ability.Charisma }, Constitution = new AbilityScore { Base = 12, Ability = Ability.Constitution }, Dexteriry = new AbilityScore { Base = 14, Ability = Ability.Dexterity }, Intelligence = new AbilityScore { Base = 16, Ability = Ability.Intelligence }, Strength = new AbilityScore { Base = 18, Ability = Ability.Strength }, Wisdom = new AbilityScore { Base = 20, Ability = Ability.Wisdom } };
            character.Classes.Add(new FighterE35());
            var manager = new CharacterManager();

            manager.Export(@"c:\temp\fighter35E.xml", character);
        }

        [TestMethod]
        public void ImportCharacterTest()
        {
            var manager = new CharacterManager();

            var character = manager.Import(@"c:\temp\fighter35E.xml");
        }
    }
}
