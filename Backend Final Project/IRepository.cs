using System;
using System.Threading.Tasks;

namespace Backend_Final_Project
{
    public interface IRepository
    {
        Task<Match> CreateMatch(Match match);
        Task<Match> GetMatch(Guid matchId);
        Task<Match[]> GetAllMatches();
        //Task<Match> UpdateMatch(Guid id, Match match);
        Task<Match> DeleteMatch(Guid matchId);
        Task<double> CharacterPickrate(string character);
        Task<double> PlayerOneWinrate();
    }
}