using BattleChess3.Core.Models;

namespace BattleChess3.Core.Figures.AttackingTypes
{
    public interface IMove
    {
        public bool CanMove(Tile tile, Tile[] board);
    }
}