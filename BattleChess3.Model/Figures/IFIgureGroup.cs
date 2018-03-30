namespace BattleChess3.Model.Figures
{
    public interface IFIgureGroup
    {
        string Name { get; }
        IFigure[] GroupFigures { get; }
    }
}
