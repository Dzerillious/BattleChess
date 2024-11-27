using BattleChess3.Game.Board;

namespace BattleChess3.DoubleChessFigures;

public class SingleBishop : IDoubleChessFigureTypeWithChainedAttackMoves
{
    Position[] IDoubleChessFigureTypeWithChainedAttackMoves.AttackMoveDirections { get; } =
    {
        (-1, -1), (-1, 1),
        (1, -1), (1, 1)
    };
}