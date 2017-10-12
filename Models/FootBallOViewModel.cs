using System;
using System.Collections;
using System.Collections.Generic;

namespace fantasyFootball.Models
{
    public class FootBallOViewModel
    {
        public int DYAR { get; set; }
        public int DYARRank { get; set; }
        public int QBR { get; set; }
        public int QBRRank { get; set; }
        public int DVOA { get; set; }
        public int DVOARank { get; set; }
        public int Yards { get; set; }
        public int EYards { get; set; }
        public int TDs { get; set; }
        public int INTs { get; set; }
        public int FLs { get; set; }
        public int SuccessRate { get; set; }
        public int DefDVOA { get; set; }
        public int DefDAVE { get; set; }
        public int DefDAVERank { get; set; }
    }
}