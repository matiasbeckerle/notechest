using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Notechest.Models
{
    public class Comment
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "A message is required.")]
        public string Message { get; set; }
    }
}