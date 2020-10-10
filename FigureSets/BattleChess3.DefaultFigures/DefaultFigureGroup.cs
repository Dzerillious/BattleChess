using BattleChess3.Core.Model.Figures;
using BattleChess3.DefaultFigures.Localization;

namespace BattleChess3.DefaultFigures
{
    public class DefaultFigureGroup : IFigureGroup
    {
        public string ShownName => CurrentLocalization.Instance["DefaultFigureGroup_Name"];

        public IFigureType[] GroupFigures => new IFigureType[]
        {
            Palm.Instance,
            Empty.Instance,
            Ninja.Instance,
            Stone.Instance,
        };
    }
}
