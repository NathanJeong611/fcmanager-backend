using System;
using System.ComponentModel.DataAnnotations;

namespace fc_manager_backend_api.Controllers.Resources
{
    public class BaseResource
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}