using System.Reflection.Metadata.Ecma335;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace fc_manager_backend_da.Models
{
    public class QueryResult<T>
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