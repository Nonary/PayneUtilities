using System;

namespace PayneUtilities
{
    public interface IMatchVerifier
    {
        bool VerifyMatch(IMatch match);
    }
}