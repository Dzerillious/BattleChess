using BattleChess3.Game.Figures;
using BattleChess3.Game.Players;

namespace BattleChess3.Game.Board;

public class PovTile : ITile
{
    private readonly ITile _innerTile;
    private readonly Player _player;

    public PovTile(ITile innerTile, Player player)
    {
        _innerTile = innerTile;
        _player = player;
    }

    public Position Position => _innerTile.Position.GetPlayerPOVPosition(_player);
    public Position AbsolutePosition => _innerTile.Position;

    public Figure Figure
    {
        get => _innerTile.Figure;
        set => _innerTile.Figure = value;
    }

    public ITile GetPovTile(Player player)
    {
        return new PovTile(this, player);
    }
}