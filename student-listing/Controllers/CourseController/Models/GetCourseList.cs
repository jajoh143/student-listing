using student_listing.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace student_listing.Web.Controllers.CourseController.Models
{
    /// <summary>
    /// GetStudentList
    /// </summary>
    public class GetCourseList
    {
        /// <summary>
        /// StudentCollection
        /// </summary>
        public CourseCollection CourseCollection{ get; set;}

        /// <summary>
        /// Ctor
        /// </summary>
        public GetCourseList(IEnumerable<Course> courses)
        {
            if (courses == null) throw new ArgumentNullException(nameof(courses), "Invalid value supplied for courses");

            CourseCollection courseCollection = new CourseCollection();

            foreach (Course course in courses)
            {
                courseCollection.Add(new CourseItem
                {
                    CourseId = course.CourseId,
                    CourseName = course.Name,
                    CreditHours = course.CreditHours,
                    Description = course.Description
                });
            }

            this.CourseCollection = courseCollection;
        }
    }
}
