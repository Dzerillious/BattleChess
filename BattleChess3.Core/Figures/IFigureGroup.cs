namespace BattleChess3.Core.Figures
{
    public interface IFigureGroup
    {
        string ShownName { get; }
        IFigureType[] GroupFigures { get; }
    }
}
