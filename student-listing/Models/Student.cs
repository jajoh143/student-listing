using System.Collections.Generic;

namespace student_listing.Models
{
    /// <summary>
    /// Student
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        
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
        /// Courses
        /// </summary>
       public string Courses { get; set; }

        /// <summary>
        /// Cumulative GPA - average of scores across registered courses for the student
        /// </summary>
        public decimal CumulativeGpa { get; set; }
    }
}
