
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;

namespace fc_manager_backend_api.Controllers.Resources
{
    public class QueryResultResource<T>
    {
        public DateTime ScheduledOn { get; set; }
        public IEnumerable<T> Matches { get; set; }
    }
}