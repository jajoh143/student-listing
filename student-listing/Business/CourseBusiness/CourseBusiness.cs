using student_listing.Data.DAL.CourseDataAccess;
using student_listing.Data.DAL.RegistrationDataAccess;
using student_listing.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace student_listing.Business.CourseBusiness
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
        public CourseBusiness(ICourseDataAccess courseDataAccess)
        {
            _courseDataAccess = courseDataAccess;
        }

        public async Task<IEnumerable<Course>> GetCourseList()
        {
            return await _courseDataAccess.GetCourses();
        }
    }
}
