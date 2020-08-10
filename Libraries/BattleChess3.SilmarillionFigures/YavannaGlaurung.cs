﻿using System;
using BattleChess3.Core.Figures;
using BattleChess3.Core.Models;
using BattleChess3.SilmarillionFigures.Localization;

namespace BattleChess3.SilmarillionFigures
{
    public class YavannaGlaurung : IFigureType
    {
        public static readonly YavannaGlaurung Instance = new YavannaGlaurung();
        public string ShownName => CurrentLocalization.Instance["YavannaGlaurung_Name"];
        public string UnitName => $"{nameof(SilmarillionFigureGroup)}.{nameof(YavannaGlaurung)}";
        public string GroupName => nameof(SilmarillionFigureGroup);
        public FigureTypes UnitTypes => FigureTypes.Foot;
        public FigureTypes Bonus => FigureTypes.Nothing;
        public FigureTypes AntiBonus => FigureTypes.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 3;
        public string Description => CurrentLocalization.Instance["YavannaGlaurung_Description"];
        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}