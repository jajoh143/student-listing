using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_listing.Controllers.RegistrationController.Models
{
    /// <summary>
    /// CreateStudentRegistrationParams
    /// </summary>
    public class CreateStudentRegistrationParam
    {
        /// <summary>
        /// Student Id for the registration
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// Course Id for the registration
        /// </summary>
        public int CourseId { get; set; }
    }
}
