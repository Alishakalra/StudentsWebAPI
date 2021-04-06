using StudentsAlishaWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsAlishaWebAPI.Data
{
    public class SqlStudentsRepo : IStudentsRepo
    {
        private readonly StudentsContext _context;

        public SqlStudentsRepo(StudentsContext context)
        {
            _context = context;
        }
        public void CreateStudent(Student std)
        {
            if (std == null)
            {
                throw new ArgumentNullException(nameof(std));
            }

            _context.Students.Add(std);
        }

        public void DeleteStudent(Student std)
        {
            if (std == null)
            {
                throw new ArgumentNullException(nameof(std));
            }
            _context.Students.Remove(std);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            return _context.Students.FirstOrDefault(p => p.StudentId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateStudent(Student std)
        {
            //Nothing
        }
    }
}
