namespace BattleChess3.Core.Model.Figures
{
    // JSON serializable
    public class FigureBlueprint
    {
        public int PlayerId { get; set; } = Player.Neutral.Id;
        public string UnitName { get; set; } = NoneFigure.Instance.UnitName;
        public double Hp { get; set; } = 100;

        public FigureBlueprint()
        {
        }
        
        public FigureBlueprint(int id, IFigureType figureType, double hp)
        {
            PlayerId = id;
            UnitName = figureType.UnitName;
            Hp = hp;
        }

        public static implicit operator FigureBlueprint((int id, IFigureType figure) pair)
            => new FigureBlueprint(pair.id, pair.figure, pair.figure.FullHp);

        public override string ToString() => $"{UnitName}{PlayerId}";
    }
}