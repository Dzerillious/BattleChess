namespace BattleChess3.Game.Figures;

public interface IEmptyFigureType : IFigureType
{
    /// <summary>
    /// Value selected for historical reasons
    /// </summary>
    public const string EmptyUnitName = "DefaultFigureGroup.Empty";
    
    string IFigureType.UnitName => EmptyUnitName;
}