namespace BattleChess3.Maps;

/// <summary>
///     Service for handling maps loading.
/// </summary>
public interface IMapService
{
    /// <summary>
    ///     Raised when maps collection has changed.
    /// </summary>
    event EventHandler<IList<MapBlueprint>>? MapsChanged;

    /// <summary>
    ///     Gets current maps.
    /// </summary>
    IList<MapBlueprint> GetCurrentMaps();

    /// <summary>
    ///     Deletes specified map.
    /// </summary>
    void Delete(MapBlueprint selectedMap);

    /// <summary>
    ///     Saves specified map.
    /// </summary>
    void Save(MapBlueprint map);
}