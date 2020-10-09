using BattleChess3.Core.Figures;

namespace BattleChess3.Core.Models
{
    public class FigureBlueprint
    {
        public int PlayerId { get; set; }
        public string FigureName { get; set; } = "";

        public static implicit operator FigureBlueprint((int id, IFigureType figure) pair) 
            => new FigureBlueprint
            {
                PlayerId = pair.id,
                FigureName = pair.figure.UnitName
            };

        public override string ToString() => $"{FigureName}{PlayerId}";
    }
}