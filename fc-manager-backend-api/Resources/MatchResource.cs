using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using fc_manager_backend_da.Models;
using System.Collections.Generic;


namespace fc_manager_backend_api.Controllers.Resources
{
    public class MatchResource : BaseResource
    {
        public string HomeTeamName { get; set; }
        public int HomeTeamId{get; set;}
        public int HomeScore { get; set; }
        public string AwayTeamName { get; set; }
        public int AwayTeamId{get; set;}
        public int AwayScore { get; set; }
        public DateTime ScheduledAt { get; set; }
        [StringLength(100)]
        public string Location {get;set;}
        public virtual League League {get;set;}
        public int LeagueId {get;set;}
        public virtual Club Club {get;set;}
        public int ClubId {get;set;}
    }
}