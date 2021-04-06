using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsAlishaWebAPI.Models
{
    public class Student
    {
 
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int RollNo { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

    }
}
