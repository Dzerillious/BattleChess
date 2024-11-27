using BattleChess3.Game.Board;

namespace BattleChess3.SpyFigures;

public class SpyQueen : ISpyFigureType, ISpyFigureTypeWithChainedAttackMoves
{
    Position[] ISpyFigureTypeWithChainedAttackMoves.AttackMoveDirections { get; } =
    {
        (-1, -1), (-1, 0), (-1, 1),
        (0, -1), (0, 1),
        (1, -1), (1, 0), (1, 1)
    };
}