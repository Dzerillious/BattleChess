using System;
using BattleChess3.Core;
using BattleChess3.Core.Figures;

namespace BattleChess3.LordOfTheRings
{
    public class PipinTroll : IFigureType
    {
        public string ShownName => "Peregrin/Troll";
        public string UnitName => "LOTR_PipinTroll";
        public string GroupName => "LOTR";
        public FigureType UnitType => FigureType.Foot;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 3;

        public string Description => "\nPerregrin Took\n\nPeregrin Took, more commonly known as Pippin, was a Hobbit of the Shire, and one of Frodo Baggins's youngest, but closest friends. He was a member of the Fellowship of the Ring.\n" +
            "\nTrolls\n\nTrolls were a very large and monstrous (ranging from between 10-18 feet tall), and for the most part unintelligent (references are made about more cunning trolls), humanoid race inhabiting Middle-earth.";

        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}