using System.Diagnostics.CodeAnalysis;

namespace BattleChess3.Multiplayer.Messaging;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
internal class Root
{
    public bool ok { get; set; }
    public List<RequestResult>? result { get; set; }
}