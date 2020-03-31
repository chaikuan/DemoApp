using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cors.Models
{
    public class Student
    {
        [Required]
        [StringLength(maximumLength:100,MinimumLength =5)]
        public string StudentName { get; set; }
    }
}