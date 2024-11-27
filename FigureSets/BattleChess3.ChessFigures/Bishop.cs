using BattleChess3.Game.Board;

namespace BattleChess3.ChessFigures;

public class Bishop : IChessFigureType, IFigureTypeWithChainedAttackMoves
{
    Position[] IFigureTypeWithChainedAttackMoves.AttackMoveDirections { get; } =
    {
        (-1, -1), (-1, 1),
        (1, -1), (1, 1),
    };
}