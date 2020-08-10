using System;
using BattleChess3.Core.Figures;
using BattleChess3.Core.Models;
using BattleChess3.DefaultFigures.Localization;

namespace BattleChess3.DefaultFigures
{
    public class Empty : IFigureType
    {
        public static Empty Instance { get; } = new Empty();
        public string ShownName => CurrentLocalization.Instance["Empty_Name"];
        public string UnitName => $"{nameof(DefaultFigureGroup)}.{nameof(Empty)}";
        public string GroupName => nameof(DefaultFigureGroup);
        public FigureTypes UnitTypes => FigureTypes.Nothing;
        public FigureTypes Bonus => FigureTypes.Nothing;
        public FigureTypes AntiBonus => FigureTypes.Nothing;
        public int Attack => 0;
        public int Defence => 1000;
        public bool MovingAttack => false;
        public string Description { get; } = CurrentLocalization.Instance["Empty_Description"];
        public int Cost => 0;
        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}