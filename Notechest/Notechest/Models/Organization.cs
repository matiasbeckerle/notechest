using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Notechest.Models
{
    public class Organization : IAuditable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        [Required(ErrorMessage = "A name is required.")]
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? LastModified { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}