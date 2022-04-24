using System;
using System.IO;
using BattleChess3.Core.Model.Figures;

namespace BattleChess3.Core.Model;

// JSON serializable
public class MapBlueprint
{
    public static readonly MapBlueprint None = new();
    public string MapPath { get; set; } = string.Empty;
    public string PreviewPath { get; set; } = string.Empty;
    public Uri PreviewUri => new Uri(Path.GetFullPath(PreviewPath));
    public int StartingPlayer { get; set; } = 0;
    public FigureBlueprint[] Figures { get; set; } = Array.Empty<FigureBlueprint>();
}
