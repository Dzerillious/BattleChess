namespace BattleChess3.Core.Figures
{
    public interface IFIgureGroup
    {
        string Name { get; }
        IFigure[] GroupFigures { get; }
    }
}
