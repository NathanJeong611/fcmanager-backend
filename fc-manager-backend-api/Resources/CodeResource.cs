using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using fc_manager_backend_da.Models;
using System.Collections.Generic;


namespace fc_manager_backend_api.Controllers.Resources
{
    public class CodeResource : BaseResource
    {
        public virtual Code ParentCode {get;set;}
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}