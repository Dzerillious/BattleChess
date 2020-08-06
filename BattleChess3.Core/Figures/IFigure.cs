using System;
using BattleChess3.Core.Figures.FigureTypes;

namespace BattleChess3.Core.Figures
{
    /// <summary>
    /// Interface for figures types
    /// </summary>
    public interface IFigure
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
        /// Gets Type of unit
        /// </summary>
        FigureType UnitType { get; }

        /// <summary>
        /// Gets Bonus against type of unit
        /// </summary>
        FigureType Bonus { get; }

        /// <summary>
        /// Gets Anti bonus against type of unit
        /// </summary>
        FigureType AntiBonus { get; }

        /// <summary>
        /// Gets Attack
        /// </summary>
        int Attack { get; }

        /// <summary>
        /// Gets Defence
        /// </summary>
        int Defence { get; }

        /// <summary>
        /// Gets If move while attacking
        /// </summary>
        bool MovingWhileAttacking { get; }

        /// <summary>
        /// Gets Cost of unit
        /// </summary>
        int Cost { get; }

        /// <summary>
        /// Gets Description of unit
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets PictureBlackPath of unit
        /// </summary>
        string PictureBlackPath { get; }

        /// <summary>
        /// Gets PictureWhitekPath of unit
        /// </summary>
        string PictureWhitePath { get; }

        /// <summary>
        /// Gets PictureNeutralPath of unit
        /// </summary>
        string PictureNeutralPath { get; }

        /// <summary>
        /// Gets positions on which attack
        /// </summary>
        Position[] AttackPattern { get; }

        /// <summary>
        /// Check if can move on position
        /// </summary>
        Func<BaseFigure, BaseFigure, Func<Position, BaseFigure>, bool> CanMove { get; }

        /// <summary>
        /// Check if can attack on position
        /// </summary>
        Func<BaseFigure, BaseFigure, Func<Position, BaseFigure>, bool> CanAttack { get; }
    }
}