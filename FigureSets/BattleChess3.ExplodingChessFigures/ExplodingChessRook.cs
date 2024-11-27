using BattleChess3.Game.Board;

namespace BattleChess3.ExplodingChessFigures;

public class ExplodingChessRook : IExplodingChessFigureType, IExplodingChessFigureTypeWithChainedAttackMoves
{
    Position[] IExplodingChessFigureTypeWithChainedAttackMoves.AttackMoveDirections { get; } = 
    {
        (-1, 0), (1, 0), (0, -1), (0, 1),
    };
}