using System;
using System.Collections;
using System.Collections.Generic;

namespace fantasyFootball.Models
{
    public class PlayersModel
    {
        public string Id { get; set; }
        public string FantasyTeamModelId { get; set; }
        public FantasyTeamModel FantasyTeamModel { get; set; }
        public string active { get; set; }
        public string jersey { get; set; }
        public string lname { get; set; }
        public string fname { get; set; }
        public string displayName { get; set; }
        public string team { get; set; }
        public string position { get; set; }
        public string dob { get; set; }
        public string college { get; set; }
    }
}