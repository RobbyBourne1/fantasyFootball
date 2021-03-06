using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace fantasyFootball.Models
{
    public class FantasyTeamModel
    {
        public string Id { get; set; }
        public string TeamName { get; set; }
        public string fantasySite { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<PlayersModel> Players { get; set; }

    }
}