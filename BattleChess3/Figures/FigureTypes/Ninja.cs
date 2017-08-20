using System;
using BattleChess3.Figures.AttackingTypes;
using BattleChess3.Properties;

namespace BattleChess3.Figures.FigureTypes
{
    public class Ninja : SimpleAttackFigure, IFigure
    {
        public string UnitName => Resource.Ninja;
        public string UnitType => Resource.Foot;
        public string Bonus => Resource.Foot;
        public string AntiBonus => Resource.Mount;
        public int Attack => 50;
        public int Defence => 0;
        public bool MovingWhileAttacking => true;
        public bool LongRanged => false;
        public int Cost => 1;
        public string Description => "Ninja is secret warior" +
                                     " and with his diagonal moves can he" +
                                     " easily suprise enemy.";

        private readonly Position[] _avaibleMoves =
        {
            new Position(1, 1),
            new Position(-1, 1),
            new Position(-1, -1),
            new Position(1, -1)
        };

        private readonly Position[] _avaibleAttacks =
        {
            new Position(0, 1),
            new Position(-1, 0),
            new Position(0, -1),
            new Position(1, 0)
        };

        public Func<Position, Position, bool> CanMove => (figurePosition, movedPosition) =>
            CanMoveSimple(figurePosition, movedPosition, _avaibleMoves);
        public Func<Position, Position, bool> CanAttack => (figurePosition, attackedPosition) =>
            CanAttackSimple(figurePosition, attackedPosition, _avaibleAttacks);
    }
}
