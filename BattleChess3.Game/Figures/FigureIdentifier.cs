using BattleChess3.Game.Players;

namespace BattleChess3.Game.Figures;

public class FigureIdentifier
{
    // JSON serializable
    public FigureIdentifier()
    {
    }

    public FigureIdentifier(int playerId, string unitName)
    {
        FigureId = Guid.NewGuid();
        PlayerId = playerId;
        UnitName = unitName;
    }

    public FigureIdentifier(Figure figure)
    {
        FigureId = figure.Id;
        PlayerId = figure.Owner.Id;
        UnitName = figure.UnitName;
    }

    public FigureIdentifier(int id, IFigureType figureType)
    {
        FigureId = Guid.NewGuid();
        PlayerId = id;
        UnitName = figureType.UnitName;
    }

    public Guid FigureId { get; set; }
    public int PlayerId { get; set; } = Player.Neutral.Id;
    public string UnitName { get; set; } = NoneFigureType.Instance.UnitName;

    public override string ToString()
    {
        return $"{UnitName}{PlayerId}";
    }
}