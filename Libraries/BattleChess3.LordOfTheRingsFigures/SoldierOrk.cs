using System;
using BattleChess3.Core;
using BattleChess3.Core.Figures;

namespace BattleChess3.LordOfTheRings
{
    public class SoldierOrk : IFigureType
    {
        public string ShownName => "Soldier/Ork";
        public string UnitName => "LOTR_SoldierOrk";
        public string GroupName => "LOTR";
        public FigureType UnitType => FigureType.Foot;
        public FigureType Bonus => FigureType.Nothing;
        public FigureType AntiBonus => FigureType.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 1;

        public string Description => "\nGuard of the Citadel\n\nThe Guards of the Citadel, sometimes referred to as the Guards of the Tower of Gondor, were the warriors responsible for guarding the upmost level of Minas Tirith, especially the courtyard that held the fountain and the White Tree of Gondor, and gave way the thronehall. They served as personal bodyguards to the Kings of Gondor, and later to the Stewards of Gondor until King Aragorn II Elessar's coronation. They were mainly a stationary guard unit, rather than a mobile force, though were sometimes seen acting as a mobile guard when travelling with the Steward.They were headed by a Captain of the Citadel, who was chosen by the Steward from nobility or high military ranks. As a whole, they were considered to be the best soldiers in the realm of Gondor. Known for their bravery, fighting skills, and unshakable loyalty, they swear an oath against their own lives to serve their lord.\n" +
            "\nOrcs\n\nBefore Oromë found the Elves at Cuiviénen, Melkor enslaved some of them and cruelly tortured them, turning them into Orcs. Many Orcs(along with fallen Maiar and other evil servants of Melkor) survived in the deep caves, pits, chambers, and tunnels of Melkor's great underground fortresses of Utumno and Angband. They multiplied and later spread through northern Middle-earth. They were first seen by the Dwarves who reported them to King Thingol, the High King of the Sindar, causing the latter to seek weapons of war for the first time. For over a millennium, the orcs were only a minor problem, but when Melkor (Morgoth) returned with the Silmarils he took full charge of them and soon unleashed them on Beleriand. The newly organised orcs killed Denethor, the King of the lightly armed Laiquendi, but were eventually defeated by Thingol and his allies. They besieged the Havens of the Falas under Círdan, and the siege wasn't broken until the arrival of the Ñoldor.The heavy losses that the Sindar suffered at the hands of the Orcs frightened them to the point that Melian, Queen of Doriath raised a great enchantment to protect their kingdom.The Laiquendi, who suffered the most in the battle, hid themselves in the Ossiriand under the cloak of secrecy, or took refuge in Doriath.";

        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}