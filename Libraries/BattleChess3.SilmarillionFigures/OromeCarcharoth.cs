using System;
using BattleChess3.Core;
using BattleChess3.Core.Figures;

namespace BattleChess3.SilmarillionFigures
{
    public class OromeCarcharoth : IFigureType
    {
        public string ShownName => "Orome/Carcharoth";
        public string UnitName => "Silmarillion_OromeCarcharoth";
        public string GroupName => "Silmarillion";
        public FigureType UnitType => FigureType.Foot;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 3;

        public string Description => "\nMandos\n\nMandos (Quenya; IPA: [ˈmandos] - \"Prison-Fortress\") is an Ainu, one of the Aratar and a Vala who is responsible for the judgement of the Spirits, or Fëa of all Elven dead. He also has responsibility for pronouncing the dooms and judgments of Eru Ilúvatar under Manwë. His real name is Námo (Quenya; IPA: \"Ordainer\" or \"Judge\") but was later known by the Elves as Mandos after his sacred halls Halls of Mandos, over which he presides and where ultimately the Elves go after they are slain.\n" +
            "\nCarcharoth\n\nCarcharoth, also known as the Red Maw, lived in the First Age of the Sun, and was the greatest werewolf who ever lived. He was of the line of Draugluin.";

        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}