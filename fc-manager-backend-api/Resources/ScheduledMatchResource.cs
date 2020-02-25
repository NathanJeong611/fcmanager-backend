using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using fc_manager_backend_da.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace fc_manager_backend_api.Controllers.Resources
{
    public class ScheduledMatchResource : BaseResource
    {
        public DateTime ScheduledAt { get; set; }
        public List<MatchResource> Matches { get; set; }

        public ScheduledMatchResource()
        {
            Matches = new List<MatchResource>();
        }
    }
}