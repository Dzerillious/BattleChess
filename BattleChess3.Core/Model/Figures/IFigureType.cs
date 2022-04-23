using System;
using System.Collections.Generic;

namespace BattleChess3.Core.Model.Figures;

public interface IFigureType
{
    /// <summary>
    /// Name shown in menus and helps
    /// </summary>
    string ShownName { get; }

    /// <summary>
    /// Gets description of unit
    /// </summary>
    string Description { get; }

    /// <summary>
    /// Gets name of unit
    /// </summary>
    string UnitName { get; }
    
    /// <summary>
    /// Gets full hp of unit
    /// </summary>
    double FullHp { get; }
    
    /// <summary>
    /// Gets attack
    /// </summary>
    double Attack { get; }

    /// <summary>
    /// Gets type of unit
    /// </summary>
    FigureTypes UnitType { get; }

    /// <summary>
    /// Gets cost of unit
    /// </summary>
    int Cost { get; }
    
    /// <summary>
    /// Images of player with id
    /// </summary>
    Dictionary<int, Uri> ImageUris { get; }

    /// <summary>
    /// Calculation of attack against another unit type.
    ///   - Considers other unit defence.
    /// </summary>
    double AttackCalculation(IFigureType figureType);

    /// <summary>
    /// Calculation of defence against another unit type.
    /// </summary>
    double DefenceCalculation(IFigureType figureType);

    /// <summary>
    /// Checks if can attack at target position.
    /// </summary>
    bool CanAttack(ITile from, ITile to, ITile[] board);

    /// <summary>
    /// Attack action
    /// </summary>
    void AttackAction(ITile from, ITile to, ITile[] board);

    /// <summary>
    /// Checks if can move to target position.
    /// </summary>
    bool CanMove(ITile from, ITile to, ITile[] board);

    /// <summary>
    /// Move action
    /// </summary>
    void MoveAction(ITile from, ITile to, ITile[] board);

    /// <summary>
    /// Chain of positions of move (if can go at first position of chain, check next one)
    /// </summary>
    Position[][] GetMoveChains(Position from, ITile[] board);

    /// <summary>
    /// Chain of positions of move (if can attack first position of chain, check next one)
    /// </summary>
    Position[][] GetAttackChains(Position from, ITile[] board);
}
