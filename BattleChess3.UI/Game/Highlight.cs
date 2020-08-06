using System.IO;
using BattleChess3.Core;
using BattleChess3.Core.Figures;

namespace BattleChess3.UI.Game
{
    public static partial class Session
    {
        public static void HighlightTiles()
        {
            if (Selected.Position == Position.Invalid)
            {
                for (var i = 0; i < 64; i++)
                {
                    Board[i / 8][i % 8].Highlighted = Directory.GetCurrentDirectory() + "\\Resources\\Pictures\\Nothing.png";
                }
            }
            else
            {
                for (var i = 0; i < 64; i++)
                {
                    var position = new Position(i / 8, i % 8);
                    var figure = GetFigureAtPosition(position);
                    figure.Highlighted = SelectedStyle.ApplicationStyle.ChessTile;
                    if (Selected.Figure.PlayerNumber == WhooseTurn)
                    {
                        HighlightDangered(figure);
                        HighlightCanGo(figure);
                    }
                }
                HighlightSelected();
                HighlightMouseOn();
            }
        }

        public static void HighlightDangered(BaseFigure figure)
        {
            if (figure.PlayerNumber != Selected.Figure.PlayerNumber && Selected.Figure.CanAttack(figure, GetFigureAtPosition))
            {
                figure.Highlighted = SelectedStyle.ApplicationStyle.DangeredChessTile;
            }
        }

        public static void HighlightCanGo(BaseFigure figure)
        {
            if (Selected.Figure.CanMove(figure, GetFigureAtPosition))
            {
                figure.Highlighted = SelectedStyle.ApplicationStyle.CanGoChessTile;
            }
        }

        public static void HighlightSelected()
        {
            Selected.Figure.Highlighted = SelectedStyle.ApplicationStyle.SelectedChessTile;
        }

        public static void HighlightMouseOn()
        {
            MouseOn.Figure.Highlighted = SelectedStyle.ApplicationStyle.SelectedChessTile;
        }
    }
}