using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_listing.Controllers.RegistrationController.Models
{
    /// <summary>
    /// UpdateStudentRegistrationResult
    /// </summary>
    public class UpdateStudentRegistrationResult
    {
        /// <summary>
        /// Whether or not the registration was updated
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="success">Whether or not the registration was updated</param>
        public UpdateStudentRegistrationResult(bool success)
        {
            Success = success;
        }
    }
}
