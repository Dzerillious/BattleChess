namespace BattleChess3.GameData.Styles
{
    /// <summary>
    /// Interface for style of application
    /// </summary>
    public class Style
    {
        public Style(string directory)
        {
            Name = directory;
            Preview = directory + "\\Preview.png";
            ApplicationBackground = directory + "\\ApplicationBackground.jpg";
            DefaultObject = directory + "\\DefaultObject.png";
            TabItem = directory + "\\TabItem.png";
            TabItemDisabled = directory + "\\TabItemDisabled.png";
            TabItemMouseOn = directory + "\\TabItemMouseOn.png";
            ChessTile = directory + "\\ChessTile.png";
            CanGoChessTile = directory + "\\ChessTileCanGo.png";
            DangeredChessTile = directory + "\\ChessTileDangered.png";
            SelectedChessTile = directory + "\\ChessTileSelected.png";
            DefaultButton = directory + "\\DefaultButton.png";;
            DefaultButtonMouseOn = directory + "\\DefaultButtonMouseOn.png";
            TextBox = directory + "\\TextBox.png";
        }

        /// <summary>
        /// Gets name of style
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        /// Gets path of preview image of style
        /// </summary>
        public string Preview { get; }
        
        /// <summary>
        /// Gets path of ApplicationBackground image
        /// </summary>
        public string ApplicationBackground { get; }
        
        /// <summary>
        /// Gets path of DefaultObject image
        /// </summary>
        public string DefaultObject { get; }
        
        /// <summary>
        /// Gets path of TabItem image
        /// </summary>
        public string TabItem { get; }
        
        /// <summary>
        /// Gets path of Disabled TabItem image
        /// </summary>
        public string TabItemDisabled { get; }
        
        /// <summary>
        /// Gets path of MouseOn TabItem image
        /// </summary>
        public string TabItemMouseOn { get; }
        
        /// <summary>
        /// Gets path of ChessTile image
        /// </summary>
        public string ChessTile { get; }
        
        /// <summary>
        /// Gets path of ChessTile where can go image
        /// </summary>
        public string CanGoChessTile { get; }
        
        /// <summary>
        /// Gets path of Dangered ChessTile image
        /// </summary>
        public string DangeredChessTile { get; }
        
        /// <summary>
        /// Gets path of ChessTile image where is mouse on
        /// </summary>
        public string SelectedChessTile { get; }
        
        /// <summary>
        /// Gets path of Default button image
        /// </summary>
        public string DefaultButton { get; }
        
        /// <summary>
        /// Gets path of Default button image where is mouse on
        /// </summary>
        public string DefaultButtonMouseOn { get; }
        
        /// <summary>
        /// Gets path of Default button image where is mouse on
        /// </summary>
        public string TextBox { get; }
    }
}