using student_listing.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace student_listing.Data.DAL.CourseDataAccess
{
    public interface ICourseDataAccess
    {
        Task<IEnumerable<Course>> GetCourses();
    }
}
