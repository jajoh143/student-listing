using System.Collections.Generic;
using student_listing.Data.Models;

namespace student_listing.Data.Features
{
    public interface IStudentDataAccess
    {
        List<Student> GetStudents();
    }
}
