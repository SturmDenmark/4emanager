namespace DnDGame
{
    using DnDGame.Data;

    public interface ICharacterExporter
    {
        void Export(string filename, Character character);
    }
}