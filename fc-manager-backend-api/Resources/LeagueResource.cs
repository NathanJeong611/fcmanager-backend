using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using fc_manager_backend_da.Models;
using System.Collections.Generic;


namespace fc_manager_backend_api.Controllers.Resources
{
    public class LeagueResource : BaseResource
    {
        public string Name {get;set;}
        [StringLength(200)]
        public int ClubId {get;set;}
        public DateTime StartedOn {get;set;}
        public DateTime? EndedOn {get;set;}
    }
}