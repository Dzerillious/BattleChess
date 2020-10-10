using BattleChess3.UI.Services;
using CommonServiceLocator;

namespace BattleChess3.UI.ViewModel
{
    public static class ViewModelLocator
    {
        public static MainWindowViewModel MainWindowViewModel
            => ServiceLocator.Current.GetInstance<MainWindowViewModel>();
        public static BoardViewModel BoardViewModel
            => ServiceLocator.Current.GetInstance<BoardViewModel>();
        public static MapService MapService
            => ServiceLocator.Current.GetInstance<MapService>();
        public static StyleService StyleService
            => ServiceLocator.Current.GetInstance<StyleService>();
        public static GameService GameService
            => ServiceLocator.Current.GetInstance<GameService>();
        public static BoardService BoardService
            => ServiceLocator.Current.GetInstance<BoardService>();
        public static FigureService FigureService
            => ServiceLocator.Current.GetInstance<FigureService>();
    }
}