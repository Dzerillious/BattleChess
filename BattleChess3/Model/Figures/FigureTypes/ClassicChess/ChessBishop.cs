using BattleChess3.GameData.Figures.AttackingTypes;
using BattleChess3.Properties;
using System;
using System.IO;

namespace BattleChess3.GameData.Figures.FigureTypes.ClassicChess
{
    public class ChessBishop : DirectionAttack, IFigure
    {
        public string UnitName => Resource.ChessBishop;
        public string UnitType => Resource.Foot;
        public string Bonus => Resource.Nothing;
        public string AntiBonus => Resource.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingWhileAttacking => true;
        public int Cost => 3;
        public string Description => "Chess bishop is quite movable unit and it can danger quite big area.";

        public string PictureBlackPath => Directory.GetCurrentDirectory() + "\\Pictures\\ClassicChess\\ChessBishopBlack.png";
        public string PictureWhitePath => Directory.GetCurrentDirectory() + "\\Pictures\\ClassicChess\\ChessBishopWhite.png";
        public string PictureNeutralPath => "";

        private readonly Position[] _avaibleMoveDirections =
        {
            new Position(1, 1),
            new Position(-1, -1),
            new Position(1, -1),
            new Position(-1, 1),
        };

        private readonly Position[] _avaibleAttackDirections =
        {
            new Position(1, 1),
            new Position(-1, -1),
            new Position(1, -1),
            new Position(-1, 1),
        };

        public Position[] AttackPattern => new[]
        {
            new Position(0, 0),
        };

        public Func<BaseFigure, BaseFigure, bool> CanMove => (figure, moveToFigure) =>
             CanMoveDirection(figure, moveToFigure, _avaibleMoveDirections);

        public Func<BaseFigure, BaseFigure, bool> CanAttack => (figure, attackFigure) =>
             CanAttackDirection(figure, attackFigure, _avaibleAttackDirections);
    }
}