namespace BattleChess3.Core.Model.Figures
{
    public class FigureBlueprint
    {
        public int PlayerId { get; set; } = Player.Neutral.Id;
        public string FigureName { get; set; } = string.Empty;

        public static implicit operator FigureBlueprint((int id, IFigureType figure) pair) 
            => new FigureBlueprint
            {
                PlayerId = pair.id,
                FigureName = pair.figure.UnitName
            };

        public override string ToString() => $"{FigureName}{PlayerId}";
    }
}