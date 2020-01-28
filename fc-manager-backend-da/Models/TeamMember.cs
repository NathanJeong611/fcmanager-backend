using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace fc_manager_backend_da.Models
{
    public class TeamMember : BaseEntity
    {
        [ForeignKey("Member")]
        public int MemberId{get;set;}
        [ForeignKey("Team")]
        public int TeamId{get;set;}
        public virtual Member Member { get; set; }
        public virtual Team Team { get; set; }
        public bool IsCaptain { get; set; }
    }
}