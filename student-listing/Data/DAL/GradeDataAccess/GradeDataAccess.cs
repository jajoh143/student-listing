using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using student_listing.Models;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace student_listing.Data.DAL.GradeDataAccess
{
    public class GradeDataAccess : IGradeDataAccess
    {
        private readonly IConfiguration _configuration;

        public GradeDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public async Task<IEnumerable<Grade>> GetGrades()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DataConnection")))
            {
                string sql = @"
                    SELECT
                    g.GradeId,
                    g.Score,
                    g.Letter
                    FROM dbo.Grades g;";

                return await db.QueryAsync<Grade>(sql);
            }
        }
    }
}
