namespace BattleChess3.Game.Figures;

public interface IFigureCreator
{
    Figure CreateFigure(FigureIdentifier figureIdentifier);

    Figure CreateEmptyFigure();
}