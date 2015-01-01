namespace DnDGame
{
    using DnDGame.Data;

    public interface ICharacterImporter
    {
        Character Import(string filename);
    }
}