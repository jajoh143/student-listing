using student_listing.Data.DAL.StudentDataAccess;
using student_listing.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_listing.Business.StudentBusiness
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
        public async Task<IEnumerable<Student>> GetStudentList()
        {
            return await _studentDataAcess.GetStudents();
        }
    }
}
