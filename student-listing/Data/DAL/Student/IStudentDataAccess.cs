using System.Collections.Generic;
using System.Threading.Tasks;
using student_listing.Data.Models;

namespace student_listing.Data.Features
{
    public interface IStudentDataAccess
    {
        Task<IEnumerable<Student>> GetStudents();
    }
}
