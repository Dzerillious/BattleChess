using BattleChess3.Game.Board;

namespace BattleChess3.UI.ViewModel;

public sealed class NoneTileViewModel : TileViewModel
{
    public static readonly NoneTileViewModel Instance = new();

    private NoneTileViewModel() : base(new Position(-1, -1))
    {
    }
}