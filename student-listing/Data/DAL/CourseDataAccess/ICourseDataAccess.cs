using student_listing.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace student_listing.Data.DAL.CourseDataAccess
{
    public interface ICourseDataAccess
    {
        /// <summary>
        /// Retrieves a list of courses from the database
        /// </summary>
        /// <returns>A list of courses from the database</returns>
        Task<IEnumerable<Course>> GetCourses();

        /// <summary>
        /// Retrieves a list of courses that the student is not currently associated with
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>List of courses</returns>
        Task<IEnumerable<Course>> GetStudentCourseList(int id);

        /// <summary>
        /// Updates the provided course in the database
        /// </summary>
        /// <param name="course">course</param>
        /// <returns>Number of affected rows</returns>
        Task<int> UpdateCourse(Course course);

        /// <summary>
        /// Creates the provided course in the database
        /// </summary>
        /// <param name="course">course</param>
        /// <returns>Number of affected rows</returns>
        Task<int> CreateCourse(Course course);

        /// <summary>
        /// Deletes the provided course
        /// </summary>
        /// <param name="courseId">course id</param>
        /// <returns>if the course was deleted</returns>
        Task<int> DeleteCourse(int courseId);

        /// <summary>
        /// Searches the courses
        /// </summary>
        /// <param name="searchTerm">search term</param>
        /// <returns>list of courses</returns>
        Task<IEnumerable<Course>> SearchCourses(string searchTerm);
    }
}
