using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using fc_manager_backend_da.Models;
using System.Collections.Generic;


namespace fc_manager_backend_api.Controllers.Resources
{
    // public class List<MatchResource>
    // {
    //     public MatchResource match {get;set;}
    // }
    public class MatchRecordResource : BaseResource
    {
        public int ScoreMemberId { get; set; }
        public string ScoreMemberName { get; set; }
        public int ScoreTeamId { get; set; }
        public int AssistMemberId { get; set; }
        public string AssistMemberName { get; set; }
        public int AssistTeamId { get; set; }
        public int CodeId { get; set; }
        public string CodeName { get; set; }
        public int MatchId { get; set; }
        public virtual Match Match { get; set; }
    }
}