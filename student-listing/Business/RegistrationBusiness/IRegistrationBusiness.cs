using System.Threading.Tasks;

namespace student_listing.Business.RegistrationBusiness
{
    public interface IRegistrationBusiness
    {
        /// <summary>
        /// Deletes a student registration
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Whether the registration was successfully deleted.</returns>
        Task<bool> RemoveStudentRegistration(int id);

        /// <summary>
        /// Creates a student registration
        /// </summary>
        /// <param name="studentId">student id</param>
        /// <param name="courseId">course id</param>
        /// <returns>Whether or not the registration was successfully added</returns>
        Task<bool> CreateStudentRegistration(int studentId, int courseId);
    }
}
