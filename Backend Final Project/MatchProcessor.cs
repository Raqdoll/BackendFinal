using System;
using System.Threading.Tasks;

namespace Backend_Final_Project
{
    public class MatchProcessor
    {
        IRepository repository;

        public MatchProcessor (IRepository repo){
            repository = repo;
        }
        public Task<Match> Get (Guid id){
            return repository.GetMatch(id);
        }
        public Task<Match[]> GetAll(){
            return repository.GetAllMatches();
        }
        public Task<Match> Create(NewMatch match){
            Match temporary = new Match();
            temporary.MatchId = Guid.NewGuid();
            temporary.TimeAndDate = DateTime.Now;
            temporary.Winner = match.Winner;
            temporary.MatchTurns = match.MatchTurns;
            temporary.PlayerOneTeam = match.PlayerOneTeam;
            temporary.PlayerTwoTeam = match.PlayerTwoTeam;
            return repository.CreateMatch(temporary);
        }
        public Task<Match> Delete(Guid id){
            return repository.DeleteMatch(id);
        }
        public Task<double> CharacterPickrate(string character){
            return repository.CharacterPickrate(character);
        }
        public Task<double> PlayerOneWinrate(){
            return repository.PlayerOneWinrate();
        }
        // public Task<Match> Update(Guid id, Match match){
        //     Match replaceMatch = new Match();
        //     replaceMatch.Winner = match.Winner;
        //     replaceMatch.MatchTurns = match.MatchTurns;
        //     replaceMatch.PlayerOneTeam = match.PlayerOneTeam;
        //     replaceMatch.PlayerTwoTeam = match.PlayerTwoTeam;
        //     replaceMatch.MatchId = Guid.NewGuid();
        //     replaceMatch.TimeAndDate = DateTime.Now;
        //     return repository.UpdateMatch(id, replaceMatch);
        // }
    }
}