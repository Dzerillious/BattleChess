using System.Diagnostics.CodeAnalysis;

namespace BattleChess3.Multiplayer.Messaging;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
internal class MessageWithType
{
    public string? message_type { get; set; }
    public string? message { get; set; }
}