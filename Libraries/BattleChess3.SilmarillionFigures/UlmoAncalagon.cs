﻿using System;
using BattleChess3.Core;
using BattleChess3.Core.Figures;

namespace BattleChess3.SilmarillionFigures
{
    public class UlmoAncalagon : IFigureType
    {
        public static readonly UlmoAncalagon Instance = new UlmoAncalagon();
        public string ShownName => "Ulmo/Ancalagon";
        public string UnitName => "Silmarillion_UlmoAncalagon";
        public string GroupName => "Silmarillion";
        public FigureType UnitType => FigureType.Foot;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 9;

        public string Description => "\nUlmo\n\nUlmo (Quenya; IPA: [ˈulmo] - \"Pourer\" or \"Rainer\") - also known as Ulubôz or Ullubôz - was an Ainu, one of the Aratar, and the Vala responsible for the control over the oceans of Arda. A lover of water, Ulmo was one of the Arda's chief architects and was always in a close friendship with Manwë. He always distrusted Melkor, and the Dark Lord feared the Sea almost as much as he feared Varda because the sea cannot be tamed. Ulmo had no dwelling in Valinor or any permanent dwelling on land, as he preferred the deeps of the seas and the rivers. His palace, on the bottom of Vaiya, was called Ulmonan.\n" +
            "\nAncalagon\n\nAncalagon, also known as Ancalagon the Black, was the greatest of all winged dragons. He was bred by Morgoth during the First Age, and was the largest dragon to have ever existed in Middle-earth. ";

        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}