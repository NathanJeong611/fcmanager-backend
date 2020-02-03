using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using fc_manager_backend_da.Models;
using System.Collections.Generic;


namespace fc_manager_backend_api.Controllers.Resources
{
    public class MemberResource : BaseResource
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        public DateTime StartedOn { get; set; }
        public int RoleId { get; set; }
        public virtual Code Role { get; set; }
        public int ClubId { get; set; }
        public virtual Club Club { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? DOB { get; set; }
    }
}