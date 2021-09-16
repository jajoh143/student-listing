using System.Collections.Generic;
using System.Threading.Tasks;
using student_listing.Models;

namespace student_listing.Business.GradeBusiness
{
    public interface IGradeBusiness
    {
        /// <summary>
        /// Retrieves a list of all grades from the database
        /// </summary>
        /// <returns>list of grades</returns>
        Task<IEnumerable<Grade>> GetGrades();
    }
}
