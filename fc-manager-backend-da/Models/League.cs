using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fc_manager_backend_da.Models
{
    public class League : BaseEntity
    {
        public string Name {get;set;}
        [StringLength(200)]
        public virtual Club Club {get;set;}
        [ForeignKey("Club")]
        public int ClubId {get;set;}
        public DateTime StartedOn {get;set;}
        public DateTime? EndedOn {get;set;}
    }
}