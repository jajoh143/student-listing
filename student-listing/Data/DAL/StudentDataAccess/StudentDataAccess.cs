using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using student_listing.Models;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace student_listing.Data.DAL.StudentDataAccess
{
    public class StudentDataAccess : IStudentDataAccess
    {
        private readonly IConfiguration _configuration;

        public StudentDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public async Task<IEnumerable<Models.Student>> GetStudents()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DataConnection")))
            {
                string sql = @"
                    SELECT
                    s.StudentId,
                    s.FirstName,
                    s.LastName,
                    s.Email,
                    CASE WHEN COUNT(c.Name) > 1 THEN isnull(RTRIM(LTRIM((SUBSTRING(STUFF((
                                                                               SELECT
                                                                                     ', '+ name AS [text()]
                                                                              FROM dbo.Courses c1
                                                                              INNER JOIN dbo.Registrations r1 ON c1.CourseId = r1.CourseId
                                                                              WHERE r1.StudentId = s.StudentId
                                                                              FOR XML PATH(''), ROOT('MyString'), TYPE
                                                                          ).value('/MyString[1]', 'varchar(max)'), 1, 0, ''), 2, 1000)))), NULL)
                    ELSE MIN(c.Name) END AS CourseList,
                    (SUM(c.CreditHours * g.Score) / SUM(c.CreditHours)) as CumulativeGpa
                    FROM dbo.Students s
                    LEFT JOIN dbo.Registrations r ON s.StudentId = r.StudentId 
                    LEFT JOIN dbo.Courses c ON r.CourseId = c.CourseId
                    LEFT JOIN dbo.Grades g ON g.GradeId = r.GradeId
                    GROUP BY s.StudentId, s.FirstName, s.LastName, s.Email
                    ORDER BY s.LastName, s.FirstName;";

                return await db.QueryAsync<Student>(sql);
            }
        }

        public async Task<Student> GetStudent(int id)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DataConnection")))
            {
                string sql = @"
                    SELECT
                    s.StudentId,
                    s.FirstName,
                    s.LastName,
                    s.Email
                    FROM dbo.Students s
                    LEFT JOIN dbo.Registrations r ON s.StudentId = r.StudentId 
                    LEFT JOIN dbo.Courses c ON r.CourseId = c.CourseId
                    LEFT JOIN dbo.Grades g ON g.GradeId = r.GradeId
                    WHERE s.StudentId = @studentId;";

                return await db.QueryFirstAsync<Student>(sql, new { StudentId = id });
            }
        }
    }
}
