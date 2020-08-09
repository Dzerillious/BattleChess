namespace BattleChess3.Core.Figures
{
    public interface IFigureGroup
    {
        string Name { get; }
        IFigureType[] GroupFigures { get; }
    }
}
