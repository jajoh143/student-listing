using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace student_listing.Web.Controllers.StudentController.Models
{
    /// <summary>
    /// Student Item - for StudentCollection
    /// </summary>
    public class StudentItem
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
        /// Cumulative GPA for student
        /// </summary>
        public decimal CumulativeGpa { get; set; }

    }
}
