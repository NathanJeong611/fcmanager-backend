
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;

namespace fc_manager_backend_api.Controllers.Resources
{
    public class QueryResultResource<T>
    {
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamLogoUrl { get; set; }
        public int Count { get; set; }
        public string Type { get; set; }
    }
}