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

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="courseBusiness">course business</param>
        public CourseController(ICourseBusiness courseBusiness)
        {
            _courseBusiness = courseBusiness;
        }

        /// <summary>
        /// Gets a list of courses the student is not currentlt assigned to via registration records
        /// </summary>
        /// <param name="studentId">student id</param>
        /// <returns>List of Courses</returns>
        [HttpGet]
        public async Task<ActionResult<GetCourseList>> Get([FromQuery] int studentId)
        {
            if (studentId > 0)
            {
                return Ok(new GetCourseList(await _courseBusiness.GetStudentCourseList(studentId)));

            }
            return Ok(new GetCourseList(await _courseBusiness.GetCourseList()));
        }

        /// <summary>
        /// Updates a course
        /// </summary>
        /// <param name="updateCourseParams">course info</param>
        /// <returns>if course was saved</returns>
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

        /// <summary>
        /// Creates a course
        /// </summary>
        /// <param name="createCourseParams">course info</param>
        /// <returns>if course was created</returns>
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

        /// <summary>
        /// Deletes a course
        /// </summary>
        /// <param name="courseId">course id</param>
        /// <returns>if the course was deleted</returns>
        [HttpDelete("{courseId}")]
        public async Task<ActionResult<DeleteCourseResult>> Delete(int courseId)
        {
            return Ok(new DeleteCourseResult(await _courseBusiness.DeleteCourse(courseId)));
        }
    }
}
