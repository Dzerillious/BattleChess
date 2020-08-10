using System;
using BattleChess3.Core.Figures;
using BattleChess3.Core.Models;
using BattleChess3.LordOfTheRingsFigures.Localization;

namespace BattleChess3.LordOfTheRingsFigures
{
    public class AragornSauron : IFigureType
    {
        public static readonly AragornSauron Instance = new AragornSauron();
        public string ShownName => CurrentLocalization.Instance["AragornSauron_Name"];
        public string UnitName => $"{nameof(LordOfTheRingsFigureGroup)}.{nameof(AragornSauron)}";
        public string GroupName => nameof(LordOfTheRingsFigureGroup);
        public FigureTypes UnitTypes => FigureTypes.Foot;
        public FigureTypes Bonus => FigureTypes.Nothing;
        public FigureTypes AntiBonus => FigureTypes.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 0;
        public string Description => CurrentLocalization.Instance["AragornSauron_Description"];
        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}