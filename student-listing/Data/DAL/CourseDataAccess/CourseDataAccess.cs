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
    }
}
