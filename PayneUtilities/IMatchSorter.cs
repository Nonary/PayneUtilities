using System.Collections.Generic;

namespace PayneUtilities
{
    public interface IMatchSorter
    {
        IEnumerable<IMatch> SortMatches(IEnumerable<IMatch> matchesToSort);
    }
}