using System.IO;

namespace BattleChess3.Properties
{
    public static class StaticResources
    {
        public static string Background => Directory.GetCurrentDirectory() + "\\Pictures\\papertexture.jpg";
        public static string BorderPic => Directory.GetCurrentDirectory() + "\\Pictures\\border.png";
        public static string Selected => Directory.GetCurrentDirectory() + "\\Pictures\\selected.png";
        public static string CanGo => Directory.GetCurrentDirectory() + "\\Pictures\\canGo.png";
        public static string Dangered => Directory.GetCurrentDirectory() + "\\Pictures\\dangered.png";
        public static string NotHighlighted => Directory.GetCurrentDirectory() + "\\Pictures\\Nothing.png";
        
        public static string BorderPic2 => Directory.GetCurrentDirectory() + "\\Pictures\\border2.png";
        public static string Disabled => Directory.GetCurrentDirectory() + "\\Pictures\\disabled.png";
        public static string MouseOver => Directory.GetCurrentDirectory() + "\\Pictures\\mouseOver.png";
        public static string Selected2 => Directory.GetCurrentDirectory() + "\\Pictures\\selected2.png";
    }
}