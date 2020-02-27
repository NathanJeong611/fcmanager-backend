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
    public class MatchRecordAssistResource
    {
        public int AssistMemberId { get; set; }
        public string AssistMemberName { get; set; }
        public int AssistTeamId { get; set; }
        public int AsisstTotal { get; set; }
    }
}