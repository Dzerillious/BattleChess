using BattleChess3.UI.Services;

namespace BattleChess3.UI.ViewModel
{
    public static class ViewModelLocator
    {
        public static MainWindowViewModel MainWindowViewModel
            => CommonServiceLocator.ServiceLocator.Current.GetInstance<MainWindowViewModel>();
        public static BoardViewModel BoardViewModel
            => CommonServiceLocator.ServiceLocator.Current.GetInstance<BoardViewModel>();
        public static MapService MapService
            => CommonServiceLocator.ServiceLocator.Current.GetInstance<MapService>();
        public static FigureService FigureService
            => CommonServiceLocator.ServiceLocator.Current.GetInstance<FigureService>();
    }
}