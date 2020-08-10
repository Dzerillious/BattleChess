using System;
using BattleChess3.ChessFigures.Localization;
using BattleChess3.Core.Figures;
using BattleChess3.Core.Models;

namespace BattleChess3.ChessFigures
{
    public class King : IFigureType
    {
        public static readonly King Instance = new King();
        public string ShownName => CurrentLocalization.Instance["King_Name"];
        public string UnitName => $"{nameof(ChessFigureGroup)}.{nameof(King)}";
        public string GroupName => nameof(ChessFigureGroup);
        public FigureTypes UnitTypes => FigureTypes.Special;
        public FigureTypes Bonus => FigureTypes.Nothing;
        public FigureTypes AntiBonus => FigureTypes.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 0;
        public string Description => CurrentLocalization.Instance["King_Description"];
        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}