using System.IO;

namespace BattleChess3.Game.Styles
{
    public class PaperStyle : IStyle
    {
        public string Name => Path.Combine(Directory.GetCurrentDirectory(),"PaperStyle");
        public string Preview => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\PaperStyle\\preview.png");
        public string ApplicationBackground => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\PaperStyle\\papertexture.jpg");
        public string Button => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\PaperStyle\\chessbutton.png");
        public string DefaultObject => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\Nothing.png");
        public string TabItem => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\PaperStyle\\border2.png");
        public string TabItemDisabled => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\PaperStyle\\disabled.png");
        public string TabItemMouseOn => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\PaperStyle\\mouseOver.png");
        public string ChessTile => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\Nothing.png");
        public string CanGoChessTile => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\PaperStyle\\canGo.png");
        public string DangeredChessTile => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\PaperStyle\\dangered.png");
        public string SelectedChessTile => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\PaperStyle\\selected.png");
        public string DefaultButton => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\PaperStyle\\border.png");
        public string DefaultButtonMouseOn => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\PaperStyle\\selected.png");
        public string TextBox => Path.Combine(Directory.GetCurrentDirectory(),"Pictures\\Nothing.png");
    }
}