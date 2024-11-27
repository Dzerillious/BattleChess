using BattleChess3.Game.Board;

namespace BattleChess3.DoubleChessFigures;

public class SingleKnight : IDoubleChessFigureTypeWithDifferentAttackMoves
{
    Position[] IDoubleChessFigureTypeWithDifferentAttackMoves.AttackMovePositions { get; } = 
    {
        (-2, -1), (-2, 1),
        (-1, -2), (-1, 2),
        (1, -2), (1, 2),
        (2, -1), (2, 1)
    };
}