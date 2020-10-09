using System;
using System.Collections.Generic;
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
        public double Attack => 100;
        public double Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 0;
        public string Description => CurrentLocalization.Instance["AragornSauron_Description"];

        public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
        {
            {1, new Uri("pack://application:,,,/BattleChess3.LordOfTheRingsFigures;component/Images/AragornSauron1.png", UriKind.Absolute)},
            {2, new Uri("pack://application:,,,/BattleChess3.LordOfTheRingsFigures;component/Images/AragornSauron2.png", UriKind.Absolute)},
        };

        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}