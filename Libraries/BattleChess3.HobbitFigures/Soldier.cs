using System;
using BattleChess3.Core.Figures;
using BattleChess3.Core.Models;
using BattleChess3.HobbitFigures.Localization;

namespace BattleChess3.HobbitFigures
{
    public class Soldier : IFigureType
    {
        public static readonly Soldier Instance = new Soldier();
        public string ShownName => CurrentLocalization.Instance["Soldier_Name"];
        public string UnitName => $"{nameof(HobbitFigureGroup)}.{nameof(Soldier)}";
        public string GroupName => nameof(HobbitFigureGroup);
        public FigureTypes UnitTypes => FigureTypes.Foot;
        public FigureTypes Bonus => FigureTypes.Nothing;
        public FigureTypes AntiBonus => FigureTypes.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 1;
        public string Description => CurrentLocalization.Instance["Soldier_Name"];
        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}