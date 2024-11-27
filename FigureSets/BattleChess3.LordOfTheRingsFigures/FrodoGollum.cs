using BattleChess3.Game.Board;

namespace BattleChess3.LordOfTheRingsFigures;

public class FrodoGollum : ILordOfTheRingsFigureType, IFigureTypeWithDifferentAttacksAndMoves
{
    Position[] IFigureTypeWithDifferentAttacksAndMoves.MovePositions { get; } =
    {
        (-1, 0), (1, 0), (0, -1), (0, 1)
    };

    Position[] IFigureTypeWithDifferentAttacksAndMoves.AttackPositions { get; } =
    {
        (-2, -2), (-1, -1),
        (-2, 2), (-1, 1),
        (2, -2), (1, -1),
        (2, 2), (1, 1),
    };
}