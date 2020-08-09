using System;
using BattleChess3.Core;
using BattleChess3.Core.Figures;

namespace BattleChess3.LordOfTheRings
{
    public class MerryTroll : IFigureType
    {
        public string ShownName => "Merry/Troll";
        public string UnitName => "LOTR_MerryTroll";
        public string GroupName => "LOTR";
        public FigureType UnitType => FigureType.Foot;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 3;

        public string Description => "\nMeriadoc Brandybuck\n\n Meriadoc \"Merry\" Brandybuck (later known as Meriadoc \"Merry\" Brandybuck I, due to his grandson's birth) was a Hobbit and one of Frodo's cousins and closest friends. He loved boats and ponies and had a great interest in the maps of Middle-earth. He was also one of the nine companions in The Fellowship of the Ring.\n" +
            "\nTrolls\n\nTrolls were a very large and monstrous (ranging from between 10-18 feet tall), and for the most part unintelligent (references are made about more cunning trolls), humanoid race inhabiting Middle-earth.";

        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}