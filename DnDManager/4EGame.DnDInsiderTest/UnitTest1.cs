namespace _4EGame.DnDInsiderTest
{
    using System.Linq;

    using Game.DnDInsider.CharacterSheet;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var importer = new Importer();
            var character = importer.Import(@"C:\Users\mdr\Downloads\Hjalmar.xml");
            Assert.AreEqual("Hjalmar", character.Name);
            Assert.AreEqual(18, character.Strength.Base);
            Assert.AreEqual(20, character.Strength.Score);
            Assert.AreEqual(8, character.Intelligence.Score);
            Assert.AreEqual(10, character.Powers.Count);
            Assert.IsNotNull(character.Powers.FirstOrDefault(item => item.Name == "Heroic Effort"));
            Assert.AreEqual("You miss with an attack or fail a saving throw.", character.Powers.First(item => item.Name == "Heroic Effort").Trigger);
            Assert.AreEqual(1, character.Powers.First(item => item.Name == "Weight of Earth").Level);
            Assert.IsFalse(string.IsNullOrWhiteSpace(character.Powers.First(item => item.Name == "Form of Winter's Herald Attack").Requirement));
        }
    }
}
