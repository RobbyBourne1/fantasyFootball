using System;
using System.Collections;
using System.Collections.Generic;

namespace fantasyFootball.Models
{
    public class FootBallOViewModel
    {
        public string Position { get; set; }
        public string DYAR { get; set; }
        public string DYARRank { get; set; }
        public string QBR { get; set; }
        public string QBRRank { get; set; }
        public string DVOA { get; set; }
        public string DVOARank { get; set; }
        public string Yards { get; set; }
        public string EYards { get; set; }
        public string TDs { get; set; }
        public string INTs { get; set; }
        public string FumblesLost { get; set; }
        public string SuccessRate { get; set; }
        public string DefDVOA { get; set; }
        public string DefDAVE { get; set; }
        public string DefDAVERank { get; set; }
        public string Passes { get; set; }
        public string CatchRate { get; set; }
        public string FGXPRatio { get; set; }
    }
}