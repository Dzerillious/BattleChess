using BattleChess3.Core.Model.Figures;
using System;
using System.Collections.Generic;

namespace BattleChess3.UI.Services;

/// <summary>
/// Figure service is used loading figure dlls and resolving it's figures.
/// </summary>
public interface IFigureService
{
    /// <summary>
    /// Raised when figure groups changes.
    /// </summary>
    event EventHandler<IList<IFigureGroup>>? FigureGroupsChanged;

    /// <summary>
    /// Gets all figure groups.
    /// </summary>
    IList<IFigureGroup> GetFigureGroups();

    /// <summary>
    /// Gets figure type based on name of the figure.
    /// </summary>
    IFigureType GetFigureFromName(string text);
}
