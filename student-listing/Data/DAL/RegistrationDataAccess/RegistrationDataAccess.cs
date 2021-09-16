using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using student_listing.Models;
using System.Text;
using System.Linq;

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
                    g.GradeId,
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

        public async Task<int> RemoveStudentRegistration(int registrationId)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DataConnection")))
            {
                string sql = @"
                   DELETE FROM dbo.Registrations
                   WHERE RegistrationId = @RegistrationId;";

                return await db.ExecuteAsync(sql, new { RegistrationId = registrationId });
            }
        }

        public async Task<int> CreateStudentRegistration(int studentId, int courseId)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DataConnection")))
            {
                string sql = @"
                    INSERT INTO dbo.Registrations (StudentId, CourseId, GradeId)
                    VALUES (@StudentId, @CourseId, 1);";

                return await db.ExecuteAsync(sql, new { StudentId = studentId, CourseId = courseId });
            }
        }

        public async Task<int> UpdateStudentRegistration(int registrationId, int gradeId)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DataConnection")))
            {
                string sql = @"
                    UPDATE dbo.Registrations
                    SET GradeId = @GradeId
                    WHERE RegistrationId = @RegistrationId;";

                return await db.ExecuteAsync(sql, new { RegistrationId = registrationId, GradeId = gradeId });
            }
        }

        public async Task<int> CreateRegistrations(IEnumerable<Registration> registrations)
        {
            StringBuilder sb = new StringBuilder("INSERT INTO dbo.Registrations (StudentId, CourseId, GradeId) VALUES ");

            foreach(Registration registration in registrations)
            {
                sb.Append(string.Format("({0}, {1}, 1)", registration.StudentId, registration.CourseId));
                if (registration != registrations.Last())
                {
                    sb.Append(",");
                }
            }

            sb.Append(";");

            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DataConnection")))
            {
                return await db.ExecuteAsync(sb.ToString());
            }
        }
    }
}
