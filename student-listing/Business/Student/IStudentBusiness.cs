using System.Collections.Generic;
using System.Threading.Tasks;

namespace student_listing.Business.Student
{
    public interface IStudentBusiness
    {
        /// <summary>
        /// GetStudentList
        /// </summary>
        /// <returns>Returns a list of all students</returns>
        Task<List<Models.Student>> GetStudentList();
    }
}
