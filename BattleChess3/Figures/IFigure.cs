using System;

namespace BattleChess3.Figures
{
    /// <summary>
    /// Interface for figures types
    /// </summary>
    public interface IFigure
    {
        /// <summary>
        /// Name of unit
        /// </summary>
        string UnitName { get; }
        
        /// <summary>
        /// Type of unit
        /// </summary>
        string UnitType { get; }
        
        /// <summary>
        /// Bonus against type of unit
        /// </summary>
        string Bonus { get; }
        
        /// <summary>
        /// Antibonus against type of unit
        /// </summary>
        string AntiBonus { get; }
        
        /// <summary>
        /// Attack
        /// </summary>
        int Attack { get; }
        
        /// <summary>
        /// Defence
        /// </summary>
        int Defence { get; }
        
        /// <summary>
        /// If move while attacking
        /// </summary>
        bool MovingWhileAttacking { get; }
        
        /// <summary>
        /// If unit is long ranged
        /// </summary>
        bool LongRanged { get; }
        
        /// <summary>
        /// Cost of unit
        /// </summary>
        int Cost { get; }
        
        /// <summary>
        /// Description of unit
        /// </summary>
        string Description { get; }

        /// <summary>
        /// PicturePath of unit
        /// </summary>
        string PicturePath { get; }

        /// <summary>
        /// Check if can move on position
        /// </summary>
        Func<Position, Position, bool> CanMove { get; }
        
        /// <summary>
        /// Check if can attack on position
        /// </summary>
        Func<Position, Position, bool> CanAttack { get; }
    }
}
