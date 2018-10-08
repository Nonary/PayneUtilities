using System.Collections.Generic;
using System.Linq;

namespace PayneUtilities
{
    public class DefaultMatchSorter : IMatchSorter
    {
        public IEnumerable<IMatch> SortMatches(IEnumerable<IMatch> matchesToSort)
        {
            return matchesToSort.Where(x => x.MatchConfidence > 0).OrderByDescending(x => x.MatchConfidence)
                .ThenBy(x => x.SourceString).ThenBy(x => x.TargetString);
        }
    }
}