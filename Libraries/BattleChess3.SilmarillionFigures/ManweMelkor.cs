using System;
using BattleChess3.Core;
using BattleChess3.Core.Figures;

namespace BattleChess3.SilmarillionFigures
{
    public class ManweMelkor : IFigureType
    {
        public string ShownName => "Manwe/Melkor";
        public string UnitName => "Silmarillion_ManweMelkor";
        public string GroupName => "Silmarillion";
        public FigureType UnitType => FigureType.Foot;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 0;

        public string Description => "\nManwe\n\nManwë (Quenya; IPA: [ˈmanʷe] - \"Blessed One\") was the leader of the Ainur, one of the Aratar, King of the Valar, husband of Varda, brother of the Dark Lord Melkor, and King of Arda. He was also known as Súlimo, Mânawenûz or Valahiru and lives atop Mount Taniquetil in Valinor, the highest mountain of the world. The winds and airs are his servants. He was the greatest in authority, but not in power, of all the Valar, Melkor being more powerful. He was however the greatest of the Aratar, among whom Melkor was not counted.\n" +
            "\nMelkor\n\nMelkor (Quenya; IPA: \"He who arises in might\"), later known predominantly as Morgoth , was the first Dark Lord, and the primordial source of evil in Eä. Originally the most powerful of the Ainur created by Eru Iluvatar, Melkor rebelled against his creator out of pride and sought to corrupt Arda.After committing many evils in the First Age, such as the theft of the Silmarils, which resulted in his name Morgoth, and the destruction of the Two Lamps and the Two Trees of Valinor, Morgoth was defeated by the Host of Valinor in the War of Wrath and cast out of Arda into the Void, where he now waits. ";

        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}