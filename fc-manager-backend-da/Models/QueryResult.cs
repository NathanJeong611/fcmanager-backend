using System.Reflection.Metadata.Ecma335;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace fc_manager_backend_da.Models
{
    public class QueryResult<T>
    {
        public DateTime ScheduledOn { get; set; }
        public IEnumerable<T> Matches { get; set; }
    }
}