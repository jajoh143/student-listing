using student_listing.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace student_listing.Data.DAL.CourseDataAccess
{
    public interface ICourseDataAccess
    {
        /// <summary>
        /// Retrieves a list of courses from the database
        /// </summary>
        /// <returns>A list of courses from the database</returns>
        Task<IEnumerable<Course>> GetCourses();
    }
}
