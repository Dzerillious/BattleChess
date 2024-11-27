using BattleChess3.Game.Board;

namespace BattleChess3.ChessFigures;

public class Queen : IChessFigureType, IFigureTypeWithChainedAttackMoves
{
    Position[] IFigureTypeWithChainedAttackMoves.AttackMoveDirections { get; } =
    {
        (-1, -1), (-1, 0), (-1, 1),
        (0, -1), (0, 1),
        (1, -1), (1, 0), (1, 1)
    };
}