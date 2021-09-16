using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using student_listing.Business.CourseBusiness;
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
        /// Student Business
        /// </summary>
        private ICourseBusiness _courseBusiness { get; set; }

        public CourseController(ICourseBusiness courseBusiness)
        {
            _courseBusiness = courseBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<GetCourseList>> Get()
        {
            IEnumerable<Course> courses = await _courseBusiness.GetCourseList();
            CourseCollection courseCollection = new CourseCollection(courses.Count());

            foreach(Course course in courses)
            {
                courseCollection.Add(new CourseItem
                {
                    CourseId = course.CourseId,
                    CourseName = course.Name,
                    CreditHours = course.CreditHours,
                    Description = course.Description
                });
            }

            return new GetCourseList
            {
                CourseCollection = courseCollection
            };
        }
    }
}
