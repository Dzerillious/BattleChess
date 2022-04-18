using BattleChess3.Core.Model.Figures;
using BattleChess3.HobbitFigures.Localization;

namespace BattleChess3.HobbitFigures;

public class HobbitFigureGroup : IFigureGroup
{
    public string ShownName => CurrentLocalization.Instance["HobbitFigureGroup_Name"];

    public IFigureType[] FigureTypes => new IFigureType[]
    {
        Leader.Instance,
        RingBearer.Instance,
        Helper.Instance,
        MinorWizard.Instance,
        Soldier.Instance,
        Warrior.Instance,
        Wizard.Instance,
    };
}
