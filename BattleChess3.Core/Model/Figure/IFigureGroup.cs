namespace BattleChess3.Core.Model.Figure
{
    public interface IFigureGroup
    {
        string ShownName { get; }
        IFigureType[] GroupFigures { get; }
    }
}
