using student_listing.Data.DAL.CourseDataAccess;
using student_listing.Data.DAL.RegistrationDataAccess;
using student_listing.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace student_listing.Business.CourseBusiness
{
    public class CourseBusiness : ICourseBusiness
    {
        /// <summary>
        /// DAL Layer for student data
        /// </summary>
        private readonly ICourseDataAccess _courseDataAccess;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="courseDataAccess">Course Data Access</param>
        public CourseBusiness(ICourseDataAccess courseDataAccess)
        {
            _courseDataAccess = courseDataAccess;
        }

        /// <summary>
        /// Gets a list of all courses
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Course>> GetCourseList()
        {
            return await _courseDataAccess.GetCourses();
        }

        /// <summary>
        /// Gets a list of courses that the student is not currently associated with
        /// </summary>
        /// <param name="studentId">student id</param>
        /// <returns></returns>
        public async Task<IEnumerable<Course>> GetStudentCourseList(int studentId)
        {
            if (studentId <= 0) throw new ArgumentNullException(nameof(studentId), "Invalid studentId value provided");

            return await _courseDataAccess.GetStudentCourseList(studentId);
        }

        /// <summary>
        /// Updates a course in the database
        /// </summary>
        /// <param name="course">course</param>
        /// <returns>Whether the course was updated successfully</returns>
        public async Task<bool> UpdateCourse(Course course)
        {
            if (course == null) throw new ArgumentNullException(nameof(course), "Invalid value provided.");

            int updateRowsAffected = await _courseDataAccess.UpdateCourse(course);

            if (updateRowsAffected == 1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Creates a course in the database
        /// </summary>
        /// <param name="course">course</param>
        /// <returns>Whether the course was created successfully</returns>
        public async Task<bool> CreateCourse(Course course)
        {
            if (course == null) throw new ArgumentNullException(nameof(course), "Invalid value provided.");

            int updateRowsAffected = await _courseDataAccess.CreateCourse(course);

            if (updateRowsAffected == 1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Deletes a course
        /// </summary>
        /// <param name="courseId">course id</param>
        /// <returns>if the course was deleted or not</returns>
        public async Task<bool> DeleteCourse(int courseId)
        {
            if (courseId <= 0) throw new ArgumentException("Invalid course id provided", nameof(courseId));

            int rowsAffected = await _courseDataAccess.DeleteCourse(courseId);
            
            if (rowsAffected == 1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Searches the courses
        /// </summary>
        /// <param name="searchTerm">search term</param>
        /// <returns>list of courses</returns>
        public async Task<IEnumerable<Course>> SearchCourses(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) throw new ArgumentNullException(nameof(searchTerm), "Invalid searchTerm provided");

            return await _courseDataAccess.SearchCourses(searchTerm);
        }
    }
}
