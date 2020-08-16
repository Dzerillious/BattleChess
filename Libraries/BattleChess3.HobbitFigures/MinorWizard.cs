using System;
using BattleChess3.Core.Figures;
using BattleChess3.Core.Models;
using BattleChess3.HobbitFigures.Localization;

namespace BattleChess3.HobbitFigures
{
    public class MinorWizard : IFigureType
    {
        public static readonly MinorWizard Instance = new MinorWizard();
        public string ShownName => CurrentLocalization.Instance["MinorWizard_Name"];
        public string UnitName => $"{nameof(HobbitFigureGroup)}.{nameof(MinorWizard)}";
        public string GroupName => nameof(HobbitFigureGroup);
        public FigureTypes UnitTypes => FigureTypes.Foot;
        public FigureTypes Bonus => FigureTypes.Nothing;
        public FigureTypes AntiBonus => FigureTypes.Nothing;
        public double Attack => 100;
        public double Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 5;
        public string Description => CurrentLocalization.Instance["MinorWizard_Description"];
        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}