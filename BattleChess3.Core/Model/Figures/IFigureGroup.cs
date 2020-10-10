namespace BattleChess3.Core.Model.Figures
{
    public interface IFigureGroup
    {
        string ShownName { get; }
        IFigureType[] GroupFigures { get; }
    }
}
