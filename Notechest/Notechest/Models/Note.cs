using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Notechest.Models
{
    public class Note : IAuditable
    {
        public int ID { get; set; }

        public int? OrganizationID { get; set; }
        public int? ProjectID { get; set; }

        [Required(ErrorMessage = "A title is required.")]
        public string Title { get; set; }

        [Column(TypeName = "ntext")]
        public string Value { get; set; }

        public string Tags { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? LastModified { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual Project Project { get; set; }

    }
}