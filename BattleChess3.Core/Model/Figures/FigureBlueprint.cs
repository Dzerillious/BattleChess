namespace BattleChess3.Core.Model.Figures;

public class FigureBlueprint
{
    public int PlayerId { get; set; } = Player.Neutral.Id;
    public string UnitName { get; set; } = NoneFigure.Instance.UnitName;
    public double Hp { get; set; } = 100;

    // JSON serializable
    public FigureBlueprint()
    {
    }
    
    public FigureBlueprint(int id, IFigureType figureType, double hp)
    {
        PlayerId = id;
        UnitName = figureType.UnitName;
        Hp = hp;
    }

    public FigureBlueprint(int id, IFigureType figureType)
    {
        PlayerId = id;
        UnitName = figureType.UnitName;
        Hp = figureType.FullHp;
    }

    public static implicit operator FigureBlueprint((int id, IFigureType figure) pair)
        => new FigureBlueprint(pair.id, pair.figure);

    public override string ToString() => $"{UnitName}{PlayerId}";
}
