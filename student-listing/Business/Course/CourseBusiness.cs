using student_listing.Data.DAL.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_listing.Business.Course
{
    public class CourseBusiness : ICourseBusiness
    {
        /// <summary>
        /// DAL Layer for student data
        /// </summary>
        private readonly ICourseDataAccess _courseDataAccess;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="studentDataAccess"></param>
        public CourseBusiness(ICourseDataAccess studentDataAccess)
        {
            _courseDataAccess = studentDataAccess;
        }

        public async Task<List<Models.Course>> GetCourseList()
        {
            IEnumerable<Data.Models.Course> courseDataContext = await _courseDataAccess.GetCourses();
            List<Models.Course> courses = new List<Models.Course>(courseDataContext.Count());
            
            foreach (Data.Models.Course course in courseDataContext)
            {
                courses.Add(new Models.Course
                {
                    Id = course.CourseId,
                    Name = course.Name,
                    Description = course.Description,
                    CreditHours = course.CreditHours
                });
            }
            return courses;
        }
    }
}
