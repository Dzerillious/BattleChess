using BattleChess3.Model.Figures.AttackingTypes;
using BattleChess3.Shared;
using BattleChess3.Shared.Properties;
using System;
using System.IO;

namespace BattleChess3.Model.Figures.FigureTypes.Silmarillion
{
    public class SilmarillionMM : SimpleAttackFigure, IFigure
    {
        public string ShownName => "Manwe/Melkor";
        public string UnitName => Resource.SilmarillionMM;
        public string UnitType => Resource.Foot;
        public string Bonus => Resource.Nothing;
        public string AntiBonus => Resource.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingWhileAttacking => true;
        public int Cost => 0;
        public string Description => "\nManwe\n\nManwë (Quenya; IPA: [ˈmanʷe] - \"Blessed One\") was the leader of the Ainur, one of the Aratar, King of the Valar, husband of Varda, brother of the Dark Lord Melkor, and King of Arda. He was also known as Súlimo, Mânawenûz or Valahiru and lives atop Mount Taniquetil in Valinor, the highest mountain of the world. The winds and airs are his servants. He was the greatest in authority, but not in power, of all the Valar, Melkor being more powerful. He was however the greatest of the Aratar, among whom Melkor was not counted.\n" +
            "\nMelkor\n\nMelkor (Quenya; IPA: \"He who arises in might\"), later known predominantly as Morgoth [1], was the first Dark Lord, and the primordial source of evil in Eä. Originally the most powerful of the Ainur created by Eru Iluvatar, Melkor rebelled against his creator out of pride and sought to corrupt Arda.After committing many evils in the First Age, such as the theft of the Silmarils, which resulted in his name Morgoth, and the destruction of the Two Lamps and the Two Trees of Valinor, Morgoth was defeated by the Host of Valinor in the War of Wrath and cast out of Arda into the Void, where he now waits. ";

        public string PictureBlackPath => Directory.GetCurrentDirectory() + "\\Pictures\\Silmarillion\\Morgoth.png";
        public string PictureWhitePath => Directory.GetCurrentDirectory() + "\\Pictures\\Silmarillion\\Manwe.png";
        public string PictureNeutralPath => "";

        private readonly Position[] _avaibleMoves =
        {
            new Position(0, 1),
            new Position(0, -1),
            new Position(1, 0),
            new Position(-1, 0),
            new Position(1, 1),
            new Position(-1, -1),
            new Position(1, -1),
            new Position(-1, 1),
        };

        private readonly Position[] _avaibleAttacks =
        {
            new Position(0, 1),
            new Position(0, -1),
            new Position(1, 0),
            new Position(-1, 0),
            new Position(1, 1),
            new Position(-1, -1),
            new Position(1, -1),
            new Position(-1, 1),
        };

        public Position[] AttackPattern => new[]
        {
            new Position(0, 0),
        };

        public Func<BaseFigure, BaseFigure, Func<Position, BaseFigure>, bool> CanMove => (figure, moveToFigure, x) =>
                CanMoveSimple(figure, moveToFigure, _avaibleMoves);

        public Func<BaseFigure, BaseFigure, Func<Position, BaseFigure>, bool> CanAttack => (figure, attackFigure, x) =>
                CanAttackSimple(figure, attackFigure, _avaibleAttacks);
    }
}