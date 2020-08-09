using System;
using BattleChess3.Core;
using BattleChess3.Core.Figures;

namespace BattleChess3.DefaultFigures
{
    public class Stone : IFigureType
    {
        public static readonly Stone Instance = new Stone();
        public string ShownName => "Stone";
        public string UnitName => "Default_Stone";
        public string GroupName => "Default";
        public FigureType UnitType => FigureType.Object;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 0;
        public int Defence => 1000;
        public bool MovingAttack => false;
        public string Description => "Stone tile, where you cannot go. It cannot move and belongs to no one";
        public int Cost => 0;
        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}