﻿using System;
using System.Collections.Generic;
using BattleChess3.Core.Figures;
using BattleChess3.Core.Models;
using BattleChess3.SilmarillionFigures.Localization;

namespace BattleChess3.SilmarillionFigures
{
    public class ElfOrc : IFigureType
    {
        public static readonly ElfOrc Instance = new ElfOrc();
        public string ShownName => CurrentLocalization.Instance["ElfOrc_Name"];
        public string UnitName => $"{nameof(SilmarillionFigureGroup)}.{nameof(ElfOrc)}";
        public string GroupName => nameof(SilmarillionFigureGroup);
        public FigureTypes UnitTypes => FigureTypes.Foot;
        public FigureTypes Bonus => FigureTypes.Nothing;
        public FigureTypes AntiBonus => FigureTypes.Nothing;
        public double Attack => 100;
        public double Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 1;
        public string Description => CurrentLocalization.Instance["ElfOrc_Description"];

        public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
        {
            {1, new Uri("pack://application:,,,/BattleChess3.SilmarillionFigures;component/Images/ElfOrc1.png", UriKind.Absolute)},
            {2, new Uri("pack://application:,,,/BattleChess3.SilmarillionFigures;component/Images/ElfOrc2.png", UriKind.Absolute)},
        };
        
        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}