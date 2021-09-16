using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using student_listing.Business.CourseBusiness;
using student_listing.Controllers.CourseController.Models;
using student_listing.Models;
using student_listing.Web.Controllers.CourseController.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_listing.Controllers.CourseController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        /// <summary>
        /// Course Business
        /// </summary>
        private ICourseBusiness _courseBusiness { get; set; }

        public CourseController(ICourseBusiness courseBusiness)
        {
            _courseBusiness = courseBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<GetCourseList>> Get([FromQuery] int studentId)
        {
            if (studentId > 0)
            {
                return Ok(new GetCourseList(await _courseBusiness.GetStudentCourseList(studentId)));
               
            }
            return Ok(new GetCourseList(await _courseBusiness.GetCourseList()));
        }

        [HttpPut]
        public async Task<ActionResult<UpdateCourseResult>> Put([FromBody] UpdateCourseParams updateCourseParams)
        {
            Course course = new Course
            {
                CourseId = updateCourseParams.CourseId,
                Name = updateCourseParams.Name,
                Description = updateCourseParams.Description,
                CreditHours = updateCourseParams.CreditHours
            };

            return Ok(new UpdateCourseResult(await _courseBusiness.UpdateCourse(course)));
        }

        [HttpPost]
        public async Task<ActionResult<CreateCourseResult>> Post([FromBody] CreateCourseParams createCourseParams)
        {
            Course course = new Course
            {
                Name = createCourseParams.Name,
                Description = createCourseParams.Description,
                CreditHours = createCourseParams.CreditHours
            };

            return Ok(new CreateCourseResult(await _courseBusiness.CreateCourse(course)));
        }
    }
}
