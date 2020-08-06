using System;

namespace BattleChess3.Core.Figures.FigureTypes.Hobbit
{
    public class HobbitHelper : IFigure
    {
        public string ShownName => "Helper";
        public string UnitName => "HobbitHelper";
        public string GroupName => "Hobbit";
        public FigureType UnitType => FigureType.Foot;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 3;
        public string Description => "\nOri\n\nOri was a member of Thorin's Company of Dwarves. He, alongside his brothers Dori and Nori, are remote kinsman of Thorin.\n" +
            "\nFelgrom\n\nFelgrom was the character created from LOTR: Two Towers which blows up the sewer grate to achieve entrance into Helms Deep. Warner Bros. elaborated upon the character, giving him a name and he is playable as a Tactician in their game: Guardians of Middle-earth. He is a suicide bomber, with several Orcish explosives strapped to his back. He is non-canonical as he doesn't appear in the books.";

        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}