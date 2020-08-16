using BattleChess3.Core.Models;

namespace BattleChess3.UI.Utilities
{
    public static class TileHelper
    {
        public static readonly Tile Invalid = new Tile
        {
            Figure = FigureHelper.Empty
        };
    }
}