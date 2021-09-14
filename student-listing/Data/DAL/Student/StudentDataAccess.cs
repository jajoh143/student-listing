using student_listing.Data.DataContext;
using System.Collections.Generic;
using System.Linq;

namespace student_listing.Data.Features
{
    public class StudentDataAccess : IStudentDataAccess
    {
        private readonly StudentListingContext _studentListingContext;

        public StudentDataAccess(StudentListingContext studentListingContext)
        {
            this._studentListingContext = studentListingContext;
        }

        public List<Models.Student> GetStudents()
        {
            return _studentListingContext.Students.ToList();
        }
    }
}
