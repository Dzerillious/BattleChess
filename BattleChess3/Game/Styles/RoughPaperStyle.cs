using System.IO;

namespace BattleChess3.Game.Styles
{
    public class RoughPaperStyle : IStyle
    {
        public string Name => Path.Combine(Directory.GetCurrentDirectory(),"RoughPaperStyle");
        public string Preview => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\RoughPaperStyle\\preview.png");
        public string ApplicationBackground => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\RoughPaperStyle\\papertexture.jpg");
        public string Button => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\RoughPaperStyle\\border.png");
        public string DefaultObject => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\default.png");
        public string TabItem => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\RoughPaperStyle\\border2.png");
        public string TabItemDisabled => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\RoughPaperStyle\\disabled.png");
        public string TabItemMouseOn => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\RoughPaperStyle\\mouseOver.png");
        public string ChessTile => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\RoughPaperStyle\\border.png");
        public string CanGoChessTile => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\RoughPaperStyle\\canGo.png");
        public string DangeredChessTile => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\RoughPaperStyle\\dangered.png");
        public string SelectedChessTile => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\RoughPaperStyle\\selected.png");
        public string DefaultButton => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\RoughPaperStyle\\border.png");
        public string DefaultButtonMouseOn => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\RoughPaperStyle\\selected.png");
        public string TextBox => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\Nothing.png");
    }
}