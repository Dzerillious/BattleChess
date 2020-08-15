using BattleChess3.UI.Services;

namespace BattleChess3.UI.ViewModel
{
    public static class ViewModelLocator
    {
        public static MainWindowViewModel MainWindowViewModel { get; }
            = CommonServiceLocator.ServiceLocator.Current.GetInstance<MainWindowViewModel>();
        public static MapService MapService { get; }
            = CommonServiceLocator.ServiceLocator.Current.GetInstance<MapService>();
        public static FigureService FigureService { get; }
            = CommonServiceLocator.ServiceLocator.Current.GetInstance<FigureService>();
    }
}