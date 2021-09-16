using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_listing.Controllers.RegistrationController.Models
{
    /// <summary>
    /// UpdateStudentRegistrationParams
    /// </summary>
    public class UpdateStudentRegistrationParams
    {
        /// <summary>
        /// Registration Id
        /// </summary>
        public int RegistrationId { get; set; }
        
        /// <summary>
        /// Grade Id
        /// </summary>
        public int GradeId { get; set; }
    }
}
