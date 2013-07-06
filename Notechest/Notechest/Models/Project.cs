using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Notechest.Models
{
    public class Project
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "A name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "An organization is required.")]
        [Display(Name = "Organization")]
        public int OrganizationID { get; set; }

        public virtual Organization Organization { get; set; }
    }
}