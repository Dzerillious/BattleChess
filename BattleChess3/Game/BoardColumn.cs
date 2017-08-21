using BattleChess3.Figures;

namespace BattleChess3.Game
{
    public class BoardColumn
    {
        public BoardColumn()
        {
            ColumnFigures = new BaseFigure[8];
        }
        public BaseFigure[] ColumnFigures { get; set; }
    }
}
