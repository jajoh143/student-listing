using student_listing.Data.Features;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_listing.Business.Student
{
    public class StudentBusiness : IStudentBusiness
    {
        /// <summary>
        /// DAL Layer for student data
        /// </summary>
        private readonly IStudentDataAccess _studentDataAcess;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="studentDataAccess"></param>
        public StudentBusiness(IStudentDataAccess studentDataAccess)
        {
            _studentDataAcess = studentDataAccess;
        }

        /// <summary>
        /// Gets a list of students
        /// </summary>
        /// <returns></returns>
        public async Task<List<Models.Student>> GetStudentList()
        {
            IEnumerable<Data.Models.Student> studentDataContext  = await _studentDataAcess.GetStudents();
            List<Models.Student> students = new List<Models.Student>(studentDataContext.Count());
            foreach(Data.Models.Student student in studentDataContext)
            { 
                students.Add(new Models.Student
                {
                    Id = student.StudentId,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Email = student.Email,
                    Courses = student.Courses,
                    CumulativeGpa = student.CumulativeGpa
                });
            }
            return students;
        }
    }
}
