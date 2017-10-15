using System;
using System.Collections;
using System.Collections.Generic;

namespace fantasyFootball.Models
{
    public class PlayerInfoViewModel
    {
       public List<FantasyProsModel> FantasyPros { get; set; }
       public List<FootBallOModel> FootBallO { get; set; }
       public List<MatchupScheduleModel> MatchupSchedule{ get; set; }
    }
}