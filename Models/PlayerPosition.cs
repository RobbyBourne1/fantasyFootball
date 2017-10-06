using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
namespace fantasyFootball.Models
{
    [DefaultValue(NOPOSITION)]
    public enum PlayerPosition
    {
        NOPOSITION = 0,
        QUARTERBACK,
        RUNNINGBACK,
        WIDERECEIVER,
        TIGHTEND,
        KICKER,
        DEFENSIVESPECIALTEAMS
    }
}