using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fc_manager_backend_da.Models
{
    public class Match : BaseEntity
    {
        public virtual Team HomeTeam { get; set; }
        [ForeignKey("Team")]
        public int HomeTeamId{get; set;}
        public int HomeScore { get; set; }
        public virtual Team AwayTeam { get; set; }
        [ForeignKey("Team")]
        public int AwayTeamId{get; set;}
        public int AwayScore { get; set; }
        public DateTime ScheduledAt { get; set; }
        [StringLength(100)]
        public string Location {get;set;}
        public virtual League League {get;set;}
        [ForeignKey("Leauge")]
        public int LeagueId {get;set;}
        public virtual Club Club {get;set;}
        [ForeignKey("Club")]
        public int ClubId {get;set;}
        public IList<MatchRecord> MatchRecords { get; set; }

        public Match()
        {
            MatchRecords = new List<MatchRecord>();
        }
    }
}