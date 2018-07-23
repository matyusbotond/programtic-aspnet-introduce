using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPWebIntroduce.Models
{
    public class TodoItem
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsDone { get; set; }

        public DateTime ClosedDate { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}