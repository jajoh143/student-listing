using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_listing.Controllers.RegistrationController.Models
{
    public class DeleteStudentRegistrationResult
    {
        /// <summary>
        /// Whether or not the registration was successfully deleted
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="success">Whether or not the registation record was deleted</param>
        public DeleteStudentRegistrationResult(bool success)
        {
            Success = success;
        }
    }
}
