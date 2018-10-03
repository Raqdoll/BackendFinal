using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend_Final_Project
{
    [System.Serializable]
    public class NewMatch
    {
        public int Winner { get; set; } //0 = tie, 1 = player 1, 2 = player 2.
        public int MatchTurns { get; set; }    
        public List<String> PlayerOneTeam { get; set; }
        public List<String> PlayerTwoTeam { get; set; }
    }
}