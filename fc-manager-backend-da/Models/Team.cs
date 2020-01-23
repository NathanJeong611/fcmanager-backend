using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fc_manager_backend_da.Models
{
    public class Team : BaseEntity
    {
        [StringLength(100)]
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public string History { get; set; }
        public DateTime StartedOn { get; set; }
        public DateTime? EndedOn { get; set; }
        public virtual Club Club { get; set; }
        [ForeignKey("Club")]
        public int ClubId {get;set;}
    }
}