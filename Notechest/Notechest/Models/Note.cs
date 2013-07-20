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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        public Guid SourceKey { get; set; }

        [Required(ErrorMessage = "A title is required.")]
        public string Title { get; set; }

        [Column(TypeName = "ntext")]
        public string Value { get; set; }

        public string Tags { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? LastModified { get; set; }

        public Organization Organization { get; set; }
        public Project Project { get; set; }
    }
}