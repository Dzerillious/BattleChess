using System;

namespace BattleChess3.Core.Figures.FigureTypes.Silmarillion
{
    public class SilmarillionIU : IFigure
    {
        public string ShownName => "Irmo/Ungoliant";
        public string UnitName => "SilmarillionIU";
        public string GroupName => "Silmarillion";
        public FigureType UnitType => FigureType.Foot;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 3;

        public string Description => "\nIrmo\n\nIrmo (Quenya; IPA: [ˈirmo] - \"Desirer\" or \"Master of Desires\") is an Ainu, and a Vala who was responsible for the creation of dreams and desires as well as visions too. He was more commonly known as Lórien, after the name of his dwelling place. Irmo-Lórien was the younger brother of Námo who also like his brother was commonly known as Mandos the name of his dwelling place, and also the brother of Nienna (Lady of Pity and Mourning).\n" +
            "\nUngoliant\n\nUngoliant (Sindarin IPA: [uŋˈɡoljant] - \"Dark Spider\") was a primordial taking the shape of a gigantic spider. She was initially an ally of Melkor in Aman, and for a short time in Middle-earth as well. She is the mother of Shelob, and therefore the oldest, and first spider of the south, possibly even the first spider. ";

        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}