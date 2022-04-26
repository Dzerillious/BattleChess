using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace BattleChess3.Core.Utilities
{
    public static class CompressionHelper
    {
        public static string Compress(string s)
        {
            using MemoryStream memoryStream1 = new MemoryStream(Encoding.UTF8.GetBytes(s));
            using MemoryStream memoryStream2 = new MemoryStream();
            using (GZipStream gzipStream = new GZipStream(memoryStream2, CompressionMode.Compress))
                memoryStream1.CopyTo(gzipStream);
            return Convert.ToHexString(memoryStream2.ToArray());
        }

        public static string Decompress(string s)
        {
            try
            {
                using MemoryStream memoryStream1 = new MemoryStream(Convert.FromHexString(s));
                using MemoryStream memoryStream2 = new MemoryStream();
                using (GZipStream gzipStream = new GZipStream(memoryStream1, CompressionMode.Decompress))
                    gzipStream.CopyTo(memoryStream2);
                return Encoding.UTF8.GetString(memoryStream2.ToArray());
            }
            catch (Exception)
            {
                using MemoryStream memoryStream1 = new MemoryStream(Convert.FromBase64String(s));
                using MemoryStream memoryStream2 = new MemoryStream();
                using (GZipStream gzipStream = new GZipStream(memoryStream1, CompressionMode.Decompress))
                    gzipStream.CopyTo(memoryStream2);
                return Encoding.UTF8.GetString(memoryStream2.ToArray());
            }
        }
    }
}