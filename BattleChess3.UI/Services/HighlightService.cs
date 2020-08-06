using System.IO;
using BattleChess3.Core;
using BattleChess3.Core.Figures;

namespace BattleChess3.UI.Services
{
    public class HighlightService
    {
        private readonly BoardService _boardService = CommonServiceLocator.ServiceLocator.Current.GetInstance<BoardService>();
        private readonly PlayerService _playerService = CommonServiceLocator.ServiceLocator.Current.GetInstance<PlayerService>();
        private readonly StyleOptions _stylingService = CommonServiceLocator.ServiceLocator.Current.GetInstance<StyleOptions>();
        
        public void HighlightTiles()
        {
            if (_boardService.SelectedTile.Position == Position.Invalid)
            {
                for (var i = 0; i < 64; i++)
                    _boardService.Board[i].Figure.Highlighted = Directory.GetCurrentDirectory() + "\\Resources\\Pictures\\Nothing.png";
            }
            else
            {
                for (var i = 0; i < 64; i++)
                {
                    var position = new Position(i / 8, i % 8);
                    var figure = _boardService.GetFigureAtPosition(position);
                    figure.Highlighted = _stylingService.ApplicationStyle.ChessTile;
                    if (_boardService.SelectedTile.Figure.Owner == _playerService.CurrentPlayer)
                    {
                        HighlightDangered(figure);
                        HighlightCanGo(figure);
                    }
                }
                HighlightSelected();
                HighlightMouseOn();
            }
        }

        public void HighlightDangered(Figure figure)
        {
            if (figure.Owner != _boardService.SelectedTile.Figure.Owner && _boardService.SelectedTile.Figure.CanAttack(figure, _boardService.GetFigureAtPosition))
                figure.Highlighted = _stylingService.ApplicationStyle.DangeredChessTile;
        }

        public void HighlightCanGo(Figure figure)
        {
            // if (_boardService.SelectedTile.Figure.CanMove(figure, BoardService.GetFigureAtPosition))
            //     figure.Highlighted = _stylingService.ApplicationStyle.CanGoChessTile;
        }

        public void HighlightSelected()
        {
            _boardService.SelectedTile.Figure.Highlighted = _stylingService.ApplicationStyle.SelectedChessTile;
        }

        public void HighlightMouseOn()
        {
            _boardService.HoverTile.Figure.Highlighted = _stylingService.ApplicationStyle.SelectedChessTile;
        }
    }
}