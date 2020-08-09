using System;
using BattleChess3.Core;
using BattleChess3.Core.Figures;

namespace BattleChess3.HobbitFigures
{
    public class Warrior : IFigureType
    {
        public static readonly Warrior Instance = new Warrior();
        public string ShownName => "Warrior";
        public string UnitName => "Hobbit_Warrior";
        public string GroupName => "Hobbit";
        public FigureType UnitType => FigureType.Foot;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 3;
        public string Description => "\nNori\n\nNori was a Dwarf of Durin's folk who lived in the northern Blue Mountains in Thorin's Halls and later the restored Lonely Mountain. He had two brothers named Dori and Ori, and was a remote kinsman of Thorin Oakenshield. His hood was purple, he played the flute, and he was very fond of regular and plentiful meals like his hobbit friend, Bilbo Baggins.\n" +
            "\nGothmog\n\nGothmog was the lieutenant of the Witch-king in the Third Age, from Minas Morgul, notably at the Battle of the Pelennor Fields. ";

        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}