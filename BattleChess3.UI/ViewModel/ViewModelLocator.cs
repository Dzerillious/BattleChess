using CommonServiceLocator;

namespace BattleChess3.UI.ViewModel;

public static class ViewModelLocator
{
    public static MainWindowViewModel MainWindowViewModel
        => ServiceLocator.Current.GetInstance<MainWindowViewModel>();
    public static ThemesViewModel ThemesViewModel
        => ServiceLocator.Current.GetInstance<ThemesViewModel>();
    public static FiguresViewModel FiguresViewModel
        => ServiceLocator.Current.GetInstance<FiguresViewModel>();
}
