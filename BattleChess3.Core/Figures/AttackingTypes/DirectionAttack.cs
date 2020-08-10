﻿// using System;
//
// namespace BattleChess3.Core.Figures.AttackingTypes
// {
//     /// <summary>
//     /// Class of simple move of figure
//     /// </summary>
//     public class DirectionAttack : DirectionMove
//     {
//         /// <summary>
//         /// Checks if position is one of possible moving positions
//         /// </summary>
//         public Func<Tile, Tile, bool> CanAttackDirection()
//         {
//             foreach (var direction in directions)
//             {
//                 for (var i = 1; i < 8; i++)
//                 {
//                     var moveToPosition = movingFigure.Position.AddPositions(direction.MultiplePosition(i));
//                     if (moveToPosition.CheckIfInBoard() == false) break;
//                     if (moveToPosition == moveToFigure.Position)
//                     {
//                         return true;
//                     }
//                     if (getFigureAtPosition(moveToPosition).FigureType.UnitName != "Nothing")
//                     {
//                         break;
//                     }
//                 }
//             }
//             return false;
//         };
//     }
// }