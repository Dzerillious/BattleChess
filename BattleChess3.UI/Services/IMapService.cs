using BattleChess3.Core.Model;
using System;
using System.Collections.Generic;

namespace BattleChess3.UI.Services;

/// <summary>
/// Service for handling maps loading.
/// </summary>
public interface IMapService
{
    /// <summary>
    /// Raised when maps collection has changed.
    /// </summary>
    event EventHandler<IList<MapBlueprint>> MapsChanged;

    /// <summary>
    /// Gets current maps.
    /// </summary>
    IList<MapBlueprint> GetCurrentMaps();
}
