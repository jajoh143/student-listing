using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using student_listing.Business.StudentBusiness;
using student_listing.Controllers.StudentController.Models;
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
    }
}
