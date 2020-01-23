using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fc_manager_backend_da.Models
{
    public class MatchRecord : BaseEntity
    {
        [ForeignKey("Member")]
        public int MemberId { get; set; }
        public virtual Member Member { get; set; }
        [ForeignKey("Code")]
        public int CodeId { get; set; }
        public virtual Code Type { get; set; }
        [ForeignKey("Match")]
        public int MatchId { get; set; }
        public virtual Match Match { get; set; }
    }
}