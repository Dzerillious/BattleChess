using System.IO;
using BattleChess3.Core;
using BattleChess3.Core.Figures;

namespace BattleChess3.UI.Services
{
    public class HighlightService
    {
        private readonly BoardService BoardService = CommonServiceLocator.ServiceLocator.Current.GetInstance<BoardService>();
        private readonly PlayerService _playerService = CommonServiceLocator.ServiceLocator.Current.GetInstance<PlayerService>();
        private readonly StylingService StylingService = CommonServiceLocator.ServiceLocator.Current.GetInstance<StylingService>();
        
        public void HighlightTiles()
        {
            if (_playerService.SelectedTile.Position == Position.Invalid)
            {
                for (var i = 0; i < 64; i++)
                {
                    BoardService.Board[i / 8][i % 8].Highlighted = Directory.GetCurrentDirectory() + "\\Resources\\Pictures\\Nothing.png";
                }
            }
            else
            {
                for (var i = 0; i < 64; i++)
                {
                    var position = new Position(i / 8, i % 8);
                    var figure = BoardService.GetFigureAtPosition(position);
                    figure.Highlighted = StylingService.ApplicationStyle.ChessTile;
                    if (_playerService.SelectedTile.Figure.Owner == _playerService.CurrentPlayer)
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
            if (figure.Owner != _playerService.SelectedTile.Figure.Owner && _playerService.SelectedTile.Figure.CanAttack(figure, BoardService.GetFigureAtPosition))
                figure.Highlighted = StylingService.ApplicationStyle.DangeredChessTile;
        }

        public void HighlightCanGo(Figure figure)
        {
            if (_playerService.SelectedTile.Figure.CanMove(figure, BoardService.GetFigureAtPosition))
                figure.Highlighted = StylingService.ApplicationStyle.CanGoChessTile;
        }

        public void HighlightSelected()
        {
            _playerService.SelectedTile.Figure.Highlighted = StylingService.ApplicationStyle.SelectedChessTile;
        }

        public void HighlightMouseOn()
        {
            _playerService.HoverTile.Figure.Highlighted = StylingService.ApplicationStyle.SelectedChessTile;
        }
    }
}