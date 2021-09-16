using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_listing.Controllers.StudentController.Models
{
    /// <summary>
    /// Update Student Result
    /// </summary>
    public class UpdateStudentResult
    {
        /// <summary>
        /// Success - whether or not the student was updated successfully
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="success"></param>
        public UpdateStudentResult(bool success)
        {
            Success = success;
        }
    }
}
