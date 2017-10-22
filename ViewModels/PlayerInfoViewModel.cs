using System;
using System.Collections;
using System.Collections.Generic;

namespace fantasyFootball.Models
{
    public class PlayerInfoViewModel
    {
       public List<FantasyProsModel> FantasyPros { get; set; } = new List<FantasyProsModel>();
       public List<FootBallOModel> FootBallO { get; set; } = new List<FootBallOModel>();
       public List<SnapCountModel> SnapCounts { get; set; } = new List<SnapCountModel>();
       public List<TargetsModel> Targets { get; set; } = new List<TargetsModel>();

    }
}