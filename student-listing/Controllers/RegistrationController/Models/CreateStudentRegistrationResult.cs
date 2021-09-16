using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_listing.Controllers.RegistrationController.Models
{
    /// <summary>
    /// CreateStudentRegistrationResult
    /// </summary>
    public class CreateStudentRegistrationResult
    {
        /// <summary>
        /// Whether the registration was successfully created
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="success"></param>
        public CreateStudentRegistrationResult(bool success)
        {
            Success = success;
        }
    }
}
