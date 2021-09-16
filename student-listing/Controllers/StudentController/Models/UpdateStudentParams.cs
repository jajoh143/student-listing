using student_listing.Models;
using student_listing.Web.Controllers.StudentController.Models;
using System.Collections.Generic;

namespace student_listing.Controllers.StudentController.Models
{
    /// <summary>
    /// Update Student Params
    /// </summary>
    public class UpdateStudentParams
    {
        /// <summary>
        /// ID
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Courses - list of course names student is in
        /// </summary>
        public string Courses { get; set; }

        /// <summary>
        /// List of registration records for the user
        /// </summary>
        public IEnumerable<Registration> Registrations { get; set; }
    }
}
