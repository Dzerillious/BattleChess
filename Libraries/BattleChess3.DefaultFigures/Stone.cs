using System;
using BattleChess3.Core.Figures;
using BattleChess3.Core.Models;
using BattleChess3.DefaultFigures.Localization;

namespace BattleChess3.DefaultFigures
{
    public class Stone : IFigureType
    {
        public static readonly Stone Instance = new Stone();
        public string ShownName => CurrentLocalization.Instance["Stone_Name"];
        public string UnitName => $"{nameof(DefaultFigureGroup)}.{nameof(Stone)}";
        public string GroupName => nameof(DefaultFigureGroup);
        public FigureTypes UnitTypes => FigureTypes.Object;
        public FigureTypes Bonus => FigureTypes.Nothing;
        public FigureTypes AntiBonus => FigureTypes.Nothing;
        public int Attack => 0;
        public int Defence => int.MaxValue;
        public bool MovingAttack => false;
        public string Description => CurrentLocalization.Instance["Stone_Description"];
        public int Cost => 0;
        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}