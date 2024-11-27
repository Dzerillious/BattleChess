using System.IO.Compression;
using System.Text;

namespace BattleChess3.Multiplayer.Utilities;

internal static class CompressionHelper
{
    public static string Compress(string s)
    {
        using var memoryStream1 = new MemoryStream(Encoding.UTF8.GetBytes(s));
        using var memoryStream2 = new MemoryStream();
        using (var gzipStream = new GZipStream(memoryStream2, CompressionMode.Compress))
        {
            memoryStream1.CopyTo(gzipStream);
        }

        return Convert.ToHexString(memoryStream2.ToArray());
    }

    public static string Decompress(string s)
    {
        using var memoryStream1 = new MemoryStream(Convert.FromHexString(s));
        using var memoryStream2 = new MemoryStream();
        using (var gzipStream = new GZipStream(memoryStream1, CompressionMode.Decompress))
        {
            gzipStream.CopyTo(memoryStream2);
        }

        return Encoding.UTF8.GetString(memoryStream2.ToArray());
    }
}