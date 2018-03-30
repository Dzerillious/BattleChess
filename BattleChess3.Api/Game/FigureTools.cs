using BattleChess3.Model;
using BattleChess3.Model.Figures;
using BattleChess3.Model.Properties;

namespace BattleChess3.Api.Game
{
    public static partial class Session
    {
        public static Player WhitePlayer = new Player(Resource.White);
        public static Player BlackPlayer = new Player(Resource.Black);

        private static void CreateFigure(string tile, Position position, string playerName, Player player = null)
        {
            var figure = TypesOfFigures.GetFigureFromString(tile.Replace(playerName, ""));
            BaseFigure newBaseFigure = new BaseFigure(playerName, position, figure);
            player?.CreateFigure(newBaseFigure);
            SetFigureAtPosition(position, newBaseFigure);
        }

        /// <summary>
        /// Tries to play the position if it is your turn
        /// </summary>
        public static bool TryPlay(BaseFigure me, Position position)
        {
            if (Session.WhooseTurn != me.Color) return false;
            var enemy = Session.GetFigureAtPosition(position);
            if (me.CanMove(enemy, GetFigureAtPosition))
            {
                Session.MoveFigureToPosition(me.Position, position);
                me.Position = position;
                return true;
            }
            if (enemy.Color != me.Color && me.CanAttack(enemy, GetFigureAtPosition))
            {
                if (me.FigureType.MovingWhileAttacking && TryAttack(me, Session.GetFigureAtPosition(position)))
                {
                    Session.MoveFigureToPosition(me.Position, position);
                    me.Position = position;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Tries to attack at certain position and return if attacked
        /// </summary>
        public static bool TryAttack(BaseFigure me, BaseFigure enemy)
        {
            var remainingHp = enemy.RemainingHpOfAttacked(me);
            if (me.FigureType.MovingWhileAttacking)
            {
                if (remainingHp > 0) return false;
                AttackPattern(enemy.Position, me);
                return true;
            }
            AttackPattern(enemy.Position, me);
            return true;
        }

        /// <summary>
        /// Attacks each figure of pattern
        /// </summary>
        public static void AttackPattern(Position attackedPosition, BaseFigure me)
        {
            foreach (var position in me.FigureType.AttackPattern)
            {
                AttackFigure(me, Session.GetFigureAtPosition(position.AddPositions(attackedPosition)));
            }
        }

        /// <summary>
        /// Attacks figure if Hp is lesser 0 figure dies
        /// </summary>
        public static void AttackFigure(BaseFigure attackingFigure, BaseFigure attackedFigure)
        {
            attackedFigure.Hp = attackedFigure.RemainingHpOfAttacked(attackingFigure);
            if (attackedFigure.Hp <= 0)
            {
                KillFigure(attackedFigure);
            }
        }

        public static BaseFigure GetFigureAtPosition(Position position) => Board[position.X][position.Y];

        public static void SetFigureAtPosition(Position position, BaseFigure figure)
        {
            Board[position.X][position.Y] = figure;
        }

        public static void MoveFigureToPosition(Position position, Position newPosition)
        {
            var figure = GetFigureAtPosition(position);
            SetFigureAtPosition(position, new BaseFigure(position));
            SetFigureAtPosition(newPosition, figure);
        }

        public static void KillFigure(BaseFigure figure)
        {
            SetFigureAtPosition(figure.Position, new BaseFigure(figure.Position));
            if (WhitePlayer.Color == figure.Color)
            {
                WhitePlayer.KillFigure(figure);
            }
            else
            {
                BlackPlayer.KillFigure(figure);
            }
        }
    }
}