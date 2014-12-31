namespace Game
{
    using Game.Data;

    public interface ICharacterImporter
    {
        Character Import(string filename);
    }
}