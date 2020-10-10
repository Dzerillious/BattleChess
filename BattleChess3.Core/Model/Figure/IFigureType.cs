using System;
using System.Collections.Generic;

namespace BattleChess3.Core.Model.Figure
{
    /// <summary>
    /// Interface for figures types
    /// </summary>
    public interface IFigureType
    {
        /// <summary>
        /// Name shown in menus and helps
        /// </summary>
        string ShownName { get; }

        /// <summary>
        /// Gets Name of unit
        /// </summary>
        string UnitName { get; }
        
        /// <summary>
        /// Gets name of group of figures
        /// </summary>
        string GroupName { get; }

        /// <summary>
        /// Gets Type of unit
        /// </summary>
        FigureTypes UnitTypes { get; }

        /// <summary>
        /// Gets Bonus against type of unit
        /// </summary>
        FigureTypes Bonus { get; }

        /// <summary>
        /// Gets Anti bonus against type of unit
        /// </summary>
        FigureTypes AntiBonus { get; }

        /// <summary>
        /// Gets Attack
        /// </summary>
        double Attack { get; }

        /// <summary>
        /// Gets Defence
        /// </summary>
        double Defence { get; }

        /// <summary>
        /// Gets If move while attacking
        /// </summary>
        bool MovingAttack { get; }

        /// <summary>
        /// Gets Cost of unit
        /// </summary>
        int Cost { get; }

        /// <summary>
        /// Gets Description of unit
        /// </summary>
        string Description { get; }
        
        /// <summary>
        /// Images of player with id
        /// </summary>
        Dictionary<int, Uri> ImageUris { get; }

        /// <summary>
        /// Attack action
        /// </summary>
        void AttackAction(Position from, Position to, Tile[] board);

        /// <summary>
        /// Check if can move on position
        /// </summary>
        Position[][] GetMoveChains(Position from);

        /// <summary>
        /// Check if can attack on position
        /// </summary>
        Position[][] GetAttackChains(Position from);
    }
}