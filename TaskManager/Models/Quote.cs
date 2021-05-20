using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{
    public class Quote
    {
        
        public int QuoteID { get; set; }

        [Required(ErrorMessage ="Enter QuoteType")]
        [StringLength(100)]
        public string QuoteType { get; set; }

        [Required(ErrorMessage = "Enter Contact")]
        [StringLength(100)]
        public string Contact { get; set; }
        public string Task { get; set; }

        [Required(ErrorMessage = "Enter Due date for quote")]
        public System.DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Enter Task Type: e.g  Follow-up, new , etc")]
        public string TaskType { get; set; }
    }
}