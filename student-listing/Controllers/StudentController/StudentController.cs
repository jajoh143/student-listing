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

        public StudentController(IStudentBusiness studentBusiness)
        {
            _studentBusiness = studentBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<GetStudentList>> Get()
        {
            return Ok(new GetStudentList(await _studentBusiness.GetStudentList()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetStudent>> Get(int id)
        {
            return Ok(new GetStudent(await _studentBusiness.GetStudent(id)));
        }

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

        [HttpPost]
        public async Task<ActionResult<CreateStudentResult>> CreateStudent([FromBody] CreateStudentParams createStudentParams)
        {
            Student student = new Student
            {
                StudentId = createStudentParams.StudentId,
                FirstName = createStudentParams.FirstName,
                LastName = createStudentParams.LastName,
                Email = createStudentParams.Email,
                Registrations = createStudentParams.Registrations
            };
            return Ok(new CreateStudentResult(await _studentBusiness.CreateStudent(student)));
        }
    }
}
