namespace BattleChess3.Core.Model.Figures;

public interface IFigureGroup
{
    /// <summary>
    /// Shown name of figure group
    /// </summary>
    string ShownName { get; }
    
    /// <summary>
    /// Figure types of group
    /// </summary>
    IFigureType[] FigureTypes { get; }
}
