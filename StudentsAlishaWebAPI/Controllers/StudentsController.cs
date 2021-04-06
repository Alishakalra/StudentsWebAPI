using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using StudentsAlishaWebAPI.Data;
using StudentsAlishaWebAPI.Dtos;
using StudentsAlishaWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsAlishaWebAPI.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsRepo _repository;
        private readonly IMapper _mapper;

        public StudentsController(IStudentsRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        //GET api/students
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAllStudents()
        {
            var studentRecords = _repository.GetAllStudents();
            return Ok(studentRecords);
        }

        //GET api/students/{id}
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            var studentRecord = _repository.GetStudentById(id);
            if (studentRecord != null)
            {
                return Ok(studentRecord);
            }

            return NotFound();
        }

        //POST api/students
        [HttpPost]
        public ActionResult<Student> CreateStudent(StudentCreateDto studentCreateDto)
        {
            var studentModel = _mapper.Map<Student>(studentCreateDto);
            _repository.CreateStudent(studentModel);
            _repository.SaveChanges();

            //return CreatedAtRoute(nameof(GetStudentById), new { id = studentModel.StudentId }, studentModel);
            return Ok(studentModel);

        }

        //PUT api/students/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, StudentUpdateDto studentUpdateDto)
        {
            var studentModelFromRepo = _repository.GetStudentById(id);
            if (studentModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(studentUpdateDto, studentModelFromRepo);

            _repository.UpdateStudent(studentModelFromRepo);

            _repository.SaveChanges();

            return Ok(studentModelFromRepo);
        }

        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialStudentUpdate(int id, JsonPatchDocument<StudentUpdateDto> patchDoc)
        {
            var studentModelFromRepo = _repository.GetStudentById(id);
            if (studentModelFromRepo == null)
            {
                return NotFound();
            }

            var studentToPatch = _mapper.Map<StudentUpdateDto>(studentModelFromRepo);
            patchDoc.ApplyTo(studentToPatch, ModelState);

            if (!TryValidateModel(studentToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(studentToPatch, studentModelFromRepo);

            _repository.UpdateStudent(studentModelFromRepo);

            _repository.SaveChanges();

            return Ok(studentModelFromRepo);
        }

        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var studentModelFromRepo = _repository.GetStudentById(id);
            if (studentModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteStudent(studentModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
