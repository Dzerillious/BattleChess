using BattleChess3.Game.Board;

namespace BattleChess3.SpyFigures;

public class SpyBishop : ISpyFigureType, ISpyFigureTypeWithChainedAttackMoves
{
    Position[] ISpyFigureTypeWithChainedAttackMoves.AttackMoveDirections { get; } =
    {
        (-1, -1), (-1, 1),
        (1, -1), (1, 1),
    };
}