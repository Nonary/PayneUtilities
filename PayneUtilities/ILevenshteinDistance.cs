namespace PayneUtilities
{
    public interface ILevenshteinDistance
    {
        int GetDistance(string source, string target);
    }
}