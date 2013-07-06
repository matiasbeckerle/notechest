using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Notechest.Models
{
    public class Organization
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "A name is required.")]
        public string Name { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}