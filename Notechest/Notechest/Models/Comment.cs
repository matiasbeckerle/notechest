using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Notechest.Models
{
    public class Comment : IAuditable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "A message is required.")]
        public string Message { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? LastModified { get; set; }
    }
}