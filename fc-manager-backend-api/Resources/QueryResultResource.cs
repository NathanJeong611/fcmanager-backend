
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;

namespace fc_manager_backend_api.Controllers.Resources
{
    public class QueryResultResource<T>
    {
        public int MemberId { get; set; }
        //public Member Member { get; set; }
        public int RecordCount { get; set;}
    }
}