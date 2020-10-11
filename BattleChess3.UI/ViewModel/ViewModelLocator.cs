using BattleChess3.UI.Services;
using CommonServiceLocator;

namespace BattleChess3.UI.ViewModel
{
    public static class ViewModelLocator
    {
        public static MainWindowViewModel MainWindowViewModel
            => ServiceLocator.Current.GetInstance<MainWindowViewModel>();
        public static MapService MapService
            => ServiceLocator.Current.GetInstance<MapService>();
        public static StyleService StyleService
            => ServiceLocator.Current.GetInstance<StyleService>();
        public static FigureService FigureService
            => ServiceLocator.Current.GetInstance<FigureService>();
    }
}