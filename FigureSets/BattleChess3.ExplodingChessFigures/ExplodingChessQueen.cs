using BattleChess3.Game.Board;

namespace BattleChess3.ExplodingChessFigures;

public class ExplodingChessQueen : IExplodingChessFigureType, IExplodingChessFigureTypeWithChainedAttackMoves
{
    Position[] IExplodingChessFigureTypeWithChainedAttackMoves.AttackMoveDirections { get; } =
    {
        (-1, -1), (-1, 0), (-1, 1),
        (0, -1), (0, 1),
        (1, -1), (1, 0), (1, 1)
    };
}