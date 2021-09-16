using student_listing.Data.DAL.RegistrationDataAccess;
using System;
using System.Threading.Tasks;

namespace student_listing.Business.RegistrationBusiness
{
    public class RegistrationBusiness : IRegistrationBusiness
    {
        private readonly IRegistrationDataAccess _registrationDataAccess;

        public RegistrationBusiness(IRegistrationDataAccess registrationDataAccess)
        {
            _registrationDataAccess = registrationDataAccess;
        }

        /// <summary>
        /// Removes a student registration
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Whether the registration was successfully deleted</returns>
        public async Task<bool> RemoveStudentRegistration(int id)
        {
            if (id <= 0) throw new ArgumentNullException(nameof(id), "Invalid studentId parameter provided");

            int rowsAffected = await _registrationDataAccess.RemoveStudentRegistration(id);
            if (rowsAffected == 1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Creates a student registration
        /// </summary>
        /// <param name="studentId">student id</param>
        /// <param name="courseId">course id</param>
        /// <returns>Whether or not the registration was successfully added</returns>
        public async Task<bool> CreateStudentRegistration(int studentId, int courseId)
        {
            if (studentId <= 0) throw new ArgumentNullException(nameof(studentId), "Invalid studentId parameter provided");
            if (courseId <= 0) throw new ArgumentNullException(nameof(courseId), "Invalid courseId parameter provided");

            int rowsAffected = await _registrationDataAccess.CreateStudentRegistration(studentId, courseId);

            if (rowsAffected == 1)
            {
                return true;
            }
            return false;
        }
    }
}
