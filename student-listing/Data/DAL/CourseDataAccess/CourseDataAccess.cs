using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using student_listing.Models;

namespace student_listing.Data.DAL.CourseDataAccess
{
    public class CourseDataAccess : ICourseDataAccess
    {
        private readonly IConfiguration _configuration;

        public CourseDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Retrieves a list of courses from the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Course>> GetCourses()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DataConnection")))
            {
                string sql = @"
                    SELECT
                    CourseId,
                    Name,
                    Description,
                    CreditHours
                    FROM dbo.Courses;";

                return await db.QueryAsync<Models.Course>(sql);
            }
        }

        /// <summary>
        /// Retrieves a list of courses from the database that the student is not currently associated with
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Course>> GetStudentCourseList(int id)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DataConnection")))
            {
                string sql = @"
                    WITH student_courses As (
                        SELECT
                        r.CourseId
                        FROM dbo.Registrations r
                        WHERE r.StudentId = @StudentId
                    )
                    SELECT
                    c.CourseId,
                    Name,
                    Description,
                    CreditHours
                    FROM dbo.Courses c
                    LEFT JOIN student_courses sc ON c.CourseId = sc.CourseId
                    WHERE sc.CourseId IS NULL;";

                return await db.QueryAsync<Models.Course>(sql, new { StudentId = id });
            }
        }

        /// <summary>
        /// Updates the provided course in the database
        /// </summary>
        /// <param name="course">course</param>
        /// <returns>Number of affected rows</returns>
        public async Task<int> UpdateCourse(Course course)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DataConnection")))
            {
                string sql = @"
                    UPDATE dbo.Courses
                    SET Name = @Name,
                    Description = @Description, 
                    CreditHours = @CreditHours,
                    WHERE CourseId = @CourseId;";

                return await db.ExecuteAsync(sql, new { Name = course.Name, Description = course.Description, CreditHours = course.CreditHours, CourseId = course.CourseId });
            }
        }

        /// <summary>
        /// Creates the provided course in the database
        /// </summary>
        /// <param name="course">course</param>
        /// <returns>Number of affected rows</returns>
        public async Task<int> CreateCourse(Course course)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DataConnection")))
            {
                string sql = @"
                    INSERT INTO dbo.Courses (Name, Description, CreditHours)
                    VALUES (@Name, @Description, @CreditHours);";

                return await db.ExecuteAsync(sql, new { Name = course.Name, Description = course.Description, CreditHours = course.CreditHours });
            }
        }

        public async Task<int> DeleteCourse(int courseId)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DataConnection")))
            {
                string sql = @"
                    DELETE FROM dbo.Courses
                    WHERE CourseId = @CourseId;";

                return await db.ExecuteAsync(sql, new { CourseId = courseId });
            }
        }
    }
}
