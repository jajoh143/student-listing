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
        
        /// <summary>
        /// Gets a list of students
        /// </summary>
        /// <returns>list of students</returns>
        public async Task<IEnumerable<Student>> GetStudents()
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

        /// <summary>
        /// Gets a student with the specified id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>student</returns>
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

        /// <summary>
        /// Updates the specified student
        /// </summary>
        /// <param name="student">student info</param>
        /// <returns>number of rows affected</returns>
        public async Task<int> UpdateStudent(Student student)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DataConnection")))
            {
                string sql = @"
                    UPDATE dbo.Students
                    SET FirstName = @FirstName,
                    LastName = @LastName,
                    Email = @Email
                    WHERE StudentId = @StudentId;";

                return await db.ExecuteAsync(sql, new 
                {  
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Email = student.Email,
                    StudentId = student.StudentId
                });
            }
        }

        /// <summary>
        /// Creates a student in the database
        /// </summary>
        /// <param name="student">student info</param>
        /// <returns>number of rows affected</returns>
        public async Task<int> CreateStudent(Student student)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DataConnection")))
            {
                string sql = @"
                   INSERT INTO dbo.Students (FirstName, LastName, Email)
                   VALUES (@FirstName, @LastName, @Email);";

                return await db.ExecuteAsync(sql, new
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Email = student.Email
                });
            }
        }

        /// <summary>
        /// Deletes a student from the database
        /// </summary>
        /// <param name="studentId">student id</param>
        /// <returns>number of rows affected</returns>
        public async Task<int> DeleteStudent(int studentId)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DataConnection")))
            {
                string sql = @"
                  DELETE FROM dbo.Students
                  WHERE StudentId = @StudentId;";

                return await db.ExecuteAsync(sql, new { StudentId = studentId });
            }
        }

        /// <summary>
        /// Searches the students
        /// </summary>
        /// <param name="searchTerm">search term</param>
        /// <returns>list of students</returns>
        public async Task<IEnumerable<Student>> SearchStudents(string searchTerm)
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
                    WHERE s.FirstName LIKE @SearchTerm
                    OR s.LastName LIKE @SearchTerm
                    OR s.Email LIKE @SearchTerm;";

                return await db.QueryAsync<Student>(sql, new { SearchTerm = "%" + searchTerm + "%" });
            }
        }
    }
}
