using System.Resources;
using System.Windows.Data;
using BattleChess3.Game.Localization;
using BattleChess3.UI.Resources;

namespace BattleChess3.UI.Localization;

internal class CurrentLocalization : LocalizationSourceBase
{
    private CurrentLocalization()
    {
        Sources.Add(this);
    }

    public static LocalizationSourceBase Instance { get; } = new CurrentLocalization();

    protected override ResourceManager ResManager()
    {
        return Strings.ResourceManager;
    }
}

internal class LocExtension : Binding
{
    public LocExtension(string name) : base("[" + name + "]")
    {
        Mode = BindingMode.OneWay;
        Source = CurrentLocalization.Instance;
    }
}