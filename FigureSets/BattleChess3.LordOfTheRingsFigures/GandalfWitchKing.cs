using System;
using BattleChess3.Core.Figures;
using BattleChess3.Core.Models;
using BattleChess3.LordOfTheRingsFigures.Localization;

namespace BattleChess3.LordOfTheRingsFigures
{
    public class GandalfWitchKing : IFigureType
    {
        public static readonly GandalfWitchKing Instance = new GandalfWitchKing();
        public string ShownName => CurrentLocalization.Instance["GandalfWitchKing_Name"];
        public string UnitName => $"{nameof(LordOfTheRingsFigureGroup)}.{nameof(GandalfWitchKing)}";
        public string GroupName => nameof(LordOfTheRingsFigureGroup);
        public FigureTypes UnitTypes => FigureTypes.Foot;
        public FigureTypes Bonus => FigureTypes.Nothing;
        public FigureTypes AntiBonus => FigureTypes.Nothing;
        public double Attack => 100;
        public double Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 9;
        public string Description => CurrentLocalization.Instance["GandalfWitchKing_Description"];
        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}