using System.Collections.Generic;
using System.Threading.Tasks;
using student_listing.Models;

namespace student_listing.Business.StudentBusiness
{
    public interface IStudentBusiness
    {
        /// <summary>
        /// GetStudentList
        /// </summary>
        /// <returns>Returns a list of all students</returns>
        Task<IEnumerable<Student>> GetStudentList();

        /// <summary>
        /// GetStudent
        /// </summary>
        /// <param name="id">student id</param>
        /// <returns>Student object</returns>
        Task<Student> GetStudent(int id);
    }
}
