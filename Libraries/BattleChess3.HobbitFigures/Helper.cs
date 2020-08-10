using System;
using BattleChess3.Core.Figures;
using BattleChess3.Core.Models;
using BattleChess3.HobbitFigures.Localization;

namespace BattleChess3.HobbitFigures
{
    public class Helper : IFigureType
    {
        public static readonly Helper Instance = new Helper();
        public string ShownName => CurrentLocalization.Instance["Helper_Name"];
        public string UnitName => $"{nameof(HobbitFigureGroup)}.{nameof(Helper)}";
        public string GroupName => nameof(HobbitFigureGroup);
        public FigureTypes UnitTypes => FigureTypes.Foot;
        public FigureTypes Bonus => FigureTypes.Nothing;
        public FigureTypes AntiBonus => FigureTypes.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 3;
        public string Description => CurrentLocalization.Instance["Helper_Name"];
        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}