using BattleChess3.UI.Services;

namespace BattleChess3.UI.ViewModel
{
    public static class ViewModelLocator
    {
        public static MapService MapService { get; }
            = CommonServiceLocator.ServiceLocator.Current.GetInstance<MapService>();
    }
}