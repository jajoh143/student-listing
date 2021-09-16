using student_listing.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace student_listing.Data.DAL.RegistrationDataAccess
{
    public interface IRegistrationDataAccess
    {
        /// <summary>
        /// Retrieves a list of registration information for a student with the provided id
        /// </summary>
        /// <param name="studentId">student id</param>
        /// <returns>List of registration information</returns>
        Task<IEnumerable<Registration>> GetRegistrationListForStudent(int studentId);
    }
}
