using BattleChess3.Game.Board;

namespace BattleChess3.LordOfTheRingsFigures;

public class GandalfWitchKing : ILordOfTheRingsFigureType, IFigureTypeWithDifferentAttacksAndMoves
{
    Position[] IFigureTypeWithDifferentAttacksAndMoves.MovePositions { get; } =
    {
        (-4, -2), (-4, 0), (-4, 2),
        (-3, -3), (-3, -1), (-3, 1), (-3, 3),
        (-2, -4), (-2, 0), (-2, 4),
        (-1, -3), (-1, -1), (-1, 1), (-1, 3),
        (0, -4), (0, -2), (0, 2), (0, 4),
        (1, -3), (1, -1), (1, 1), (1, 3),
        (2, -4), (2, 0), (2, 4),
        (3, -3), (3, -1), (3, 1), (3, 3),
        (4, -2), (4, 0), (4, 2)
    };

    Position[] IFigureTypeWithDifferentAttacksAndMoves.AttackPositions { get; } =
    {
        (-2, -1), (-2, 1),
        (-1, -2), (-1, 2),
        (1, -2), (1, 2),
        (2, -1), (2, 1)
    };
}