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
    public class MatchRecordScoreResource
    {
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public int RecordCount { get; set;}
        
    }
}