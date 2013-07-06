using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Notechest.Models
{
    public class Note
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "A title is required.")]
        public string Title { get; set; }

        public string Value { get; set; }
        public string Tags { get; set; }
    }
}