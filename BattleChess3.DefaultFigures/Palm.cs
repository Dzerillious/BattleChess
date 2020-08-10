using System;
using BattleChess3.Core.Figures;
using BattleChess3.Core.Models;
using BattleChess3.DefaultFigures.Localization;

namespace BattleChess3.DefaultFigures
{
    public class Palm : IFigureType
    {
        public static readonly Palm Instance = new Palm();
        public string ShownName => CurrentLocalization.Instance["Palm_Name"];
        public string UnitName => $"{nameof(DefaultFigureGroup)}.{nameof(Palm)}";
        public string GroupName => nameof(DefaultFigureGroup);
        public FigureTypes UnitTypes => FigureTypes.Object;
        public FigureTypes Bonus => FigureTypes.Nothing;
        public FigureTypes AntiBonus => FigureTypes.Nothing;
        public int Attack => 0;
        public int Defence => -50;
        public bool MovingAttack => false;
        public string Description => CurrentLocalization.Instance["Palm_Description"];
        public int Cost => 0;
        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}