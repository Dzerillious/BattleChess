using System;
using BattleChess3.Core;
using BattleChess3.Core.Figures;

namespace BattleChess3.HobbitFigures
{
    public class Soldier : IFigureType
    {
        public string ShownName => "Soldier";
        public string UnitName => "Hobbit_Soldier";
        public string GroupName => "Hobbit";
        public FigureType UnitType => FigureType.Foot;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 1;
        public string Description => "\nSteward of Gondor\n\nThe Stewards of Gondor were firstly the chief high councillors to the Kings of Gondor and then the rulers of Gondor, until the return of the rightful ruler King Aragorn II Elessar.\n" +
            "\nThe Great Spiders\n\nThe Great Spiders, also known as the Children of Ungoliant, were a race of oversized and sentient arachnids that lived in Middle-earth, particularly in dark and perilous places affected by the power of the Shadow.";

        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}