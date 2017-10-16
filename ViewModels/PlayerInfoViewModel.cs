using System;
using System.Collections;
using System.Collections.Generic;

namespace fantasyFootball.Models
{
    public class PlayerInfoViewModel
    {
       public List<FantasyProsModel> FantasyPros { get; set; } = new List<FantasyProsModel>();
       public List<FootBallOModel> FootBallO { get; set; } = new List<FootBallOModel>();
       public List<MatchupScheduleModel> MatchupSchedule{ get; set; } = new List<MatchupScheduleModel>();
    }
}