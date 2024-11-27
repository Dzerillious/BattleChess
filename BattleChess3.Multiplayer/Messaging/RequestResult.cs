using System.Diagnostics.CodeAnalysis;

namespace BattleChess3.Multiplayer.Messaging;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
internal abstract class RequestResult
{
    public long update_id { get; set; }
    public ChannelPost? channel_post { get; set; }
}