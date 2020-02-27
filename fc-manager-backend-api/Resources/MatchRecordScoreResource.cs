using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using fc_manager_backend_da.Models;
using System.Collections.Generic;


namespace fc_manager_backend_api.Controllers.Resources
{

    public class MatchRecordScoreResource
    {
        public int? ScoreMemberId { get; set; }
        public virtual Member ScoreMember { get; set; }
        public int? AssistMemberId { get; set; }
        public virtual Member AssistMember { get; set; }
        public int CodeId { get; set; }
        public virtual Code Type { get; set; }
        public int MatchId { get; set; }
        public virtual Match Match { get; set; }
        
    }
}