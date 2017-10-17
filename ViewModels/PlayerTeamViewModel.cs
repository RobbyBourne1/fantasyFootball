using System;
using System.Collections;
using System.Collections.Generic;

namespace fantasyFootball.Models
{
    public class PlayerTeamViewModel
    {
       public List<FantasyTeamModel> FantasyTeam { get; set; } = new List<FantasyTeamModel>();
       public List<PlayersModel> FantasyPlayers { get; set; } = new List<PlayersModel>();
    }
}