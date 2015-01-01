namespace RulesetE35
{
    using System.IO;
    using System.Xml.Serialization;

    using DnDGame;
    using DnDGame.Data;

    using Newtonsoft.Json;

    public class CharacterManager : ICharacterImporter, ICharacterExporter
    {
        public Character Import(string filename)
        {
            return JsonConvert.DeserializeObject<Character>(File.OpenText(filename).ReadToEnd());
        }

        public void Export(string filename, Character character)
        {
            var serializer = new XmlSerializer(character.GetType());

            serializer.Serialize(File.OpenWrite(filename), character);
        }
    }
}