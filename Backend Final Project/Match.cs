using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend_Final_Project
{
    public class Match
    {
        public Guid MatchId { get; set; }
        public DateTime TimeAndDate { get; set; }
        [Range(0,2)]
        public int Winner { get; set; } //0 = tie, 1 = player 1, 2 = player 2.
        public int MatchTurns { get; set; }    
        public List<String> PlayerOneTeam { get; set; }
        public List<String> PlayerTwoTeam { get; set; }
    }
}