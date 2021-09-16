using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using student_listing.Models;

namespace student_listing.Data.DAL.RegistrationDataAccess
{
    public class RegistrationDataAccess : IRegistrationDataAccess
    {
        private readonly IConfiguration _configuration;

        public RegistrationDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<Registration>> GetRegistrationListForStudent(int studentId)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DataConnection")))
            {
                string sql = @"
                    SELECT
                    r.RegistrationId,
                    s.StudentId,
                    s.FirstName AS StudentFirstName,
                    s.LastName AS StudentLastName,
                    c.CourseId,
                    c.Name AS CourseName,
                    c.Description,
                    c.CreditHours AS CourseHours,
                    g.Letter AS GradeLetter,
                    g.Score AS GradeScore
                    FROM dbo.Registrations r
                    INNER JOIN dbo.Students s ON r.StudentId = s.StudentId
                    INNER JOIN dbo.Courses c ON r.CourseId = c.CourseId
                    INNER JOIN dbo.Grades g ON r.GradeId = g.GradeId
                    WHERE r.StudentId = @StudentId
                    ORDER BY c.Name;";

                return await db.QueryAsync<Registration>(sql, new { StudentId = studentId });
            }
        }
    }
}
