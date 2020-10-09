using System;
using System.Collections.Generic;
using BattleChess3.Core.Figures;
using BattleChess3.Core.Models;
using BattleChess3.DefaultFigures.Localization;

namespace BattleChess3.DefaultFigures
{
    public class Stone : IFigureType
    {
        public static readonly Stone Instance = new Stone();
        public string ShownName => CurrentLocalization.Instance["Stone_Name"];
        public string UnitName => $"{nameof(DefaultFigureGroup)}.{nameof(Stone)}";
        public string GroupName => nameof(DefaultFigureGroup);
        public FigureTypes UnitTypes => FigureTypes.Object;
        public FigureTypes Bonus => FigureTypes.Nothing;
        public FigureTypes AntiBonus => FigureTypes.Nothing;
        public double Attack => 0;
        public double Defence => double.PositiveInfinity;
        public bool MovingAttack => false;
        public string Description => CurrentLocalization.Instance["Stone_Description"];

        public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
        {
            {0, new Uri("pack://application:,,,/BattleChess3.DefaultFigures;component/Images/Stone0.png", UriKind.Absolute)},
        };

        public int Cost => 0;
        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}