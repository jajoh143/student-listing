using student_listing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_listing.Business.CourseBusiness
{
    public interface ICourseBusiness
    {
        /// <summary>
        /// Retrieves a list of all courses
        /// </summary>
        /// <returns>List of all courses</returns>
        Task<IEnumerable<Course>> GetCourseList();
        
       /// <summary>
       /// Retrieves a list of courses that a provded student is not associated with (via registration)
       /// </summary>
       /// <returns>List of courses</returns>
        Task<IEnumerable<Course>> GetStudentCourseList(int id);

        /// <summary>
        /// Updates the provided course in the database
        /// </summary>
        /// <param name="course">course</param>
        /// <returns>Whether or not the course was updated successfully</returns>
        Task<bool> UpdateCourse(Course course);

        /// <summary>
        /// Creates the provided course in the database
        /// </summary>
        /// <param name="course">course</param>
        /// <returns>Whether or not the course was created successfully</returns>
        Task<bool> CreateCourse(Course course);

        /// <summary>
        /// Deletes the course
        /// </summary>
        /// <param name="courseId">course id</param>
        /// <returns>If the course was deleted or not</returns>
        Task<bool> DeleteCourse(int courseId);

        /// <summary>
        /// Searches the courses
        /// </summary>
        /// <param name="searchTerm">search term</param>
        /// <returns>list of courses</returns>
        Task<IEnumerable<Course>> SearchCourses(string searchTerm);
    }
}
