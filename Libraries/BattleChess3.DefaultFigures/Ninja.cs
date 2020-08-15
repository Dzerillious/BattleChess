using System;
using BattleChess3.Core.Figures;
using BattleChess3.Core.Models;
using BattleChess3.DefaultFigures.Localization;

namespace BattleChess3.DefaultFigures
{
    public class Ninja : IFigureType
    {
        public static readonly Ninja Instance = new Ninja();
        public string ShownName => CurrentLocalization.Instance["Ninja_Name"];
        public string UnitName => $"{nameof(DefaultFigureGroup)}.{nameof(Ninja)}";
        public string GroupName => nameof(DefaultFigureGroup);
        public FigureTypes UnitTypes => FigureTypes.Foot;
        public FigureTypes Bonus => FigureTypes.Foot;
        public FigureTypes AntiBonus => FigureTypes.Mount;
        public int Attack => 50;
        public int Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 1;
        public string Description => CurrentLocalization.Instance["Ninja_Description"];
        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}