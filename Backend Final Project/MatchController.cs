using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Final_Project
{
    [Route("api/match")]
    [ApiController]
    public class MatchController : Controller
    {
        private MatchProcessor processor;

        public MatchController (MatchProcessor pro){
            processor = pro;
        }
        [HttpGet("{id}")]
        public Task<Match> Get (Guid id){
            return processor.Get(id);
        }
        [HttpGet]
        public Task<Match[]>GetAll(){
            return processor.GetAll();
        }
        [HttpPost]
        public Task<Match> Create(NewMatch match){
            // Match tempCreate = new Match();
            // tempCreate.Winner = match.Winner;
            // tempCreate.MatchTurns = match.MatchTurns;
            // tempCreate.PlayerOneTeam = match.PlayerOneTeam;
            // tempCreate.PlayerTwoTeam = match.PlayerTwoTeam;
            Console.WriteLine(match.Winner);

            return processor.Create(match);
        }
        //[HttpPut("{id}")]
        // public Task<Match> Update(Guid id, [FromBody] Match match){
        //     return processor.Update(id, match);
        // }
        [HttpDelete("{id}")]
        public Task<Match> Delete(Guid id){
            return processor.Delete(id);
        }
        [HttpGet("{character}")]
        public Task<double> CharacterPickrate(string character){
            return processor.CharacterPickrate(character);
        }
        [HttpGet]
        public Task<double> PlayerOneWinrate(){
            return processor.PlayerOneWinrate();
        }
    }
}