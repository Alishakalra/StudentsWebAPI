using Microsoft.EntityFrameworkCore;
using StudentsAlishaWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsAlishaWebAPI.Data
{
    public class StudentsContext : DbContext
    {
        public StudentsContext(DbContextOptions<StudentsContext> opt) : base(opt)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}
