using BattleChess3.Core.Model.Figures;

namespace BattleChess3.Core.Model
{
    public class PlayedTile : ITile
    {
        private readonly ITile _innerTile;
        private readonly Player _player;

        public Position Position
        {
            get => _innerTile.Position.GetPlayerPOVPosition(_player);
        }
        
        public Figure Figure
        {
            get => _innerTile.Figure;
            set => _innerTile.Figure = value;
        }

        public PlayedTile(ITile innerTile, Player player)
        {
            _innerTile = innerTile;
            _player = player;
        }

        public ITile GetPovTile(Player player)
            => new PlayedTile(this, player);
    }
}
