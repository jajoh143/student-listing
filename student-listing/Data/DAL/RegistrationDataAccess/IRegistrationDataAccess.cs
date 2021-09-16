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

        /// <summary>
        /// Removes a student registration.
        /// </summary>
        /// <param name="registrationId">registration id</param>
        /// <returns>Whether or not the registration was deleted.</returns>
        Task<int> RemoveStudentRegistration(int registrationId);

        /// <summary>
        /// Creates a new student registration for the provided student and course
        /// </summary>
        /// <param name="studentId">student id</param>
        /// <param name="courseId">course id</param>
        /// <returns>Whether or not the registration was created</returns>
        Task<int> CreateStudentRegistration(int studentId, int courseId);
    }
}
