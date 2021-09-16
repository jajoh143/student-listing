using student_listing.Models;
using student_listing.Web.Controllers.StudentController.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_listing.Controllers.StudentController.Models
{
    /// <summary>
    /// Create Student Params
    /// </summary>
    public class CreateStudentParams
    {
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
        /// List of registration records for the user
        /// </summary>
        public IEnumerable<Registration> Registrations { get; set; }
    }
}
