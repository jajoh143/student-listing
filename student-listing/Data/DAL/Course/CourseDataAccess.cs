using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace student_listing.Data.DAL.Course
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
        public async Task<IEnumerable<Models.Course>> GetCourses()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DataConnection")))
            {
                string sql = @"
                    SELECT
                    s.StudentId,
                    s.FirstName,
                    s.LastName,
                    s.Email,
                    (SELECT CONCAT(c1.Name, ',') FROM dbo.Courses c1 INNER JOIN dbo.Registrations r1 on c1.CourseId = r1.CourseId WHERE r1.StudentId = s.StudentId) as Courses,
                    (SUM(c.CreditHours * g.Score) / SUM(c.CreditHours)) as CumulativeGpa
                    FROM dbo.Students s
                    LEFT JOIN dbo.Registrations r ON s.StudentId = r.StudentId 
                    LEFT JOIN dbo.Courses c ON r.CourseId = c.CourseId
                    LEFT JOIN dbo.Grades g ON g.GradeId = r.GradeId
                    GROUP BY s.StudentId, s.FirstName, s.LastName, s.Email
                    ORDER BY s.LastName, s.FirstName;";

                return await db.QueryAsync<Models.Course>(sql);
            }
        }
    }
}
