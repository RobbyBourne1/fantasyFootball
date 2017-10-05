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
        public string PlayerFirstName { get; set; }
        public string PlayerLastName { get; set; }
        public PlayerPosition Position { get; set; }
        public string PlayerPosition { get => this.PlayerPosition.ToString(); }
        public string ProfessionalTeamName { get; set; }
        public string Status { get; set; }
        public int PassingYards { get; set; }
        public int PassingTDs { get; set; }
        public int PassingInts { get; set; }
        public int RushingYards { get; set; }
        public int RushingTDs { get; set; }
        public int Receptions { get; set; }
        public int ReceivingYards { get; set; }
        public int ReceivingTDs { get; set; }
        public int FumblesLost { get; set; }
        public int TwoPtConv { get; set; }
        public int PointAfterAttempts { get; set; }
        public int FGMade { get; set; }
        public int Sacks { get; set; }
        public int FumbleRecoveries { get; set; }
        public int ForcedFumbles { get; set; }
        public int Safeties { get; set; }
        public int DefensiveTDs { get; set; }
        public int SpecialTeamsTDs { get; set; }
        public int TotalFantasyPoints { get; set; }


    }
}