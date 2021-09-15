using System.Collections.Generic;
using System.Threading.Tasks;
using student_listing.Models;

namespace student_listing.Data.DAL.StudentDataAccess
{
    public interface IStudentDataAccess
    {
        Task<IEnumerable<Student>> GetStudents();
    }
}
