using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using student_listing.Business.Student;
using student_listing.Web.Controllers.Student.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_listing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        /// <summary>
        /// Student Business
        /// </summary>
        private IStudentBusiness _studentBusiness { get; set; }

        public CourseController(IStudentBusiness studentBusiness)
        {
            _studentBusiness = studentBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<GetStudentList>> Get()
        {
            List<Models.Student> students = await _studentBusiness.GetStudentList();
            StudentCollection studentCollection = new StudentCollection(students.Count);

            foreach(Models.Student student in students)
            {
                studentCollection.Add(new StudentItem
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Email = student.Email,
                    Courses = student.Courses,
                    CumulativeGpa = student.CumulativeGpa
                });
            }

            return new GetStudentList
            {
                StudentCollection = studentCollection
            };
        }
    }
}
