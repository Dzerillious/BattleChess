using BattleChess3.Model.Figures.AttackingTypes;
using BattleChess3.Shared;
using BattleChess3.Shared.Properties;
using System;
using System.IO;

namespace BattleChess3.Model.Figures.FigureTypes.Hobbit
{
    public class HobbitLeader : SimpleAttackFigure, IFigure
    {
        public string ShownName => "Leader";
        public string UnitName => Resource.HobbitLeader;
        public string UnitType => Resource.Foot;
        public string Bonus => Resource.Nothing;
        public string AntiBonus => Resource.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingWhileAttacking => true;
        public int Cost => 0;
        public string Description => "";

        public string PictureBlackPath => Directory.GetCurrentDirectory() + "\\Pictures\\Hobbit\\Sauron.png";
        public string PictureWhitePath => Directory.GetCurrentDirectory() + "\\Pictures\\Hobbit\\Galadriel.png";
        public string PictureNeutralPath => "";

        private readonly Position[] _avaibleMoves =
        {
            new Position(0, 1),
            new Position(0, -1),
            new Position(1, 0),
            new Position(-1, 0),
            new Position(1, 1),
            new Position(-1, -1),
            new Position(1, -1),
            new Position(-1, 1),
        };

        private readonly Position[] _avaibleAttacks =
        {
            new Position(0, 1),
            new Position(0, -1),
            new Position(1, 0),
            new Position(-1, 0),
            new Position(1, 1),
            new Position(-1, -1),
            new Position(1, -1),
            new Position(-1, 1),
        };

        public Position[] AttackPattern => new[]
        {
            new Position(0, 0),
        };

        public Func<BaseFigure, BaseFigure, Func<Position, BaseFigure>, bool> CanMove => (figure, moveToFigure, x) =>
                CanMoveSimple(figure, moveToFigure, _avaibleMoves);

        public Func<BaseFigure, BaseFigure, Func<Position, BaseFigure>, bool> CanAttack => (figure, attackFigure, x) =>
                CanAttackSimple(figure, attackFigure, _avaibleAttacks);
    }
}