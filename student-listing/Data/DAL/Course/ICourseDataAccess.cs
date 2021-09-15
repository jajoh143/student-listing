using System.Collections.Generic;
using System.Threading.Tasks;

namespace student_listing.Data.DAL.Course
{
    public interface ICourseDataAccess
    {
        Task<IEnumerable<Data.Models.Course>> GetCourses();
    }
}
