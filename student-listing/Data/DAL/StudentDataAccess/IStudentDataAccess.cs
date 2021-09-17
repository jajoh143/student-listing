using System.Collections.Generic;
using System.Threading.Tasks;
using student_listing.Models;

namespace student_listing.Data.DAL.StudentDataAccess
{
    public interface IStudentDataAccess
    {
        /// <summary>
        /// Retrieves a list of all students from the database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Student>> GetStudents();

        /// <summary>
        /// Retrieves a student from the database
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>The student object</returns>
        Task<Student> GetStudent(int id);

        /// <summary>
        /// Updates a provided student in the database
        /// </summary>
        /// <param name="student">student</param>
        /// <returns>Number of rows affected</returns>
        Task<int> UpdateStudent(Student student);

        /// <summary>
        /// Creates a provided student in the database
        /// </summary>
        /// <param name="student">student</param>
        /// <returns>Number of rows affected</returns>
        Task<int> CreateStudent(Student student);

        /// <summary>
        /// Deletes a student
        /// </summary>
        /// <param name="studentId">student id</param>
        /// <returns>count of rows affected</returns>
        Task<int> DeleteStudent(int studentId);

        /// <summary>
        /// Searches the students
        /// </summary>
        /// <param name="searchTerm">search term</param>
        /// <returns>List of students</returns>
        Task<IEnumerable<Student>> SearchStudents(string searchTerm);
    }
}
