using System.Collections.Generic;
using System.Threading.Tasks;
using student_listing.Models;

namespace student_listing.Data.DAL.GradeDataAccess
{
    public interface IGradeDataAccess
    {
        /// <summary>
        /// Retrieves a list of all grades from the database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Grade>> GetGrades();
    }
}
