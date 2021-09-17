using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using student_listing.Business.StudentBusiness;
using student_listing.Controllers.StudentController.Models;
using student_listing.Models;
using student_listing.Web.Controllers.StudentController.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace student_listing.Controllers.StudentController
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        /// <summary>
        /// Student Business
        /// </summary>
        private IStudentBusiness _studentBusiness { get; set; }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="studentBusiness"></param>
        public StudentController(IStudentBusiness studentBusiness)
        {
            _studentBusiness = studentBusiness;
        }

        /// <summary>
        /// Gets a list of all students
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<GetStudentList>> Get([FromQuery] string searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                return Ok(new GetStudentList(await _studentBusiness.SearchStudents(searchTerm)));
            }
            return Ok(new GetStudentList(await _studentBusiness.GetStudentList()));
        }

        /// <summary>
        /// Gets a student with the supplied id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>student</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<GetStudent>> Get(int id)
        {
            return Ok(new GetStudent(await _studentBusiness.GetStudent(id)));
        }

        /// <summary>
        /// Updates a student
        /// </summary>
        /// <param name="updateStudentParams">info to update student with</param>
        /// <returns>If the student was updated</returns>
        [HttpPut]
        public async Task<ActionResult<UpdateStudentResult>> UpdateStudent([FromBody] UpdateStudentParams updateStudentParams)
        {
            Student student = new Student
            {
                StudentId = updateStudentParams.StudentId,
                FirstName = updateStudentParams.FirstName,
                LastName = updateStudentParams.LastName,
                Email = updateStudentParams.Email,
                Registrations = updateStudentParams.Registrations
            };

            return Ok(new UpdateStudentResult(await _studentBusiness.UpdateStudent(student)));
        }

        /// <summary>
        /// Creates a student
        /// </summary>
        /// <param name="createStudentParams">info to create the student with</param>
        /// <returns>If the student was created</returns>
        [HttpPost]
        public async Task<ActionResult<CreateStudentResult>> Post([FromBody] CreateStudentParams createStudentParams)
        {
            Student student = new Student
            {
                FirstName = createStudentParams.FirstName,
                LastName = createStudentParams.LastName,
                Email = createStudentParams.Email
            };
            return Ok(new CreateStudentResult(await _studentBusiness.CreateStudent(student)));
        }

        /// <summary>
        /// Deletes a student
        /// </summary>
        /// <param name="studentId">student id</param>
        /// <returns>if the student was deleted</returns>
        [HttpDelete("{studentId}")]
        public async Task<ActionResult<DeleteStudentResult>> Delete(int studentId)
        {
            return Ok(new DeleteStudentResult(await _studentBusiness.DeleteStudent(studentId)));
        }
    }
}
