namespace BattleChess3.Game.Styles
{
    /// <summary>
    /// Interface for style of application
    /// </summary>
    public interface IStyle
    {
        /// <summary>
        /// Gets name of style
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// Gets path of preview image of style
        /// </summary>
        string Preview { get; }
        
        /// <summary>
        /// Gets path of ApplicationBackground image
        /// </summary>
        string ApplicationBackground { get; }
        
        /// <summary>
        /// Gets path of Button image
        /// </summary>
        string Button { get; }
        
        /// <summary>
        /// Gets path of DefaultObject image
        /// </summary>
        string DefaultObject { get; }
        
        /// <summary>
        /// Gets path of TabItem image
        /// </summary>
        string TabItem { get; }
        
        /// <summary>
        /// Gets path of Disabled TabItem image
        /// </summary>
        string TabItemDisabled { get; }
        
        /// <summary>
        /// Gets path of MouseOn TabItem image
        /// </summary>
        string TabItemMouseOn { get; }
        
        /// <summary>
        /// Gets path of ChessTile image
        /// </summary>
        string ChessTile { get; }
        
        /// <summary>
        /// Gets path of ChessTile where can go image
        /// </summary>
        string CanGoChessTile { get; }
        
        /// <summary>
        /// Gets path of Dangered ChessTile image
        /// </summary>
        string DangeredChessTile { get; }
        
        /// <summary>
        /// Gets path of ChessTile image where is mouse on
        /// </summary>
        string SelectedChessTile { get; }
        
        /// <summary>
        /// Gets path of Default button image
        /// </summary>
        string DefaultButton { get; }
        
        /// <summary>
        /// Gets path of Default button image where is mouse on
        /// </summary>
        string DefaultButtonMouseOn { get; }
        
        /// <summary>
        /// Gets path of Default button image where is mouse on
        /// </summary>
        string TextBox { get; }
    }
}