using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace fantasyFootball.Models
{
    [DefaultValue(INDIFFERENT)]
    public enum Position
    {
        QUARTERBACK = "QB",
        RUNNINGBACK = "RB",
        WIDERECEIVER = "WR",
        TIGHTEND = "TE",
        KICKER = "K",
        DEFENSIVESPECIALTEAMS = "DST"
    }
}