using BattleChess3.Game.Figures;

namespace BattleChess3.Maps;

// JSON serializable
public class MapBlueprint
{
    public static readonly MapBlueprint None = new();
    public string MapPath { get; init; } = string.Empty;
    public string PreviewPath { get; init; } = string.Empty;
    public Uri? PreviewUri => string.IsNullOrEmpty(PreviewPath) ? default : new Uri(Path.GetFullPath(PreviewPath));
    public int StartingPlayer { get; init; }
    public FigureIdentifier[] Figures { get; init; } = Array.Empty<FigureIdentifier>();
}