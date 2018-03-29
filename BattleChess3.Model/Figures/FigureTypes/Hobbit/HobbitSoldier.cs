using BattleChess3.Model.Figures.AttackingTypes;
using BattleChess3.Shared;
using BattleChess3.Shared.Properties;
using System;
using System.IO;

namespace BattleChess3.Model.Figures.FigureTypes.Hobbit
{
    public class HobbitSoldier : SimpleFrontAttackFigure, IFigure
    {
        public string ShownName => "Soldier";
        public string UnitName => Resource.HobbitSoldier;
        public string UnitType => Resource.Foot;
        public string Bonus => Resource.Nothing;
        public string AntiBonus => Resource.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingWhileAttacking => true;
        public int Cost => 1;
        public string Description => "";

        public string PictureBlackPath => Directory.GetCurrentDirectory() + "\\Pictures\\Hobbit\\Spider.png";
        public string PictureWhitePath => Directory.GetCurrentDirectory() + "\\Pictures\\Hobbit\\Beregond.png";
        public string PictureNeutralPath => "";

        private readonly Position[] _avaibleFirstMoves =
        {
            new Position(0, 1),
            new Position(0, 2),
            new Position(0, -1),
            new Position(0, -2),
        };

        private readonly Position[] _avaibleMoves =
        {
            new Position(0, 1),
            new Position(0, -1),
        };

        private readonly Position[] _avaibleAttacks =
        {
            new Position(1, 1),
            new Position(-1, -1),
            new Position(-1, 1),
            new Position(1, -1),
        };

        public Position[] AttackPattern => new[]
        {
            new Position(0, 0),
        };

        public Func<BaseFigure, BaseFigure, Func<Position, BaseFigure>, bool> CanMove => (figure, moveToFigure, x) =>
        {
            if (figure.Position.Y == 1 || figure.Position.Y == 6)
            {
                return CanMoveSimple(figure, moveToFigure, _avaibleFirstMoves);
            }
            else
            {
                return CanMoveSimple(figure, moveToFigure, _avaibleMoves);
            }
        };

        public Func<BaseFigure, BaseFigure, Func<Position, BaseFigure>, bool> CanAttack => (figure, attackFigure, x) =>
                CanAttackSimple(figure, attackFigure, _avaibleAttacks);
    }
}