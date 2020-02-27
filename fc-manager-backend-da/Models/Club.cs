using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fc_manager_backend_da.Models
{
    public class Club : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public string Description { get; set; }
        public string History { get; set; }
        public DateTime StartedOn { get; set; }
    }
}
