using System.IO;

namespace BattleChess3.Game.Styles
{
    public class SciFiStyle : IStyle
    {
        public string Name => Path.Combine(Directory.GetCurrentDirectory(),"SciFiStyle");
        public string Preview => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\SciFiStyle\\preview.png");
        public string ApplicationBackground => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\SciFiStyle\\papertexture.jpg");
        public string Button => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\SciFiStyle\\border.png");
        public string DefaultObject => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\Nothing.png");
        public string TabItem => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\SciFiStyle\\border.png");
        public string TabItemDisabled => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\SciFiStyle\\disabled.png");
        public string TabItemMouseOn => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\SciFiStyle\\mouseon.png");
        public string ChessTile => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\Nothing.png");
        public string CanGoChessTile => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\SciFiStyle\\chessbuttoncango.png");
        public string DangeredChessTile => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\SciFiStyle\\disabled.png");
        public string SelectedChessTile => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\SciFiStyle\\mouseon.png");
        public string DefaultButton => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\SciFiStyle\\border.png");
        public string DefaultButtonMouseOn => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\SciFiStyle\\mouseon.png");
        public string TextBox => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\SciFiStyle\\textbox.png");
    }
}