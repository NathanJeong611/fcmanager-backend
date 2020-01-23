using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fc_manager_backend_da.Models
{
    public class Member : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        public DateTime StartedOn { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public virtual Code Role { get; set; }
        [ForeignKey("Club")]
        public int ClubId { get; set; }
        public virtual Club Club { get; set; }
        public virtual List<TeamMember> TeamMembers { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? DOB { get; set; }
    }
}
