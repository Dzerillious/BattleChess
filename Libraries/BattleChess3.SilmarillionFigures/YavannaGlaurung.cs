using System;
using BattleChess3.Core;
using BattleChess3.Core.Figures;

namespace BattleChess3.SilmarillionFigures
{
    public class YavannaGlaurung : IFigureType
    {
        public string ShownName => "Yavanna/Glaurung";
        public string UnitName => "Silmarillion_YavannaGlaurung";
        public string GroupName => "Silmarillion";
        public FigureType UnitType => FigureType.Foot;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 3;

        public string Description => "\nYavanna\n\nYavanna (Quenya; IPA: [jaˈvanna] - \"Giver of Fruits\") was of the Ainur and Valar, and one of the Aratar who was responsible for the growth of all the fruits and growing things of Arda. She was also called Kementári (Quenya; IPA: \"Queen of the Earth\"), Ivon (Sindarin; IPA: \"Giver of Fruits\"). She resided in the Pastures of Yavanna, in the south of Valinor. She is the wife of Aulë, older sister of Vána, and kin to Melian." +
            "\nGlaurung\n\nGlaurung was the first terrestrial, fire-breathing Dragon in Middle-earth. He is known as the Father of Dragons.";

        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}