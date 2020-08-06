using BattleChess3.Core.Figures.AttackingTypes;
using System;
using System.IO;

namespace BattleChess3.Core.Figures.FigureTypes.Silmarillion
{
    public class SilmarillionEO : SimpleAttackFigure, IFigure
    {
        public string ShownName => "Elves/Orcs";
        public string UnitName => "SilmarillionEO";
        public FigureType UnitType => FigureType.Foot;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingWhileAttacking => true;
        public int Cost => 1;

        public string Description => "\nElves\n\nThe Elves, who called themselves the Quendi, and who in lore are commonly referred to as the Eldar (adj. Eldarin), were the first and eldest of the Children of Ilúvatar, and are considered to be the fairest and wisest of any race of Arda given sapience. Some, known afterwards as the Calaquendi(Elves of the Light), were brought by the Valar from Middle-earth to Valinor across the Sea, where they were taught by the Ainur.But after the Silmarils were stolen by Melkor, some of the Elves returned to Middle-earth, where they remained until the end of the Third Age.\n" +
            "\nOrcs\n\nBefore Oromë found the Elves at Cuiviénen, Melkor enslaved some of them and cruelly tortured them, turning them into Orcs. Many Orcs(along with fallen Maiar and other evil servants of Melkor) survived in the deep caves, pits, chambers, and tunnels of Melkor's great underground fortresses of Utumno and Angband. They multiplied and later spread through northern Middle-earth. They were first seen by the Dwarves who reported them to King Thingol, the High King of the Sindar, causing the latter to seek weapons of war for the first time. For over a millennium, the orcs were only a minor problem, but when Melkor (Morgoth) returned with the Silmarils he took full charge of them and soon unleashed them on Beleriand. The newly organised orcs killed Denethor, the King of the lightly armed Laiquendi, but were eventually defeated by Thingol and his allies. They besieged the Havens of the Falas under Círdan, and the siege wasn't broken until the arrival of the Ñoldor.The heavy losses that the Sindar suffered at the hands of the Orcs frightened them to the point that Melian, Queen of Doriath raised a great enchantment to protect their kingdom.The Laiquendi, who suffered the most in the battle, hid themselves in the Ossiriand under the cloak of secrecy, or took refuge in Doriath.";

        public string PictureBlackPath => Directory.GetCurrentDirectory() + "\\Pictures\\Silmarillion\\Orcs.png";
        public string PictureWhitePath => Directory.GetCurrentDirectory() + "\\Pictures\\Silmarillion\\Elves.png";
        public string PictureNeutralPath => "";

        private readonly Position[] _avaibleFirstMoves =
        {
            new Position(0, 1),
            new Position(0, 2),
            new Position(0, -1),
            new Position(0, -2),
        };

        private readonly Position[] _avaibleMoves =
        {
            new Position(0, 1),
            new Position(0, -1),
        };

        private readonly Position[] _avaibleAttacks =
        {
            new Position(1, 1),
            new Position(-1, -1),
            new Position(-1, 1),
            new Position(1, -1),
        };

        public Position[] AttackPattern => new[]
        {
            new Position(0, 0),
        };

        public Func<Figure, Figure, Func<Position, Figure>, bool> CanMove => (figure, moveToFigure, x) =>
        {
            if (figure.Position.Y == 1 || figure.Position.Y == 6)
            {
                return CanMoveSimple(figure, moveToFigure, _avaibleFirstMoves);
            }
            else
            {
                return CanMoveSimple(figure, moveToFigure, _avaibleMoves);
            }
        };

        public Func<Figure, Figure, Func<Position, Figure>, bool> CanAttack => (figure, attackFigure, x) =>
                 CanAttackSimple(figure, attackFigure, _avaibleAttacks);
    }
}