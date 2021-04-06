using StudentsAlishaWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsAlishaWebAPI.Data
{
    public interface IStudentsRepo
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int id);
        void CreateStudent(Student std);
        void UpdateStudent(Student std);
        void DeleteStudent(Student std);
        bool SaveChanges();
    }
}
